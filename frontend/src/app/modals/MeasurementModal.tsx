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
  title?: string
  customer?: Customer
}

const MeasurementModal: React.FC<Props> = ({show, setShow, title, customer}) => {
  const [measurement, setMeasurement] = useState({
    CustomerId: customer?.customerId,
    GarmentId: 0,
  })

  const [showModal, setShowModal] = useState(false)
  const [garment, setGarment] = useState<
    {
      garmentId: number
      name: string
      garmentFields: {fieldName: string}[]
    }[]
  >([])

  const [tempMeasurement, setTempMeasurement] = useState<Record<string, string>[]>([])

  const handleFieldChange = (fields: string[]) => {
    const updatedMeasurements = fields.map((field) => ({[field]: ''}))
    setTempMeasurement(updatedMeasurements)
  }

  const fetchGarments = async () => {
    try {
      const response = await axios.get('https://localhost:7016/api/Garment')
      setGarment(response.data)
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
    if (show) {
      fetchGarments()
    }
  }, [show])

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    const mergedFields = tempMeasurement.reduce((acc, fieldObj) => ({...acc, ...fieldObj}), {})
    const newMeasurement = {
      ...measurement,
      ...mergedFields,
    }

    axios
      .put('https://localhost:7016/api/Measurement', newMeasurement)
      .then(() => {
        Swal.fire({
          icon: 'success',
          title: 'Success',
          text: 'Measurement update successfully!',
        })
        setMeasurement({
          CustomerId: customer?.customerId,
          GarmentId: 0,
        })
        setTempMeasurement([])
      })
      .catch((error) => {
        console.error('Error submitting measurement:', error)
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: 'Failed to update measurement. Please try again later.',
        })
      })

    console.log('Measurement submitted:', newMeasurement)
  }

  const GarmentOptions = [
    {value: '', label: 'Select Garment'},
    ...garment.map((g) => ({value: g.garmentId.toString(), label: g.name})),
  ]

  return (
    <ReusableModal
      show={show}
      onClose={() => {
        setShow(false)
        setGarment([])
        setTempMeasurement([])
      }}
    >
      <div className='card shadow-sm col-lg-12 m-3 mt-1'>
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
                          selectedGarment.garmentFields.map((field) => field.fieldName)
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
                  {tempMeasurement.map((fieldObj, idx) => {
                    const key = Object.keys(fieldObj)[0]
                    return (
                      <div key={key + idx} className='mb-3 col-md-6'>
                        <label htmlFor={key} className='form-label'>
                          {key}:
                        </label>
                        <input
                          type='number'
                          id={key}
                          name={key}
                          className='form-control'
                          value={fieldObj[key]}
                          onChange={(e) =>
                            setTempMeasurement((prev) => {
                              const updated = [...prev]
                              updated[idx] = {[key]: e.target.value}
                              return updated
                            })
                          }
                        />
                      </div>
                    )
                  })}
                </div>
              </>
            )}

            <div className='text-end mt-3'>
              <button type='submit' className='btn btn-outline-success'>
                Submit
              </button>
            </div>
          </form>
        </div>
      </div>

      <GarmentModal showModal={showModal} setShowModal={setShowModal} />
    </ReusableModal>
  )
}

export default MeasurementModal
