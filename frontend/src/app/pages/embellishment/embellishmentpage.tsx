import React, {useState, FormEvent, useEffect} from 'react'
import {KTSVG} from '../../../_metronic/helpers'
import {Link} from 'react-router-dom'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import EmbellishmentModal from '../../modals/EmbellishmentModal'
import axios from 'axios'
import Swal from 'sweetalert2'
import {mockEmbellishments} from './mockEmbellishments'
type Embellishment = {
  embellishmentId: number
  embellishmentName: string
  embellishmentTypeName: string
  embellishmentDescription: string
  embellishmentTypeId: number
  Cost: number
}
type Props = {
  className: string
}

const EmbellishmentPage: React.FC<Props> = ({className}) => {
  // Prepare options for CustomSelect
  const [updateEmbellishment, setUpdateEmbellishment] = useState<Embellishment>()
  const [showModal, setShowModal] = useState(false)
  const allEmbellishments: Embellishment[] = mockEmbellishments

  const [embellishment, setEmbellishment] = useState(mockEmbellishments)

  const search = (value: string) => {
    if (value.trim() === '') {
      setEmbellishment(allEmbellishments)
    } else {
      const filtered = allEmbellishments.filter((c) =>
        c.embellishmentName.toLowerCase().includes(value.toLowerCase())
      )
      setEmbellishment(filtered)
    }
  }
  const handleDelete = (Id: number) => {
    Swal.fire({
      title: 'Are you sure you want delete?',
      text: 'this type would be deleted!',
      icon: 'warning',
      showCancelButton: true,
      cancelButtonText: 'Cancel',
      showConfirmButton: true,
      confirmButtonText: 'Yes, Delete it!',
    }).then((result) => {
      if (result) {
        const updatedTypes = allEmbellishments.filter((t) => t.embellishmentId != Id)
        setEmbellishment(updatedTypes)
      }
    })
  }
  const fetchEmbellishments = async () => {
    try {
      const response = await axios.get<Embellishment[]>('https://localhost:7016/api/embellishments')
      if (response.status === 200) {
        setEmbellishment(response.data)
      }
    } catch (error) {
      console.error('Error fetching embellishments:', error)
    }
  }
  useEffect(() => {
    fetchEmbellishments()
  }, [])
  const handleEdit = (Id: number) => {
    const updateEmbellishment = allEmbellishments.find((t) => t.embellishmentId === Id)
    if (updateEmbellishment) {
      setUpdateEmbellishment(updateEmbellishment)
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
            <span className='card-label fw-bold fs-3 mb-1'>Embellishment</span>
          </h3>

          <div
            className='card-toolbar'
            data-bs-toggle='tooltip'
            data-bs-placement='top'
            data-bs-trigger='hover'
            title='Click to add a user'
          >
            <Link
              to='/embellishment-create'
              className='btn btn-sm btn-light-primary'
              // data-bs-toggle='modal'
              // data-bs-target='#kt_modal_invite_friends'
            >
              <KTSVG path='/media/icons/duotune/arrows/arr075.svg' className='svg-icon-3' />
              New Embellishment
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
                  <th className='min-w-140px'>Type Name</th>
                  <th className='min-w-120px'>Description</th>
                  <th className='min-w-100px text-end'>Actions</th>
                </tr>
              </thead>
              {/* end::Table head */}

              {/* begin::Table body */}
              <tbody>
                {embellishment.map((c, index) => (
                  <tr key={c.embellishmentId}>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className='me-2 fs-7 fw-semibold'>{c.embellishmentId}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className='me-2 fs-7 fw-semibold'>{c.embellishmentName}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className=' me-2 fs-7 fw-semibold'>{c.embellishmentTypeName}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className='me-2 fs-7 fw-semibold'>
                            {c.embellishmentDescription}
                          </span>
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
                            handleEdit(c.embellishmentId)
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
                            handleDelete(c.embellishmentId)
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
      <EmbellishmentModal
        showModal={showModal}
        setShowModal={() => setShowModal(false)}
        update={true}
        updateEmbellishment={updateEmbellishment}
      />
    </>
  )
}

export default EmbellishmentPage
