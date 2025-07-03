import * as React from 'react'
import {useEffect, useState} from 'react'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import CustomSelect from '../../components/CustomSelect'
import {mockGarments} from './mockGarments'
import GarmentModal from '../../modals/GarmentModal'
import {Link} from 'react-router-dom'
const CreateMeasurementPage = () => {
  const [measurement, setMeasurement] = useState({
    CustomerId: '',
    Garment: '',
  })
  const [showModal, setShowModal] = useState(false)
  const [garment, setGarment] =
    useState<{GarmentId: number; GarmentName: string; GarmentFields: string[]}[]>(mockGarments)
  const [tempMeasurement, setTempMeasurement] = useState<Record<string, string>[]>([])

  const handleFieldChange = (fields: string[]) => {
    const updatedMeasurements = fields.map((field) => ({[field]: ''}))
    setTempMeasurement(updatedMeasurements)
  }

  useEffect(() => {}, [tempMeasurement])
  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    const mergedFields = tempMeasurement.reduce((acc, fieldObj) => ({...acc, ...fieldObj}), {})
    setMeasurement((prev) => ({
      ...prev,
      ...mergedFields,
    }))
    console.log('Measurement submitted:', measurement)
  }

  const GarmentOptions = [
    {value: '', label: 'Select Garment'},
    ...garment.map((g) => ({value: g.GarmentName, label: g.GarmentName})),
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
            <form onSubmit={handleSubmit}>
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
                      [
                        {value: '', label: 'Select Customer'},
                        {value: '1', label: 'John Doe'},
                        {value: '2', label: 'Jane Smith'},
                      ].find((option) => option.value === measurement.CustomerId) || null
                    }
                    onChange={(selected) => {
                      setMeasurement((prev) => ({
                        ...prev,
                        CustomerId: selected ? selected.value : '',
                      }))
                    }}
                    options={[
                      {value: '', label: 'Select Customer'},
                      {value: '1', label: 'John Doe'},
                      {value: '2', label: 'Jane Smith'},
                    ]}
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
                        GarmentOptions.find((option) => option.value === measurement.Garment) ||
                        null
                      }
                      onChange={(selected) => {
                        setMeasurement((prev) => ({
                          ...prev,
                          Garment: selected ? selected.value : '',
                        }))
                        const selectedGarment = garment.find(
                          (g) => g.GarmentName === selected?.value
                        )
                        if (selectedGarment) {
                          handleFieldChange(selectedGarment.GarmentFields)
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
                    Temporary Measurement:
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
