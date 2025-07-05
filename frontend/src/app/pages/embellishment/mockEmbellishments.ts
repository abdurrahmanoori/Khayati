type EmbellishmentType = {
  id: number
  name: string
}

type Embellishment = {
  embellishmentId: number
  name: string
  embellishmentType: EmbellishmentType
  description: string
  embellishmentTypeId: number
  Cost: number
}

export const mockEmbellishments: Embellishment[] = [
  {
    embellishmentId: 1,
    name: 'Neck',
    embellishmentType: {id: 1, name: 'Neck'},
    description: 'Various neck styles',
    embellishmentTypeId: 1,
    Cost: 1350,
  },
  {
    embellishmentId: 2,
    name: 'Sleeve',
    embellishmentType: {id: 2, name: 'Sleeve'},
    description: 'Different sleeve designs and lengths',
    embellishmentTypeId: 2,
    Cost: 1800,
  },
  {
    embellishmentId: 3,
    name: 'Cuff',
    embellishmentType: {id: 3, name: 'Cuff'},
    description: 'Cuff designs and finishes',
    embellishmentTypeId: 3,
    Cost: 1125,
  },
  {
    embellishmentId: 4,
    name: 'Hem',
    embellishmentType: {id: 4, name: 'Hem'},
    description: 'Styles for garment hems',
    embellishmentTypeId: 4,
    Cost: 900,
  },
  {
    embellishmentId: 5,
    name: 'Pocket',
    embellishmentType: {id: 5, name: 'Pocket'},
    description: 'Pocket designs and placements',
    embellishmentTypeId: 5,
    Cost: 720,
  },
  {
    embellishmentId: 6,
    name: 'Button',
    embellishmentType: {id: 6, name: 'Button'},
    description: 'Button styles and placements',
    embellishmentTypeId: 6,
    Cost: 450,
  },
  {
    embellishmentId: 7,
    name: 'Embroidery',
    embellishmentType: {id: 7, name: 'Embroidery'},
    description: 'Decorative embroidery work',
    embellishmentTypeId: 7,
    Cost: 2700,
  },
  {
    embellishmentId: 8,
    name: 'Patch',
    embellishmentType: {id: 8, name: 'Patch'},
    description: 'Fabric patches for decoration',
    embellishmentTypeId: 8,
    Cost: 675,
  },
  {
    embellishmentId: 9,
    name: 'Beading',
    embellishmentType: {id: 9, name: 'Beading'},
    description: 'Beadwork for embellishment',
    embellishmentTypeId: 9,
    Cost: 2250,
  },
  {
    embellishmentId: 10,
    name: 'Lace',
    embellishmentType: {id: 10, name: 'Lace'},
    description: 'Lace detailing and borders',
    embellishmentTypeId: 10,
    Cost: 1620,
  },
]
