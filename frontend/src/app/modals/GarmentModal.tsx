import * as React from 'react'
import Select from 'react-select'
import {ReusableModal} from './reusableModal'
import CustomMultiSelect from '../components/CustomMultiSelect'
import axios from 'axios'
import Swal from 'sweetalert2'
type OptionType = {label: string; value: string}

type Garment = {
  Name: string
  GarmentFields: {fieldName: string}[]
  Cost: number
}

type Props = {
  showModal: boolean
  setShowModal: (val: boolean) => void
}

const GarmentModal: React.FC<Props> = ({showModal, setShowModal}) => {
  const [garment, setGarment] = React.useState<Garment>({
    Name: '',
    GarmentFields: [],
    Cost: 0,
  })

  const availableFields: OptionType[] = [
    {value: 'Height', label: 'Height'},
    {value: 'Chest', label: 'Chest'},
    {value: 'Waist', label: 'Waist'},
    {value: 'Leg', label: 'Leg'},
    {value: 'Trousers', label: 'Trousers'},
    {value: 'Neck', label: 'Neck'},
    {value: 'Sleeve', label: 'Sleeve'},
    {value: 'ShoulderWidth', label: 'Shoulder Width'},
    {value: 'ArmLength', label: 'Arm Length'},
    {value: 'Hip', label: 'Hip'},
    {value: 'Inseam', label: 'Inseam'},
    {value: 'Thigh', label: 'Thigh'},
    {value: 'Knee', label: 'Knee'},
    {value: 'Bicep', label: 'Bicep'},
    {value: 'Wrist', label: 'Wrist'},
    {value: 'Ankle', label: 'Ankle'},
    {value: 'Bust', label: 'Bust'},
    {value: 'UnderBust', label: 'Under Bust'},
    {value: 'BackWidth', label: 'Back Width'},
    {value: 'FrontLength', label: 'Front Length'},
    {value: 'TorsoLength', label: 'Torso Length'},
    {value: 'SkirtLength', label: 'Skirt Length'},
    {value: 'ShoulderToBust', label: 'Shoulder to Bust'},
    {value: 'ShoulderToWaist', label: 'Shoulder to Waist'},
    {value: 'WaistToHip', label: 'Waist to Hip'},
    {value: 'WaistToFloor', label: 'Waist to Floor'},
    {value: 'Armhole', label: 'Armhole'},
    {value: 'Calf', label: 'Calf'},
    {value: 'NeckToWaist', label: 'Neck to Waist'},
  ]

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    console.log({
      garmentName: garment.Name,
      selectedFields: garment.GarmentFields.map((f) => f.fieldName),
      cost: garment.Cost,
    })
    const response = await axios.post('https://localhost:7016/api/Garment', garment)
    if (response.status === 200) {
      console.log('Garment added successfully:', response.data)
      Swal.fire({
        icon: 'success',
        title: 'Garment Added',
        text: 'The garment has been added successfully.',
      })
      setShowModal(false)
      setGarment({Name: '', GarmentFields: [], Cost: 0})
    } else {
      console.error('Failed to add garment:', response.data)
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failed to add garment. Please try again later.',
      })
    }
  }

  return (
    <ReusableModal
      show={showModal}
      onClose={() => {
        setShowModal(false)
        setGarment({Name: '', GarmentFields: [], Cost: 0})
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
                value={garment.Name}
                onChange={(e) => setGarment((prev) => ({...prev, Name: e.target.value}))}
              />
            </div>
            <div className='col-md-6 mb-3'>
              <label className='form-label'>Fields</label>
              <CustomMultiSelect
                isMulti={true}
                options={availableFields}
                value={garment.GarmentFields.map((field) => ({
                  value: field.fieldName,
                  label: field.fieldName,
                }))}
                placeholder='Select Fields'
                onChange={(selected: any) =>
                  setGarment((prev) => ({
                    ...prev,
                    GarmentFields: selected.map((option: any) => ({fieldName: option.value})),
                  }))
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
                onChange={(e) => setGarment((prev) => ({...prev, Cost: Number(e.target.value)}))}
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
