import {useEffect, useState} from 'react'
import {axios, Swal} from '../../../components'
import {OptionType, Customer, Fabric, Garment, Embellishment} from '../../../types/commonTypes'

export const useFetchGarments = () => {
  const [garmentOptions, setGarmentOptions] = useState<OptionType[]>([])
  const [allGarments, setAllGarments] = useState<Garment[]>([])

  useEffect(() => {
    const fetchGarments = async () => {
      try {
        const response = await axios.get('https://localhost:7016/api/garment')
        if (response.status === 200) {
          setAllGarments(response.data)
          setGarmentOptions(
            response.data.map((garment: any) => ({
              value: garment.garmentId.toString(),
              label: `${garment.name}`,
            }))
          )
        }
      } catch (error) {
        console.error('Error fetching garments:', error)
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: 'Failed to fetch garments.',
        })
      }
    }

    fetchGarments()
  }, [])

  return {garmentOptions, allGarments}
}

export const useFetchCustomers = () => {
  const [customerOptions, setCustomerOptions] = useState<OptionType[]>([])
  const [customers, setCustomers] = useState<Customer[]>([])

  useEffect(() => {
    const fetchCustomers = async () => {
      try {
        const response = await axios.get('https://localhost:7016/api/customer')
        if (response.status === 200) {
          setCustomers(response.data)
          setCustomerOptions(
            response.data.map((customer: Customer) => ({
              value: customer.customerId,
              label: customer.name,
            }))
          )
        }
      } catch (error) {
        console.error('Error fetching customers:', error)
      }
    }

    fetchCustomers()
  }, [])

  return {customers, customerOptions}
}

export const useFetchFabrics = () => {
  const [fabricOptions, setFabricOptions] = useState<OptionType[]>([])
  const [allFabrics, setAllFabrics] = useState<Fabric[]>([])

  useEffect(() => {
    const FabricTypes: string[] = []
    const fetchFabrics = async () => {
      try {
        const response = await axios.get('https://localhost:7016/api/fabric')
        if (response.status === 200) {
          setAllFabrics(response.data)
          const uniqueFabrics = response.data.filter((fabric: Fabric) => {
            if (!FabricTypes.includes(fabric.fabricType)) {
              FabricTypes.push(fabric.fabricType)
              return true
            }
            return false
          })
          setFabricOptions(
            uniqueFabrics.map((fabric: Fabric) => ({
              value: fabric.fabricId.toString(),
              label: fabric.fabricType,
            }))
          )
        }
      } catch (error) {
        console.error('Error fetching fabrics:', error)
      }
    }

    fetchFabrics()
  }, [])

  return {allFabrics, fabricOptions}
}

export const useFetchEmbellishments = () => {
  const [embellishments, setEmbellishments] = useState<Embellishment[]>([])
  const [embellishmentOptions, setEmbellishmentOptions] = useState<OptionType[]>([])

  useEffect(() => {
    const fetchEmbellishments = async () => {
      try {
        const response = await axios.get('https://localhost:7016/api/embellishments')
        if (response.status === 200) {
          setEmbellishments(response.data)
          setEmbellishmentOptions(
            response.data.map((embellishment: Embellishment) => ({
              value: embellishment.embellishmentId,
              label: embellishment.name,
            }))
          )
        }
      } catch (error) {
        console.error('Error fetching embellishments:', error)
      }
    }

    fetchEmbellishments()
  }, [])

  return {embellishments, embellishmentOptions}
}

export const useFetchEmbellishmentTypes = () => {
  const [embellishmentTypeOptions, setEmbellishmentTypeOptions] = useState<OptionType[]>([])

  useEffect(() => {
    const fetchEmbellishmentTypes = async () => {
      try {
        const response = await axios.get('https://localhost:7016/api/embellishmenttype')
        if (response.status === 200) {
          setEmbellishmentTypeOptions(
            response.data.map((type: any) => ({
              value: type.embellishmentTypeId,
              label: type.name,
            }))
          )
        }
      } catch (error) {
        console.error('Error fetching embellishment types:', error)
      }
    }

    fetchEmbellishmentTypes()
  }, [])

  return {embellishmentTypeOptions}
}
