import { Model4Iteration } from "./Model4Iteration";

export class Model4Prediction {

  mean!: number;
  minimum!: number;
  maximum!: number;

  iterations!: Model4Iteration[];
  percentiles!: Percentile[];
  bands!: Band[];
  cumulativeBands!: Band[];
}

export class Percentile {
  percentileSelector!: number;
  value!: number;
}

export class Band {
  lower!: number;
  upper!: number;
  percentage!: number;
}
