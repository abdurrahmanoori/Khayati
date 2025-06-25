import * as React from 'react'
import {useState, useEffect} from 'react'
import {ReusableModal} from './reusableModal'
import {SingleValue} from 'react-select'
import {ThemeModeComponent} from '../../_metronic/assets/ts/layout'
import CustomSelect from '../components/CustomSelect'
import {Link} from 'react-router-dom'

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

            <div className='card shadow-sm col-lg-8 m-3 mt-1'>
              <div className='card-body p-4'>
                <form onSubmit={handleSubmit}>
                  <div className='row mb-3'>
                    <div className='d-flex align-items-center my-4'>
                      <div className='flex-grow-1 border-top border-2'></div>
                      <span className='mx-3 fw-bold text-muted'>Customer Info</span>
                      <div className='flex-grow-1 border-top border-2'></div>
                    </div>
                  </div>
                  <div className='row mb-3'>
                    <div className='col-md-6'>
                      {' '}
                      <label htmlFor='Status' className='form-label'>
                        Customer:
                      </label>{' '}
                      <Link to='/customer-create'>Create</Link>
                      <CustomSelect
                        id='CustomerSelect'
                        name='CustomerSelect'
                        options={customerOptions}
                        value={
                          customerOptions.find((opt) => opt.value === updateorder?.CustomerName) ||
                          null
                        }
                        onChange={(selected: SingleValue<OptionType>) =>
                          setOrder((prev) => ({...prev, CustomerName: selected?.value || ''}))
                        }
                        placeholder='Select Customer'
                      />
                    </div>
                    <div className='col-md-6'>
                      {' '}
                      <label htmlFor='OrderDate' className='form-label'>
                        Delivery Date:
                      </label>
                      <input
                        id='OrderDate'
                        name='OrderDate'
                        type='date'
                        className='form-control text-muted fw-bold'
                        value={updateorder?.ExpectedCompletionDate}
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
                        value={
                          priorityOptions.find((opt) => opt.value === order.orderPriority) || null
                        }
                        onChange={(selected: SingleValue<OptionType>) =>
                          setOrder((prev) => ({...prev, orderPriority: selected?.value || ''}))
                        }
                        placeholder='Select Order Priority'
                      />
                    </div>
                  </div>
                  <div className='row mb-3'>
                    <div className='d-flex align-items-center my-4'>
                      <div className='flex-grow-1 border-top border-2'></div>
                      <span className='mx-3 fw-bold text-muted'>Garment Info</span>
                      <div className='flex-grow-1 border-top border-2'></div>
                    </div>
                  </div>
                  {garments.map((g, gIndex) => (
                    <React.Fragment key={gIndex}>
                      <div className='row mb-3'>
                        <div className='col-md-6'>
                          <label className='form-label'>Select Garment:</label>
                          <CustomSelect
                            options={garmentOptions}
                            value={garmentOptions.find((opt) => opt.value === g.garment) || null}
                            onChange={(selected: SingleValue<OptionType>) =>
                              setGarments((prev) => {
                                const updated = [...prev]
                                updated[gIndex].garment = selected?.value || ''
                                return updated
                              })
                            }
                            placeholder='Select Garment'
                          />
                        </div>
                        <div className='col-md-6'>
                          <label className='form-label'>Select Fabric:</label>
                          <CustomSelect
                            options={fabricOptions}
                            value={fabricOptions.find((opt) => opt.value === g.fabric) || null}
                            onChange={(selected: SingleValue<OptionType>) =>
                              setGarments((prev) => {
                                const updated = [...prev]
                                updated[gIndex].fabric = selected?.value || ''
                                return updated
                              })
                            }
                            placeholder='Select Fabric'
                          />
                        </div>
                      </div>

                      <div className='row mb-3'>
                        <div className='col-md-6'>
                          <label className='form-label'>Select Color:</label>
                          <CustomSelect
                            options={colorOptions}
                            value={colorOptions.find((opt) => opt.value === g.color) || null}
                            onChange={(selected: SingleValue<OptionType>) =>
                              setGarments((prev) => {
                                const updated = [...prev]
                                updated[gIndex].color = selected?.value || ''
                                return updated
                              })
                            }
                            placeholder='Select Color'
                          />
                        </div>
                        <div className='col-md-6 mt-8'>
                          <div className='form-check mt-4'>
                            <input
                              type='checkbox'
                              className='form-check-input'
                              id={`isEmbellished-${gIndex}`}
                              checked={g.isEmbellished}
                              onChange={(e) =>
                                setGarments((prev) => {
                                  const updated = [...prev]
                                  updated[gIndex].isEmbellished = e.target.checked
                                  if (!e.target.checked) {
                                    updated[gIndex].embellishments = [{type: '', name: ''}]
                                  }
                                  return updated
                                })
                              }
                            />
                            <label className='form-check-label' htmlFor={`isEmbellished-${gIndex}`}>
                              Is Embellished?
                            </label>
                          </div>
                        </div>
                      </div>

                      {g.isEmbellished && (
                        <>
                          {g.embellishments.map((emb, eIndex) => (
                            <div className='row mb-3' key={eIndex}>
                              <div className='col-md-5'>
                                <label className='form-label'>Embellishment Type:</label>
                                <CustomSelect
                                  options={embellishmentTypeOptions}
                                  value={
                                    embellishmentTypeOptions.find(
                                      (opt) => opt.value === emb.type
                                    ) || null
                                  }
                                  onChange={(selected: SingleValue<OptionType>) =>
                                    setGarments((prev) => {
                                      const updated = [...prev]
                                      updated[gIndex].embellishments[eIndex].type =
                                        selected?.value || ''
                                      return updated
                                    })
                                  }
                                  placeholder='Select Embellishment Type'
                                />
                              </div>
                              <div className='col-md-5'>
                                <label className='form-label'>Embellishment:</label>
                                <CustomSelect
                                  options={embellishmentOptions}
                                  value={
                                    embellishmentOptions.find((opt) => opt.value === emb.name) ||
                                    null
                                  }
                                  onChange={(selected: SingleValue<OptionType>) =>
                                    setGarments((prev) => {
                                      const updated = [...prev]
                                      updated[gIndex].embellishments[eIndex].name =
                                        selected?.value || ''
                                      return updated
                                    })
                                  }
                                  placeholder='Select Embellishment'
                                />
                              </div>
                              {eIndex !== 0 ? (
                                <div className='col-md-2 d-flex align-items-end justify-content-end'>
                                  <button
                                    type='button'
                                    className='btn btn-danger d-flex align-items-center gap-2 px-4 py-2 rounded-pill shadow-sm'
                                    onClick={() =>
                                      setGarments((prev) => {
                                        const updated = [...prev]
                                        updated[gIndex].embellishments.splice(eIndex, 1)
                                        return updated
                                      })
                                    }
                                  >
                                    -
                                  </button>
                                </div>
                              ) : (
                                ''
                              )}
                            </div>
                          ))}

                          <div className='row mb-3'>
                            <div className='col-md-12 d-flex justify-content-end'>
                              <button
                                type='button'
                                className='btn btn-success d-flex align-items-center gap-2 px-4 py-2 rounded-pill shadow-sm'
                                onClick={() => addEmbellishment(gIndex)}
                              >
                                +
                              </button>
                            </div>
                          </div>
                        </>
                      )}
                      {gIndex !== 0 ? (
                        <div className='row mb-3'>
                          <div className='col-md-6'>
                            <div
                              className='btn btn-outline-danger text-end'
                              onClick={() => removeGarment(g.id)}
                            >
                              Remove
                            </div>
                          </div>
                        </div>
                      ) : (
                        ''
                      )}
                      <div className='row'>
                        <div className='col'>
                          <hr
                            className='border-top border-3'
                            style={{borderColor: 'var(--kt-border-dashed-color)'}}
                          />
                        </div>
                      </div>
                    </React.Fragment>
                  ))}
                  <div className='row mb-3'>
                    <div className='col-md-6'>
                      <div className='btn btn-outline-success text-start' onClick={addGarment}>
                        Add
                      </div>
                    </div>
                  </div>
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
                        id='DeliveryAddress'
                        name='DeliveryAddress'
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
