export class Inputs {
  startYear: number = 2025;
  ageAtStart: number = 30;
  endYear: number = 2065;
  amountAtStart: number = 100000;
  annualContribution = 12000;
  meanAnnualReturn = 0.05;
}


export class Year {
  calendarYear!: number;
  age!: number;
  yearIndex!: number;
  amountAtStart!: number;
  annualContribution!: number;
  investmentReturn!: number;
  amountAtEnd!: number; // Calculated
}

export class Model1Prediction {

  years!: Year[];

}
