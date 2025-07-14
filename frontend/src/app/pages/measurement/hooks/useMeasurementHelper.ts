import axios from 'axios'
import Swal from 'sweetalert2'
import {Customer} from '../../../types/commonTypes'
export const useMeasurementHelper = () => {
  const handleSubmit = (
    e: React.FormEvent<HTMLFormElement>,
    measurement: {CustomerId: number; GarmentId: number},
    tempMeasurement: Record<string, string>[],
    setTempMeasurement: React.Dispatch<React.SetStateAction<Record<string, string>[]>>,
    setMeasurement: React.Dispatch<React.SetStateAction<{CustomerId: number; GarmentId: number}>>
  ) => {
    e.preventDefault()
    const mergedFields = tempMeasurement.reduce((acc, fieldObj) => ({...acc, ...fieldObj}), {})
    const newMeasurement = {
      ...measurement,
      ...mergedFields,
    }
    const reponse = axios.post('https://localhost:7016/api/Measurement', newMeasurement)
    reponse
      .then((res) => {
        Swal.fire({
          icon: 'success',
          title: 'Success',
          text: 'Measurement added successfully!',
        })
        setTempMeasurement([])
        setMeasurement({CustomerId: 0, GarmentId: 0})
      })

      .catch((error) => {
        console.error('Error submitting measurement:', error)
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: 'Failed to add measurement. Please try again later.',
        })
      })
    // Reset the form after submission
    setMeasurement(newMeasurement)
    console.log('Measurement submitted:', newMeasurement)
  }
  const handleDelete = (customer: Customer, garmentId: number) => {
    const MeasurementToDelete: any = customer?.measurements?.find(
      (m: any) => m.garmentId === garmentId
    )
    if (MeasurementToDelete) {
      Swal.fire({
        title: 'Delete!',
        text: 'Are you sure you want to Delete?',
        showCancelButton: true,
        showConfirmButton: true,
        confirmButtonText: 'Yes, Delete it!',
        icon: 'warning',
      }).then(async (result) => {
        if (result.isConfirmed) {
          const response = await axios.delete(
            `https://localhost:7016/api/Measurement/${MeasurementToDelete.measurementId}`
          )
          if (response.status == 200) {
            Swal.fire({
              title: 'Deleted!',
              text: 'Successfully Deleted!',
              timer: 2000,
              icon: 'success',
              showConfirmButton: true,
            })
          } else {
            Swal.fire({
              title: 'Error',
              text: 'Error while deleting measurement',
              icon: 'error',
              timer: 2000,
              showConfirmButton: true,
            })
          }
        }
      })
    }
  }
  const fetchGarments = async (
    setGarment: Function,
    setGarmentsOptions: Function,
    customer: Customer
  ) => {
    try {
      const response = await axios.get('https://localhost:7016/api/Garment')
      const filteredGarment = response.data.filter((g: any) => {
        return customer?.measurements?.some((m: any) => {
          return m.garmentId === g.garmentId
        })
      })
      setGarment(filteredGarment)
      setGarmentsOptions([
        {value: '', label: 'Select Garment'},
        ...filteredGarment.map((g: any) => ({value: g.garmentId.toString(), label: g.name})),
      ])
    } catch (error) {
      console.error('Error fetching garments:', error)
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failed to fetch garments. Please try again later.',
      })
    }
  }

  const handleUpdate = (
    e: React.FormEvent<HTMLFormElement>,
    customer: Customer,
    tempMeasurement: any,
    setMeasurement: Function,
    setTempMeasurement: Function
  ) => {
    e.preventDefault()
    const Measurements = customer?.measurements
    const updatedMeasurements = Measurements?.map((m: any) => {
      // Find matching tempMeasurement by garment ID
      const match = tempMeasurement.find((t: any) => t.gId === m.garmentId)

      if (!match) return m // No updates for this garment

      // Merge all fields in match.values into a single object
      const mergedFields = match.values.reduce(
        (acc: any, fieldObj: any) => ({...acc, ...fieldObj}),
        {}
      )

      return {
        ...m,
        ...mergedFields,
      }
    })
    if (updatedMeasurements && updatedMeasurements.length > 0) {
      Promise.all(
        updatedMeasurements.map((m) => {
          console.log('measurementID:', m.measurementId, 'measurement:', m)
          axios.put(`https://localhost:7016/api/Measurement/${m.measurementId}`, m)
        })
      )
        .then(() => {
          Swal.fire({
            icon: 'success',
            title: 'Success',
            text: 'All measurements updated successfully!',
          })
          setMeasurement({
            CustomerId: customer?.customerId,
            GarmentId: 0,
          })
          setTempMeasurement([])
        })
        .catch((error) => {
          console.error('Error submitting measurements:', error)
          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Failed to update one or more measurements. Please try again later.',
          })
        })
    } else {
      Swal.fire({
        icon: 'warning',
        title: 'No Measurements',
        text: 'No measurements to update.',
      })
    }

    console.log('Updated Measurement submitted:', updatedMeasurements)
  }
  return {handleSubmit, handleDelete, fetchGarments, handleUpdate}
}
