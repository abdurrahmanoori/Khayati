import {useState} from 'react'
import {Fabric, Embellishment, OptionType} from '../../../types/commonTypes'

export const useGarmentHelpers = (allFabrics: Fabric[], embellishments: Embellishment[]) => {
  const [colorOptions, setColorOptions] = useState<OptionType[][]>([])
  const [allEmbellishmentsOptions, setAllEmbellishmentsOptions] = useState<OptionType[][][]>([])

  const setColor = (fabricType: string, gIndex: number) => {
    const options = allFabrics
      .filter((f) => f.fabricType === fabricType)
      .map((f) => ({value: f.color, label: f.color}))
    setColorOptions((prev) => {
      const updated = [...prev]
      updated[gIndex] = options
      return updated
    })
  }

  const setFabric = (
    name: string,
    color: string,
    gIndex: number,
    setGarments: React.Dispatch<React.SetStateAction<any[]>>
  ) => {
    const fabric = allFabrics.find((f) => f.fabricType === name && f.color === color)
    if (fabric) {
      setGarments((prev) => {
        const updated = [...prev]
        updated[gIndex].fabric = fabric.fabricId.toString()
        return updated
      })
    }
  }

  const setTypes = (typeId: string, gIndex?: number, eIndex?: number) => {
    const filtered = embellishments.filter((e) => e.embellishmentTypeId === Number(typeId))

    if (gIndex !== undefined && eIndex !== undefined) {
      const updated = [...allEmbellishmentsOptions]
      if (!updated[gIndex]) updated[gIndex] = []
      updated[gIndex][eIndex] = filtered.map((e) => ({
        value: e.embellishmentId.toString(),
        label: e.name,
      }))
      setAllEmbellishmentsOptions(updated)
    }
  }

  return {
    setColor,
    setFabric,
    setTypes,
    colorOptions,
    allEmbellishmentsOptions,
  }
}
