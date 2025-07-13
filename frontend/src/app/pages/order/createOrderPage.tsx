import React, {useEffect, useState} from 'react'
import {useGarmentHelpers} from '../order/hooks/useGarmentHelpers'
import {
  ThemeModeComponent,
  CustomerInfo,
  GarmentInfo,
  PaymentInfo,
  Toolbar1,
} from '../../components'
import {
  useFetchGarments,
  useFetchCustomers,
  useFetchFabrics,
  useFetchEmbellishments,
  useFetchEmbellishmentTypes,
} from '../order/hooks/useFetchData'
import {useCreateOrder} from './hooks/useCreateOrder'
import {OptionType, Garment, Order, defaultOrder, Customer} from '../../types/commonTypes'
import {priorityOptions, paymentOptions} from './options'
const CreateOrderPage = () => {
  const [order, setOrder] = useState<Order>(defaultOrder)
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

  const {garmentOptions} = useFetchGarments()
  const {customerOptions} = useFetchCustomers()
  const {fabricOptions, allFabrics} = useFetchFabrics()
  const {embellishments, embellishmentOptions} = useFetchEmbellishments()
  const {embellishmentTypeOptions} = useFetchEmbellishmentTypes()
  const {setColor, setFabric, setTypes, colorOptions, allEmbellishmentsOptions} = useGarmentHelpers(
    allFabrics,
    embellishments
  )

  const [themeMode, setThemeMode] = useState<'light' | 'dark' | 'system'>(
    ThemeModeComponent.getMode()
  )
  useEffect(() => {
    const updateTheme = () => setThemeMode(ThemeModeComponent.getMode())
    const interval = setInterval(updateTheme, 1000)
    return () => clearInterval(interval)
  }, [])
  const {handleSubmit} = useCreateOrder(order, garments, () => {
    setOrder(defaultOrder)
    setGarments([])
  })
  const isDark = themeMode === 'dark'
  const addGarment = () => {
    const i = garments.length
    const newGarments = [
      ...garments,
      {
        id: i,
        garment: '',
        color: '',
        fabric: '',
        isEmbellished: false,
        embellishments: [{type: '', name: ''}],
      },
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

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const {name, value} = e.target
    setOrder((prev) => ({...prev, [name]: value}))
  }
  const statusOptions: OptionType[] = [
    {value: '1', label: 'Pending'},
    {value: '2', label: 'Processing'},
    {value: '3', label: 'Completed'},
    {value: '4', label: 'Cancelled'},
  ]
  return (
    <>
      <Toolbar1 />
      <div className='container m-2 p-1'>
        <div className='container-fluid pt-4'>
          <h3 className='fw-bold'>
            <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30' /> Add Order
          </h3>
        </div>

        <div className='card shadow-sm col-lg-8 m-3 mt-1'>
          <div className='card-body p-4'>
            <form onSubmit={handleSubmit}>
              <CustomerInfo
                setOrder={setOrder}
                order={order}
                handleChange={handleChange}
                customerOptions={customerOptions}
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
                embellishments={embellishments}
                allEmbellishmentsOptions={allEmbellishmentsOptions}
                setTypes={setTypes}
                setFabric={setFabric}
                setColor={setColor}
              />
              <PaymentInfo
                setOrder={setOrder}
                order={order}
                handleChange={handleChange}
                paymentOptions={paymentOptions}
              />
            </form>
          </div>
        </div>
      </div>
    </>
  )
}

export default CreateOrderPage
