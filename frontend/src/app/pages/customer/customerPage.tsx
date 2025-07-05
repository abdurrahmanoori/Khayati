/* eslint-disable jsx-a11y/anchor-is-valid */
import React, {useEffect} from 'react'
import {KTSVG, toAbsoluteUrl} from '../../../_metronic/helpers'
import {useState} from 'react'
import {Link} from 'react-router-dom'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import Swal from 'sweetalert2'
import CustomerModal from '../../modals/CustomerModal'
import {Customer} from '../../types/commonTypes'
import axios from 'axios'
type Props = {
  className: string
}

const CustomerPage: React.FC<Props> = ({className}) => {
  const [show, setShowModal] = useState(false)
  const [customerUpdate, setCustomerUpdate] = useState<Customer>({
    customerId: 0,
    name: '',
    lastName: '',
    emailAddress: '',
    dateOfBirth: '',
    phoneNumber: '',
    address: 'Default',
    nationalID: '54652154654',
    customerType: 'VIP',
    customerSince: '2023-10-01',
    measurements: [],
  })

  const [customers, setCustomer] = useState<Customer[]>([])
  const [allCustomers, setAllCustomers] = useState(customers)

  const fetchCustomers = async () => {
    const response = await axios.get('https://localhost:7016/api/customer')
    if (response.status === 200) {
      setCustomer(response.data)
    }
  }

  useEffect(() => {
    fetchCustomers()
  }, [])

  const search = (value: string) => {
    if (value === '') {
      setCustomer(allCustomers)
    } else {
      const filteredcustomers = customers.filter((c) =>
        c.name.toLowerCase().includes(value.toLowerCase())
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
    }).then(async (result) => {
      if (result.isConfirmed) {
        const response = await axios.delete(`https://localhost:7016/api/customer/${Id}`)
        if (response.status === 200) {
          fetchCustomers() // Refresh the customer list
          Swal.fire('Deleted!', 'The customer has been deleted.', 'success')
        } else {
          Swal.fire('Error!', 'Failed to delete the customer.', 'error')
        }
      }
    })
  }

  const handleEdit = (Id: number) => {
    const updatedCustomer = customers.find((c) => c.customerId == Id)

    if (!updatedCustomer) {
      // Handle invalid index, e.g. return or show error
      return
    }

    setCustomerUpdate({
      customerId: updatedCustomer.customerId, // no ? because now we are sure updatedCustomer exists
      name: updatedCustomer.name || '',
      lastName: '',
      emailAddress: updatedCustomer.emailAddress || '',
      dateOfBirth: updatedCustomer.dateOfBirth || '',
      phoneNumber: updatedCustomer.phoneNumber || '',
      address: 'Default', // if you have a real address, use it
      nationalID: '54652154654', // or real value
      customerType: 'VIP', // or real value
      customerSince: '2023-10-01', // or real value
      measurements: [], // or real value
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
                            {c.name}
                          </a>
                        </div>
                      </div>
                    </td>
                    <td>
                      <span className='fw-semibold d-block fs-7'>
                        {c.dateOfBirth
                          ? new Date(c.dateOfBirth).toLocaleDateString('en-US', {
                              year: 'numeric',
                              month: '2-digit',
                              day: '2-digit',
                            })
                          : 'N/A'}
                      </span>
                    </td>

                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className=' me-2 fs-7 fw-semibold'>{c.phoneNumber}</span>
                        </div>
                      </div>
                    </td>
                    <td className='text-end'>
                      <div className='d-flex flex-column w-100 me-2'>
                        <div className='d-flex flex-stack mb-2'>
                          <span className='me-2 fs-7 fw-semibold'>{c.emailAddress}</span>
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
                            handleEdit(c.customerId)
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
                            handleDelete(c.customerId)
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
      <CustomerModal
        showModal={show}
        setShowModal={setShowModal}
        customerUpdate={customerUpdate!}
        setCustomerUpdate={setCustomerUpdate}
      />
    </>
  )
}

export default CustomerPage
