"use strict";

const fetchModel1Data = async (requestBody) => {
  const response = await fetch('http://localhost:5200/api/model1', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(requestBody)
  });
  const body = await response.json();
  return {
      response,
      body
  }
};

describe('Model1', () => {

  describe('when called with a valid request', () => {

    const requestBody = {
      startYear: 2020,
      ageAtStart: 30,
      endYear: 2022,
      amountAtStart: 1000,
      annualContribution: 1000,
      meanAnnualReturn: 0,
      targetAge: 60
    };

    let response, body;

    beforeAll(async () => {
      ({ response, body } = await fetchModel1Data(requestBody) );
    });

    it('should return 200', async () => {
      expect(response.status).toBe(200);
    });

    it('should return a correct set of years', async () => {

      const years = body.years;

      expect(years.length).toBe(3);

      expect(years[0].calendarYear).toBe(2020);
      expect(years[0].yearIndex).toBe(0);
      expect(years[0].age).toBe(30);

      expect(years[1].calendarYear).toBe(2021);
      expect(years[1].yearIndex).toBe(1);
      expect(years[1].age).toBe(31);

      expect(years[2].calendarYear).toBe(2022);
      expect(years[2].yearIndex).toBe(2);
      expect(years[2].age).toBe(32);
    });
  });

  describe('when called with zero mean annual return', () => {

    const requestBody = {
      startYear: 2020,
      ageAtStart: 30,
      endYear: 2022,
      amountAtStart: 1000,
      annualContribution: 1000,
      meanAnnualReturn: 0,
      targetAge: 60
    };
    
    let response, body;
    
    beforeAll(async () => {
      ({ response, body } = await fetchModel1Data(requestBody) );      
    });

    it('should return 200', async () => {
      expect(response.status).toBe(200);
    });


    it('should have zero investment return', () => {
      const years = body.years;

      years.forEach(year => {
        expect(year.investmentReturn).toBe(0);
      });

    });

    it('should have correct start of year values', () => {
      const years = body.years;

      expect(years[0].priorYear).toBe(1000);
      expect(years[0].amountAtStart).toBe(2000);

      expect(years[1].priorYear).toBe(2000);
      expect(years[1].amountAtStart).toBe(3000);

      expect(years[2].priorYear).toBe(3000);
      expect(years[2].amountAtStart).toBe(4000);
    });

    it('should have correct end of year values', () => {
      const years = body.years;
      expect(years[0].amountAtEnd).toBe(2000);
      expect(years[1].amountAtEnd).toBe(3000);
      expect(years[2].amountAtEnd).toBe(4000);
    });
  });


  describe('when called with a non-zero mean annual return', () => {

    const requestBody = {
      startYear: 2020,
      ageAtStart: 30,
      endYear: 2022,
      amountAtStart: 1000,
      annualContribution: 1000,
      meanAnnualReturn: 0.05,
      targetAge: 60
    };

    let response, body;

    beforeAll(async () => {
      ({ response, body } = await fetchModel1Data(requestBody) );      
    });

    it('should return 200', async () => {
      expect(response.status).toBe(200);
    });

    it('should have correct investment return', () => {
      const years = body.years;

      expect(years[0].investmentReturn).toBe(100);
      expect(years[1].investmentReturn).toBe(155);
      expect(years[2].investmentReturn).toBe(212.75);
    });

    it('should have correct end of year values', () => {
      const years = body.years;
      expect(years[0].amountAtEnd).toBe(2100);
      expect(years[1].amountAtEnd).toBe(3255);
      expect(years[2].amountAtEnd).toBe(4467.75);
    });
  });
});