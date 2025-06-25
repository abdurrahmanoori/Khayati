import * as React from 'react'
import {useState, useEffect} from 'react'
import CustomSelect from '../../../components/CustomSelect'
import {SingleValue} from 'react-select'

type Type = {
  value: string
  label: string
}

type UpdateOrder = {
  OrderId: number
  CustomerName?: string
  OrderDate: string
  ExpectedCompletionDate?: string
  TotalCost?: number
  PaymentStatus: string
  OrderStatus: string
}

type Props = {
  setOrder: Function
  handleChange: React.ChangeEventHandler<HTMLInputElement>
  updateorder?: UpdateOrder | undefined
  paymentOptions: Type[]
  order: Order
}
type Order = {
  OrderDate: string
  CustomerName: string
  Status: string
  TotalCost: number
  PaidAmount: number
  IsEmbellished: boolean
  embellishmentType: string
  embellishment: string
  orderPriority: string
  garment: string
  fabric: string
  color: string
  payment: string
  description: string
}
const PaymentInfo: React.FC<Props> = ({
  order,
  updateorder,
  handleChange,
  setOrder,
  paymentOptions,
}) => {
  return (
    <React.Fragment>
      <div className='row mb-3'>
        <div className='d-flex align-items-center my-4'>
          <div className='flex-grow-1 border-top border-2'></div>
          <span className='mx-3 fw-bold text-muted'>Payment Info</span>
          <div className='flex-grow-1 border-top border-2'></div>
        </div>
      </div>
      <div className='row mb-3'>
        <div className='col-md-6'>
          <label htmlFor='TotalCost' className='form-label'>
            Total Cost:
          </label>
          <input
            id='TotalCost'
            name='TotalCost'
            type='text'
            className='form-control border-success-subtle'
            value={order?.TotalCost || ''}
            onChange={(e: React.ChangeEvent<HTMLInputElement>) => handleChange(e)}
            placeholder='Enter total cost'
            required
          />
        </div>

        <div className='col-md-6'>
          <label htmlFor='Status' className='form-label'>
            Payment Status:
          </label>
          <CustomSelect
            id='PaymentStatus'
            name='PaymentStatus'
            options={paymentOptions}
            value={paymentOptions.find((opt) => opt.value === updateorder?.PaymentStatus) || null}
            onChange={(selected: SingleValue<Type>) =>
              setOrder((prev: Order) => ({...prev, payment: selected?.value || ''}))
            }
            placeholder='Select Payment status'
          />
        </div>
      </div>
      <div className='row mb-3'>
        <div className='col-md-6'>
          <label htmlFor='PaidAmount' className='form-label'>
            Amount Paid:
          </label>
          <input
            id='PaidAmount'
            name='PaidAmount'
            type='text'
            className='form-control border-success-subtle'
            value={order.PaidAmount}
            onChange={handleChange}
            placeholder='Enter paid amount'
            required
          />
        </div>
      </div>{' '}
      <div className='row mb-3'></div>
      <div className='row mb-3'>
        <div key='description' className='mb-3 col-md-8'>
          <label htmlFor='Note' className='form-label'>
            Note
          </label>
          <textarea
            name='Description'
            id='Description'
            className='form-control'
            rows={5}
            placeholder='Enter description'
            value={order.description}
            onChange={(e: React.ChangeEvent<HTMLTextAreaElement>) =>
              setOrder((prev: Order) => ({...prev, description: e.target.value}))
            }
          />
        </div>
      </div>
      <div className='text-end mt-3'>
        <button type='submit' className='btn btn-outline-success'>
          update Order
        </button>
      </div>
    </React.Fragment>
  )
}

export default PaymentInfo
