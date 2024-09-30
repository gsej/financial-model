export class Model3Year {
  calendarYear!: number;
  age!: number;
  yearIndex!: number;
  priorYear!: number;
  amountAtStart!: number;
  investmentReturn!: number;
  allocations!: Model3AllocationYear[];
  amountAtEnd!: number;
}

export class Model3AllocationYear {
  name!: string;
  amountAtStart!: number;
  investmentReturn!: number;
}
