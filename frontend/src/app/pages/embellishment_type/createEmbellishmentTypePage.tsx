import React, {useState, FormEvent} from 'react'
import CustomFormLayout from '../../components/CustomFormLayout'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
type EmbellishmentTypeForm = {
  Name: string
  SortOrder: string
  Description: string
}

const CreateEmbellishmentTypePage: React.FC = () => {
  const [formData, setFormData] = useState<EmbellishmentTypeForm>({
    Name: '',
    SortOrder: '',
    Description: '',
  })

  const [errors, setErrors] = useState<Partial<EmbellishmentTypeForm>>({})

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    })
  }

  const validate = () => {
    const newErrors: Partial<EmbellishmentTypeForm> = {}
    if (!formData.Name.trim()) newErrors.Name = 'Name is required'
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
    // submit logic here
    console.log('Form submitted:', formData)
  }

  return (
    <>
      <Toolbar1 />
      <CustomFormLayout
        title={
          <>
            <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30' /> Create Embellishment
            Type
          </>
        }
        onSubmit={handleSubmit}
        submitLabel='Add Type'
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
                value={formData.Name}
                onChange={handleChange}
              />
              {errors.Name && <div className='invalid-feedback'>{errors.Name}</div>}
            </div>,

            <div key='sortorder' className='mb-3'>
              <label htmlFor='SortOrder' className='form-label'>
                Number
              </label>
              <input
                name='SortOrder'
                id='SortOrder'
                type='number'
                className='form-control border-primary border-2'
                placeholder='Enter number for sorting'
                value={formData.SortOrder}
                onChange={handleChange}
              />
            </div>,
          ],
          [
            <div key='description' className='mb-3 col-md-8'>
              <label htmlFor='Description' className='form-label'>
                Description
              </label>
              <textarea
                name='Description'
                id='Description'
                className='form-control border-primary border-2'
                rows={5}
                placeholder='Enter description'
                value={formData.Description}
                onChange={handleChange}
              />
            </div>,
          ],
        ]}
      />
    </>
  )
}
export default CreateEmbellishmentTypePage
