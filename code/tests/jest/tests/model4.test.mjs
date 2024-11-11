"use strict";

const fetchModel4Data = async (requestBody) => {
    const response = await fetch('http://localhost:5200/api/model4', {
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

describe('Model3', () => {

    describe('when called with a valid request', () => {
        const requestBody = {
            ageAtStart: 30,
            targetAge: 50,
            amountAtStart: 1000,
            annualContribution: 1000,
            allocations: [
                {
                    name: "Equities",
                    proportion: 1,
                    meanAnnualReturn: 0.05,
                    standardDeviation: 0.25
                }
            ],
            iterations: 10
        };

        let response, result;

        beforeAll(async () => {
            ({ response, body: result } = await fetchModel4Data(requestBody));
        });


        it('should return 200', () => {
            expect(response.status).toBe(200);
        });

        it('should return a correct set of iterations', () => {
            const iterations = result.iterations;

            expect(iterations.length).toBe(10);

            const amounts = iterations.map(iteration => iteration.amountAtTargetAge);
            const minimum = Math.min(...amounts);
            const maximum = Math.max(...amounts);
            const mean = amounts.reduce((acc, amount) => acc + amount, 0) / amounts.length;

            expect(result.minimum).toBe(minimum);
            expect(result.maximum).toBe(maximum);
            expect(result.mean).toBeCloseTo(mean, 4);
        });
    });
   
})
