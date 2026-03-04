import { Model5Year } from "./Model5Year";

export class Model5Prediction {
    targetAge!: number;
    amountAtTargetAge: number | undefined;
    years!: Model5Year[];
}
