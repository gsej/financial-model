export class Model2Inputs {
  startYear: number = 2025;
  ageAtStart: number = 30;
  endYear: number = 2065;
  amountAtStart: number = 100000;
  annualContribution = 12000;
  allocations: Model2Allocation[] = [
    new Model2Allocation('Growth', 0.5, 0.05),
    new Model2Allocation('MinimalRisk', 0.5, 0)];
  meanAnnualReturn = 0.05;
  targetAge = 67
}

export class Model2Allocation {
  constructor(public name: string,
    public proportion: number,
    public meanAnnualReturn: number) {
  }
}
