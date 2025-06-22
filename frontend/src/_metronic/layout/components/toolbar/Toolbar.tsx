import React from 'react'
import {useLayout} from '../../core/LayoutProvider'
import {Toolbar1} from './Toolbar1'
import {Toolbar2} from './Toolbar2'
import {Toolbar3} from './Toolbar3'
import {Toolbar4} from './Toolbar4'
import {Toolbar5} from './Toolbar5'
const Toolbar = () => {
  const {config} = useLayout()

  switch (config.toolbar.layout) {
    case 'toolbar1':
      return <Toolbar1 />

    default:
      return <Toolbar4 />
  }
}

export {Toolbar}
