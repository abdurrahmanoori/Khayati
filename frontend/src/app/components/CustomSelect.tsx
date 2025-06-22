// src/app/components/CustomSelect/index.tsx
import React from 'react'
import Select, {SingleValue, StylesConfig} from 'react-select'
import {ThemeModeComponent} from '../../_metronic/assets/ts/layout'

export type OptionType = {
  value: string
  label: string
}

interface CustomSelectProps {
  id?: string
  name?: string
  options: OptionType[]
  value: OptionType | null
  onChange: (selected: SingleValue<OptionType>) => void
  placeholder?: string
  className?: string
  classNamePrefix?: string
  isSearchable?: boolean
}

const CustomSelect: React.FC<CustomSelectProps> = ({
  id,
  name,
  options,
  value,
  onChange,
  placeholder,
  className = 'form-control',
  classNamePrefix = 'custom-select',
  isSearchable = true,
}) => {
  // Get current theme mode
  const themeMode = ThemeModeComponent.getMode()
  const isDark = themeMode === 'dark'
  // Styles for react-select control to match your usage
  const customSelectStyles: StylesConfig<OptionType, false> = {
    control: (base, state) => ({
      ...base,
      minHeight: 0,
      height: 23,
      borderColor: '#ced4da',
      borderWidth: 0,
      borderStyle: 'solid',
      borderRadius: '0.375rem',
      boxShadow: 'none',
      paddingLeft: 0,
    }),
    valueContainer: (base) => ({
      ...base,
      height: 23,
      padding: 0,
      display: 'flex',
      alignItems: 'center',
    }),
    input: (base) => ({
      ...base,
      margin: 0,
      padding: 0,
    }),
    indicatorsContainer: (base) => ({
      ...base,
      height: 23,
    }),
    placeholder: (base) => ({
      ...base,
      color: 'var(--kt-text-muted)',
      opacity: 1,
    }),
  }

  return (
    <Select
      id={id}
      name={name}
      styles={customSelectStyles}
      key={themeMode} // Force re-render on theme change
      options={options}
      value={value}
      onChange={onChange}
      className={className}
      classNamePrefix={classNamePrefix}
      classNames={{
        option: () => 'text-muted fw-bold', // Apply muted style to dropdown options
        singleValue: () => 'text-muted fw-bold', // Apply to selected value
      }}
      isSearchable={isSearchable}
      placeholder={placeholder}
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
  )
}

export default CustomSelect
