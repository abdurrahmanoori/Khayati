import React, {useState, FormEvent} from 'react'

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

  // For demo: simple client-side validation errors (empty fields)
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
  }

  return (
    <div className='container mt-5 fw-bold'>
      <div className='container-fluid pt-4 '>
        <h3 className='fw-bold '>
          <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30'> </i> Create Embellishment
          Type
        </h3>
      </div>
      <div className='card shadow-sm col-lg-9 m-3 mt-1'>
        <div className='card-body p-4'>
          <form id='myForm' onSubmit={handleSubmit}>
            <div className='row'>
              {/* Name Input */}
              <div className='col-md-4'>
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
              </div>

              {/* SortOrder Input */}
              <div className='col-md-4'>
                <label htmlFor='SortOrder' className='form-label'>
                  Number
                </label>
                <input
                  name='SortOrder'
                  id='SortOrder'
                  type='text'
                  className='form-control border-primary border-2'
                  placeholder='Enter number for sorting'
                  value={formData.SortOrder}
                  onChange={handleChange}
                />
              </div>

              {/* Description Textarea */}
              <div className='mt-3 col-md-8'>
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
              </div>

              {/* Buttons */}
              <div className='col-12 text-end text mt-3'>
                <button type='submit' className='btn btn-outline-success'>
                  <i className='fas fa-plus text-dark m-2 mt-1 mb-1'></i> Add Type
                </button>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}

export default CreateEmbellishmentTypePage
