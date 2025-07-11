/* eslint-disable jsx-a11y/anchor-is-valid */
import React, {useEffect, useState} from 'react'
import {KTSVG, toAbsoluteUrl} from '../../../_metronic/helpers'
import {Link} from 'react-router-dom'
import dayjs from 'dayjs'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import {useIntl} from 'react-intl'
import OrderModal from '../../modals/OrderModal'
import Swal from 'sweetalert2'
import {Order, Customer} from '../../types/commonTypes'
import {mockOrders} from './mockOrders'

type Props = {
  className: string
}
const OrderPage: React.FC<Props> = ({className}) => {
  const [showModal, setShowModal] = useState(false)
  const [updateOrder, setUpdateOrder] = useState<Order>()
  const getStatusBadgeClass = (status: string) => {
    switch (status.toLowerCase()) {
      case 'completed':
        return 'badge-light-success'
      case 'pending':
        return 'badge-light-warning'
      case 'cancelled':
        return 'badge-light-danger'
      default:
        return 'badge-light-primary'
    }
  }
  const [orders, setOrders] = useState<Order[]>(mockOrders)
  const [Customers, setCustomers] = useState<Customer[]>([])
  const [allOrders] = useState(orders)

  const fetchCustomers = async () => {
    try {
      const response = await fetch('https://localhost:7016/api/customer')
      if (response.ok || response.status === 200) {
        const data = await response.json()
        setCustomers(data)
      } else {
        throw new Error('Failed to fetch customers')
      }
    } catch (error) {
      console.error('Error fetching customers:', error)
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failed to fetch customers. Please try again later.',
      })
    }
  }
  useEffect(() => {
    fetchCustomers()
  }, [])
  const search = (value: string) => {
    if (value === '') {
      setOrders(allOrders)
    } else {
      const filteredOrders = allOrders.filter((o) =>
        // o.CustomerId?.toLowerCase().includes(value.toLowerCase()) ||
        o.OrderId.toString().includes(value)
      )
      setOrders(filteredOrders)
    }
  }

  const handleDelete = (OrderId: number) => {
    Swal.fire({
      title: 'Delete',
      text: 'Are you sure you want to delete?',
      icon: 'warning',
      showCancelButton: true,
      showCloseButton: true,
      showConfirmButton: true,
      confirmButtonText: 'Yes, Delete it!',
    }).then((result) => {
      if (result) {
        const newOrders = orders.filter((o) => o.OrderId != OrderId)
        setOrders(newOrders)
      }

      Swal.fire({
        title: 'Deleted Successfully',
        icon: 'success',
        showConfirmButton: true,
        timer: 2000,
      })
    })
  }
  const handleEdit = (OrderId: number) => {
    const order = orders.find((o) => o.OrderId == OrderId)
    setUpdateOrder(order)
    setShowModal(true)
  }
  const intl = useIntl()
  return (
    <>
      <Toolbar1 />
      <div className={`card ${className}`}>
        {/* Header */}
        <div className='card-title'>
          <div className='d-flex align-items-center position-relative my-1'>
            <KTSVG
              path='/media/icons/duotune/general/gen021.svg'
              className='svg-icon-1 position-absolute ms-6'
            />
            <input
              type='text'
              data-kt-user-table-filter='search'
              className='form-control form-control-solid w-250px ps-14'
              placeholder='Search orders by customer or ID'
              onChange={(e) => search(e.target.value)}
            />
          </div>
        </div>

        <div className='card-header border-0 pt-5'>
          <h3 className='card-title align-items-start flex-column'>
            <span className='card-label fw-bold fs-3 mb-1'>Orders</span>
            <span className='mt-1 fw-semibold fs-7'>Over {orders.length} Orders</span>
          </h3>

          <div
            className='card-toolbar'
            data-bs-toggle='tooltip'
            data-bs-placement='top'
            data-bs-trigger='hover'
            title='Click to add an order'
          >
            <Link to='/order-create' className='btn btn-sm btn-light-primary'>
              <KTSVG path='/media/icons/duotune/arrows/arr075.svg' className='svg-icon-3' />
              New Order
            </Link>
          </div>
        </div>

        {/* Body */}
        <div className='card-body py-3'>
          <div className='table-responsive'>
            <table className='table table-row-dashed table-row-gray-300 align-middle gs-0 gy-4'>
              <thead>
                <tr className='fw-bold'>
                  <th className='w-25px'>
                    <div className='form-check form-check-sm form-check-custom form-check-solid'>
                      ID
                    </div>
                  </th>
                  <th className='min-w-150px'>Customer Name</th>
                  <th className='min-w-140px'>Order Date</th>
                  <th className='min-w-140px'>Expected Completion</th>
                  <th className='min-w-120px'>Total Cost</th>
                  <th className='min-w-120px'>Payment Status</th>
                  <th className='min-w-120px'>Order Status</th>
                  <th className='min-w-100px text-end'>Actions</th>
                </tr>
              </thead>
              <tbody>
                {orders.map((order, index) => (
                  <tr key={order.OrderId}>
                    <td>
                      <div className='form-check form-check-sm form-check-custom form-check-solid'>
                        <span className='mt-1 fw-semibold fs-7'>{order.OrderId}</span>
                      </div>
                    </td>
                    <td>
                      <div className='d-flex align-items-center'>
                        <div className='d-flex justify-content-start flex-column'>
                          <a href='#' className='text-dark fw-bold text-hover-primary fs-6'>
                            {order.CustomerId || 'Unknown'}
                          </a>
                        </div>
                      </div>
                    </td>
                    <td>
                      <span className='fw-semibold d-block fs-7'>
                        {dayjs(order.OrderDate).format('MMM D, YYYY')}
                      </span>
                    </td>
                    <td>
                      <span className='fw-semibold d-block fs-7'>
                        {dayjs(order.DeliveryDate).format('MMM D,YYYY') || 'N/A'}
                      </span>
                    </td>
                    <td>
                      <span className='fw-semibold d-block fs-7'>
                        {order.TotalCost !== undefined ? `$${order.TotalCost.toFixed(2)}` : 'N/A'}
                      </span>
                    </td>
                    <td>
                      <span className='fw-semibold d-block fs-7'>{order.PaymentStatus}</span>
                    </td>
                    <td>
                      <span
                        className={`fw-semibold d-block fs-7 badge ${getStatusBadgeClass(
                          order.OrderStatus
                        )}`}
                      >
                        {order.OrderStatus}
                      </span>
                    </td>
                    <td>
                      <div className='d-flex justify-content-end flex-shrink-0'>
                        <button
                          type='button'
                          className='btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'
                          aria-label='Edit'
                          onClick={() => {
                            handleEdit(order.OrderId)
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
                            handleDelete(order.OrderId)
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
            </table>
          </div>
        </div>
      </div>

      <OrderModal showModal={showModal} setShowModal={setShowModal} updateorder={updateOrder} />
    </>
  )
}

export default OrderPage
