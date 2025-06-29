import React, {useState, FormEvent} from 'react'
import CustomFormLayout from '../../components/CustomFormLayout'
import CustomSelect from '../../components/CustomSelect'
import {SingleValue} from 'react-select'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import axios from 'axios'
import Swal from 'sweetalert2'

type EmbellishmentTypeForm = {
  Name: string
  Cost: number
  Description: string
  EmbellishmentTypeId: number
  IsAcitve: boolean
}

const CreateEmbellishmentPage: React.FC = () => {
  const [formData, setFormData] = useState<EmbellishmentTypeForm>({
    Name: '',
    Cost: 0,
    Description: '',
    EmbellishmentTypeId: 0,
    IsAcitve: true,
  })

  const types = ['Neck', 'Pocket', 'Dress', 'Pants']

  const [errors, setErrors] = useState<Partial<EmbellishmentTypeForm>>({})

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    })
  }

  const handleSelectChange = (selected: SingleValue<{label: string; value: string}>) => {
    if (selected?.value === 'Neck')
      setFormData({
        ...formData,
        EmbellishmentTypeId: 1, // Assuming 1 is the ID for Neck
      })
    else if (selected?.value === 'Pocket')
      setFormData({
        ...formData,
        EmbellishmentTypeId: 2, // Assuming 2 is the ID for Pocket
      })
    else if (selected?.value === 'Dress')
      setFormData({
        ...formData,
        EmbellishmentTypeId: 3, // Assuming 3 is the ID for Dress
      })
    else if (selected?.value === 'Pants')
      setFormData({
        ...formData,
        EmbellishmentTypeId: 4, // Assuming 4 is the ID for Pants
      })
  }

  const validate = () => {
    const newErrors: Partial<EmbellishmentTypeForm> = {}
    if (!formData.Name.trim()) newErrors.Name = 'Name is required'
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
    const response = await axios.post('https://localhost:7016/api/embellishments', formData)
    if (response.status === 200) {
      // Handle success, e.g., show a success message or redirect
      Swal.fire({
        title: 'Success',
        text: 'Embellishment created successfully!',
        icon: 'success',
        confirmButtonText: 'OK',
      })
    } else {
      // Handle error, e.g., show an error message
      Swal.fire({
        title: 'Error',
        text: 'Failed to create embellishment.',
        icon: 'error',
        confirmButtonText: 'OK',
      })
    }
    setErrors({})
    // Submit logic here
    console.log('Form submitted', formData)
  }

  // Prepare options for CustomSelect
  const typeOptions = types.map((t, id) => ({value: t, label: t}))

  return (
    <>
      <Toolbar1 />
      <CustomFormLayout
        title={
          <>
            <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30' /> Create Embellishment
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
                placeholder='Enter Embellishment name'
                value={formData.Name}
                onChange={handleChange}
              />
              {errors.Name && <div className='invalid-feedback'>{errors.Name}</div>}
            </div>,

            <div key='sortorder' className='mb-3'>
              <label htmlFor='SortOrder' className='form-label'>
                Cost
              </label>
              <input
                name='Cost'
                id='Cost'
                type='text'
                className='form-control border-primary border-2'
                placeholder='Enter cost'
                value={formData.Cost}
                onChange={handleChange}
              />
            </div>,

            <div key='type' className='mb-3'>
              <label htmlFor='Type' className='form-label'>
                Type
              </label>
              <CustomSelect
                id='Type'
                name='Type'
                options={typeOptions}
                value={
                  typeOptions.find((opt, id) => id + 1 === formData.EmbellishmentTypeId) || null
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
export default CreateEmbellishmentPage
