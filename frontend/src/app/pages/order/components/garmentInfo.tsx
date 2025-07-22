import * as React from 'react'
import CustomSelect from '../../../components/CustomSelect'
import {SingleValue} from 'react-select'
import {Garment, OptionType as Type, Embellishment} from '../../../types/commonTypes'
import {number} from 'yup'
type Props = {
  garments: Garment[]
  garmentOptions: Type[]
  setGarments: React.Dispatch<React.SetStateAction<any[]>>
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
  setFabric?: (
    name: string,
    color: string,
    index: number,
    setGarments: React.Dispatch<React.SetStateAction<any[]>>
  ) => void
  setColor?: (FabricName: string, gIndex: number) => void
  order?: any
  setOrder?: React.Dispatch<React.SetStateAction<any[]>>
  CalculateCost?: Function
  AllGarments?: any[]
  AllFabrics?: any[]
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
  CalculateCost = () => {},
  AllGarments,
  embellishments,
  AllFabrics,
}) => {
  React.useEffect(() => {}, [allEmbellishmentsOptions])
  const [FabricName, setFabricName] = React.useState<string[]>([])
  const [prevFabricName, setPrevFabricName] = React.useState<string[]>([])
  const AddGarmentCost = (id: number) => {
    const garment = AllGarments?.find((g) => g.garmentId == id)
    CalculateCost(garment?.cost)
  }
  const RemoveGarmentCost = (id: number) => {
    if (id != 0) {
      const garment = AllGarments?.find((g) => g.garmentId == id)
      CalculateCost(-garment?.cost)
    }
  }
  const AddEmbellishmentCost = (id: number) => {
    const embellishement = embellishments?.find((e) => e.embellishmentId === id)
    CalculateCost(embellishement?.cost)
  }
  const RemoveEmbellishmentCost = (id: number) => {
    if (id != 0) {
      const embellishement = embellishments?.find((e) => e.embellishmentId === id)
      CalculateCost(-(embellishement?.cost ?? 0))
    }
  }
  const AddFabricCost = (fabricType: string, color: string) => {
    const fabric = AllFabrics?.find(
      (item) => item.fabricType === fabricType && item.color === color
    )

    console.log('Adding cost for:', fabricType, color, 'Found fabric:', fabric)

    CalculateCost((fabric?.costPerMeter ?? 0) * 4)
  }
  const RemoveFabricCost = (fabricType: string, color: string) => {
    const fabric = AllFabrics?.find(
      (item) => item.fabricType === fabricType && item.color === color
    )

    console.log('Removing cost for:', fabricType, color, 'Found fabric:', fabric)

    CalculateCost(-(fabric?.costPerMeter ?? 0) * 4)
  }

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
                onChange={(selected: SingleValue<Type>) => {
                  RemoveGarmentCost(Number(garments[gIndex].garment ?? 0))
                  setGarments((prev: Garment[]) => {
                    const updated = [...prev]
                    updated[gIndex].garment = selected?.value || ''
                    return updated
                  })
                  AddGarmentCost(Number(selected?.value))
                }}
                placeholder='Select Garment'
              />
            </div>
            <div className='col-md-6'>
              <label className='form-label'>Select Fabric:</label>
              <CustomSelect
                options={fabricOptions}
                value={fabricOptions.find((opt) => opt.label === FabricName[gIndex]) || null}
                onChange={(selected: SingleValue<Type>) => {
                  const newLabel = selected?.label || ''
                  const oldLabel = FabricName[gIndex]

                  // Only update previous if old label exists
                  if (oldLabel) {
                    setPrevFabricName((prev) => {
                      const updated = [...prev]
                      updated[gIndex] = oldLabel
                      return updated
                    })
                  }

                  // Set new fabric name
                  setFabricName((prev) => {
                    const updated = [...prev]
                    updated[gIndex] = newLabel
                    return updated
                  })

                  // Update color accordingly
                  setColor(newLabel, gIndex)
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
                onChange={(selected: SingleValue<Type>) => {
                  const newColor = selected?.value || ''
                  const oldColor = garments[gIndex]?.color || ''
                  const fabricName = prevFabricName[gIndex] ?? FabricName[gIndex]

                  // Remove previous cost if any
                  if (oldColor && fabricName) {
                    RemoveFabricCost(fabricName, oldColor)
                  }

                  // Update garments color
                  setGarments((prev: Garment[]) => {
                    const updated = [...prev]
                    if (updated[gIndex]) {
                      updated[gIndex].color = newColor
                    }
                    return updated
                  })
                  AddFabricCost(FabricName[gIndex], newColor)
                  // Apply new fabric selection and update cost
                  setFabric(fabricName, newColor, gIndex, setGarments)
                }}
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
                      onChange={(selected: SingleValue<Type>) => {
                        RemoveEmbellishmentCost(
                          Number(garments[gIndex].embellishments[eIndex].name ?? 0)
                        )
                        setGarments((prev: Garment[]) => {
                          const updated = [...prev]
                          updated[gIndex].embellishments[eIndex].name = selected?.value || ''
                          return updated
                        })
                        AddEmbellishmentCost(Number(selected?.value))
                      }}
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
