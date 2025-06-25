import React, {useState, FormEvent, useEffect} from 'react'
import CustomFormLayout from '../components/CustomFormLayout'
import {ReusableModal} from './reusableModal'
type EmbellishmentType = {
  Id: number
  Name: string
  SortValue: string
  Description: string
}
type Props = {
  showModal: boolean
  setShowModal: Function
  embellishmentType?: EmbellishmentType
  update?: boolean
}
const EmbellishmentTypeModal: React.FC<Props> = ({
  showModal,
  setShowModal,
  embellishmentType,
  update = false,
}) => {
  const [formData, setFormData] = useState<EmbellishmentType>({
    Id: 0,
    Name: '',
    SortValue: '',
    Description: '',
  })

  useEffect(() => {
    if (embellishmentType) setFormData(embellishmentType)
  }, [embellishmentType])

  const [errors, setErrors] = useState<Partial<EmbellishmentType>>({})

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    })
  }

  const validate = () => {
    const newErrors: Partial<EmbellishmentType> = {}
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
      <ReusableModal show={showModal} onClose={() => setShowModal(false)}>
        <CustomFormLayout
          title={
            <>
              <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30' />{' '}
              {update ? 'Update Embellishment' : 'Create Embellishment'}
              Type
            </>
          }
          onSubmit={handleSubmit}
          submitLabel={update ? 'Update Type' : 'Add Type'}
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
                  value={formData.SortValue}
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
      </ReusableModal>
    </>
  )
}

export default EmbellishmentTypeModal
