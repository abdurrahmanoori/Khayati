import * as React from 'react'
import {useState} from 'react'

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
    <React.Fragment>
      <div className='container m-2 p-1'>
        <div className='container-fluid pt-4 '>
          <h3 className='fw-bold'>
            <i className='fas fa-plus text-dark m-2 mt-1 mb-1'></i> Add Measurement
          </h3>
        </div>
      </div>
      <div className='card shadow-sm col-lg-8 m-3 mt-1'>
        <div className='card-body p-4'>
          <form onSubmit={handleSubmit}>
            <div className='row'>
              <div className='col-md-6 mb-3'>
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
              </div>
              <div className='col-md-6 mb-3'>
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
              </div>
            </div>

            <div className='row'>
              <div className='col-md-6 mb-3'>
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
              </div>
              <div className='col-md-6 mb-3'>
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
              </div>
            </div>

            <div className='row'>
              <div className='col-md-6 mb-3'>
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
              </div>
              <div className='col-md-6 mb-3'>
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
              </div>
            </div>

            <div className='row'>
              <div className='col-md-6 mb-3'>
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
              </div>
              <div className='col-md-6 mb-3'>
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
              </div>
            </div>

            <div className='row'>
              <div className='col-md-6 mb-3'>
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
              </div>
            </div>

            <div className='text-end mt-3'>
              <button type='submit' className='btn btn-outline-success'>
                <i className='fas fa-plus text-dark m-2 mt-1 mb-1'></i> Save Measurement
              </button>
            </div>
          </form>
        </div>
      </div>
    </React.Fragment>
  )
}

export default CreateMeasurementPage
