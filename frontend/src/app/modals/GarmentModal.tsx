import * as React from 'react'
import Select from 'react-select'
import {ReusableModal} from './reusableModal'
import CustomMultiSelect from '../components/CustomMultiSelect'

type OptionType = {label: string; value: string}

type Garment = {
  GarmentName: string
  GarmentFields: OptionType[]
  Cost: string
}

type Props = {
  showModal: boolean
  setShowModal: (val: boolean) => void
}

const GarmentModal: React.FC<Props> = ({showModal, setShowModal}) => {
  const [garment, setGarment] = React.useState<Garment>({
    GarmentName: '',
    GarmentFields: [],
    Cost: '',
  })

  const availableFields: OptionType[] = [
    {value: 'Neck', label: 'Neck'},
    {value: 'Chest', label: 'Chest'},
    {value: 'Waist', label: 'Waist'},
    {value: 'Hips', label: 'Hips'},
    {value: 'Shoulder', label: 'Shoulder'},
    {value: 'Sleeve Length', label: 'Sleeve Length'},
    {value: 'Thigh', label: 'Thigh'},
    {value: 'Knee', label: 'Knee'},
    {value: 'Ankle', label: 'Ankle'},
    {value: 'Height', label: 'Height'},
    {value: 'Leg', label: 'Leg'},
  ]

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    console.log({
      garmentName: garment.GarmentName,
      selectedFields: garment.GarmentFields.map((f) => f.value),
      cost: garment.Cost,
    })
    setShowModal(false)
    setGarment({GarmentName: '', GarmentFields: [], Cost: ''})
  }

  return (
    <ReusableModal
      show={showModal}
      onClose={() => {
        setShowModal(false)
        setGarment({GarmentName: '', GarmentFields: [], Cost: ''})
      }}
    >
      <div className='modal-header justify-content-center'>
        <h5 className='modal-title'>Add Garment</h5>
      </div>
      <div className='p-4'>
        <form onSubmit={handleSubmit}>
          <div className='row mb-3'>
            <div className='col-md-6 mb-3'>
              <label htmlFor='garmentName' className='form-label'>
                Garment Name
              </label>
              <input
                type='text'
                className='form-control'
                id='garmentName'
                name='garmentName'
                value={garment.GarmentName}
                onChange={(e) => setGarment((prev) => ({...prev, GarmentName: e.target.value}))}
              />
            </div>
            <div className='col-md-6 mb-3'>
              <label className='form-label'>Fields</label>
              <CustomMultiSelect
                isMulti={true}
                options={availableFields}
                value={garment.GarmentFields}
                onChange={(selected: any) =>
                  setGarment((prev) => ({...prev, GarmentFields: selected as OptionType[]}))
                }
              />
            </div>
          </div>
          <div className='row mb-3'>
            <div className='col-md-6'>
              <label htmlFor='Cost' className='form-label'>
                Cost
              </label>
              <input
                type='text'
                className='form-control'
                id='Cost'
                name='Cost'
                value={garment.Cost}
                onChange={(e) => setGarment((prev) => ({...prev, Cost: e.target.value}))}
              />
            </div>
          </div>
          <button type='submit' className='btn btn-primary'>
            Save
          </button>
        </form>
      </div>
    </ReusableModal>
  )
}

export default GarmentModal
