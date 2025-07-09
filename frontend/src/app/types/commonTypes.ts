export type OptionType = {value: string; label: string}

export type Garment = {
  id: number
  garment: string
  fabric: string
  color: string
  isEmbellished: boolean
  embellishments: {type: string; name: string}[]
}
export type OrderDesign = {
  DesignId: number
  FabricId: number
  CustomerId: number
  OrderId: number
  Details: string
  MeasurementId: number
  EmbellishmentId: number
}
export type EmbellishmentType = {
  embellishmentTypeId: number
  name: string
  sortOrder: number
  description: string
}

export type Embellishment = {
  embellishmentId: number
  name: string
  embellishmentType: EmbellishmentType
  description: string
  embellishmentTypeId: number
  cost: number
}
export type Fabric = {
  fabricId: number
  fabricType: string
  color: string
  requiredMeters: number
  pattern: string
  thickness: number
  durability: string
  costPerMeter: number
}

export type Order = {
  OrderId: number
  OrderDate: string
  DeliveryDate: string
  CustomerId: number
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
  CustomerId: 0,
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
  customerId: number
  name: string
  lastName: string
  address: string
  emailAddress: string
  nationalID: string
  dateOfBirth: string
  phoneNumber: string
  customerType: string | null
  customerSince: string
  measurements: []
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
