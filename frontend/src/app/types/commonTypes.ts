export type OptionType = {value: string; label: string}

export type Embellishment = {type: string; name: string}

export type Garment = {
  id: number
  garment: string
  fabric: string
  color: string
  isEmbellished: boolean
  embellishments: Embellishment[]
}

export type Order = {
  OrderId: number
  OrderDate: string
  DeliveryDate: string
  CustomerName: string
  OrderStatus: string
  PaymentStatus: string
  TotalCost: number
  PaidAmount: number
  IsEmbellished: boolean
  embellishmentType: string
  embellishment: string
  orderPriority: string
  garment: string
  fabric: string
  color: string
  payment: string
  description: string
}
export const defaultOrder: Order = {
  OrderId: 0,
  OrderDate: '',
  DeliveryDate: '',
  CustomerName: '',
  OrderStatus: '',
  PaymentStatus: '',
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
}
export type Customer = {
  Id: number
  Name: string
  Address: string
  EmailAddress: string
  NationalID: string
  DateOfBirth: string
  PhoneNumber: string
}

export type Measurement = {
  ArmLength: string
  Chest: string
  Height: string
  Leg: string
  Neck: string
  Sleeve: string
  Waist: string
  ShoulderWidth: string
  CustomerId: string
  trousers: string
}
