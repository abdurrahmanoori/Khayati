import React, {useState, FormEvent, useEffect} from 'react'
import {ReusableModal} from './reusableModal'
import CustomFormLayout from '../components/CustomFormLayout'
import CustomSelect from '../components/CustomSelect'
import {SingleValue} from 'react-select'
import {EmbellishmentType} from '../types/commonTypes'
import axios from 'axios'
import Swal from 'sweetalert2'
type Props = {
  showModal: boolean
  setShowModal: Function
  updateEmbellishment?: Embellishment
  update?: boolean
}
type Embellishment = {
  embellishmentId: number
  name: string
  embellishmentType: EmbellishmentType
  description: string
  embellishmentTypeId?: number
  cost: number
}
type EmbellishmentTypeForm = {
  Name: string
  SortOrder: string
  Description: string
  Type: string
}
const EmbellishmentModal: React.FC<Props> = ({
  showModal,
  setShowModal,
  updateEmbellishment,
  update = false,
}) => {
  const [formData, setFormData] = useState<Embellishment>({
    embellishmentId: 0,
    name: '',
    cost: 0,
    description: '',
    embellishmentType: {embellishmentTypeId: 0, name: '', description: '', sortOrder: 0},
  })

  useEffect(() => {
    if (updateEmbellishment) setFormData(updateEmbellishment)
  }, [updateEmbellishment])
  const types = [
    'Neck',
    'Pocket',
    'Dress',
    'Pants',
    'Sleeve',
    'Hem',
    'Cuff',
    'Button',
    'Embroidery',
    'Patch',
    'Beading',
    'Lace',
  ]
  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    })
  }

  const handleSelectChange = (selected: SingleValue<{label: string; value: string}>) => {
    setFormData({
      ...formData,
      embellishmentType: selected
        ? {embellishmentTypeId: 0, name: selected.value, description: '', sortOrder: 0}
        : {embellishmentTypeId: 0, name: '', description: '', sortOrder: 0},
    })
  }

  const validate = () => {
    const newErrors: Partial<EmbellishmentTypeForm> = {}
    if (!formData.name.trim()) newErrors.Name = 'Name is required'
    // add other validations as needed
    return newErrors
  }

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault()
    const validationErrors = validate()
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors)
      return
    }
    setErrors({})
    const response = await axios.put<Embellishment>(
      `https://localhost:7016/api/embellishments/${formData.embellishmentId}`,
      formData
    )
    if (response.status === 200) {
      Swal.fire({
        title: 'Success',
        text: update ? 'Embellishment updated successfully' : 'Embellishment created successfully',
        icon: 'success',
      })
      setShowModal(false)
    } else {
      Swal.fire({
        title: 'Error',
        text: 'Failed to save embellishment',
        icon: 'error',
      })
    }

    // Submit logic here
    console.log('Form submitted', formData)
  }
  const [errors, setErrors] = useState<Partial<EmbellishmentTypeForm>>({})
  // Prepare options for CustomSelect
  const typeOptions = types.map((t) => ({value: t, label: t}))
  // Original full data

  return (
    <>
      <ReusableModal show={showModal} onClose={() => setShowModal(false)}>
        <CustomFormLayout
          title={
            <>
              <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30' />{' '}
              {update ? 'Update Embellishment' : 'Create Embellishment'}
            </>
          }
          onSubmit={handleSubmit}
          submitLabel={update ? 'Update Embellishment' : 'Create Embellishment'}
          rows={[
            [
              <div key='name' className='mb-3'>
                <label htmlFor='Name' className='form-label'>
                  Name
                </label>
                <input
                  name='name'
                  id='name'
                  type='text'
                  className={`form-control border-primary border-2 ${
                    errors.Name ? 'is-invalid' : ''
                  }`}
                  placeholder='Enter design name'
                  value={formData.name}
                  onChange={handleChange}
                />
                {errors.Name && <div className='invalid-feedback'>{errors.Name}</div>}
              </div>,

              <div key='sortorder' className='mb-3'>
                <label htmlFor='SortOrder' className='form-label'>
                  Cost
                </label>
                <input
                  name='cost'
                  id='cost'
                  type='text'
                  className='form-control border-primary border-2'
                  placeholder='Enter cost'
                  value={formData.cost}
                  onChange={handleChange}
                />
              </div>,

              <div key='type' className='mb-3'>
                <label htmlFor='Type' className='form-label'>
                  Type
                </label>
                <CustomSelect
                  id='TypeName'
                  name='TypeName'
                  options={typeOptions}
                  value={
                    typeOptions.find((opt) => opt.value === formData.embellishmentType.name) || null
                  }
                  onChange={handleSelectChange}
                  placeholder='Select Type'
                  className='form-control border-primary border-2'
                />
              </div>,
            ],
            [
              <div key='description' className='mb-3 col-md-12'>
                <label htmlFor='Description' className='form-label'>
                  Description
                </label>
                <textarea
                  name='description'
                  id='description'
                  className='form-control border-primary border-2'
                  rows={5}
                  placeholder='Enter description'
                  value={formData.description}
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

export default EmbellishmentModal
