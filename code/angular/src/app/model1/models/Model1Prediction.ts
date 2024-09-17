import { Model1Year } from "./Model1Year";

export class Model1Prediction {
    targetAge!: number;
    amountAtTargetAge: number | undefined;
    years!: Model1Year[];
}
