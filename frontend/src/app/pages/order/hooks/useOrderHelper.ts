import axios from 'axios'
import Swal from 'sweetalert2'
export const useOrderHelper = () => {
  const getStatusBadgeClass = (status: string): string => {
    switch (status) {
      case 'Pending':
        return 'badge-light-warning'
      case 'In Progress':
        return 'badge-light-info'
      case 'Completed':
        return 'badge-light-success'
      case 'Cancelled':
        return 'badge-light-danger'
      default:
        return 'badge-light-secondary'
    }
  }

  const getOrderStatusText = (status: number): string => {
    switch (status) {
      case 1:
        return 'Pending'
      case 2:
        return 'In Progress'
      case 3:
        return 'Completed'
      case 4:
        return 'Cancelled'
      default:
        return 'Unknown'
    }
  }
  const getPaymentStatusText = (status: number): string => {
    switch (status) {
      case 1:
        return 'Paid'
      case 2:
        return 'Partial'
      case 3:
        return 'Unpaid'
      default:
        return 'Unknown'
    }
  }

  const fetchOrders = async (
    setCustomers: Function,
    setOrders: Function,
    setAllOrders: Function
  ) => {
    try {
      const customerResponse = await axios.get('https://localhost:7016/api/customer')
      const orderResponse = await axios.get('https://localhost:7016/api/orders')

      if (customerResponse.status !== 200 || orderResponse.status !== 200) {
        throw new Error('Failed to fetch customers or orders')
      }

      const customers = customerResponse.data
      const orders = orderResponse.data

      // Merge orders with customer info (if needed)
      const uniqueCustomers: any[] = []

      orders.forEach((order: any) => {
        const customer = customers.find((c: any) => c.customerId === order.customerId)
        if (customer && !uniqueCustomers.some((c) => c.customerId === customer.customerId)) {
          uniqueCustomers.push(customer)
        }
      })
      console.log('orders: ', orders)
      setCustomers(uniqueCustomers)
      setOrders(orders)
      setAllOrders(orders)
      // if you want enriched orders
    } catch (error) {
      console.error('Error fetching customers or orders:', error)
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failed to fetch customers or orders. Please try again later.',
      })
    }
  }
  const handleDelete = (OrderId: number, setOrders: Function, orders: any[]) => {
    console.log('OrderId: ', OrderId)
    Swal.fire({
      title: 'Delete',
      text: 'Are you sure you want to delete?',
      icon: 'warning',
      showCancelButton: true,
      showCloseButton: true,
      showConfirmButton: true,
      confirmButtonText: 'Yes, Delete it!',
    }).then(async (result) => {
      if (result.isConfirmed) {
        const reponse = await axios.delete(`https://localhost:7016/api/orders/${OrderId}`)
        console.log('Response of the Delete: ', reponse)
        if (reponse.status == 200) {
          const newOrders = orders.filter((o: any) => o.OrderId != OrderId)
          setOrders(newOrders)
          Swal.fire({
            title: 'Deleted Successfully',
            icon: 'success',
            showConfirmButton: true,
            timer: 2000,
          })
        }
      } else {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: 'Error Deleting Order',
          timer: 2000,
        })
      }
    })
  }
  return {getOrderStatusText, getStatusBadgeClass, getPaymentStatusText, fetchOrders, handleDelete}
}
