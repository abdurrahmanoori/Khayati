import React, {useState} from 'react'
import {KTSVG, toAbsoluteUrl} from '../../../_metronic/helpers'
import {Link} from 'react-router-dom'
import {Toolbar1} from '../../../_metronic/layout/components/toolbar/Toolbar1'
import MeasurementModal from '../../modals/MeasurementModal'
import Swal from 'sweetalert2'
type Props = {
  className: string
}
type Measurement = {
  ArmLength: string
  Chest: string
  Height: string
  Leg: string
  Neck: string
  Sleeve: string
  Waist: string
  ShoulderWidth: string
  CustomerId: string
  trousers: string
}
const MeasurementPage: React.FC<Props> = ({className}) => {
  // Original full data
  const allMeasurements: Measurement[] = [
    {
      ArmLength: '60',
      Chest: '95',
      Height: '175',
      Leg: '100',
      Neck: '39',
      Sleeve: '60',
      Waist: '85',
      ShoulderWidth: '45',
      CustomerId: '1',
      trousers: '95',
    },
    {
      ArmLength: '62',
      Chest: '100',
      Height: '180',
      Leg: '105',
      Neck: '41',
      Sleeve: '62',
      Waist: '90',
      ShoulderWidth: '47',
      CustomerId: '2',
      trousers: '100',
    },
    {
      ArmLength: '58',
      Chest: '92',
      Height: '168',
      Leg: '98',
      Neck: '38',
      Sleeve: '58',
      Waist: '82',
      ShoulderWidth: '44',
      CustomerId: '3',
      trousers: '94',
    },
    {
      ArmLength: '65',
      Chest: '110',
      Height: '185',
      Leg: '110',
      Neck: '43',
      Sleeve: '65',
      Waist: '95',
      ShoulderWidth: '48',
      CustomerId: '4',
      trousers: '105',
    },
    {
      ArmLength: '61',
      Chest: '98',
      Height: '172',
      Leg: '102',
      Neck: '40',
      Sleeve: '61',
      Waist: '88',
      ShoulderWidth: '46',
      CustomerId: '5',
      trousers: '98',
    },
    {
      ArmLength: '59',
      Chest: '94',
      Height: '170',
      Leg: '99',
      Neck: '39',
      Sleeve: '59',
      Waist: '84',
      ShoulderWidth: '44',
      CustomerId: '6',
      trousers: '96',
    },
    {
      ArmLength: '63',
      Chest: '105',
      Height: '178',
      Leg: '106',
      Neck: '42',
      Sleeve: '63',
      Waist: '92',
      ShoulderWidth: '47',
      CustomerId: '7',
      trousers: '101',
    },
    {
      ArmLength: '57',
      Chest: '90',
      Height: '165',
      Leg: '95',
      Neck: '37',
      Sleeve: '57',
      Waist: '80',
      ShoulderWidth: '43',
      CustomerId: '8',
      trousers: '92',
    },
    {
      ArmLength: '66',
      Chest: '112',
      Height: '188',
      Leg: '112',
      Neck: '44',
      Sleeve: '66',
      Waist: '98',
      ShoulderWidth: '49',
      CustomerId: '9',
      trousers: '108',
    },
    {
      ArmLength: '60',
      Chest: '97',
      Height: '174',
      Leg: '101',
      Neck: '39',
      Sleeve: '60',
      Waist: '86',
      ShoulderWidth: '45',
      CustomerId: '10',
      trousers: '97',
    },
  ]
  const [measurement, setMeasurement] = useState<Measurement>()
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
  const [showModal, setShowModal] = useState(false)
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
  const handleDelete = (Id: string) => {
    Swal.fire({
      title: 'Delete!',
      text: 'Are you sure want to delete?',
      icon: 'warning',
      showCancelButton: true,
      showCloseButton: true,
      showConfirmButton: true,
      confirmButtonText: 'Yes, Delete it!',
    }).then((result) => {
      const c = customers.filter((c) => c.Id.toString() != Id)
      setCustomer(c)
    })
  }
  const handleEdit = (Id: string) => {
    const updateMeasurement = allMeasurements.find((m) => m.CustomerId == Id)
    setMeasurement(updateMeasurement)
    setShowModal(true)
  }

  return (
    <>
      <Toolbar1 />
      <div className={`card ${className}`}>
        {/* begin::Header */}
        <div className='card-title'>
          {/* begin::Search */}
          <div className='d-flex align-items-center position-relative my-1'>
            <KTSVG
              path='/media/icons/duotune/general/gen021.svg'
              className='svg-icon-1 position-absolute ms-6'
            />
            <input
              type='text'
              data-kt-user-table-filter='search'
              className='form-control form-control-solid w-250px ps-14'
              placeholder='Search user'
              onChange={(e) => search(e.target.value)}
            />
          </div>
          {/* end::Search */}
        </div>
        <div className='card-header border-0 pt-5'>
          <h3 className='card-title align-items-start flex-column'>
            <span className='card-label fw-bold fs-3 mb-1'>Measurement</span>
          </h3>

          <div
            className='card-toolbar'
            data-bs-toggle='tooltip'
            data-bs-placement='top'
            data-bs-trigger='hover'
            title='Click to add a user'
          >
            <Link
              to='/measurement-create'
              className='btn btn-sm btn-light-primary'
              // data-bs-toggle='modal'
              // data-bs-target='#kt_modal_invite_friends'
            >
              <KTSVG path='/media/icons/duotune/arrows/arr075.svg' className='svg-icon-3' />
              New Measurement
            </Link>
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
                <tr className='fw-bold'>
                  <th className='w-25px'>ID</th>
                  <th className='min-w-150px pl-5'>Name</th>
                  <th className='min-w-100px text-end'>Actions</th>
                </tr>
              </thead>
              {/* end::Table head */}

              {/* begin::Table body */}
              <tbody>
                {customers.map((c, index) => (
                  <tr key={c.Id}>
                    <td>
                      <div className='form-check form-check-sm form-check-custom form-check-solid'>
                        <span className=' mt-1 fw-semibold fs-7'>{index + 1}</span>
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
                        </div>
                      </div>
                    </td>
                    <td>
                      <div className='d-flex justify-content-end flex-shrink-0'>
                        <button
                          type='button'
                          className='btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'
                          aria-label='Edit'
                          onClick={() => {
                            handleEdit(c.Id.toString())
                          }}
                        >
                          <KTSVG
                            path='/media/icons/duotune/art/art005.svg'
                            className='svg-icon-3'
                          />
                        </button>
                        <button
                          type='button'
                          className='btn btn-icon btn-bg-light btn-active-color-primary btn-sm'
                          aria-label='Delete'
                          onClick={() => {
                            handleDelete(c.Id.toString())
                          }}
                        >
                          <KTSVG
                            path='/media/icons/duotune/general/gen027.svg'
                            className='svg-icon-3'
                          />
                        </button>
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
        {/* end::Body */}
      </div>
      <MeasurementModal
        show={showModal}
        setShow={() => setShowModal(false)}
        title='Update Measurement'
        updatemeasurement={measurement}
      />
    </>
  )
}

export default MeasurementPage
