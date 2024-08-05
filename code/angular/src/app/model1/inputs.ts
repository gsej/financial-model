export class Inputs {
  startYear: number = 2025;
  ageAtStart: number = 30;
  endYear: number = 2065;
  amountAtStart: number = 100000;
  annualContribution = 12000;
  meanAnnualReturn = 0.05;
  targetAge = 67
}


export class Year {
  calendarYear!: number;
  age!: number;
  yearIndex!: number;
  priorYear!: number;
  amountAtStart!: number;
  investmentReturn!: number;
  amountAtEnd!: number;
}

export class Model1Prediction {
  targetAge!: number;
  amountAtTargetAge: number | undefined;
  years!: Year[];

}
