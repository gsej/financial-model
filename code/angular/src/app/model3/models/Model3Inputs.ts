export class Model3Inputs {
  startYear: number = 2025;
  ageAtStart: number = 30;
  endYear: number = 2065;
  amountAtStart: number = 100000;
  annualContribution = 12000;
  allocations: Model3Allocation[] = [
    new Model3Allocation('Growth', 0.5, 0.05, 0.25),
    new Model3Allocation('MinimalRisk', 0.5, 0, 0)];
  meanAnnualReturn = 0.05;
  targetAge = 67
}

export class Model3Allocation {
  constructor(public name: string,
    public proportion: number,
    public meanAnnualReturn: number,
    public standardDeviation: number,
  ) {
  }
}
