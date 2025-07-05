import React, {useState, FormEvent, useEffect} from 'react'
import CustomFormLayout from '../components/CustomFormLayout'
import {ReusableModal} from './reusableModal'
import axios from 'axios'
import Swal from 'sweetalert2'
import {EmbellishmentType} from '../types/commonTypes'
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
    embellishmentTypeId: 0,
    name: '',
    sortOrder: 0,
    description: '',
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
    if (!formData.name.trim()) newErrors.name = 'Name is required'
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
    const result = await axios.put(
      `https://localhost:7016/api/embellishmenttype/${formData.embellishmentTypeId}`,
      formData
    )
    if (result.status === 200) {
      Swal.fire({
        title: update ? 'Updated Successfully!' : 'Added Successfully!',
        icon: 'success',
        showCloseButton: true,
        showConfirmButton: true,
      }).then(() => {
        setShowModal(false)
      })
    } else {
      Swal.fire({
        title: 'Error',
        text: 'Failed to save embellishment type',
        icon: 'error',
        showCloseButton: true,
        showConfirmButton: true,
      })
    }
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
                  name='name'
                  id='name'
                  type='text'
                  className={`form-control border-primary border-2 ${
                    errors.name ? 'is-invalid' : ''
                  }`}
                  placeholder='Enter design name'
                  value={formData.name}
                  onChange={handleChange}
                />
                {errors.name && <div className='invalid-feedback'>{errors.name}</div>}
              </div>,

              <div key='sortorder' className='mb-3'>
                <label htmlFor='SortOrder' className='form-label'>
                  Sort Order
                </label>
                <input
                  name='sortOrder'
                  id='sortOrder'
                  type='number'
                  className='form-control border-primary border-2'
                  placeholder='Enter number for sorting'
                  value={formData.sortOrder}
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

export default EmbellishmentTypeModal
