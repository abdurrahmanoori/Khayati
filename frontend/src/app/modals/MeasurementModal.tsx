import React, {useState, useEffect} from 'react'
import {ReusableModal} from './reusableModal'
import CustomFormLayout from '../components/CustomFormLayout'
import {Measurement, Customer, Garment} from '../types/commonTypes'
import GarmentModal from './GarmentModal'
import CustomSelect from '../components/CustomSelect'
import axios from 'axios'
import Swal from 'sweetalert2'
import {Link} from 'react-router-dom'
import {useMeasurementHelper} from '../pages/measurement/hooks/useMeasurementHelper'
import {KTSVG} from '../../_metronic/helpers'

type Props = {
  show: boolean
  setShow: Function
  customer?: Customer
  IsEditable?: boolean
  IsDeletable?: boolean
}

const MeasurementModal: React.FC<Props> = ({
  show,
  setShow,
  customer,
  IsEditable,
  IsDeletable = false,
}) => {
  const [measurement, setMeasurement] = useState({
    CustomerId: customer?.customerId,
    GarmentId: 0,
  })
  const [isEditable, setIsEditable] = useState<boolean>(IsEditable!)
  const [isDeletable, setIsDeletable] = useState<boolean>(IsDeletable)
  const [title, setTitle] = useState<string>('')
  const [showModal, setShowModal] = useState(false)
  const [garmentToDelete, setGarmentToDelete] = useState<number>()
  const [garment, setGarment] = useState<
    {
      garmentId: number
      name: string
      garmentFields: {fieldName: string}[]
    }[]
  >([])
  const {handleDelete, fetchGarments, handleUpdate} = useMeasurementHelper()
  const [tempMeasurement, setTempMeasurement] = useState<
    {gId: number; values: Record<string, string>[]}[]
  >([])
  const [GarmentOptions, setGarmentsOptions] = useState<{value: string; label: string}[]>([
    {value: '', label: 'Select Garment'},
    ...garment.map((g) => ({value: g.garmentId.toString(), label: g.name})),
  ])
  const handleFieldChange = (fields: string[], gId: number) => {
    const matchedMeasurement = customer?.measurements.find((m: any) => m.garmentId === gId)

    const updatedMeasurements = fields.map((field) => {
      const value = matchedMeasurement?.[field] ?? ''
      return {[field]: value}
    })

    // Keep only the current garment's temp measurement
    setTempMeasurement([{gId, values: updatedMeasurements}])
  }

  useEffect(() => {
    if (isEditable) {
      setTitle('Update Measurement')
    } else setTitle('')
    if (show) {
      fetchGarments(setGarment, setGarmentsOptions, customer!)
    }
  }, [show, isEditable, isDeletable])

  return (
    <ReusableModal
      show={show}
      onClose={() => {
        setShow(false)
        setGarment([])
        setTempMeasurement([])
        setIsEditable(false)
        setIsDeletable(false)
        setIsEditable(false)
      }}
    >
      <div className='card shadow-sm col-lg-12 m-3 mt-1'>
        <div className='modal-header justify-content-center'>
          <h5 className='modal-title'>{title}</h5>
        </div>

        <div className='card-body p-4'>
          <div className='row mt-3'>
            <div className='col-md-6 form-check'>
              <input
                type='radio'
                id='editable'
                name='mode'
                className='form-check-input'
                checked={isEditable}
                onChange={() => {
                  setIsEditable(true)
                  setIsDeletable(false)
                }}
              />
              <label htmlFor='editable' className='form-check-label'>
                <KTSVG path='/media/icons/duotune/art/art005.svg' className='svg-icon-3' />
              </label>
            </div>

            <div className='col-md-6 form-check'>
              <input
                type='radio'
                id='deletable'
                name='mode'
                className='form-check-input'
                checked={isDeletable}
                onChange={() => {
                  setIsEditable(false)
                  setIsDeletable(true)
                }}
              />
              <label htmlFor='deletable' className='form-check-label'>
                <KTSVG path='/media/icons/duotune/general/gen027.svg' className='svg-icon-3' />
              </label>
            </div>
          </div>

          <form
            onSubmit={(e) =>
              handleUpdate(e, customer!, tempMeasurement, setMeasurement, setTempMeasurement)
            }
          >
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
                        setGarmentToDelete(selectedGarment.garmentId)
                        handleFieldChange(
                          selectedGarment.garmentFields.map((field) => field.fieldName),
                          selectedGarment.garmentId
                        )
                      }
                    }}
                    options={GarmentOptions}
                  />
                  <Link
                    to=''
                    onClick={() => {
                      !isDeletable ? setShowModal(true) : handleDelete(customer!, garmentToDelete!)
                    }}
                    className='mt-4'
                  >
                    {isDeletable ? 'Delete' : 'Create'}
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
                              disabled={!isEditable}
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
              {isEditable && (
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
