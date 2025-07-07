import React, {useEffect, useState} from 'react'
import {ThemeModeComponent} from '../../../_metronic/assets/ts/layout'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import axios from 'axios'
import CustomerInfo from './components/customerInfo'
import GarmentInfo from './components/garmentInfo'
import PaymentInfo from './components/paymentInfo'
import Swal from 'sweetalert2'
import {
  OptionType,
  Garment,
  Order,
  defaultOrder,
  Customer,
  Embellishment,
} from '../../types/commonTypes'
import {
  priorityOptions,
  paymentOptions,
  garmentOptions,
  fabricOptions,
  colorOptions,
} from './options'
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
  const [embellishments, setEmbellishments] = useState<Embellishment[]>([])
  const [customerOptions, setCustomerOptions] = useState<OptionType[]>([])
  const [Customers, setCustomers] = useState<Customer[]>([])
  const [embellishmentOptions, setEmbellishmentOptions] = useState<OptionType[]>([])
  const [allEmbellishmentsOptions, setAllEmbellishmentsOptions] = useState<OptionType[][][]>([])
  const [embellishmentTypeOptions, setEmbellishmentTypeOptions] = useState<OptionType[]>([])
  const fetchCustomers = async () => {
    try {
      const response = await axios.get('https://localhost:7016/api/customer')
      if (response.status === 200) {
        setCustomers(response.data)
        const options = response.data.map((customer: Customer) => ({
          value: customer.customerId,
          label: `${customer.name}`,
        }))
        setCustomerOptions(options)
      }
    } catch (error) {
      console.error('Error fetching customers:', error)
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failed to fetch customers. Please try again later.',
      })
    }
  }
  const setTypes = (type: string, gindex?: number, eIndex?: number) => {
    const filteredEmbellishments: Embellishment[] = embellishments.filter(
      (embellishment) => embellishment.embellishmentTypeId === Number(type)
    )

    if (gindex !== undefined && eIndex !== undefined) {
      const newList = [...allEmbellishmentsOptions]

      // Initialize inner array if it doesn't exist
      if (!newList[gindex]) {
        newList[gindex] = []
      }

      newList[gindex][eIndex] = filteredEmbellishments.map((embellishment: any) => ({
        value: embellishment.embellishmentId,
        label: `${embellishment.name}`,
      }))

      setAllEmbellishmentsOptions(newList)
    }

    console.log(
      'Filtered Embellishments:',
      filteredEmbellishments,
      'Type:',
      type,
      'gIndex:',
      gindex,
      'All Embellishments:',
      allEmbellishmentsOptions
    )
  }

  const fetchEmbellishments = async () => {
    try {
      const response = await axios.get('https://localhost:7016/api/embellishments')
      if (response.status === 200) {
        setEmbellishments(response.data)
        setEmbellishmentOptions(
          response.data.map((embellishment: any) => ({
            value: embellishment.embellishmentId,
            label: `${embellishment.name}`,
          }))
        )
      }
    } catch (error) {
      console.error('Error fetching embellishments:', error)
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failed to fetch embellishments. Please try again later.',
      })
    }
  }
  const fetchEmbellishmentTypes = async () => {
    try {
      const response = await axios.get('https://localhost:7016/api/embellishmenttype')
      if (response.status === 200) {
        setEmbellishmentTypeOptions(
          response.data.map((type: any) => ({
            value: type.embellishmentTypeId,
            label: `${type.name}`,
          }))
        )
      }
    } catch (error) {
      console.error('Error fetching embellishment types:', error)
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failed to fetch embellishment types. Please try again later.',
      })
    }
  }
  const [themeMode, setThemeMode] = useState<'light' | 'dark' | 'system'>(
    ThemeModeComponent.getMode()
  )
  useEffect(() => {
    fetchCustomers()
    fetchEmbellishments()
    fetchEmbellishmentTypes()
    const updateTheme = () => setThemeMode(ThemeModeComponent.getMode())
    const interval = setInterval(updateTheme, 1000)
    return () => clearInterval(interval)
  }, [])

  const isDark = themeMode === 'dark'
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
  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    const orderData = {
      customerId: order.CustomerId,
      orderDate: new Date().toISOString(),
      expectedCompletionDate: order.DeliveryDate,
      orderStatus: order.OrderStatus,
      paymentStatus: order.PaymentStatus,
      totalCost: Number(order.TotalCost),
      isPaid: order.PaidAmount === order.TotalCost,
      cost: Number(order.TotalCost),
      orderPriority: order.orderPriority,
      orderDesigns: garments.map((g) => ({
        DesignId: g.id,
        FabricId: g.fabric,
        CustomerId: order.CustomerId,
        Details: g.garment,
        MeasurementId: 0, // Assuming MeasurementId is not used here
        EmbellishmentId: g.isEmbellished ? g.embellishments[0] : null, // Assuming only one embellishment per garment
      })),
      note: order.description,
      Payments: [{amount: Number(order.TotalCost), paymentDate: new Date().toISOString()}],
    }
    axios
      .post('https://localhost:7016/api/orders', orderData)
      .then((response) => {
        if (response.status === 200) {
          Swal.fire({
            icon: 'success',
            title: 'Order Created',
            text: 'Your order has been successfully created.',
          })
          setOrder(defaultOrder)
          setGarments([
            {
              id: 0,
              garment: '',
              color: '',
              fabric: '',
              isEmbellished: false,
              embellishments: [{type: '', name: ''}],
            },
          ])
        }
      })
      .catch((error) => {
        console.error('Error creating order:', error)
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: 'Failed to create order. Please try again later.',
        })
      })

    console.log('obj:', orderData)
  }
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
                order={order}
                embellishments={embellishments}
                allEmbellishmentsOptions={allEmbellishmentsOptions}
                setTypes={setTypes}
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
