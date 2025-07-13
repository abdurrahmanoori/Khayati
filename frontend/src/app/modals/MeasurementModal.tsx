import React, {useState, useEffect} from 'react'
import {ReusableModal} from './reusableModal'
import CustomFormLayout from '../components/CustomFormLayout'
import {Measurement, Customer, Garment} from '../types/commonTypes'
import GarmentModal from './GarmentModal'
import CustomSelect from '../components/CustomSelect'
import axios from 'axios'
import Swal from 'sweetalert2'
import {Link} from 'react-router-dom'

type Props = {
  show: boolean
  setShow: Function
  customer?: Customer
  IsEditable?: boolean
}

const MeasurementModal: React.FC<Props> = ({show, setShow, customer, IsEditable}) => {
  const [measurement, setMeasurement] = useState({
    CustomerId: customer?.customerId,
    GarmentId: 0,
  })
  const [isEditable, setIsEditable] = useState<boolean>(IsEditable!)
  const [title, setTitle] = useState<string>('')
  const [showModal, setShowModal] = useState(false)
  const [garment, setGarment] = useState<
    {
      garmentId: number
      name: string
      garmentFields: {fieldName: string}[]
    }[]
  >([])

  const [tempMeasurement, setTempMeasurement] = useState<
    {gId: number; values: Record<string, string>[]}[]
  >([])
  const [GarmentOptions, setGarmentsOptions] = useState<{value: string; label: string}[]>([
    {value: '', label: 'Select Garment'},
    ...garment.map((g) => ({value: g.garmentId.toString(), label: g.name})),
  ])
  // const handleFieldChange = (fields: string[], gId: number) => {
  //   const matchedMeasurement = customer?.measurements.find((m: any) => m.garmentId === gId)

  //   const updatedMeasurements = fields.map((field) => {
  //     console.log('Field name:', field, 'value:', matchedMeasurement?.[field])
  //     const value = matchedMeasurement?.[field] ?? ''
  //     return {[field]: value}
  //   })

  //   setTempMeasurement((prev) => {
  //     const existing = prev.find((entry) => entry.gId === gId)

  //     if (existing) {
  //       // Update existing
  //       return prev.map((entry) =>
  //         entry.gId === gId ? {...entry, values: updatedMeasurements} : entry
  //       )
  //     } else {
  //       // Add new entry
  //       return [...prev, {gId, values: updatedMeasurements}]
  //     }
  //   })
  // }
  const handleFieldChange = (fields: string[], gId: number) => {
    const matchedMeasurement = customer?.measurements.find((m: any) => m.garmentId === gId)

    const updatedMeasurements = fields.map((field) => {
      const value = matchedMeasurement?.[field] ?? ''
      return {[field]: value}
    })

    // Keep only the current garment's temp measurement
    setTempMeasurement([{gId, values: updatedMeasurements}])
  }

  const fetchGarments = async () => {
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

  useEffect(() => {
    if (IsEditable) {
      setTitle('Update Measurement')
    } else setTitle('')
    if (show) {
      fetchGarments()
    }
  }, [show, isEditable])

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    const Measurements = customer?.measurements
    const updatedMeasurements = Measurements?.map((m: any) => {
      // Find matching tempMeasurement by garment ID
      const match = tempMeasurement.find((t) => t.gId === m.garmentId)

      if (!match) return m // No updates for this garment

      // Merge all fields in match.values into a single object
      const mergedFields = match.values.reduce((acc, fieldObj) => ({...acc, ...fieldObj}), {})

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

  return (
    <ReusableModal
      show={show}
      onClose={() => {
        setShow(false)
        setGarment([])
        setTempMeasurement([])
        setIsEditable(false)
      }}
    >
      <div className='card shadow-sm col-lg-12 m-3 mt-1'>
        <div className='modal-header justify-content-center'>
          <h5 className='modal-title'>{title}</h5>
        </div>
        <div className='card-body p-4'>
          <form onSubmit={handleSubmit}>
            <div className='row mb-3'>
              <div className='col-md-5'>
                <label htmlFor='CustomerName' className='form-label'>
                  Customer:
                </label>
                <input type='text' className='form-control' value={customer?.name} disabled />
              </div>

              <div className='col-md-5'>
                <label htmlFor='Garment' className='form-label'>
                  Garment:
                </label>

                <div className='d-flex gap-2'>
                  <CustomSelect
                    id='Garment'
                    name='Garment'
                    className='form-control'
                    value={
                      GarmentOptions.find(
                        (option) => option.value === measurement.GarmentId.toString()
                      ) || null
                    }
                    onChange={(selected) => {
                      setMeasurement((prev) => ({
                        ...prev,
                        GarmentId: selected ? Number(selected.value) : 0,
                      }))
                      const selectedGarment = garment.find(
                        (g) => g.garmentId.toString() === selected?.value
                      )
                      if (selectedGarment) {
                        handleFieldChange(
                          selectedGarment.garmentFields.map((field) => field.fieldName),
                          selectedGarment.garmentId
                        )
                      }
                    }}
                    options={GarmentOptions}
                  />
                  <Link to='' onClick={() => setShowModal(true)} className='mt-4'>
                    create
                  </Link>
                </div>
              </div>
            </div>

            {tempMeasurement.length > 0 && (
              <>
                <div className='row mb-3 mt-3'>
                  <label htmlFor='TempMeasurement' className='form-label'>
                    Measurement Fields:
                  </label>
                </div>

                <div className='row'>
                  {tempMeasurement.map((measurement, idx) => (
                    <React.Fragment key={measurement.gId}>
                      {measurement.values.map((fieldObj, fieldIdx) => {
                        const key = Object.keys(fieldObj)[0]
                        const value = fieldObj[key]

                        return (
                          <div key={`${measurement.gId}-${key}`} className='mb-3 col-md-6'>
                            <label htmlFor={`${measurement.gId}-${key}`} className='form-label'>
                              {key}:
                            </label>
                            <input
                              type='number'
                              id={`${measurement.gId}-${key}`}
                              name={key}
                              className='form-control'
                              value={value}
                              disabled={!IsEditable}
                              onChange={(e) => {
                                const updatedValue = e.target.value

                                setTempMeasurement((prev) => {
                                  const updated = [...prev]
                                  updated[idx] = {
                                    ...updated[idx],
                                    values: updated[idx].values.map((fObj, i) => {
                                      if (i === fieldIdx) {
                                        return {[key]: updatedValue}
                                      }
                                      return fObj
                                    }),
                                  }
                                  return updated
                                })
                              }}
                            />
                          </div>
                        )
                      })}
                    </React.Fragment>
                  ))}
                </div>
              </>
            )}

            <div className='text-end mt-3'>
              {IsEditable && (
                <button type='submit' className='btn btn-outline-success'>
                  Submit
                </button>
              )}
            </div>
          </form>
        </div>
      </div>

      <GarmentModal showModal={showModal} setShowModal={setShowModal} />
    </ReusableModal>
  )
}

export default MeasurementModal
