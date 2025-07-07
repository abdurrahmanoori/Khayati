import * as React from 'react'
import {Link} from 'react-router-dom'
import CustomSelect from '../../../components/CustomSelect'
import {SingleValue} from 'react-select'
import {OptionType, Order} from '../../../types/commonTypes'

type Props = {
  customerOptions: OptionType[]
  setOrder: Function
  handleChange: React.ChangeEventHandler<HTMLInputElement>
  priorityOptions: OptionType[]
  order: Order
}
const CustomerInfo: React.FC<Props> = ({
  customerOptions,
  setOrder,
  handleChange,
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
            value={customerOptions.find((opt) => Number(opt.value) === order?.CustomerId) || null}
            onChange={(selected: SingleValue<OptionType> | null) =>
              setOrder((prev: Order) => ({
                ...prev,
                CustomerId: selected?.value || 0,
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
            id='DeliveryDate'
            name='DeliveryDate'
            type='date'
            className='form-control text-muted fw-bold'
            value={order?.DeliveryDate || ''}
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
            onChange={(selected: SingleValue<OptionType>) =>
              setOrder((prev: Order) => ({...prev, orderPriority: selected?.value || ''}))
            }
            placeholder='Select Order Priority'
          />
        </div>
      </div>
    </div>
  )
}

export default CustomerInfo
