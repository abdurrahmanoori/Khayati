import axios from 'axios'
import Swal from 'sweetalert2'
export const useCreateMeasurement = () => {
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
  return {handleSubmit}
}
