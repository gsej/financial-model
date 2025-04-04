# fincancial-model

Implements the pension planning spreadsheet presented by Lars Kroijer in one of his video series, but using code rather than 
Excel.

In his [video series](https://www.youtube.com/watch?v=1LUIQa5hgMg), Lars creates a spreadsheet modeling the performance of a 
portfolio comprising a growth component (e.g. an equities fund) and a minimal risk component (e.g. short term gilts).

I found this very informative, however his spreadsheet uses features available in Excel (e.g. datatables) but not in LibreOffice, and as I use Linux, 
and enjoy using code, I decided to explore this with a C# api, and an Angular front end

In Lars's spreadsheet, he builds up his solution in _stages_, each stage expanding on the last, and he creates a new spreadsheet tab for each stage. In my
app on the other hand, I've called each stage a _model_, and each can be accessed using the options at the top of the screen.

My _models_ are not identical to the _tabs_ in the spreadsheet Lars presents, because to an extent I've changed them for my own needs, but they
are pretty close.

## Model 1

This is a simple model assumes all of the assets in the portfolio are of a single type with a fixed annual growth rate. 
It's based on part 1 of the video series: [https://www.youtube.com/watch?v=1LUIQa5hgMg](https://www.youtube.com/watch?v=1LUIQa5hgMg)
For example, the entire portfolio could be in global equities, and it could be assumed they'll grow at 5% a year

## Model 2

This model splits the portfolio into two allocations each with its own fixed annual growth rate. 
It's based on part 2 of the video series: [https://www.youtube.com/watch?v=nMfT6cAYJjU](https://www.youtube.com/watch?v=nMfT6cAYJjU)
For example, we could have 80% of the portfolio in global equities (our _Growth_ allocation, with a growth rate of 5% a year,
and 20% in GILTs (our _Minimal Risk_ allocation), with a growth rate of 1% per year.

## Model 3 (Adding Risk)

This model adds in an element of risk around the annual investment return. As well as the mean, we have a standard deviation, so the 
return in any given year is the equivalent of the excel formula NORMINV(RAND(), m, s) where m is the mean annual return, and s the standard
deviation. In the video Lars uses 25% for the standard deviation, and explains that this is a reasonable simplification.
It's based on part 3 of the video series: [https://www.youtube.com/watch?v=3CeD0eefeQc](https://www.youtube.com/watch?v=3CeD0eefeQc)

## Model 4 (Multiple iterations)

Here I use the same underlying model as in Model 3, however the model is run multiple times, and rather than the results being year-by-year, they reflect the value attained at the target age. 
add validation to ensure allocations add up to 100%
add validation to make sure number of years entered isn't crazy (before making public)



### TODO: 


Part 5 (https://www.youtube.com/watch?v=QKTlwQC8BwQ&t=10s)

Just adds the ability to switch from contribution to withdrawal at a certain age. He also adds volatility into the contributions (but I don't want to implement that)

Can be modelled just by allowing a separate inflow/outflow rate for each year. Possibly combine this with a more flexible approach to 
allocations.

Perhaps need to add additional charts or output to show the 
possible results at various ages - not just the "target age", which at this point becomes a bit arbitrary.

Part 6 (https://www.youtube.com/watch?v=C7HtNy5ggWI)

Talks about difference between CAGR and average growth rate. 

We should specify the CAGR, but then calculate average annual return for the calculations of each year. Look up formula.

# Future
specify rebalancing strategy

Model 4 add reverse cummulative

rename project - perhaps to portfolio-model


