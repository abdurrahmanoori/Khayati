import React, {FC, ReactNode} from 'react'
import {Modal} from 'react-bootstrap'
import {KTSVG} from '../../_metronic/helpers'

type Props = {
  show: boolean
  children: ReactNode
  onClose: () => void
  onApply?: () => void
}

const Edit_CustomerModal: FC<Props> = ({show, children, onClose, onApply}) => {
  return (
    <Modal show={show} onHide={onClose} dialogClassName='modal-lg' backdrop='static' centered>
      <div className='modal-content'>
        <div className='modal-header justify-content-end'>
          <div className='btn btn-icon btn-sm btn-active-light-primary ms-2 ' onClick={onClose}>
            <KTSVG path='/media/icons/duotune/arrows/arr061.svg' className='svg-icon-2x' />
          </div>
        </div>

        <div className='modal-body'>{children}</div>

        <div className='modal-footer'>
          <button className='btn btn-light-primary' onClick={onClose}>
            Cancel
          </button>
          {onApply && (
            <button className='btn btn-primary' onClick={onApply}>
              Apply
            </button>
          )}
        </div>
      </div>
    </Modal>
  )
}

export {Edit_CustomerModal}
