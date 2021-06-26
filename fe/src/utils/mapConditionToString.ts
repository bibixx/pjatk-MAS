export enum GameCondition {
  BrandNew = 0,
  Perfect = 1,
  VeryGood = 2,
  UsageVisible = 3
}

const stringMap: Record<GameCondition, string> = {
  [GameCondition.BrandNew]: 'Zapakowany',
  [GameCondition.Perfect]: 'Idealny',
  [GameCondition.VeryGood]: 'Bardzo dobry',
  [GameCondition.UsageVisible]: 'Używany',
}

export const mapConditionToString = (condition: GameCondition) => stringMap[condition]
