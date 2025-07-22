import {useCallback} from 'react'
import {Order, Garment} from '../../../types/commonTypes'
import axios from 'axios'
import Swal from 'sweetalert2'

export const useCreateOrder = (order: Order, garments: Garment[], onSuccess: () => void) => {
  const handleSubmit = useCallback(
    (e: React.FormEvent<HTMLFormElement>) => {
      e.preventDefault()

      const orderData = {
        customerId: order.CustomerId,
        orderDate: new Date().toISOString(),
        expectedCompletionDate: new Date(order.DeliveryDate).toISOString(),
        orderStatus: 'Pending',
        paymentStatus: order.PaymentStatus,
        totalCost: Number(order.TotalCost),
        isPaid: order.PaidAmount === order.TotalCost,
        cost: Number(order.TotalCost),
        orderPriority: order.orderPriority,
        orderGarments: garments.map((g, index) => ({
          GarmentId: Number(g.garment) || 1,
          FabricId: Number(g.fabric) || 1,
          Qurantity: 1,
          IsMainGarment: true,
          ProductionStatus: 'Pending',
          CutDate: new Date().toISOString(),
          ExpectedCompletionDate: new Date(order.DeliveryDate).toISOString(),
          Notes: '',
          FabricCostAtTheTimeOfOrder: 0,
          FabricQuantityUsed: 3,
          OrderGarmentEmbellishments: garments[index].embellishments.map((e: any) => ({
            EmbellishmentId: Number(e.name),
            CustomInstructions: '',
            CostAtTimeOfOrder: Number(e.name),
          })),
        })),
        Payments: [
          {
            amount: Number(order.TotalCost),
            paymentDate: new Date().toISOString(),
          },
        ],
      }
      console.log('Order data: ', orderData)
      axios
        .post('https://localhost:7016/api/orders', orderData)
        .then((response) => {
          if (response.status === 200) {
            Swal.fire({
              icon: 'success',
              title: 'Order Created',
              text: 'Your order has been successfully created.',
              timer: 2000,
            })
            onSuccess()
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
    },
    [order, garments, onSuccess]
  )

  return {handleSubmit}
}
