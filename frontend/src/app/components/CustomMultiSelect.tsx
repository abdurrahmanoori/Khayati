import React from 'react'
import Select, {MultiValue, SingleValue, StylesConfig} from 'react-select'
import {ThemeModeComponent} from '../../_metronic/assets/ts/layout'

export type OptionType = {
  value: string
  label: string
}

interface Props {
  id?: string
  name?: string
  options: OptionType[]
  value: OptionType | OptionType[] | null
  onChange: (selected: SingleValue<OptionType> | MultiValue<OptionType>) => void
  placeholder?: string
  className?: string
  classNamePrefix?: string
  isSearchable?: boolean
  isMulti?: boolean
}

const CustomSelect: React.FC<Props> = ({
  id,
  name,
  options,
  value,
  onChange,
  placeholder,
  className = 'form-control',
  classNamePrefix = 'custom-select',
  isSearchable = true,
  isMulti = false,
}) => {
  const themeMode = ThemeModeComponent.getMode()
  const isDark = themeMode === 'dark'

  const customSelectStyles: StylesConfig<OptionType, boolean> = {
    control: (base) => ({
      ...base,
      minHeight: 23,

      borderColor: '#ced4da',
      borderWidth: 0,
      borderStyle: 'solid',
      borderRadius: '0.375rem',
      boxShadow: 'none',
      paddingLeft: 0,
      backgroundColor: isDark ? '#1e1e2d' : '#fff',
      color: isDark ? '#fff' : '#000',
    }),
    valueContainer: (base) => ({
      ...base,
      minHeight: 23,
      padding: 0,
      display: 'flex',
      alignItems: 'center',
    }),
    input: (base) => ({
      ...base,
      margin: 0,
      padding: 0,
      color: isDark ? '#fff' : '#000',
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
    multiValue: (base) => ({
      ...base,
      backgroundColor: isDark ? '#333' : '#e2e8f0',
      color: isDark ? '#fff' : '#000',
    }),
    multiValueLabel: (base) => ({
      ...base,
      color: isDark ? '#fff' : '#000',
    }),
    multiValueRemove: (base) => ({
      ...base,
      color: isDark ? '#fff' : '#000',
      ':hover': {
        backgroundColor: isDark ? '#555' : '#ccc',
        color: isDark ? '#fff' : '#000',
      },
    }),
  }

  return (
    <Select
      isMulti={isMulti}
      id={id}
      name={name}
      styles={customSelectStyles}
      key={themeMode}
      options={options}
      value={value}
      onChange={onChange}
      className={className}
      classNamePrefix={classNamePrefix}
      classNames={{
        option: () => 'text-muted fw-bold',
        singleValue: () => 'text-muted fw-bold',
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
