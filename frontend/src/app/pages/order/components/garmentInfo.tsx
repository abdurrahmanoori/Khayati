import * as React from 'react'
import {useState, useEffect} from 'react'
import CustomSelect from '../../../components/CustomSelect'
import {SingleValue} from 'react-select'
import {Order, Garment, OptionType as Type} from '../../../types/commonTypes'
type Props = {
  garments: Garment[]
  garmentOptions: Type[]
  setGarments: Function
  removeGarment: Function
  fabricOptions: Type[]
  colorOptions: Type[]
  embellishmentTypeOptions: Type[]
  embellishmentOptions: Type[]
  addEmbellishment: Function
  addGarment: Function
  order?: Order
}
const GarmentInfo: React.FC<Props> = ({
  garments,
  garmentOptions,
  setGarments,
  fabricOptions,
  colorOptions,
  embellishmentTypeOptions,
  embellishmentOptions,
  addEmbellishment,
  removeGarment,
  addGarment,
  order,
}) => {
  return (
    <React.Fragment>
      <div className='row mb-3'>
        <div className='d-flex align-items-center my-4'>
          <div className='flex-grow-1 border-top border-2'></div>
          <span className='mx-3 fw-bold text-muted'>Garment Info</span>
          <div className='flex-grow-1 border-top border-2'></div>
        </div>
      </div>
      {garments.map((g, gIndex) => (
        <React.Fragment key={gIndex}>
          <div className='row mb-3'>
            <div className='col-md-6'>
              <label className='form-label'>Select Garment:</label>
              <CustomSelect
                options={garmentOptions}
                value={garmentOptions.find((opt) => opt.value === g.garment) || null}
                onChange={(selected: SingleValue<Type>) =>
                  setGarments((prev: Garment[]) => {
                    const updated = [...prev]
                    updated[gIndex].garment = selected?.value || ''
                    return updated
                  })
                }
                placeholder='Select Garment'
              />
            </div>
            <div className='col-md-6'>
              <label className='form-label'>Select Fabric:</label>
              <CustomSelect
                options={fabricOptions}
                value={fabricOptions.find((opt) => opt.value === g.fabric) || null}
                onChange={(selected: SingleValue<Type>) =>
                  setGarments((prev: Garment[]) => {
                    const updated = [...prev]
                    updated[gIndex].fabric = selected?.value || ''
                    return updated
                  })
                }
                placeholder='Select Fabric'
              />
            </div>
          </div>

          <div className='row mb-3'>
            <div className='col-md-6'>
              <label className='form-label'>Select Color:</label>
              <CustomSelect
                options={colorOptions}
                value={colorOptions.find((opt) => opt.value === g.color) || null}
                onChange={(selected: SingleValue<Type>) =>
                  setGarments((prev: Garment[]) => {
                    const updated = [...prev]
                    updated[gIndex].color = selected?.value || ''
                    return updated
                  })
                }
                placeholder='Select Color'
              />
            </div>
            <div className='col-md-6 mt-8'>
              <div className='form-check mt-4'>
                <input
                  type='checkbox'
                  className='form-check-input'
                  id={`isEmbellished-${gIndex}`}
                  checked={g.isEmbellished}
                  onChange={(e) =>
                    setGarments((prev: Garment[]) => {
                      const updated = [...prev]
                      updated[gIndex].isEmbellished = e.target.checked
                      if (!e.target.checked) {
                        updated[gIndex].embellishments = [{type: '', name: ''}]
                      }
                      return updated
                    })
                  }
                />
                <label className='form-check-label' htmlFor={`isEmbellished-${gIndex}`}>
                  Is Embellished?
                </label>
              </div>
            </div>
          </div>

          {g.isEmbellished && (
            <>
              {g.embellishments.map((emb, eIndex) => (
                <div className='row mb-3' key={eIndex}>
                  <div className='col-md-5'>
                    <label className='form-label'>Embellishment Type:</label>
                    <CustomSelect
                      options={embellishmentTypeOptions}
                      value={embellishmentTypeOptions.find((opt) => opt.value === emb.type) || null}
                      onChange={(selected: SingleValue<Type>) =>
                        setGarments((prev: Garment[]) => {
                          const updated = [...prev]
                          updated[gIndex].embellishments[eIndex].type = selected?.value || ''
                          return updated
                        })
                      }
                      placeholder='Select Embellishment Type'
                    />
                  </div>
                  <div className='col-md-5'>
                    <label className='form-label'>Embellishment:</label>
                    <CustomSelect
                      options={embellishmentOptions}
                      value={embellishmentOptions.find((opt) => opt.value === emb.name) || null}
                      onChange={(selected: SingleValue<Type>) =>
                        setGarments((prev: Garment[]) => {
                          const updated = [...prev]
                          updated[gIndex].embellishments[eIndex].name = selected?.value || ''
                          return updated
                        })
                      }
                      placeholder='Select Embellishment'
                    />
                  </div>
                  {eIndex !== 0 ? (
                    <div className='col-md-2 d-flex align-items-end justify-content-end'>
                      <button
                        type='button'
                        className='btn btn-danger d-flex align-items-center gap-2 px-4 py-2 rounded-pill shadow-sm'
                        onClick={() =>
                          setGarments((prev: Garment[]) => {
                            const updated = [...prev]
                            updated[gIndex].embellishments.splice(eIndex, 1)
                            return updated
                          })
                        }
                      >
                        -
                      </button>
                    </div>
                  ) : (
                    ''
                  )}
                </div>
              ))}

              <div className='row mb-3'>
                <div className='col-md-12 d-flex justify-content-end'>
                  <button
                    type='button'
                    className='btn btn-success d-flex align-items-center gap-2 px-4 py-2 rounded-pill shadow-sm'
                    onClick={() => addEmbellishment(gIndex)}
                  >
                    +
                  </button>
                </div>
              </div>
            </>
          )}
          {gIndex !== 0 ? (
            <div className='row mb-3'>
              <div className='col-md-6'>
                <div
                  className='btn btn-outline-danger text-end'
                  onClick={() => removeGarment(g.id)}
                >
                  Remove
                </div>
              </div>
            </div>
          ) : (
            ''
          )}
          <div className='row'>
            <div className='col'>
              <hr
                className='border-top border-3'
                style={{borderColor: 'var(--kt-border-dashed-color)'}}
              />
            </div>
          </div>
        </React.Fragment>
      ))}
      <div className='row mb-3'>
        <div className='col-md-6'>
          <div className='btn btn-outline-success text-start' onClick={() => addGarment()}>
            Add
          </div>
        </div>
      </div>
    </React.Fragment>
  )
}

export default GarmentInfo
