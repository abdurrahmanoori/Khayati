import * as React from 'react'
import {useState, useEffect} from 'react'
import CustomFormLayout from '../../components/CustomFormLayout'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import axios from 'axios'
import Swal from 'sweetalert2'
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

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()

    try {
      const response = await axios.post('https://localhost:7016/api/customer', customerAdd)

      if (response.status === 200) {
        Swal.fire({
          title: 'Success',
          text: 'Customer added successfully!',
          icon: 'success',
          confirmButtonText: 'OK',
        })
        setCustomerAdd({
          Name: '',
          Address: '',
          EmailAddress: '',
          NationalID: '',
          DateOfBirth: '',
          PhoneNumber: '',
        })
      }
    } catch (error) {
      console.error('Error adding customer:', error)
      Swal.fire({
        title: 'Error',
        text: 'Failed to add customer.',
        icon: 'error',
        confirmButtonText: 'OK',
      })
    }
  }

  useEffect(() => {
    // Reset form on component mount
    setCustomerAdd({
      Name: '',
      Address: '',
      EmailAddress: '',
      NationalID: '',
      DateOfBirth: '',
      PhoneNumber: '',
    })
  }, [])

  return (
    <React.Fragment>
      <Toolbar1 />
      <CustomFormLayout
        title={
          <>
            <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30'> </i> Add Customer
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
                value={customerAdd.Name}
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
                value={customerAdd.Address}
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
                value={customerAdd.EmailAddress}
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
                value={customerAdd.NationalID}
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
                value={customerAdd.DateOfBirth}
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
                value={customerAdd.PhoneNumber}
                onChange={handleChange}
                required
              />
            </div>,
          ],
        ]}
      />
    </React.Fragment>
  )
}

export default CreateCustomer
