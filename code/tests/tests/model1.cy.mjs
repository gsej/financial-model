import 'cypress-plugin-api'

describe('Model1', () => {

  it('when called with a valid request', () => {
    const requestBody = {
      startYear: 2020,
      ageAtStart: 30,
      endYear: 2022,
      amountAtStart: 1000,
      annualContribution: 1000,
      meanAnnualReturn: 0,
      targetAge: 60
    };

    cy.api('POST', '/api/model1', requestBody)
      .then(response => {

        it('should return 200', () => {
          expect(response.status).to.eq(200);
        });

        it('should return a correct set of years', () => {
          const years = response.body.years;

          expect(years.length).to.eq(3);

          expect(years[0].calendarYear).to.eq(2020);
          expect(years[0].yearIndex).to.eq(0);
          expect(years[0].age).to.eq(30);

          expect(years[1].calendarYear).to.eq(2021);
          expect(years[1].yearIndex).to.eq(1);
          expect(years[1].age).to.eq(31);

          expect(years[2].calendarYear).to.eq(2022);
          expect(years[2].yearIndex).to.eq(2);
          expect(years[2].age).to.eq(32);
        });
      });
  })


  it('when called with zero mean annual return', () => {

    const requestBody = {
      startYear: 2020,
      ageAtStart: 30,
      endYear: 2022,
      amountAtStart: 1000,
      annualContribution: 1000,
      meanAnnualReturn: 0,
      targetAge: 60
    };

    cy.api('POST', '/api/model1', requestBody)
      .then(response => {

        it('should have zero investment return', () => {
          const years = response.body.years;
          cy.wrap(years).each(year => {
            expect(year.investmentReturn).to.eq(0);
          })
        });

        it('should have correct start of year values', () => {
          const years = response.body.years;

          expect(years[0].priorYear).to.eq(1000);
          expect(years[0].amountAtStart).to.eq(2000);

          expect(years[1].priorYear).to.eq(2000);
          expect(years[1].amountAtStart).to.eq(3000);

          expect(years[2].priorYear).to.eq(3000);
          expect(years[2].amountAtStart).to.eq(4000);
        });

        it('should have correct end of year values', () => {
          const years = response.body.years;
          expect(years[0].amountAtEnd).to.eq(2000);
          expect(years[1].amountAtEnd).to.eq(3000);
          expect(years[2].amountAtEnd).to.eq(4000);
        });
      });
  })
});
