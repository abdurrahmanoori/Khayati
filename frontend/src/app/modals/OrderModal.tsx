import * as React from 'react'
import {useState, useEffect} from 'react'
import {ReusableModal} from './reusableModal'
import {ThemeModeComponent} from '../../_metronic/assets/ts/layout'
import CustomerInfo from '../pages/order/components/customerInfo'
import GarmentInfo from '../pages/order/components/garmentInfo'
import PaymentInfo from '../pages/order/components/paymentInfo'
import {Order, Garment, defaultOrder} from '../types/commonTypes'
import {
  customerOptions,
  priorityOptions,
  paymentOptions,
  garmentOptions,
  fabricOptions,
  colorOptions,
  embellishmentTypeOptions,
  embellishmentOptions,
} from '../pages/order/options'

type Props = {
  showModal: boolean
  setShowModal: Function
  updateorder?: Order
}

const OrderModal: React.FC<Props> = ({showModal, setShowModal, updateorder}) => {
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
  const [themeMode, setThemeMode] = useState<'light' | 'dark' | 'system'>(
    ThemeModeComponent.getMode()
  )

  useEffect(() => {
    if (updateorder) setOrder(updateorder)
    const interval = setInterval(() => setThemeMode(ThemeModeComponent.getMode()), 1000)
    return () => clearInterval(interval)
  }, [updateorder])

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const {name, value} = e.target
    setOrder((prev) => ({...prev, [name]: value}))
  }

  const addGarment = () => {
    setGarments((prev) => [
      ...prev,
      {
        id: prev.length,
        garment: '',
        color: '',
        fabric: '',
        isEmbellished: false,
        embellishments: [],
      },
    ])
  }

  const removeGarment = (gId: number) => {
    setGarments((prev) => prev.filter((g) => g.id !== gId))
  }

  const addEmbellishment = (GarmentId: number) => {
    setGarments((prev) => {
      const updated = [...prev]
      updated[GarmentId].embellishments.push({type: '', name: ''})
      return updated
    })
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
                colorOptions={colorOptions}
                fabricOptions={fabricOptions}
                addGarment={addGarment}
                order={order}
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
