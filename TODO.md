add validation to ensure allocations add up to 100%
add validation to make sure number of years entered isn't crazy (before making public)


Refactor input sections to make them row based rather than column based

adding retirement spending.

basically uses a negative contribution after retirement risk, then
looking at the potential death date (e.g. age 95) see what the odds are of
running out of money.

Move shared components into an npm package (keep within same repo for now)

# Future
specify rebalancing strategy
