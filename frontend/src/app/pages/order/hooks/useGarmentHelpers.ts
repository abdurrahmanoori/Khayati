import {useState} from 'react'
import {Fabric, Embellishment, OptionType} from '../../../types/commonTypes'

export const useGarmentHelpers = (
  allFabrics: Fabric[],
  embellishments: Embellishment[],
  AllGarments?: any[],
  CalculateCost?: Function
) => {
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
  const AddGarmentCost = (id: number) => {
    const garment = AllGarments?.find((g) => g.garmentId === id)
    CalculateCost?.(garment?.cost ?? 0)
  }

  const RemoveGarmentCost = (id: number) => {
    const garment = AllGarments?.find((g) => g.garmentId === id)
    CalculateCost?.(-(garment?.cost ?? 0))
  }

  const AddEmbellishmentCost = (id: number) => {
    const embellishment = embellishments?.find((e) => e.embellishmentId === id)
    CalculateCost?.(embellishment?.cost ?? 0)
  }

  const RemoveEmbellishmentCost = (id: number) => {
    const embellishment = embellishments?.find((e) => e.embellishmentId === id)
    CalculateCost?.(-(embellishment?.cost ?? 0))
  }

  const AddFabricCost = (fabricType: string, color: string) => {
    const fabric = allFabrics?.find((f) => f.fabricType === fabricType && f.color === color)
    CalculateCost?.((fabric?.costPerMeter ?? 0) * 4)
  }

  const RemoveFabricCost = (fabricType: string, color: string) => {
    const fabric = allFabrics?.find((f) => f.fabricType === fabricType && f.color === color)
    CalculateCost?.(-(fabric?.costPerMeter ?? 0) * 4)
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
    AddFabricCost,
    AddEmbellishmentCost,
    AddGarmentCost,
    RemoveEmbellishmentCost,
    RemoveFabricCost,
    RemoveGarmentCost,
  }
}
