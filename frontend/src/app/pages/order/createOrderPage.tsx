import * as React from 'react'
import {useState} from 'react'

const CreateOrderPage = () => {
  const [order, setOrder] = useState({
    OrderDate: '',
    CustomerName: '',
    DeliveryAddress: '',
    ContactPhone: '',
    Email: '',
    Status: '', // e.g. Pending, Completed
  })

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const {name, value} = e.target
    setOrder((prev) => ({
      ...prev,
      [name]: value,
    }))
  }

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    // TODO: Submit order data to your API/backend here
    console.log('Order submitted:', order)
  }

  return (
    <React.Fragment>
      <div className='container m-2 p-1'>
        <div className='container-fluid pt-4 '>
          <h3 className='fw-bold '>
            <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30'> </i> Add Order
          </h3>
        </div>
      </div>
      <div className='card shadow-sm col-lg-8 m-3 mt-1'>
        <div className='card-body p-4'>
          <form onSubmit={handleSubmit}>
            <div className='row'>
              {/* Order Date */}
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='OrderDate' className='form-label'>
                    Order Date:
                  </label>
                  <input
                    id='OrderDate'
                    name='OrderDate'
                    type='date'
                    className='form-control border-success-subtle'
                    value={order.OrderDate}
                    onChange={handleChange}
                    required
                  />
                </div>
              </div>

              {/* Customer Name */}
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='CustomerName' className='form-label'>
                    Customer Name:
                  </label>
                  <input
                    id='CustomerName'
                    name='CustomerName'
                    type='text'
                    className='form-control border-success-subtle'
                    placeholder='Enter customer name'
                    value={order.CustomerName}
                    onChange={handleChange}
                    required
                  />
                </div>
              </div>
            </div>

            <div className='row'>
              {/* Delivery Address */}
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='DeliveryAddress' className='form-label'>
                    Delivery Address:
                  </label>
                  <input
                    id='DeliveryAddress'
                    name='DeliveryAddress'
                    type='text'
                    className='form-control border-success-subtle'
                    placeholder='Enter delivery address'
                    value={order.DeliveryAddress}
                    onChange={handleChange}
                    required
                  />
                </div>
              </div>

              {/* Contact Phone */}
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='ContactPhone' className='form-label'>
                    Contact Phone:
                  </label>
                  <input
                    id='ContactPhone'
                    name='ContactPhone'
                    type='tel'
                    className='form-control border-success-subtle'
                    placeholder='Enter contact phone'
                    value={order.ContactPhone}
                    onChange={handleChange}
                    required
                  />
                </div>
              </div>
            </div>

            <div className='row'>
              {/* Email */}
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='Email' className='form-label'>
                    Email:
                  </label>
                  <input
                    id='Email'
                    name='Email'
                    type='email'
                    className='form-control border-success-subtle'
                    placeholder='Enter email address'
                    value={order.Email}
                    onChange={handleChange}
                    required
                  />
                </div>
              </div>

              {/* Status */}
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='Status' className='form-label'>
                    Status:
                  </label>
                  <select
                    id='Status'
                    name='Status'
                    className='form-select border-success-subtle'
                    value={order.Status}
                    onChange={handleChange}
                    required
                  >
                    <option value=''>Select status</option>
                    <option value='Pending'>Pending</option>
                    <option value='Processing'>Processing</option>
                    <option value='Completed'>Completed</option>
                    <option value='Cancelled'>Cancelled</option>
                  </select>
                </div>
              </div>
            </div>

            <div className='text-end mt-3'>
              <button type='submit' className='btn btn-outline-success'>
                <i className='fas fa-plus text-dark m-2 mt-1 mb-1'></i> Add Order
              </button>
            </div>
          </form>
        </div>
      </div>
    </React.Fragment>
  )
}

export default CreateOrderPage
