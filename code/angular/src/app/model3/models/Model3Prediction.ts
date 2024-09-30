import { Model3Year } from "./Model3Year";

export class Model3Prediction {
    targetAge!: number;
    amountAtTargetAge: number | undefined;
    years!: Model3Year[];
}
