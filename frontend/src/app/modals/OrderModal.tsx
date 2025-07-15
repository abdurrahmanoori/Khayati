import * as React from 'react'
import {useState, useEffect} from 'react'
import {ReusableModal} from './reusableModal'
import {ThemeModeComponent} from '../../_metronic/assets/ts/layout'
import CustomerInfo from '../pages/order/components/customerInfo'
import GarmentInfo from '../pages/order/components/garmentInfo'
import PaymentInfo from '../pages/order/components/paymentInfo'
import {Order, Garment, defaultOrder, OptionType} from '../types/commonTypes'
import {priorityOptions, paymentOptions} from '../pages/order/options'
import {
  useFetchGarments,
  useFetchCustomers,
  useFetchFabrics,
  useFetchEmbellishments,
  useFetchEmbellishmentTypes,
} from '../../app/pages/order/hooks/useFetchData'
import {useGarmentHelpers} from '../pages/order/hooks/useGarmentHelpers'

type Props = {
  showModal: boolean
  setShowModal: Function
  updateorder?: any
}

const OrderModal: React.FC<Props> = ({showModal, setShowModal, updateorder}) => {
  const [order, setOrder] = useState<any>(updateorder ?? {})
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
  const [themeMode, setThemeMode] = useState<'light' | 'dark' | 'system'>(
    ThemeModeComponent.getMode()
  )
  const {setColor, setFabric, setTypes, colorOptions, allEmbellishmentsOptions} = useGarmentHelpers(
    allFabrics,
    embellishments
  )

  useEffect(() => {
    if (updateorder) setOrder(updateorder)
    const interval = setInterval(() => setThemeMode(ThemeModeComponent.getMode()), 1000)
    return () => clearInterval(interval)
  }, [updateorder])

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const {name, value} = e.target
    setOrder((prev: any) => ({...prev, [name]: value}))
  }

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

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    console.log('Order submitted:', order)
  }

  return (
    <ReusableModal show={showModal} onClose={() => setShowModal(false)}>
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
                allEmbellishmentsOptions={allEmbellishmentsOptions}
                colorOptions={colorOptions}
                fabricOptions={fabricOptions}
                addGarment={addGarment}
                order={updateorder}
                setColor={setColor}
                setFabric={setFabric}
                setTypes={setTypes}
              />
              <PaymentInfo
                setOrder={setOrder}
                update
                order={order}
                handleChange={handleChange}
                paymentOptions={paymentOptions}
              />
            </form>
          </div>
        </div>
      </div>
    </ReusableModal>
  )
}

export default OrderModal
