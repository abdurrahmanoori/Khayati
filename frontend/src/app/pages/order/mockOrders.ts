import {Order} from '../../types/commonTypes'

export const mockOrders: Order[] = [
  {
    OrderId: 1,
    OrderDate: '2025-06-25',
    DeliveryDate: '2025-06-30',
    CustomerId: 101,
    OrderStatus: 'Pending',
    PaymentStatus: 'Partial',
    TotalCost: 2500,
    PaidAmount: 500,
    IsEmbellished: true,
    embellishmentType: 'Embroidery',
    embellishment: 'Collar Embroidery',
    orderPriority: 'High',
    garment: 'Shalwar Kameez',
    fabric: 'Cotton',
    color: 'White',
    payment: 'Partial',
    description: 'Urgent wedding order',
  },
  {
    OrderId: 2,
    OrderDate: '2025-06-24',
    DeliveryDate: '2025-06-29',
    CustomerId: 102,
    OrderStatus: 'Completed',
    PaymentStatus: 'Paid',
    TotalCost: 4000,
    PaidAmount: 4000,
    IsEmbellished: false,
    embellishmentType: '',
    embellishment: '',
    orderPriority: 'Normal',
    garment: 'Abaya',
    fabric: 'Silk',
    color: 'Black',
    payment: 'Paid',
    description: 'Simple design',
  },
  {
    OrderId: 3,
    OrderDate: '2025-06-20',
    DeliveryDate: '2025-06-28',
    CustomerId: 103,
    OrderStatus: 'In Progress',
    PaymentStatus: 'Partial',
    TotalCost: 3200,
    PaidAmount: 2000,
    IsEmbellished: true,
    embellishmentType: 'Beads',
    embellishment: 'Front Panel Beads',
    orderPriority: 'High',
    garment: 'Kurta',
    fabric: 'Lawn',
    color: 'Sky Blue',
    payment: 'Partial',
    description: 'Urgent order with beads',
  },
  {
    OrderId: 4,
    OrderDate: '2025-06-18',
    DeliveryDate: '2025-06-26',
    CustomerId: 104,
    OrderStatus: 'Completed',
    PaymentStatus: 'Paid',
    TotalCost: 2800,
    PaidAmount: 2800,
    IsEmbellished: false,
    embellishmentType: '',
    embellishment: '',
    orderPriority: 'Low',
    garment: 'Dress',
    fabric: 'Chiffon',
    color: 'Pink',
    payment: 'Paid',
    description: 'Casual summer dress',
  },
  {
    OrderId: 5,
    OrderDate: '2025-06-15',
    DeliveryDate: '2025-06-25',
    CustomerId: 105,
    OrderStatus: 'Pending',
    PaymentStatus: 'Unpaid',
    TotalCost: 5000,
    PaidAmount: 0,
    IsEmbellished: true,
    embellishmentType: 'Lace',
    embellishment: 'Sleeve Lace',
    orderPriority: 'High',
    garment: 'Sherwani',
    fabric: 'Cotton Silk',
    color: 'Beige',
    payment: 'Unpaid',
    description: 'Sherwani with lace design',
  },
  {
    OrderId: 6,
    OrderDate: '2025-06-10',
    DeliveryDate: '2025-06-20',
    CustomerId: 106,
    OrderStatus: 'In Progress',
    PaymentStatus: 'Partial',
    TotalCost: 1500,
    PaidAmount: 500,
    IsEmbellished: false,
    embellishmentType: '',
    embellishment: '',
    orderPriority: 'Normal',
    garment: 'Scarf',
    fabric: 'Silk',
    color: 'Red',
    payment: 'Partial',
    description: 'Simple silk scarf',
  },
  {
    OrderId: 7,
    OrderDate: '2025-06-08',
    DeliveryDate: '2025-06-18',
    CustomerId: 107,
    OrderStatus: 'Completed',
    PaymentStatus: 'Paid',
    TotalCost: 2200,
    PaidAmount: 2200,
    IsEmbellished: true,
    embellishmentType: 'Buttons',
    embellishment: 'Fancy Buttons',
    orderPriority: 'Normal',
    garment: 'Shirt',
    fabric: 'Cotton',
    color: 'Navy Blue',
    payment: 'Paid',
    description: 'Formal office shirt with buttons',
  },
  {
    OrderId: 8,
    OrderDate: '2025-06-05',
    DeliveryDate: '2025-06-15',
    CustomerId: 108,
    OrderStatus: 'Pending',
    PaymentStatus: 'Partial',
    TotalCost: 6000,
    PaidAmount: 1000,
    IsEmbellished: true,
    embellishmentType: 'Stonework',
    embellishment: 'Neck Stonework',
    orderPriority: 'High',
    garment: 'Gown',
    fabric: 'Net',
    color: 'Emerald Green',
    payment: 'Partial',
    description: 'Evening gown with stonework',
  },
  {
    OrderId: 9,
    OrderDate: '2025-06-03',
    DeliveryDate: '2025-06-12',
    CustomerId: 109,
    OrderStatus: 'In Progress',
    PaymentStatus: 'Partial',
    TotalCost: 3000,
    PaidAmount: 1500,
    IsEmbellished: false,
    embellishmentType: '',
    embellishment: '',
    orderPriority: 'Normal',
    garment: 'Trousers',
    fabric: 'Denim',
    color: 'Black',
    payment: 'Partial',
    description: 'Casual black denim trousers',
  },
  {
    OrderId: 10,
    OrderDate: '2025-06-01',
    DeliveryDate: '2025-06-10',
    CustomerId: 110,
    OrderStatus: 'Completed',
    PaymentStatus: 'Paid',
    TotalCost: 4500,
    PaidAmount: 4500,
    IsEmbellished: true,
    embellishmentType: 'Lace',
    embellishment: 'Bottom Lace',
    orderPriority: 'Low',
    garment: 'Maxi Dress',
    fabric: 'Georgette',
    color: 'Purple',
    payment: 'Paid',
    description: 'Party maxi dress with lace',
  },
]
