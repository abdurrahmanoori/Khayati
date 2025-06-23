/* eslint-disable jsx-a11y/anchor-is-valid */
import React from 'react'
import CustomFormLayout from '../../components/CustomFormLayout'
import {KTSVG, toAbsoluteUrl} from '../../../_metronic/helpers'
import {useState} from 'react'
import {Link} from 'react-router-dom'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import {Edit_CustomerModal} from '../../modals/edit_CustomerModal'
import Swal from 'sweetalert2'
import {title} from 'process'

type Props = {
  className: string
}

const CustomerPage: React.FC<Props> = ({className}) => {
  const [showModal, setShowModal] = useState(false)
  const [customerUpdate, setCustomerUpdate] = useState({
    Id: 0,
    Name: '',
    Address: '',
    EmailAddress: '',
    NationalID: '',
    DateOfBirth: '',
    PhoneNumber: '',
  })

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const {name, value} = e.target
    setCustomerUpdate((prev) => ({
      ...prev,
      [name]: value,
    }))
  }

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    // TODO: Submit form data to your API or backend here
    console.log('Form submitted:', customerUpdate)
  }

  const [customers, setCustomer] = useState([
    {
      Id: 1,
      Name: 'Abubakr',
      Date: '2/20/2020',
      Phone: '0747627648',
      Email: 'abubakr.kaakar.2016@gmail.com',
    },
    {
      Id: 2,
      Name: 'Ahmad',
      Date: '3/15/2021',
      Phone: '0747123456',
      Email: 'ahmad@example.com',
    },
    {
      Id: 3,
      Name: 'Fatima',
      Date: '5/10/2022',
      Phone: '0747987654',
      Email: 'fatima@example.com',
    },
    {
      Id: 4,
      Name: 'Zainab',
      Date: '7/18/2020',
      Phone: '0747888888',
      Email: 'zainab@example.com',
    },
    {
      Id: 5,
      Name: 'Omar',
      Date: '9/12/2023',
      Phone: '0747555544',
      Email: 'omar@example.com',
    },
    {
      Id: 6,
      Name: 'Yusuf',
      Date: '11/25/2021',
      Phone: '0747666777',
      Email: 'yusuf@example.com',
    },
    {
      Id: 7,
      Name: 'Maryam',
      Date: '1/8/2022',
      Phone: '0747000011',
      Email: 'maryam@example.com',
    },
    {
      Id: 8,
      Name: 'Ayesha',
      Date: '6/3/2020',
      Phone: '0747222233',
      Email: 'ayesha@example.com',
    },
    {
      Id: 9,
      Name: 'Bilal',
      Date: '10/30/2022',
      Phone: '0747333444',
      Email: 'bilal@example.com',
    },
    {
      Id: 10,
      Name: 'Sara',
      Date: '12/12/2023',
      Phone: '0747444555',
      Email: 'sara@example.com',
    },
  ])
  const [allCustomers, setAllCustomers] = useState(customers)

  const search = (value: string) => {
    if (value === '') {
      setCustomer(allCustomers)
    } else {
      const filteredcustomers = customers.filter((c) =>
        c.Name.toLowerCase().includes(value.toLowerCase())
      )
      setCustomer(filteredcustomers)
    }
  }
  const handleDelete = (Id: number) => {
    Swal.fire({
      title: 'Are you sure you want to delete?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'Cancel',
    }).then((result) => {
      if (result.isConfirmed) {
        // If user confirmed deletion:
        const updatedCustomers = customers.filter((c) => c.Id !== Id)
        setCustomer(updatedCustomers)

        Swal.fire('Deleted!', 'The customer has been deleted.', 'success')
      }
    })
  }

  const handleEdit = (Id: number) => {
    const updatedCustomer = customers.find((c) => c.Id == Id)

    if (!updatedCustomer) {
      // Handle invalid index, e.g. return or show error
      return
    }

    setCustomerUpdate({
      Id: updatedCustomer.Id, // no ? because now we are sure updatedCustomer exists
      Name: updatedCustomer.Name || '',
      EmailAddress: updatedCustomer.Email || '',
      DateOfBirth: updatedCustomer.Date || '',
      PhoneNumber: updatedCustomer.Phone || '',
      Address: 'Default', // if you have a real address, use it
      NationalID: '54652154654', // or real value
    })
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
            <span className='card-label fw-bold fs-3 mb-1'>Customers</span>
            <span className=' mt-1 fw-semibold fs-7'>Over 500 Customers</span>
          </h3>

          <div
            className='card-toolbar'
            data-bs-toggle='tooltip'
            data-bs-placement='top'
            data-bs-trigger='hover'
            title='Click to add a user'
          >
            <Link
              to='/customer-create'
              className='btn btn-sm btn-light-primary'
              // data-bs-toggle='modal'
              // data-bs-target='#kt_modal_invite_friends'
            >
              <KTSVG path='/media/icons/duotune/arrows/arr075.svg' className='svg-icon-3' />
              New Customer
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
                  <th className='w-25px'>
                    <div className='form-check form-check-sm form-check-custom form-check-solid'>
                      ID
                    </div>
                  </th>
                  <th className='min-w-150px'>Name</th>
                  <th className='min-w-140px'>Date</th>
                  <th className='min-w-120px'>Phone</th>
                  <th className='min-w-120px'>Email</th>
                  <th className='min-w-100px text-end'>Actions</th>
                </tr>
              </thead>
              {/* end::Table head */}
              {/* begin::Table body */}
              <tbody>
                {customers.map((c, index) => (
                  <tr key={index}>
                    <td>
                      <div className='form-check form-check-sm form-check-custom form-check-solid'>
                        <span className='mt-1 fw-semibold fs-7'>{index + 1}</span>
                      </div>
                    </td>
                    <td>
                      <div className='d-flex align-items-center'>
                        <div className='symbol symbol-45px me-5'>
                          <img src={toAbsoluteUrl(`/media/avatars/300-${index + 1}.jpg`)} alt='' />
                        </div>
                        <div className='d-flex justify-content-start flex-column'>
                          <a href='#' className='text-dark fw-bold text-hover-primary fs-6'>
                            {c.Name}
                          </a>
                        </div>
                      </div>
                    </td>
                    <td>
                      <span className='fw-semibold d-block fs-7'>{c.Date}</span>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className=' me-2 fs-7 fw-semibold'>{c.Phone}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className='me-2 fs-7 fw-semibold'>{c.Email}</span>
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
                            handleEdit(c.Id)
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
                            handleDelete(c.Id)
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
        {/* begin::Body */}
      </div>
      <Edit_CustomerModal show={showModal} onClose={() => setShowModal(false)}>
        <CustomFormLayout
          title={
            <>
              <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30'> </i> Edit Customer
            </>
          }
          onSubmit={handleSubmit}
          submitLabel='Add Customer'
          rows={[
            [
              <div className='mb-3' key='name'>
                <label htmlFor='Name' className='form-label'>
                  Full Name:
                </label>
                <input
                  id='Name'
                  name='Name'
                  type='text'
                  className='form-control border-success-subtle'
                  placeholder='Enter your full name'
                  value={customerUpdate.Name}
                  onChange={handleChange}
                />
              </div>,

              <div className='mb-3' key='address'>
                <label htmlFor='Address' className='form-label'>
                  Address:
                </label>
                <input
                  id='Address'
                  name='Address'
                  type='text'
                  className='form-control border-success-subtle'
                  placeholder='Enter your address'
                  value={customerUpdate.Address}
                  onChange={handleChange}
                  required
                />
              </div>,
            ],

            [
              <div className='mb-3' key='email'>
                <label htmlFor='EmailAddress' className='form-label'>
                  Email Address:
                </label>
                <input
                  id='EmailAddress'
                  name='EmailAddress'
                  type='email'
                  className='form-control border-success-subtle'
                  placeholder='Enter your email'
                  value={customerUpdate.EmailAddress}
                  onChange={handleChange}
                  required
                />
              </div>,

              <div className='mb-3' key='nid'>
                <label htmlFor='NationalID' className='form-label'>
                  National ID:
                </label>
                <input
                  id='NationalID'
                  name='NationalID'
                  type='text'
                  className='form-control border-success-subtle'
                  placeholder='Enter your national ID'
                  value={customerUpdate.NationalID}
                  onChange={handleChange}
                  required
                />
              </div>,
            ],

            [
              <div className='mb-3' key='dob'>
                <label htmlFor='DateOfBirth' className='form-label'>
                  Date of Birth:
                </label>
                <input
                  id='DateOfBirth'
                  name='DateOfBirth'
                  type='date'
                  className='form-control border-success-subtle'
                  value={customerUpdate.DateOfBirth}
                  onChange={handleChange}
                  required
                />
              </div>,

              <div className='mb-3' key='phone'>
                <label htmlFor='PhoneNumber' className='form-label'>
                  Phone Number:
                </label>
                <input
                  id='PhoneNumber'
                  name='PhoneNumber'
                  type='tel'
                  className='form-control border-success-subtle'
                  placeholder='Enter your phone number'
                  value={customerUpdate.PhoneNumber}
                  onChange={handleChange}
                  required
                />
              </div>,
            ],
          ]}
        />
      </Edit_CustomerModal>
    </>
  )
}

export default CustomerPage
