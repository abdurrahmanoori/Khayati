import {useEffect, useState} from 'react'
import {ThemeModeComponent} from '../../_metronic/assets/ts/layout'

const useThemeMode = () => {
  const [themeMode, setThemeMode] = useState<'light' | 'dark' | 'system'>(
    ThemeModeComponent.getMode()
  )

  useEffect(() => {
    const updateTheme = () => setThemeMode(ThemeModeComponent.getMode())
    const interval = setInterval(updateTheme, 1000)
    return () => clearInterval(interval)
  }, [])

  return themeMode
}

export default useThemeMode

// src/hooks/useOrderForm.ts
