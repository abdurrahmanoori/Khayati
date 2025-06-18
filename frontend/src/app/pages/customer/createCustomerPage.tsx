import * as React from 'react'
import {useState, useEffect} from 'react'
const CreateCustomer = () => {
  const [customerAdd, setCustomerAdd] = useState({
    Name: '',
    Address: '',
    EmailAddress: '',
    NationalID: '',
    DateOfBirth: '',
    PhoneNumber: '',
  })

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const {name, value} = e.target
    setCustomerAdd((prev) => ({
      ...prev,
      [name]: value,
    }))
  }

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    // TODO: Submit form data to your API or backend here
    console.log('Form submitted:', customerAdd)
  }

  return (
    <React.Fragment>
      <div className='container m-2 p-1'>
        <div className='container-fluid pt-4 '>
          <h3 className='fw-bold '>
            <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30'> </i> Add Customer
          </h3>
        </div>
      </div>
      <div className='card shadow-sm col-lg-8 m-3 mt-1'>
        <div className='card-body p-4'>
          <form onSubmit={handleSubmit}>
            <div className='row'>
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='Name' className='form-label'>
                    Full Name:
                  </label>
                  <input
                    id='Name'
                    name='Name'
                    type='text'
                    className='form-control border-success-subtle'
                    placeholder='Enter your full name'
                    value={customerAdd.Name}
                    onChange={handleChange}
                  />
                </div>
              </div>
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='Address' className='form-label'>
                    Address:
                  </label>
                  <input
                    id='Address'
                    name='Address'
                    type='text'
                    className='form-control border-success-subtle'
                    placeholder='Enter your address'
                    value={customerAdd.Address}
                    onChange={handleChange}
                    required
                  />
                </div>
              </div>
            </div>

            <div className='row'>
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='EmailAddress' className='form-label'>
                    Email Address:
                  </label>
                  <input
                    id='EmailAddress'
                    name='EmailAddress'
                    type='email'
                    className='form-control border-success-subtle'
                    placeholder='Enter your email'
                    value={customerAdd.EmailAddress}
                    onChange={handleChange}
                    required
                  />
                </div>
              </div>
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='NationalID' className='form-label'>
                    National ID:
                  </label>
                  <input
                    id='NationalID'
                    name='NationalID'
                    type='text'
                    className='form-control border-success-subtle'
                    placeholder='Enter your national ID'
                    value={customerAdd.NationalID}
                    onChange={handleChange}
                    required
                  />
                </div>
              </div>
            </div>

            <div className='row'>
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='DateOfBirth' className='form-label'>
                    Date of Birth:
                  </label>
                  <input
                    id='DateOfBirth'
                    name='DateOfBirth'
                    type='date'
                    className='form-control border-success-subtle'
                    value={customerAdd.DateOfBirth}
                    onChange={handleChange}
                    required
                  />
                </div>
              </div>
              <div className='col-md-6'>
                <div className='mb-3'>
                  <label htmlFor='PhoneNumber' className='form-label'>
                    Phone Number:
                  </label>
                  <input
                    id='PhoneNumber'
                    name='PhoneNumber'
                    type='tel'
                    className='form-control border-success-subtle'
                    placeholder='Enter your phone number'
                    value={customerAdd.PhoneNumber}
                    onChange={handleChange}
                    required
                  />
                </div>
              </div>
            </div>

            <div className='text-end mt-3'>
              <button type='submit' className='btn btn-outline-success'>
                <i className='fas fa-plus text-dark m-2 mt-1 mb-1'></i> Add Customer
              </button>
            </div>
          </form>
        </div>
      </div>
    </React.Fragment>
  )
}

export default CreateCustomer
