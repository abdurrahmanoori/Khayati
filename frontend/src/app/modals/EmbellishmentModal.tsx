import React, {useState, FormEvent, useEffect} from 'react'
import {ReusableModal} from './reusableModal'
import CustomFormLayout from '../components/CustomFormLayout'
import CustomSelect from '../components/CustomSelect'
import {SingleValue} from 'react-select'
type Props = {
  showModal: boolean
  setShowModal: Function
  updateEmbellishment?: Embellishment
  update?: boolean
}
type Embellishment = {
  embellishmentId: number
  embellishmentName: string
  embellishmentTypeName: string
  embellishmentDescription: string
  embellishmentTypeId?: number
  Cost: number
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
    embellishmentName: '',
    Cost: 0,
    embellishmentDescription: '',
    embellishmentTypeName: '',
  })

  useEffect(() => {
    if (updateEmbellishment) setFormData(updateEmbellishment)
  })
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
      embellishmentTypeName: selected?.value || '',
    })
  }

  const validate = () => {
    const newErrors: Partial<EmbellishmentTypeForm> = {}
    if (!formData.embellishmentName.trim()) newErrors.Name = 'Name is required'
    // add other validations as needed
    return newErrors
  }

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault()
    const validationErrors = validate()
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors)
      return
    }
    setErrors({})
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
                  name='Name'
                  id='Name'
                  type='text'
                  className={`form-control border-primary border-2 ${
                    errors.Name ? 'is-invalid' : ''
                  }`}
                  placeholder='Enter design name'
                  value={formData.embellishmentName}
                  onChange={handleChange}
                />
                {errors.Name && <div className='invalid-feedback'>{errors.Name}</div>}
              </div>,

              <div key='sortorder' className='mb-3'>
                <label htmlFor='SortOrder' className='form-label'>
                  Number
                </label>
                <input
                  name='SortNo'
                  id='SortNo'
                  type='text'
                  className='form-control border-primary border-2'
                  placeholder='Enter number for sorting'
                  value={formData.Cost}
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
                    typeOptions.find((opt) => opt.value === formData.embellishmentTypeName) || null
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
                  name='Description'
                  id='Description'
                  className='form-control border-primary border-2'
                  rows={5}
                  placeholder='Enter description'
                  value={formData.embellishmentDescription}
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
