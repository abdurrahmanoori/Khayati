/* eslint-disable jsx-a11y/anchor-is-valid */
import clsx from 'clsx'
import {useLayout} from '../../core'
import {Link} from 'react-router-dom'

const Toolbar1: React.FC = () => {
  const {classes} = useLayout()

  return (
    <div className='toolbar py-4' id='kt_toolbar'>
      {/* begin::Container */}
      <div
        id='kt_toolbar_container'
        className={clsx(
          classes.toolbarContainer.join(' '),
          'd-flex flex-wrap justify-content-center gap-4'
        )}
      >
        <Link
          to='/order-create'
          className='btn btn-outline-success d-flex align-items-center gap-2 px-4 py-2'
        >
          <i className='bi bi-plus-lg fs-5' />
          New Order
        </Link>

        <Link
          to='/customer-create'
          className='btn btn-outline-primary d-flex align-items-center gap-2 px-4 py-2'
        >
          <i className='bi bi-person-plus fs-5' />
          New Customer
        </Link>
      </div>
      {/* end::Container */}
    </div>
  )
}

export {Toolbar1}
