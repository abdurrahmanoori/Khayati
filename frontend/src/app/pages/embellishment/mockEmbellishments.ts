type Embellishment = {
  embellishmentId: number
  embellishmentName: string
  embellishmentTypeName: string
  embellishmentDescription: string
  embellishmentTypeId: number
  Cost: number
}
export const mockEmbellishments: Embellishment[] = [
  {
    embellishmentId: 1,
    embellishmentName: 'Neck',
    embellishmentTypeName: 'Neck',
    embellishmentDescription: 'Various neck styles',
    embellishmentTypeId: 1,
    Cost: 1350,
  },
  {
    embellishmentId: 2,
    embellishmentName: 'Sleeve',
    embellishmentTypeName: 'Sleeve',
    embellishmentDescription: 'Different sleeve designs and lengths',
    embellishmentTypeId: 2,
    Cost: 1800,
  },
  {
    embellishmentId: 3,
    embellishmentName: 'Cuff',
    embellishmentTypeName: 'Cuff',
    embellishmentDescription: 'Cuff designs and finishes',
    embellishmentTypeId: 3,
    Cost: 1125,
  },
  {
    embellishmentId: 4,
    embellishmentName: 'Hem',
    embellishmentTypeName: 'Hem',
    embellishmentDescription: 'Styles for garment hems',
    embellishmentTypeId: 4,
    Cost: 900,
  },
  {
    embellishmentId: 5,
    embellishmentName: 'Pocket',
    embellishmentTypeName: 'Pocket',
    embellishmentDescription: 'Pocket designs and placements',
    embellishmentTypeId: 5,
    Cost: 720,
  },
  {
    embellishmentId: 6,
    embellishmentName: 'Button',
    embellishmentTypeName: 'Button',
    embellishmentDescription: 'Button styles and placements',
    embellishmentTypeId: 6,
    Cost: 450,
  },
  {
    embellishmentId: 7,
    embellishmentName: 'Embroidery',
    embellishmentTypeName: 'Embroidery',
    embellishmentDescription: 'Decorative embroidery work',
    embellishmentTypeId: 7,
    Cost: 2700,
  },
  {
    embellishmentId: 8,
    embellishmentName: 'Patch',
    embellishmentTypeName: 'Patch',
    embellishmentDescription: 'Fabric patches for decoration',
    embellishmentTypeId: 8,
    Cost: 675,
  },
  {
    embellishmentId: 9,
    embellishmentName: 'Beading',
    embellishmentTypeName: 'Beading',
    embellishmentDescription: 'Beadwork for embellishment',
    embellishmentTypeId: 9,
    Cost: 2250,
  },
  {
    embellishmentId: 10,
    embellishmentName: 'Lace',
    embellishmentTypeName: 'Lace',
    embellishmentDescription: 'Lace detailing and borders',
    embellishmentTypeId: 10,
    Cost: 1620,
  },
]
