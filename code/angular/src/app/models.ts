export const model1 = `
                      <p>
                        This is a simple model that assumes all of the assets in the portfolio are of a single
                        type with a fixed annual growth rate.
                       </p>
                      <p>
                        It behaves in the same way as a regular compound interest calculator.
                      </p>
                      <p>
                        For example, it could model a portfolio invested entirely in equities, assuming they grow at a fix rate of 5% a year.
                      </p>`;

export const model2 = `<p>
                        This model splits the portfolio into two allocations each with its own fixed annual growth rate.
                       </p>
                       <p>
                        For example, we could have 80% of the portfolio in a <em>Growth</em> allocation (e.g. a global equity fund) at a growth rate of 5% a year,
                        and 20% in a <em>Minimal Risk</em> allocation (e.g. GILTs), with a growth rate of 1% per year.
                       </p>`;

export const model3 = `
                      <p>
                        This model splits the portfolio into two allocations each with its own fixed annual growth rate.
                        For example, we could have 80% of the portfolio in a <em>Growth</em> allocation (e.g. a global equity fund) at a mean growth rate of 5% a year,
                        and 20% in a <em>Minimal Risk</em> allocation (e.g. GILTs), with a mean growth rate of 1% per year.
                      </p>
                      <p>
                        The actual growth rate for each year is generated from a normal distribution, with the given mean and standard deviation. It's basically
                        equivalent to the Excel formula <em>NORMINV(RAND(), mean, standardDeviation)</em>.
                        A reasonable starting point for the standard deviation is 25%.
                      </p>
                      <p>
                        In theory this method could result in a growth rate of less than -100%, which doesn't make sense, so I clip the growth rate at -99%.
                      </p>`;

export const model4 = `<p>
                        Here I use the same underlying model as in Model 3, however the model is run multiple times,
                        and rather than the results being year-by-year, they reflect the value attained at the target age.
                      </p>`;
