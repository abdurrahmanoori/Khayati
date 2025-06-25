import * as React from 'react'
import {useState, useEffect} from 'react'
import {ReusableModal} from './reusableModal'
import {SingleValue} from 'react-select'
import {ThemeModeComponent} from '../../_metronic/assets/ts/layout'
import CustomSelect from '../components/CustomSelect'
import CustomerInfo from '../pages/order/components/customerInfo'
import GarmentInfo from '../pages/order/components/garmentInfo'
import PaymentInfo from '../pages/order/components/paymentInfo'
type OptionType = {
  value: string
  label: string
}
type Embellishment = {
  type: string
  name: string
}
type Order = {
  OrderId: number
  CustomerName?: string
  OrderDate: string
  ExpectedCompletionDate?: string
  TotalCost?: number
  PaymentStatus: string
  OrderStatus: string
}
type Garment = {
  id: number
  garment: string
  fabric: string
  color: string
  isEmbellished: boolean
  embellishments: Embellishment[]
}
type Props = {
  showModal: boolean
  setShowModal: Function
  updateorder: Order | undefined
}
const OrderModal: React.FC<Props> = ({showModal, setShowModal, updateorder}) => {
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
    description: '',
  })
  const [garments, setGarments] = useState<Garment[]>([
    {
      id: 0,
      garment: '',
      color: '',
      fabric: '',
      isEmbellished: false,
      embellishments: [{type: '', name: ''}],
    },
  ])
  const addGarment = () => {
    const i = garments.length
    const newGarments = [
      ...garments,
      {id: i, garment: '', color: '', fabric: '', isEmbellished: false, embellishments: []},
    ]
    setGarments(newGarments)
  }
  const removeGarment = (gId: number) => {
    const newGarments = garments.filter((g) => g.id != gId)
    setGarments(newGarments)
  }
  const addEmbellishment = (GarmentId: number) => {
    const newGarments = [...garments]
    newGarments[GarmentId].embellishments.push({
      type: '',
      name: '',
    })
    setGarments(newGarments)
  }
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
    <>
      <ReusableModal show={showModal} onClose={() => setShowModal(false)}>
        <>
          <div className='container m-2 p-1'>
            <div className='container-fluid pt-4'>
              <h3 className='fw-bold'>
                <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30' /> Update Order
              </h3>
            </div>

            <div className='card shadow-sm col-lg-12 m-3 mt-1'>
              <div className='card-body p-4'>
                <form onSubmit={handleSubmit}>
                  <CustomerInfo
                    setOrder={setOrder}
                    updateorder={updateorder}
                    customerOptions={customerOptions}
                    handleChange={handleChange}
                    order={order}
                    priorityOptions={priorityOptions}
                  />
                  <GarmentInfo
                    garments={garments}
                    garmentOptions={garmentOptions}
                    setGarments={setGarments}
                    addEmbellishment={addEmbellishment}
                    removeGarment={removeGarment}
                    embellishmentOptions={embellishmentOptions}
                    embellishmentTypeOptions={embellishmentTypeOptions}
                    colorOptions={colorOptions}
                    fabricOptions={fabricOptions}
                    addGarment={addGarment}
                  />
                  {/* <PaymentInfo
                    setOrder={setOrder}
                    updateorder={updateorder}
                    order={order}
                    handleChange={handleChange}
                    paymentOptions={paymentOptions}
                  /> */}
                  <div className='row mb-3'>
                    <div className='d-flex align-items-center my-4'>
                      <div className='flex-grow-1 border-top border-2'></div>
                      <span className='mx-3 fw-bold text-muted'>Payment Info</span>
                      <div className='flex-grow-1 border-top border-2'></div>
                    </div>
                  </div>
                  <div className='row mb-3'>
                    <div className='col-md-6'>
                      {' '}
                      <label htmlFor='DeliveryAddress' className='form-label'>
                        Total Cost:
                      </label>
                      <input
                        id='TotalCost'
                        name='TotalCost'
                        type='text'
                        className='form-control border-success-subtle'
                        value={updateorder?.TotalCost}
                        onChange={handleChange}
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
                        value={
                          paymentOptions.find((opt) => opt.value === updateorder?.PaymentStatus) ||
                          null
                        }
                        onChange={(selected: SingleValue<OptionType>) =>
                          setOrder((prev) => ({...prev, payment: selected?.value || ''}))
                        }
                        placeholder='Select Payment status'
                      />
                    </div>
                  </div>
                  <div className='row mb-3'>
                    <div className='col-md-6'>
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
                          setOrder((prev) => ({...prev, description: e.target.value}))
                        }
                      />
                    </div>
                  </div>
                  <div className='text-end mt-3'>
                    <button type='submit' className='btn btn-outline-success'>
                      update Order
                    </button>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </>
      </ReusableModal>
    </>
  )
}

export default OrderModal
