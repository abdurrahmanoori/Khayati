/* eslint-disable jsx-a11y/anchor-is-valid */
import clsx from 'clsx'
import {useLayout} from '../../core'

type Props = {
  Title: string
}
const Toolbar1: React.FC<Props> = ({Title}) => {
  const {classes} = useLayout()

  return (
    <>
      <div className='toolbar' id='kt_toolbar'>
        {/* begin::Container */}
        <div
          id='kt_toolbar_container'
          className={clsx(classes.toolbarContainer.join(' '), 'd-flex flex-stack')}
        >
          <h1 className='d-flex align-items-center text-dark fw-bolder my-1 fs-3'>{Title}</h1>
        </div>
        {/* end::Container */}
      </div>
    </>
  )
}

export {Toolbar1}
