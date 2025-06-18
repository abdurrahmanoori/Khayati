/* eslint-disable jsx-a11y/anchor-is-valid */
import React from 'react'
import {KTSVG, toAbsoluteUrl} from '../../../helpers'
import {useState} from 'react'

type Props = {
  className: string
}

const TablesWidget9: React.FC<Props> = ({className}) => {
  const [customers, setCustomer] = useState([
    {
      Id: 1,
      Name: 'Abubakr',
      Date: '2/20/2020',
      Phone: '0747627648',
      Email: 'abubakr.kaakar.2016@gmail.com',
    },
    {
      Id: 2,
      Name: 'Ahmad',
      Date: '3/15/2021',
      Phone: '0747123456',
      Email: 'ahmad@example.com',
    },
    {
      Id: 3,
      Name: 'Fatima',
      Date: '5/10/2022',
      Phone: '0747987654',
      Email: 'fatima@example.com',
    },
    {
      Id: 4,
      Name: 'Zainab',
      Date: '7/18/2020',
      Phone: '0747888888',
      Email: 'zainab@example.com',
    },
    {
      Id: 5,
      Name: 'Omar',
      Date: '9/12/2023',
      Phone: '0747555544',
      Email: 'omar@example.com',
    },
    {
      Id: 6,
      Name: 'Yusuf',
      Date: '11/25/2021',
      Phone: '0747666777',
      Email: 'yusuf@example.com',
    },
    {
      Id: 7,
      Name: 'Maryam',
      Date: '1/8/2022',
      Phone: '0747000011',
      Email: 'maryam@example.com',
    },
    {
      Id: 8,
      Name: 'Ayesha',
      Date: '6/3/2020',
      Phone: '0747222233',
      Email: 'ayesha@example.com',
    },
    {
      Id: 9,
      Name: 'Bilal',
      Date: '10/30/2022',
      Phone: '0747333444',
      Email: 'bilal@example.com',
    },
    {
      Id: 10,
      Name: 'Sara',
      Date: '12/12/2023',
      Phone: '0747444555',
      Email: 'sara@example.com',
    },
  ])
  const [allCustomers, setAllCustomers] = useState(customers)

  const search = (value: string) => {
    if (value === '') {
      setCustomer(allCustomers)
    } else {
      const filteredcustomers = customers.filter((c) =>
        c.Name.toLowerCase().includes(value.toLowerCase())
      )
      setCustomer(filteredcustomers)
    }
  }

  return (
    <div className={`card ${className}`}>
      {/* begin::Header */}
      <div className='d-flex align-items-center' data-kt-search='true'>
        <div className='position-relative' data-kt-search-element='form'>
          <input
            type='text'
            className='form-control'
            placeholder='🔍Search...'
            data-kt-search-element='input'
            onChange={(e) => search(e.target.value)}
          />
          <span className='spinner-border d-none' data-kt-search-element='spinner'></span>
        </div>
      </div>

      <div className='card-header border-0 pt-5'>
        <h3 className='card-title align-items-start flex-column'>
          <span className='card-label fw-bold fs-3 mb-1'>Customers</span>
          <span className='text-muted mt-1 fw-semibold fs-7'>Over 500 Customers</span>
        </h3>

        <div
          className='card-toolbar'
          data-bs-toggle='tooltip'
          data-bs-placement='top'
          data-bs-trigger='hover'
          title='Click to add a user'
        >
          <a
            href='#'
            className='btn btn-sm btn-light-primary'
            data-bs-toggle='modal'
            data-bs-target='#kt_modal_invite_friends'
          >
            <KTSVG path='/media/icons/duotune/arrows/arr075.svg' className='svg-icon-3' />
            New Customer
          </a>
        </div>
      </div>
      {/* end::Header */}
      {/* begin::Body */}
      <div className='card-body py-3'>
        {/* begin::Table container */}
        <div className='table-responsive'>
          {/* begin::Table */}
          <table className='table table-row-dashed table-row-gray-300 align-middle gs-0 gy-4'>
            {/* begin::Table head */}
            <thead>
              <tr className='fw-bold text-muted'>
                <th className='w-25px'>
                  <div className='form-check form-check-sm form-check-custom form-check-solid'>
                    ID
                  </div>
                </th>
                <th className='min-w-150px'>Name</th>
                <th className='min-w-140px'>Date</th>
                <th className='min-w-120px'>Phone</th>
                <th className='min-w-120px'>Email</th>
                <th className='min-w-100px text-end'>Actions</th>
              </tr>
            </thead>
            {/* end::Table head */}
            {/* begin::Table body */}
            <tbody>
              {customers.map((c, index) => (
                <tr key={index}>
                  <td>
                    <div className='form-check form-check-sm form-check-custom form-check-solid'>
                      <span className='text-muted mt-1 fw-semibold fs-7'>{index + 1}</span>
                    </div>
                  </td>
                  <td>
                    <div className='d-flex align-items-center'>
                      <div className='symbol symbol-45px me-5'>
                        <img src={toAbsoluteUrl(`/media/avatars/300-${index + 1}.jpg`)} alt='' />
                      </div>
                      <div className='d-flex justify-content-start flex-column'>
                        <a href='#' className='text-dark fw-bold text-hover-primary fs-6'>
                          {c.Name}
                        </a>
                        <span className='text-muted fw-semibold text-muted d-block fs-7'>
                          HTML, JS, ReactJS
                        </span>
                      </div>
                    </div>
                  </td>
                  <td>
                    <span className='text-muted fw-semibold text-muted d-block fs-7'>{c.Date}</span>
                  </td>
                  <td className='text-end'>
                    <div className='d-flex flex-column w-100 me-2'>
                      <div className='d-flex flex-stack mb-2'>
                        <span className='text-muted me-2 fs-7 fw-semibold'>{c.Phone}</span>
                      </div>
                    </div>
                  </td>
                  <td className='text-end'>
                    <div className='d-flex flex-column w-100 me-2'>
                      <div className='d-flex flex-stack mb-2'>
                        <span className='text-muted me-2 fs-7 fw-semibold'>{c.Email}</span>
                      </div>
                    </div>
                  </td>
                  <td>
                    <div className='d-flex justify-content-end flex-shrink-0'>
                      <a
                        href='#'
                        className='btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'
                      >
                        <KTSVG path='/media/icons/duotune/art/art005.svg' className='svg-icon-3' />
                      </a>
                      <a
                        href='#'
                        className='btn btn-icon btn-bg-light btn-active-color-primary btn-sm'
                      >
                        <KTSVG
                          path='/media/icons/duotune/general/gen027.svg'
                          className='svg-icon-3'
                        />
                      </a>
                    </div>
                  </td>
                </tr>
              ))}
            </tbody>

            {/* end::Table body */}
          </table>
          {/* end::Table */}
        </div>
        {/* end::Table container */}
      </div>
      {/* begin::Body */}
    </div>
  )
}

export default TablesWidget9
