import {useEffect, useState} from 'react'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import CustomSelect from '../../components/CustomSelect'
import GarmentModal from '../../modals/GarmentModal'
import {Link} from 'react-router-dom'
import axios from 'axios'
import Swal from 'sweetalert2'
import {useCreateMeasurement} from './hooks/useCreateMeasurement'
const CreateMeasurementPage = () => {
  const [measurement, setMeasurement] = useState({
    CustomerId: 0,
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
  const [customerOptions, setCustomerOptions] = useState<{value: string; label: string}[]>([])

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
  const fetchCustomers = async () => {
    try {
      const response = await axios.get('https://localhost:7016/api/Customer')
      const customerOptions = response.data.map((customer: any) => ({
        value: customer?.customerId.toString(),
        label: customer?.name,
      }))
      setCustomerOptions(customerOptions)
    } catch (error) {
      console.error('Error fetching customers:', error)
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failed to fetch customers. Please try again later.',
      })
    }
  }
  useEffect(() => {
    fetchCustomers()
    fetchGarments()
  }, [tempMeasurement])
  const {handleSubmit} = useCreateMeasurement()
  const GarmentOptions = [
    {value: '', label: 'Select Garment'},
    ...garment.map((g) => ({value: g.garmentId.toString(), label: g.name})),
  ]
  return (
    <>
      <Toolbar1 />
      <div className='container m-2 p-1'>
        <div className='container-fluid pt-4'>
          <h3 className='fw-bold'>
            <i className='fas fa-plus text-dark m-2 mt-1 mb-1' /> Add Measurement
          </h3>
        </div>

        <div className='card shadow-sm col-lg-8 m-3 mt-1'>
          <div className='card-body p-4'>
            <form
              onSubmit={(e) =>
                handleSubmit(e, measurement, tempMeasurement, setTempMeasurement, setMeasurement)
              }
            >
              <div className='row mb-3'>
                <div className='col-md-5'>
                  <label htmlFor='CustomerId' className='form-label'>
                    Customer:
                  </label>
                  <CustomSelect
                    id='CustomerId'
                    name='CustomerId'
                    className='form-control'
                    value={
                      customerOptions.find(
                        (option) => option.value === measurement.CustomerId.toString()
                      ) || null
                    }
                    onChange={(selected) => {
                      setMeasurement((prev) => ({
                        ...prev,
                        CustomerId: selected ? Number(selected.value) : 0,
                      }))
                    }}
                    options={customerOptions}
                  />
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
              {tempMeasurement.length > 0 ? (
                <div className='row mb-3 mt-3'>
                  <label htmlFor='TempMeasurement' className='form-label'>
                    Measurement:
                  </label>
                </div>
              ) : (
                ''
              )}
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

              <div className='text-end mt-3'>
                <button type='submit' className='btn btn-outline-success'>
                  Submit
                </button>
              </div>
            </form>
          </div>
        </div>
        <GarmentModal showModal={showModal} setShowModal={setShowModal} />
      </div>
    </>
  )
}

export default CreateMeasurementPage
