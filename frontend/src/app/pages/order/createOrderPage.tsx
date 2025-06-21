import React, {useEffect, useState} from 'react'
import {SingleValue} from 'react-select'
import {ThemeModeComponent} from '../../../_metronic/assets/ts/layout'
import CustomSelect from '../../components/CustomSelect'
import FormLayout from '../../components/CustomFormLayout'
import {Link} from 'react-router-dom'

type OptionType = {
  value: string
  label: string
}

const CreateOrderPage = () => {
  const [order, setOrder] = useState({
    OrderDate: '',
    CustomerName: '',
    Status: '',
    TotalCost: 0,
    PaidAmount: 0,
    IsEmbellished: false,
    embellishmentType: '',
    embellishment: '',
    orderPriority: '',
    garment: '',
    fabric: '',
    color: '',
    payment: '',
  })

  const [themeMode, setThemeMode] = useState<'light' | 'dark' | 'system'>(
    ThemeModeComponent.getMode()
  )
  useEffect(() => {
    const updateTheme = () => setThemeMode(ThemeModeComponent.getMode())
    const interval = setInterval(updateTheme, 1000)
    return () => clearInterval(interval)
  }, [])
  const isDark = themeMode === 'dark'

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const {name, value} = e.target
    setOrder((prev) => ({...prev, [name]: value}))
  }

  const statusOptions: OptionType[] = [
    {value: 'Pending', label: 'Pending'},
    {value: 'Processing', label: 'Processing'},
    {value: 'Completed', label: 'Completed'},
    {value: 'Cancelled', label: 'Cancelled'},
  ]

  const customerOptions: OptionType[] = [
    {value: 'Abubakr', label: 'Abubakr'},
    {value: 'Fatima', label: 'Fatima'},
    {value: 'Zubair', label: 'Zubair'},
    {value: 'Aisha', label: 'Aisha'},
    {value: 'Omar', label: 'Omar'},
  ]
  const priorityOptions: OptionType[] = [
    {value: 'high', label: 'High'},
    {value: 'medium', label: 'Medium'},
    {value: 'low', label: 'Low'},
  ]
  const paymentOptions: OptionType[] = [
    {value: 'Not paid', label: 'Not paid'},
    {value: 'Parial Paid', label: 'Parial Paid'},
    {value: 'Paid', label: 'Paid'},
  ]
  const garmentOptions: OptionType[] = [
    {value: 'shirt', label: 'Shirt'},
    {value: 'pant', label: 'Pant'},
    {value: 'coat', label: 'Coat'},
    {value: 'dress', label: 'Dress'},
    {value: 'kurta', label: 'Kurta'},
  ]
  const fabricOptions: OptionType[] = [
    {value: 'cotton', label: 'Cotton'},
    {value: 'linen', label: 'Linen'},
    {value: 'silk', label: 'Silk'},
    {value: 'wool', label: 'Wool'},
    {value: 'polyester', label: 'Polyester'},
  ]
  const colorOptions: OptionType[] = [
    {value: 'black', label: 'Black'},
    {value: 'white', label: 'White'},
    {value: 'navy', label: 'Navy Blue'},
    {value: 'beige', label: 'Beige'},
    {value: 'gray', label: 'Gray'},
  ]
  const embellishmentTypeOptions: OptionType[] = [
    {value: 'neck', label: 'Neck'},
    {value: 'sleeve', label: 'Sleeve'},
    {value: 'pocket', label: 'Pocket'},
    {value: 'border', label: 'Border'},
    {value: 'back', label: 'Back'},
  ]
  const embellishmentOptions: OptionType[] = [
    {value: 'lace', label: 'Lace'},
    {value: 'embroidery', label: 'Embroidery'},
    {value: 'beads', label: 'Beads'},
    {value: 'sequins', label: 'Sequins'},
    {value: 'patchwork', label: 'Patchwork'},
  ]

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    console.log('Order submitted:', order)
  }

  return (
    <FormLayout
      title={
        <>
          <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30' /> Add Order
        </>
      }
      onSubmit={handleSubmit}
      rows={[
        [
          <div className='d-flex align-items-center my-4'>
            <div className='flex-grow-1 border-top border-2'></div>
            <span className='mx-3 fw-bold text-muted'>Customer Info</span>
            <div className='flex-grow-1 border-top border-2'></div>
          </div>,
        ],
        [
          <>
            <label htmlFor='Status' className='form-label'>
              Customer:
            </label>{' '}
            <Link to='/customer-create'>Create</Link>
            <CustomSelect
              id='CustomerSelect'
              name='CustomerSelect'
              options={customerOptions}
              value={customerOptions.find((opt) => opt.value === order.CustomerName) || null}
              onChange={(selected: SingleValue<OptionType>) =>
                setOrder((prev) => ({...prev, CustomerName: selected?.value || ''}))
              }
              placeholder='Select Customer'
            />
          </>,
          <>
            <label htmlFor='OrderDate' className='form-label'>
              Delivery Date:
            </label>
            <input
              id='OrderDate'
              name='OrderDate'
              type='date'
              className='form-control text-muted fw-bold'
              value={order.OrderDate}
              onChange={handleChange}
              required
            />
          </>,
        ],
        [
          <>
            <>
              <label htmlFor='Status' className='form-label'>
                Order Priority:
              </label>
              <CustomSelect
                id='OrderPriority'
                name='OrderPriority'
                options={priorityOptions}
                value={priorityOptions.find((opt) => opt.value === order.orderPriority) || null}
                onChange={(selected: SingleValue<OptionType>) =>
                  setOrder((prev) => ({...prev, orderPriority: selected?.value || ''}))
                }
                placeholder='Select Order Priority'
              />
            </>
          </>,
          <></>,
        ],
        [
          <div className='d-flex align-items-center my-4'>
            <div className='flex-grow-1 border-top border-2'></div>
            <span className='mx-3 fw-bold text-muted'>Garment Info</span>
            <div className='flex-grow-1 border-top border-2'></div>
          </div>,
        ],
        [
          <>
            <label htmlFor='Status' className='form-label'>
              Select Garment:
            </label>
            <CustomSelect
              id='Garment'
              name='Garment'
              options={garmentOptions}
              value={garmentOptions.find((opt) => opt.value === order.garment) || null}
              onChange={(selected: SingleValue<OptionType>) =>
                setOrder((prev) => ({...prev, garment: selected?.value || ''}))
              }
              placeholder='Select Payment status'
            />
          </>,
          <>
            <label htmlFor='Status' className='form-label'>
              Select Fabric:
            </label>
            <CustomSelect
              id='Fabric'
              name='Fabric'
              options={fabricOptions}
              value={fabricOptions.find((opt) => opt.value === order.fabric) || null}
              onChange={(selected: SingleValue<OptionType>) =>
                setOrder((prev) => ({...prev, fabric: selected?.value || ''}))
              }
              placeholder='Select Fabric'
            />
          </>,
        ],
        [
          <>
            <label htmlFor='Status' className='form-label'>
              Select Color:
            </label>
            <CustomSelect
              id='PaymentStatus'
              name='PaymentStatus'
              options={colorOptions}
              value={colorOptions.find((opt) => opt.value === order.color) || null}
              onChange={(selected: SingleValue<OptionType>) =>
                setOrder((prev) => ({...prev, color: selected?.value || ''}))
              }
              placeholder='Select Color'
            />
          </>,
          <>
            <div className='form-check mt-12'>
              <input
                className='form-check-input'
                type='checkbox'
                name='isEmbellishment'
                id='isEmbellishment'
                checked={order.IsEmbellished} // make it a controlled component
                onChange={(e) => {
                  setOrder((prev) => ({
                    ...prev,
                    IsEmbellished: e.target.checked,
                  }))
                }}
              />
              <label htmlFor='isEmbellishment' className='form-check-label ms-2'>
                Is Embellishment?
              </label>
            </div>
          </>,
        ],
        order.IsEmbellished
          ? [
              <>
                <label htmlFor='embellishmentType' className='form-label'>
                  Embellishment Type:
                </label>
                <CustomSelect
                  id='embellishmentType'
                  name='embellishmentType'
                  options={embellishmentTypeOptions}
                  value={
                    embellishmentTypeOptions.find((opt) => opt.value === order.embellishmentType) ||
                    null
                  }
                  onChange={(selected: SingleValue<OptionType>) =>
                    setOrder((prev) => ({
                      ...prev,
                      embellishmentType: selected?.value || '',
                    }))
                  }
                  placeholder='Select Embellishment Type'
                />
              </>,
              <>
                <label htmlFor='embellishment' className='form-label'>
                  Embellishment:
                </label>
                <CustomSelect
                  id='embellishment'
                  name='embellishment'
                  options={embellishmentOptions}
                  value={
                    embellishmentOptions.find((opt) => opt.value === order.embellishment) || null
                  }
                  onChange={(selected: SingleValue<OptionType>) =>
                    setOrder((prev) => ({
                      ...prev,
                      embellishment: selected?.value || '',
                    }))
                  }
                  placeholder='Select Embellishment'
                />
              </>,
              <>
                <button className='btn btn-outline-success mt-8 border-0'>+</button>
              </>,
            ]
          : [],
        [
          <div className='d-flex align-items-center my-4'>
            <div className='flex-grow-1 border-top border-2'></div>
            <span className='mx-3 fw-bold text-muted'>Payment Info</span>
            <div className='flex-grow-1 border-top border-2'></div>
          </div>,
        ],
        [
          <>
            <label htmlFor='DeliveryAddress' className='form-label'>
              Total Cost:
            </label>
            <input
              id='DeliveryAddress'
              name='DeliveryAddress'
              type='text'
              className='form-control border-success-subtle'
              value={order.TotalCost}
              onChange={handleChange}
              placeholder='Enter total cost'
              required
            />
          </>,
          <>
            <label htmlFor='Status' className='form-label'>
              Payment Status:
            </label>
            <CustomSelect
              id='PaymentStatus'
              name='PaymentStatus'
              options={paymentOptions}
              value={paymentOptions.find((opt) => opt.value === order.payment) || null}
              onChange={(selected: SingleValue<OptionType>) =>
                setOrder((prev) => ({...prev, payment: selected?.value || ''}))
              }
              placeholder='Select Payment status'
            />
          </>,
        ],
        [
          <>
            <label htmlFor='DeliveryAddress' className='form-label'>
              Amount Paid:
            </label>
            <input
              id='DeliveryAddress'
              name='DeliveryAddress'
              type='text'
              className='form-control border-success-subtle'
              value={order.PaidAmount}
              onChange={handleChange}
              placeholder='Enter paid amount'
              required
            />
          </>,
          <></>,
        ],
      ]}
      submitLabel='Add Order'
    />
  )
}

export default CreateOrderPage
