import { Model4Year } from "./Model4Year";

export class Model4Prediction {

  mean!: number;
  minimum!: number;
  maximum!: number;

  iterations!: Model4Year[];
  percentiles!: Percentile[];
  bands!: Band[];
  cumulativeBands!: Band[];
}

export class Percentile {
  percentileSelector!: number;
  value!: number;
}

export class Band {
  upper!: number;
  percentage!: number;
}
