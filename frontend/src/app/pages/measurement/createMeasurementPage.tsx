import * as React from 'react'
import {useState} from 'react'
import CustomFormLayout from '../../components/CustomFormLayout'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import CustomSelect from '../../components/CustomSelect'
const CreateMeasurementPage = () => {
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
    Garment: '',
  })

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
      <Toolbar1 />
      <CustomFormLayout
        title={
          <>
            <i className='fas fa-plus text-dark m-2 mt-1 mb-1' /> Add Measurement
          </>
        }
        onSubmit={handleSubmit}
        submitLabel='Save Measurement'
        rows={[
          [
            <div key='CustomerId' className='mb-3'>
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
            </div>,
            <div key='Garment' className='mb-3'>
              <label htmlFor='Garment' className='form-label'>
                Garment:
              </label>
              <CustomSelect
                id='Garment'
                name='Garment'
                className='form-control'
                value={
                  [
                    {value: '', label: 'Select Garment'},
                    {value: 'shirt', label: 'Shirt'},
                    {value: 'trousers', label: 'Trousers'},
                  ].find((option) => option.value === measurement.Garment) || null
                }
                onChange={(selected) => {
                  setMeasurement((prev) => ({
                    ...prev,
                    Garment: selected ? selected.value : '',
                  }))
                }}
                options={[
                  {value: '', label: 'Select Garment'},
                  {value: 'shirt', label: 'Shirt'},
                  {value: 'trousers', label: 'Trousers'},
                ]}
              />
            </div>,
          ],
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
                value={measurement.ArmLength}
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
                value={measurement.Chest}
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
                value={measurement.Height}
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
                value={measurement.Leg}
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
                value={measurement.Neck}
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
                value={measurement.Sleeve}
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
                value={measurement.Waist}
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
                value={measurement.ShoulderWidth}
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
                value={measurement.trousers}
                onChange={handleChange}
              />
            </div>,
          ],
        ]}
      />
    </>
  )
}

export default CreateMeasurementPage
