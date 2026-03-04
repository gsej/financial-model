export class Model5Year {
  calendarYear!: number;
  age!: number;
  yearIndex!: number;
  priorYear!: number;
  amountAtStart!: number;
  investmentReturn!: number;
  allocations!: Model5AllocationYear[];
  amountAtEnd!: number;
}

export class Model5AllocationYear {
  name!: string;
  amountAtStart!: number;
  investmentReturn!: number;
}
