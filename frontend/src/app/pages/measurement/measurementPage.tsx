import React, {useState} from 'react'
import {KTSVG, toAbsoluteUrl} from '../../../_metronic/helpers'
import {Link} from 'react-router-dom'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import MeasurementModal from '../../modals/MeasurementModal'
import Swal from 'sweetalert2'
import {Customer} from '../../types/commonTypes'
import axios from 'axios'
type Props = {
  className: string
}
const MeasurementPage: React.FC<Props> = ({className}) => {
  const [customers, setCustomer] = useState<Customer[]>([])
  const [allCustomers, setAllCustomers] = useState<Customer[]>([])
  const [customerToUpdate, setCustomerToUpdate] = useState<Customer>()
  const [showModal, setShowModal] = useState(false)
  const [isEditable, setIsEditable] = useState<boolean>(false)
  const handleView = (c: Customer) => {
    //setTitle('')
    setIsEditable(false)
    setCustomerToUpdate(c)
    setShowModal(true)
  }
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
  const fetchCustomers = async () => {
    try {
      const response = await axios.get('https://localhost:7016/api/Customer')
      const MeasuredCustomers = response.data.filter((c: any) => c.measurements.length > 0)
      setCustomer(MeasuredCustomers)
      setAllCustomers(MeasuredCustomers)
    } catch (error) {
      console.error('Error fetching customers:', error)
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failed to fetch customers. Please try again later.',
      })
    }
  }
  React.useEffect(() => {
    fetchCustomers()
  }, [])

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
            <span className='card-label fw-bold fs-3 mb-1'>Measurement</span>
          </h3>

          <div
            className='card-toolbar'
            data-bs-toggle='tooltip'
            data-bs-placement='top'
            data-bs-trigger='hover'
            title='Click to add a user'
          >
            <Link
              to='/measurement-create'
              className='btn btn-sm btn-light-primary'
              // data-bs-toggle='modal'
              // data-bs-target='#kt_modal_invite_friends'
            >
              <KTSVG path='/media/icons/duotune/arrows/arr075.svg' className='svg-icon-3' />
              New Measurement
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
                  <th className='min-w-150px pl-5'>Name</th>
                </tr>
              </thead>
              {/* end::Table head */}

              {/* begin::Table body */}
              <tbody>
                {customers.map((c, index) => (
                  <tr
                    key={c.customerId ?? index}
                    onClick={(e: any) => {
                      handleView(c)
                    }}
                    style={{
                      cursor: 'pointer',
                    }}
                  >
                    <td>
                      <div className='form-check form-check-sm form-check-custom form-check-solid'>
                        <span className=' mt-1 fw-semibold fs-7'>{c.customerId}</span>
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
      <MeasurementModal
        show={showModal}
        setShow={() => {
          setShowModal(false)
        }}
        customer={customerToUpdate}
        IsEditable={isEditable}
      />
    </>
  )
}

export default MeasurementPage
