/* eslint-disable jsx-a11y/anchor-is-valid */
import React, {useState} from 'react'
import {KTSVG, toAbsoluteUrl} from '../../../_metronic/helpers'
import {Link} from 'react-router-dom'

type Props = {
  className: string
}

type Order = {
  OrderId: number
  CustomerName?: string
  OrderDate: string
  ExpectedCompletionDate?: string
  TotalCost?: number
  PaymentStatus: string
}

const OrderPage: React.FC<Props> = ({className}) => {
  const [orders, setOrders] = useState<Order[]>([
    {
      OrderId: 1,
      CustomerName: 'Abubakr',
      OrderDate: '2020-02-20',
      ExpectedCompletionDate: '2020-03-01',
      TotalCost: 120.5,
      PaymentStatus: 'Pending',
    },
    {
      OrderId: 2,
      CustomerName: 'Ahmad',
      OrderDate: '2021-03-15',
      ExpectedCompletionDate: '2021-04-01',
      TotalCost: 200,
      PaymentStatus: 'Completed',
    },
    {
      OrderId: 3,
      CustomerName: 'Fatima',
      OrderDate: '2022-05-10',
      ExpectedCompletionDate: '2022-06-05',
      TotalCost: 350,
      PaymentStatus: 'PartialPayment',
    },
    // ... more orders here
  ])

  const [allOrders] = useState(orders)

  const search = (value: string) => {
    if (value === '') {
      setOrders(allOrders)
    } else {
      const filteredOrders = allOrders.filter(
        (o) =>
          o.CustomerName?.toLowerCase().includes(value.toLowerCase()) ||
          o.OrderId.toString().includes(value)
      )
      setOrders(filteredOrders)
    }
  }

  const handleDelete = (OrderId: number) => {
    alert(`Order with id ${OrderId} is deleted`)
  }
  const handleEdit = (OrderId: number) => {
    console.log('Edit clicked for id:', OrderId)
    alert(`Order with id ${OrderId} is edited`)
  }

  return (
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
                      <div className='symbol symbol-45px me-5'>
                        <img
                          src={toAbsoluteUrl(`/media/avatars/300-${(index % 10) + 1}.jpg`)}
                          alt=''
                        />
                      </div>
                      <div className='d-flex justify-content-start flex-column'>
                        <a href='#' className='text-dark fw-bold text-hover-primary fs-6'>
                          {order.CustomerName || 'Unknown'}
                        </a>
                      </div>
                    </div>
                  </td>
                  <td>
                    <span className='fw-semibold d-block fs-7'>{order.OrderDate}</span>
                  </td>
                  <td>
                    <span className='fw-semibold d-block fs-7'>
                      {order.ExpectedCompletionDate || 'N/A'}
                    </span>
                  </td>
                  <td className='text-end'>
                    <span className='fw-semibold d-block fs-7'>
                      {order.TotalCost !== undefined ? `$${order.TotalCost.toFixed(2)}` : 'N/A'}
                    </span>
                  </td>
                  <td>
                    <span className='fw-semibold d-block fs-7'>{order.PaymentStatus}</span>
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
                        <KTSVG path='/media/icons/duotune/art/art005.svg' className='svg-icon-3' />
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
  )
}

export default OrderPage
