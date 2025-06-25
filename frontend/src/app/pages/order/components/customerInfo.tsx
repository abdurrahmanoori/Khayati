import * as React from 'react'
import {Link} from 'react-router-dom'
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
  customerOptions: Type[]
  setOrder: Function
  handleChange: React.ChangeEventHandler<HTMLInputElement>
  updateorder: UpdateOrder | undefined
  priorityOptions: Type[]
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

const CustomerInfo: React.FC<Props> = ({
  customerOptions,
  setOrder,
  handleChange,
  updateorder,
  priorityOptions,
  order,
}) => {
  return (
    <div className='container-fluid'>
      <div className='row mb-3'>
        <div className='d-flex align-items-center my-4'>
          <div className='flex-grow-1 border-top border-2'></div>
          <span className='mx-3 fw-bold text-muted'>Customer Info</span>
          <div className='flex-grow-1 border-top border-2'></div>
        </div>
      </div>
      <div className='row mb-3'>
        <div className='col-md-6'>
          <label htmlFor='CustomerSelect' className='form-label'>
            Customer:
          </label>
          <Link to='/customer-create' className='ms-2'>
            Create
          </Link>
          <CustomSelect
            id='CustomerSelect'
            name='CustomerSelect'
            options={customerOptions}
            value={customerOptions.find((opt) => opt.value === updateorder?.CustomerName) || null}
            onChange={(selected: SingleValue<Type> | null) =>
              setOrder((prev: UpdateOrder) => ({
                ...prev,
                CustomerName: selected?.value || '',
              }))
            }
            placeholder='Select Customer'
          />
        </div>

        <div className='col-md-6'>
          <label htmlFor='OrderDate' className='form-label'>
            Delivery Date:
          </label>
          <input
            id='OrderDate'
            name='OrderDate'
            type='date'
            className='form-control text-muted fw-bold'
            value={updateorder?.ExpectedCompletionDate || ''}
            onChange={handleChange}
            required
          />
        </div>
      </div>
      <div className='row mb-3'>
        <div className='col-md-6'>
          {' '}
          <label htmlFor='Status' className='form-label'>
            Order Priority:
          </label>
          <CustomSelect
            id='OrderPriority'
            name='OrderPriority'
            options={priorityOptions}
            value={priorityOptions.find((opt) => opt.value === order.orderPriority) || null}
            onChange={(selected: SingleValue<Type>) =>
              setOrder((prev: UpdateOrder) => ({...prev, orderPriority: selected?.value || ''}))
            }
            placeholder='Select Order Priority'
          />
        </div>
      </div>
    </div>
  )
}

export default CustomerInfo
