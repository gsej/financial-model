export class Model4Inputs {
  ageAtStart: number = 30;
  amountAtStart: number = 100000;
  annualContribution = 12000;
  allocations: Model4Allocation[] = [
    new Model4Allocation('Growth', 0.5, 0.05, 0.25),
    new Model4Allocation('MinimalRisk', 0.5, 0, 0)];
  meanAnnualReturn = 0.05;
  targetAge = 67;
  iterations = 1000;
}

export class Model4Allocation {
  constructor(public name: string,
    public proportion: number,
    public meanAnnualReturn: number,
    public standardDeviation: number,
  ) {
  }
}
