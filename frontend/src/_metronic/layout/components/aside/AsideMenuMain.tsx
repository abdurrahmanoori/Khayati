/* eslint-disable react/jsx-no-target-blank */
import React from 'react'
import {useIntl} from 'react-intl'
import {KTSVG} from '../../../helpers'
import {AsideMenuItemWithSub} from './AsideMenuItemWithSub'
import {AsideMenuItem} from './AsideMenuItem'

export function AsideMenuMain() {
  const intl = useIntl()

  return (
    <>
      <AsideMenuItem
        to='/dashboard'
        icon='/media/icons/duotune/art/art002.svg'
        title={intl.formatMessage({id: 'MENU.DASHBOARD'})}
        fontIcon='bi-app-indicator'
      />
      <div className='menu-item'>
        <div className='menu-content'>
          <div className='separator mx-1 my-4'></div>
        </div>
      </div>
      <AsideMenuItem
        to='/order'
        icon='/media/icons/duotune/general/gen005.svg' // Order icon here
        title='Orders'
        fontIcon='bi-person' // You can also update or remove this if not used
      />

      <AsideMenuItem
        to='/customer'
        icon='/media/icons/duotune/communication/com006.svg'
        title='Customers'
        fontIcon='bi-person'
      />
      <AsideMenuItemWithSub to='' title='Embellishment' icon='/media/icons/duotune/art/art001.svg'>
        <AsideMenuItem
          to='/embellishment'
          icon='/media/icons/duotune/art/art001.svg'
          title='Embellishments'
          fontIcon='bi-patch-check'
        />
        <AsideMenuItem
          to='/embellishmentType'
          icon='/media/icons/duotune/art/art003.svg'
          title='Embellishment Types'
          fontIcon='bi-brush'
        />
      </AsideMenuItemWithSub>

      <AsideMenuItem
        to='/measurement'
        icon='/media/icons/duotune/general/gen028.svg'
        title='Measurements'
        fontIcon='bi-rulers'
      />

      <AsideMenuItem
        to=''
        icon='/media/icons/duotune/communication/com005.svg'
        title='Relatives'
        fontIcon='bi-people'
      />
      <div className='menu-item'>
        <div className='menu-content'>
          <div className='separator mx-1 my-4'></div>
        </div>
      </div>
    </>
  )
}
