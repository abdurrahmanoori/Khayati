import React, {useState, FormEvent, useEffect} from 'react'
import CustomFormLayout from '../../components/CustomFormLayout'
import {KTSVG} from '../../../_metronic/helpers'
import {Link} from 'react-router-dom'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import EmbellishmentTypeModal from '../../modals/EmbellishmentTypeModal'
import Swal from 'sweetalert2'
import axios from 'axios'
import {EmbellishmentType} from '../../types/commonTypes'

type Props = {
  className: string
}
const EmbellishmentTypePage: React.FC<Props> = ({className}) => {
  // Original full data
  const [updateEmbellishmentType, setUpdateEmbellishmentType] = useState<EmbellishmentType>()
  const [showModal, setShowModal] = useState(false)
  const [allEmbellishmentTypes, setAllEmbellishmentType] = useState<EmbellishmentType[]>([])

  const [embellishmentType, setEmbellishmentType] = useState(allEmbellishmentTypes)

  const search = (value: string) => {
    if (value.trim() === '') {
      setEmbellishmentType(allEmbellishmentTypes)
    } else {
      const filtered = allEmbellishmentTypes.filter((c) =>
        c.name.toLowerCase().includes(value.toLowerCase())
      )
      setEmbellishmentType(filtered)
    }
  }
  const fetchEmbellishmentTypes = async () => {
    try {
      const response = await axios.get('https://localhost:7016/api/embellishmenttype')
      if (response.status === 200) {
        setEmbellishmentType(response.data)
        setAllEmbellishmentType(response.data)
      } else {
        console.error('Failed to fetch embellishment types')
      }
    } catch (error) {
      console.error('Error fetching embellishment types:', error)
    }
  }
  useEffect(() => {
    fetchEmbellishmentTypes()
  }, [])
  const handleDelete = (Id: number) => {
    Swal.fire({
      title: 'Delete!',
      text: 'Are you sure want to delete?',
      icon: 'warning',
      showCancelButton: true,
      showCloseButton: true,
      showConfirmButton: true,
      confirmButtonText: 'Yes, Delete it!',
    }).then(async (result) => {
      if (result) {
        const response = await axios.delete(`https://localhost:7016/api/embellishmenttype/${Id}`)
        if (response.status === 200) {
          fetchEmbellishmentTypes()
          Swal.fire({
            title: 'Deleted Successfully!',
            icon: 'success',
            showConfirmButton: true,
            timer: 2000,
          })
        }
      }
    })
  }
  const handleEdit = (Id: number) => {
    const updateType = allEmbellishmentTypes.find((e) => e.embellishmentTypeId === Id)
    if (updateType) {
      setUpdateEmbellishmentType(updateType)
    }
    setShowModal(true)
  }
  return (
    <>
      <Toolbar1 />
      <div className={`card ${className}`}>
        {/* begin::Header */}
        <div className='card-title'>
          {/* begin::Search */}
          <div className='d-flex align-items-center position-relative my-1'>
            <KTSVG
              path='/media/icons/duotune/general/gen021.svg'
              className='svg-icon-1 position-absolute ms-6'
            />
            <input
              type='text'
              data-kt-user-table-filter='search'
              className='form-control form-control-solid w-250px ps-14'
              placeholder='Search user'
              onChange={(e) => search(e.target.value)}
            />
          </div>
          {/* end::Search */}
        </div>
        <div className='card-header border-0 pt-5'>
          <h3 className='card-title align-items-start flex-column'>
            <span className='card-label fw-bold fs-3 mb-1'>Embellishment Type</span>
          </h3>

          <div
            className='card-toolbar'
            data-bs-toggle='tooltip'
            data-bs-placement='top'
            data-bs-trigger='hover'
            title='Click to add a user'
          >
            <Link
              to='/embellishmentType-create'
              className='btn btn-sm btn-light-primary'
              // data-bs-toggle='modal'
              // data-bs-target='#kt_modal_invite_friends'
            >
              <KTSVG path='/media/icons/duotune/arrows/arr075.svg' className='svg-icon-3' />
              New Type
            </Link>
          </div>
        </div>
        {/* end::Header */}

        {/* begin::Body */}
        <div className='card-body py-3'>
          {/* begin::Table container */}
          <div className='table-responsive'>
            {/* begin::Table */}
            <table className='table table-row-dashed table-row-gray-300 align-middle gs-0 gy-4'>
              {/* begin::Table head */}
              <thead>
                <tr className='fw-bold'>
                  <th className='w-25px'>ID</th>
                  <th className='min-w-150px'>Name</th>
                  <th className='min-w-140px'>Sort No</th>
                  <th className='min-w-120px'>Description</th>
                  <th className='min-w-100px text-end'>Actions</th>
                </tr>
              </thead>
              {/* end::Table head */}

              {/* begin::Table body */}
              <tbody>
                {embellishmentType.map((c, index) => (
                  <tr key={c.embellishmentTypeId}>
                    <td>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className=' me-2 fs-7 fw-semibold'>{c.embellishmentTypeId}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className=' me-2 fs-7 fw-semibold'>{c.name}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className=' me-2 fs-7 fw-semibold'>{c.sortOrder}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className='me-2 fs-7 fw-semibold'>{c.description}</span>
                        </div>
                      </div>
                    </td>
                    <td>
                      <div className='d-flex justify-content-end flex-shrink-0'>
                        <button
                          type='button'
                          className='btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'
                          aria-label='Edit'
                          onClick={() => {
                            handleEdit(c.embellishmentTypeId)
                          }}
                        >
                          <KTSVG
                            path='/media/icons/duotune/art/art005.svg'
                            className='svg-icon-3'
                          />
                        </button>
                        <button
                          type='button'
                          className='btn btn-icon btn-bg-light btn-active-color-primary btn-sm'
                          aria-label='Delete'
                          onClick={() => {
                            handleDelete(c.embellishmentTypeId)
                          }}
                        >
                          <KTSVG
                            path='/media/icons/duotune/general/gen027.svg'
                            className='svg-icon-3'
                          />
                        </button>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
              {/* end::Table body */}
            </table>
            {/* end::Table */}
          </div>
          {/* end::Table container */}
        </div>
        {/* end::Body */}
      </div>
      <EmbellishmentTypeModal
        showModal={showModal}
        setShowModal={() => setShowModal(false)}
        update={true}
        embellishmentType={updateEmbellishmentType!}
      />
    </>
  )
}
export default EmbellishmentTypePage
