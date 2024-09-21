export class Model2Year {
    calendarYear!: number;
    age!: number;
    yearIndex!: number;
    priorYear!: number;
    amountAtStart!: number;
    investmentReturn!: number;
    allocations!: Model2AllocationYear[];
    amountAtEnd!: number;
}

export class Model2AllocationYear {
  name!: string;
  amountAtStart!: number;
  investmentReturn!: number;
}
