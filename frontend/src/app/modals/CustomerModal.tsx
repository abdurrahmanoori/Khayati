import * as React from 'react'
import {ReusableModal} from './reusableModal'
import CustomFormLayout from '../components/CustomFormLayout'
import {Customer} from '../types/commonTypes'
import axios from 'axios'
import Swal from 'sweetalert2'
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
  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    const result = await axios.put(
      `https://localhost:7016/api/customer/${customerUpdate.customerId}`,
      customerUpdate
    )
    if (result.status === 200) {
      Swal.fire({
        title: 'Success',
        text: 'Customer updated successfully!',
        icon: 'success',
        confirmButtonText: 'OK',
      })
      setShowModal(false)
    } else {
      Swal.fire({
        title: 'Error',
        text: 'Failed to update customer.',
        icon: 'error',
        confirmButtonText: 'OK',
      })
    }
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
                  name='name'
                  type='text'
                  className='form-control border-success-subtle'
                  placeholder='Enter your full name'
                  value={customerUpdate.name}
                  onChange={handleChange}
                />
              </div>,

              <div className='mb-3' key='address'>
                <label htmlFor='Address' className='form-label'>
                  Address:
                </label>
                <input
                  id='Address'
                  name='address'
                  type='text'
                  className='form-control border-success-subtle'
                  placeholder='Enter your address'
                  value={customerUpdate.address}
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
                  name='emailAddress'
                  type='email'
                  className='form-control border-success-subtle'
                  placeholder='Enter your email'
                  value={customerUpdate.emailAddress}
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
                  name='nationalID'
                  type='text'
                  className='form-control border-success-subtle'
                  placeholder='Enter your national ID'
                  value={customerUpdate.nationalID}
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
                  name='dateOfBirth'
                  type='date'
                  className='form-control border-success-subtle'
                  value={customerUpdate.dateOfBirth ? customerUpdate.dateOfBirth.slice(0, 10) : ''}
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
                  name='phoneNumber'
                  type='tel'
                  className='form-control border-success-subtle'
                  placeholder='Enter your phone number'
                  value={customerUpdate.phoneNumber}
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
