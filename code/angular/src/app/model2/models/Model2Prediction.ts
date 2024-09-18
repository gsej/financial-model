import { Model2Year } from "./Model2Year";

export class Model2Prediction {
    targetAge!: number;
    amountAtTargetAge: number | undefined;
    years!: Model2Year[];
}
