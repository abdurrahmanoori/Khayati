import * as React from 'react'
import CustomSelect from '../../../components/CustomSelect'
import {SingleValue} from 'react-select'
import {Order, Garment, OptionType as Type, Embellishment} from '../../../types/commonTypes'
import axios from 'axios'
type Props = {
  garments: Garment[]
  garmentOptions: Type[]
  setGarments: Function
  removeGarment: Function
  fabricOptions: Type[]
  colorOptions: Type[][]
  embellishmentTypeOptions: Type[]
  embellishmentOptions: Type[]
  addEmbellishment: Function
  addGarment: Function
  embellishments?: Embellishment[]
  allEmbellishmentsOptions?: Type[][][]
  setTypes?: (type: string, index?: number, eindex?: number) => void
  setFabric?: (name: string, color: string, index: number) => void
  setColor?: (FabricName: string, gIndex: number) => void
}
const GarmentInfo: React.FC<Props> = ({
  garments,
  garmentOptions,
  setGarments,
  fabricOptions,
  colorOptions,
  embellishmentTypeOptions,
  addEmbellishment,
  removeGarment,
  addGarment,
  setTypes = () => {},
  allEmbellishmentsOptions = [],
  setFabric = () => {},
  setColor = () => {},
}) => {
  React.useEffect(() => {}, [allEmbellishmentsOptions])
  const [FabricName, setFabricName] = React.useState<string[]>([])
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
                value={fabricOptions.find((opt) => opt.label === FabricName[gIndex]) || null}
                onChange={(selected: SingleValue<Type>) => {
                  setFabricName((prev) => {
                    const updated = [...prev]
                    updated[gIndex] = selected?.label || ''
                    return updated
                  })
                  setColor(selected?.label || '', gIndex)
                }}
                placeholder='Select Fabric'
              />
            </div>
          </div>

          <div className='row mb-3'>
            <div className='col-md-6'>
              <label className='form-label'>Select Color:</label>
              <CustomSelect
                options={colorOptions[gIndex] || []}
                value={colorOptions[gIndex]?.find((opt) => opt.value === g.color) || null}
                onChange={(selected: SingleValue<Type>) =>
                  setGarments((prev: Garment[]) => {
                    const updated = [...prev]
                    if (updated[gIndex]) {
                      updated[gIndex].color = selected?.value || ''
                      setFabric(FabricName[gIndex], selected?.value || '', gIndex)
                    }
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
                          setTypes(selected?.value || '', gIndex, eIndex)
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
                      options={allEmbellishmentsOptions[gIndex]?.[eIndex] || []}
                      value={
                        allEmbellishmentsOptions[gIndex]?.[eIndex]?.find(
                          (opt) => opt.value === emb.name
                        ) || null
                      }
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
