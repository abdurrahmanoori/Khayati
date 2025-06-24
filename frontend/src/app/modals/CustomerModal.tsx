import * as React from 'react'
import {useState, useEffect} from 'react'
import {ReusableModal} from './reusableModal'
import CustomFormLayout from '../components/CustomFormLayout'
type Customer = {
  Id: number
  Name: string
  Address: string
  EmailAddress: string
  NationalID: string
  DateOfBirth: string
  PhoneNumber: string
}

type Props = {
  showModal: boolean
  setShowModal: (val: boolean) => void
  customerUpdate: Customer
  setCustomerUpdate: (val: Customer) => void
}
const CustomerModal: React.FC<Props> = ({
  showModal,
  setShowModal,
  customerUpdate,
  setCustomerUpdate,
}) => {
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const {name, value} = e.target
    setCustomerUpdate({
      ...customerUpdate,
      [name]: value,
    })
  }

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    // TODO: Submit form data to your API or backend here
    console.log('Form submitted:', customerUpdate)
  }

  return (
    <>
      <ReusableModal show={showModal} onClose={() => setShowModal(false)}>
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
      </ReusableModal>
    </>
  )
}

export default CustomerModal
