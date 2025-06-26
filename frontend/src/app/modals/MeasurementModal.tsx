import * as React from 'react'
import {useState, useEffect} from 'react'
import {ReusableModal} from './reusableModal'
import CustomFormLayout from '../components/CustomFormLayout'
import {Measurement} from '../types/commonTypes'
type Props = {
  show: boolean
  setShow: Function
  title?: string
  updatemeasurement?: Measurement
}
const MeasurementModal: React.FC<Props> = ({show, setShow, title, updatemeasurement}) => {
  const [measurement, setMeasurement] = useState({
    ArmLength: '',
    Chest: '',
    Height: '',
    Leg: '',
    Neck: '',
    Sleeve: '',
    Waist: '',
    ShoulderWidth: '',
    CustomerId: '',
    trousers: '',
  })
  useEffect(() => {
    if (updatemeasurement) {
      setMeasurement(updatemeasurement)
    }
  }, [updatemeasurement])
  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const {name, value} = e.target
    setMeasurement((prev) => ({
      ...prev,
      [name]: value,
    }))
  }

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    console.log('Measurement submitted:', measurement)
  }

  return (
    <>
      <ReusableModal show={show} onClose={() => setShow(false)}>
        <CustomFormLayout
          title={
            <>
              <i className='fas fa-plus text-dark m-2 mt-1 mb-1' />{' '}
              {title != '' ? title : 'Add Measurement'}
            </>
          }
          onSubmit={handleSubmit}
          submitLabel={title != '' ? 'Save Measurement' : 'Add Measurement'}
          rows={[
            [
              <div key='ArmLength' className='mb-3'>
                <label htmlFor='ArmLength' className='form-label'>
                  Arm Length:
                </label>
                <input
                  type='number'
                  id='ArmLength'
                  name='ArmLength'
                  className='form-control'
                  value={parseInt(measurement.ArmLength)}
                  onChange={handleChange}
                />
              </div>,

              <div key='Chest' className='mb-3'>
                <label htmlFor='Chest' className='form-label'>
                  Chest:
                </label>
                <input
                  type='number'
                  id='Chest'
                  name='Chest'
                  className='form-control'
                  value={parseInt(measurement.Chest)}
                  onChange={handleChange}
                />
              </div>,
            ],
            [
              <div key='Height' className='mb-3'>
                <label htmlFor='Height' className='form-label'>
                  Height:
                </label>
                <input
                  type='number'
                  id='Height'
                  name='Height'
                  className='form-control'
                  value={parseInt(measurement.Height)}
                  onChange={handleChange}
                />
              </div>,

              <div key='Leg' className='mb-3'>
                <label htmlFor='Leg' className='form-label'>
                  Leg:
                </label>
                <input
                  type='number'
                  id='Leg'
                  name='Leg'
                  className='form-control'
                  value={parseInt(measurement.Leg)}
                  onChange={handleChange}
                />
              </div>,
            ],
            [
              <div key='Neck' className='mb-3'>
                <label htmlFor='Neck' className='form-label'>
                  Neck:
                </label>
                <input
                  type='number'
                  id='Neck'
                  name='Neck'
                  className='form-control'
                  value={parseInt(measurement.Neck)}
                  onChange={handleChange}
                />
              </div>,

              <div key='Sleeve' className='mb-3'>
                <label htmlFor='Sleeve' className='form-label'>
                  Sleeve:
                </label>
                <input
                  type='number'
                  id='Sleeve'
                  name='Sleeve'
                  className='form-control'
                  value={parseInt(measurement.Sleeve)}
                  onChange={handleChange}
                />
              </div>,
            ],
            [
              <div key='Waist' className='mb-3'>
                <label htmlFor='Waist' className='form-label'>
                  Waist:
                </label>
                <input
                  type='number'
                  id='Waist'
                  name='Waist'
                  className='form-control'
                  value={parseInt(measurement.Waist)}
                  onChange={handleChange}
                />
              </div>,

              <div key='ShoulderWidth' className='mb-3'>
                <label htmlFor='ShoulderWidth' className='form-label'>
                  Shoulder Width:
                </label>
                <input
                  type='number'
                  id='ShoulderWidth'
                  name='ShoulderWidth'
                  className='form-control'
                  value={parseInt(measurement.ShoulderWidth)}
                  onChange={handleChange}
                />
              </div>,
            ],
            [
              <div key='trousers' className='mb-3 col-md-6'>
                <label htmlFor='trousers' className='form-label'>
                  Trousers:
                </label>
                <input
                  type='number'
                  id='trousers'
                  name='trousers'
                  className='form-control'
                  value={parseInt(measurement.trousers)}
                  onChange={handleChange}
                />
              </div>,
            ],
          ]}
        />
      </ReusableModal>
    </>
  )
}

export default MeasurementModal
