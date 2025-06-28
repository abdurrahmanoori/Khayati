import React from 'react'

interface FormLayoutProps {
  title: React.ReactNode // Form heading (e.g. "Add Order" with icon)
  rows: React.ReactNode[][] // Form fields grouped by rows
  onSubmit: (e: React.FormEvent<HTMLFormElement>) => void
  submitLabel?: string
  submitClassName?: string
  containerClassName?: string
  cardClassName?: string
  cardBodyClassName?: string
}

const FormLayout: React.FC<FormLayoutProps> = ({
  title,
  rows,
  onSubmit,
  submitLabel = 'Submit',
  submitClassName = 'btn btn-outline-success',
  containerClassName = 'container m-2 p-1',
  cardClassName = 'card shadow-sm col-lg-12 m-3 mt-1',
  cardBodyClassName = 'card-body p-4',
}) => {
  return (
    <div className={containerClassName}>
      <div className='container-fluid pt-4'>
        <h3 className='fw-bold'>{title}</h3>
      </div>

      <div className={cardClassName}>
        <div className={cardBodyClassName}>
          <form onSubmit={onSubmit}>
            {rows.map((row, i) => (
              <div className='row mb-3' key={i}>
                {row.map((field, j) => (
                  <div className={`col-md-${12 / row.length}`} key={j}>
                    {field}
                  </div>
                ))}
              </div>
            ))}
            <div className='text-end mt-3'>
              <button type='submit' className={submitClassName}>
                {submitLabel}
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}

export default FormLayout
