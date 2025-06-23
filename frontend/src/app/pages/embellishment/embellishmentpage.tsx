import React, {useState, FormEvent} from 'react'
import {KTSVG} from '../../../_metronic/helpers'
import {Link} from 'react-router-dom'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import {ReusableModal} from '../../modals/reusableModal'
import CustomFormLayout from '../../components/CustomFormLayout'
import CustomSelect from '../../components/CustomSelect'
import {SingleValue} from 'react-select'
import Swal from 'sweetalert2'
type Embellishment = {
  Id: number
  Name: string
  TypeName: string
  Description: string
}
type EmbellishmentTypeForm = {
  Name: string
  SortOrder: string
  Description: string
  Type: string
}
type Props = {
  className: string
}

const EmbellishmentPage: React.FC<Props> = ({className}) => {
  const [formData, setFormData] = useState<EmbellishmentTypeForm>({
    Name: '',
    SortOrder: '',
    Description: '',
    Type: '',
  })

  const types = ['Neck', 'Pocket', 'Dress', 'Pants']

  const [errors, setErrors] = useState<Partial<EmbellishmentTypeForm>>({})

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    })
  }

  const handleSelectChange = (selected: SingleValue<{label: string; value: string}>) => {
    setFormData({
      ...formData,
      Type: selected?.value || '',
    })
  }

  const validate = () => {
    const newErrors: Partial<EmbellishmentTypeForm> = {}
    if (!formData.Name.trim()) newErrors.Name = 'Name is required'
    // add other validations as needed
    return newErrors
  }

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault()
    const validationErrors = validate()
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors)
      return
    }
    setErrors({})
    // Submit logic here
    console.log('Form submitted', formData)
  }

  // Prepare options for CustomSelect
  const typeOptions = types.map((t) => ({value: t, label: t}))
  // Original full data
  const [showModal, setShowModal] = useState(false)
  const allEmbellishmentTypes: Embellishment[] = [
    {
      Id: 1,
      Name: 'Neck',
      TypeName: 'Neck',
      Description: 'Various neck styles',
    },
    {
      Id: 2,
      Name: 'Sleeve',
      TypeName: 'Sleeve',
      Description: 'Different sleeve designs and lengths',
    },
    {
      Id: 3,
      Name: 'Cuff',
      TypeName: 'Cuff',
      Description: 'Cuff designs and finishes',
    },
    {
      Id: 4,
      Name: 'Hem',
      TypeName: 'Hem',
      Description: 'Styles for garment hems',
    },
    {
      Id: 5,
      Name: 'Pocket',
      TypeName: 'Pocket',
      Description: 'Pocket designs and placements',
    },
    {
      Id: 6,
      Name: 'Button',
      TypeName: 'Button',
      Description: 'Button styles and placements',
    },
    {
      Id: 7,
      Name: 'Embroidery',
      TypeName: 'Embroidery',
      Description: 'Decorative embroidery work',
    },
    {
      Id: 8,
      Name: 'Patch',
      TypeName: 'Patch',
      Description: 'Fabric patches for decoration',
    },
    {
      Id: 9,
      Name: 'Beading',
      TypeName: 'Beading',
      Description: 'Beadwork for embellishment',
    },
    {
      Id: 10,
      Name: 'Lace',
      TypeName: 'Lace',
      Description: 'Lace detailing and borders',
    },
  ]

  const [embellishmentType, setEmbellishmentType] = useState(allEmbellishmentTypes)

  const search = (value: string) => {
    if (value.trim() === '') {
      setEmbellishmentType(allEmbellishmentTypes)
    } else {
      const filtered = allEmbellishmentTypes.filter((c) =>
        c.Name.toLowerCase().includes(value.toLowerCase())
      )
      setEmbellishmentType(filtered)
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
        const updatedTypes = allEmbellishmentTypes.filter((t) => t.Id != Id)
        setEmbellishmentType(updatedTypes)
      }
    })
  }
  const handleEdit = (Id: number) => {
    const updateType = allEmbellishmentTypes.filter((t) => t.Id)
    //setFormData(updateType)
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
                {embellishmentType.map((c, index) => (
                  <tr key={c.Id}>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className='me-2 fs-7 fw-semibold'>{c.Id}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className='me-2 fs-7 fw-semibold'>{c.Name}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className=' me-2 fs-7 fw-semibold'>{c.TypeName}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className='me-2 fs-7 fw-semibold'>{c.Description}</span>
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
                            handleEdit(index)
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
                            handleDelete(index)
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
      <ReusableModal show={showModal} onClose={() => setShowModal(false)}>
        <CustomFormLayout
          title={
            <>
              <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30' /> Create Embellishment
            </>
          }
          onSubmit={handleSubmit}
          submitLabel='Add Type'
          rows={[
            [
              <div key='name' className='mb-3'>
                <label htmlFor='Name' className='form-label'>
                  Name
                </label>
                <input
                  name='Name'
                  id='Name'
                  type='text'
                  className={`form-control border-primary border-2 ${
                    errors.Name ? 'is-invalid' : ''
                  }`}
                  placeholder='Enter design name'
                  value={formData.Name}
                  onChange={handleChange}
                />
                {errors.Name && <div className='invalid-feedback'>{errors.Name}</div>}
              </div>,

              <div key='sortorder' className='mb-3'>
                <label htmlFor='SortOrder' className='form-label'>
                  Number
                </label>
                <input
                  name='SortOrder'
                  id='SortOrder'
                  type='text'
                  className='form-control border-primary border-2'
                  placeholder='Enter number for sorting'
                  value={formData.SortOrder}
                  onChange={handleChange}
                />
              </div>,

              <div key='type' className='mb-3'>
                <label htmlFor='Type' className='form-label'>
                  Type
                </label>
                <CustomSelect
                  id='Type'
                  name='Type'
                  options={typeOptions}
                  value={typeOptions.find((opt) => opt.value === formData.Type) || null}
                  onChange={handleSelectChange}
                  placeholder='Select Type'
                  className='form-control border-primary border-2'
                />
              </div>,
            ],
            [
              <div key='description' className='mb-3 col-md-12'>
                <label htmlFor='Description' className='form-label'>
                  Description
                </label>
                <textarea
                  name='Description'
                  id='Description'
                  className='form-control border-primary border-2'
                  rows={5}
                  placeholder='Enter description'
                  value={formData.Description}
                  onChange={handleChange}
                />
              </div>,
            ],
          ]}
        />
      </ReusableModal>
    </>
  )
}

export default EmbellishmentPage
