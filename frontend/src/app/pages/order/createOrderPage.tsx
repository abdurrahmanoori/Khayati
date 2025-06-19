import * as React from 'react'
import {useEffect, useState} from 'react'
import Select, {SingleValue, Theme} from 'react-select'
import {ThemeModeComponent} from '../../../_metronic/assets/ts/layout'

const CreateOrderPage = () => {
  const [order, setOrder] = useState({
    OrderDate: '',
    CustomerName: '',
    DeliveryAddress: '',
    ContactPhone: '',
    Email: '',
    Status: '',
  })
  type OptionType = {
    value: string
    label: string
  }

  const [themeMode, setThemeMode] = useState<'light' | 'dark' | 'system'>(
    ThemeModeComponent.getMode()
  )

  // Listen for theme changes and update component state
  useEffect(() => {
    const updateTheme = () => setThemeMode(ThemeModeComponent.getMode())

    // Poll the theme every 500ms
    const interval = setInterval(updateTheme, 1000)

    return () => clearInterval(interval)
  }, [])

  const isDark = themeMode === 'dark'

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const {name, value} = e.target
    setOrder((prev) => ({
      ...prev,
      [name]: value,
    }))
  }

  const statusOptions = [
    {value: 'Pending', label: 'Pending'},
    {value: 'Processing', label: 'Processing'},
    {value: 'Completed', label: 'Completed'},
    {value: 'Cancelled', label: 'Cancelled'},
  ]

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    console.log('Order submitted:', order)
  }

  return (
    <>
      <div className='container m-2 p-1'>
        <div className='container-fluid pt-4'>
          <h3 className='fw-bold'>
            <i className='fas fa-plus text-dark m-2 mt-1 mb-1 img-size-30' /> Add Order
          </h3>
        </div>
      </div>

      <div className='card shadow-sm col-lg-8 m-3 mt-1'>
        <div className='card-body p-4'>
          <form onSubmit={handleSubmit}>
            <div className='row'>
              {' '}
              <div className='col-md-6 mb-3'>
                <label htmlFor='Status' className='form-label'>
                  Status:
                </label>
                <Select
                  key={themeMode} // Force re-render on theme change
                  id='Status'
                  name='Status'
                  options={statusOptions}
                  value={statusOptions.find((opt) => opt.value === order.Status)}
                  onChange={(selected: SingleValue<OptionType>) =>
                    setOrder((prev) => ({
                      ...prev,
                      Status: selected?.value || '',
                    }))
                  }
                  classNamePrefix='custom-select'
                  classNames={{
                    option: () => 'text-muted fw-bold', // ✅ Apply text-muted to dropdown options
                    singleValue: () => 'text-muted fw-bold', // optional: apply to selected value
                  }}
                  isSearchable
                  placeholder='Select Customer'
                  theme={(theme: any) => ({
                    ...theme,
                    colors: {
                      ...theme.colors,
                      primary25: isDark ? '#2a2a2a' : '#e2e8f0',
                      primary: '#50cd89',
                      neutral0: isDark ? '#1e1e2d' : '#ffffff',
                      neutral80: isDark ? '#ffffff' : '#2e2e2e',
                      neutral20: isDark ? '#444' : '#ccc',
                    },
                  })}
                />
              </div>
              <div className='col-md-6 mb-3'>
                <label htmlFor='OrderDate' className='form-label'>
                  Delivery Date:
                </label>
                <input
                  id='OrderDate'
                  name='OrderDate'
                  type='date'
                  className='form-control border-success-subtle'
                  value={order.OrderDate}
                  onChange={handleChange}
                  required
                />
              </div>
            </div>

            <div className='row'>
              <div className='col-md-6 mb-3'>
                <label htmlFor='DeliveryAddress' className='form-label'>
                  Total Cost:
                </label>
                <input
                  id='DeliveryAddress'
                  name='DeliveryAddress'
                  type='text'
                  className='form-control border-success-subtle'
                  value={order.DeliveryAddress}
                  onChange={handleChange}
                  required
                />
              </div>
              <div className='col-md-6 mb-3'>
                <label htmlFor='Status' className='form-label'>
                  Payment Status:
                </label>
                <Select
                  key={themeMode} // Force re-render on theme change
                  id='Status'
                  name='Status'
                  options={statusOptions}
                  value={statusOptions.find((opt) => opt.value === order.Status)}
                  onChange={(selected: SingleValue<OptionType>) =>
                    setOrder((prev) => ({
                      ...prev,
                      Status: selected?.value || '',
                    }))
                  }
                  classNamePrefix='custom-select'
                  classNames={{
                    option: () => 'text-muted fw-bold', // ✅ Apply text-muted to dropdown options
                    singleValue: () => 'text-muted fw-bold', // optional: apply to selected value
                  }}
                  isSearchable
                  placeholder='Select status'
                  theme={(theme: any) => ({
                    ...theme,
                    colors: {
                      ...theme.colors,
                      primary25: isDark ? '#2a2a2a' : '#e2e8f0',
                      primary: '#50cd89',
                      neutral0: isDark ? '#1e1e2d' : '#ffffff',
                      neutral80: isDark ? '#ffffff' : '#2e2e2e',
                      neutral20: isDark ? '#444' : '#ccc',
                    },
                  })}
                />
              </div>
            </div>

            <div className='row'></div>

            <div className='text-end mt-3'>
              <button type='submit' className='btn btn-outline-success'>
                <i className='fas fa-plus text-dark m-2 mt-1 mb-1' /> Add Order
              </button>
            </div>
          </form>
        </div>
      </div>
    </>
  )
}

export default CreateOrderPage
