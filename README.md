# pension-predictor

Implements the pension planning spreadsheet presented by Lars Kroijer in one of his video series, but using code rather than 
Excel.

In his [video series](https://www.youtube.com/watch?v=1LUIQa5hgMg),  Lars creates a spreadsheet modeling the performance of a 
portfolio comprising a growth component (e.g. an equities fund) and a minimal risk component (e.g. short term gilts). 
He runs the model 1000 times, and shows the spread of outcomes. I found this very informative, however his spreadsheet uses 
features available in Excel (e.g. datatables) but not in LibreOffice, and as I use Linux, I decided to replicate this in code.

The application is made up of a dotnet webapi which performs the calculations, and a relatively dumb angular front end 
which displays the data.

Both the api and the front end are divided into different `models`. Each model is based on one of the spreadsheets presented
by Lars. They are not identical to the ones he presents, because to an extent I've changed them for my own needs, but they
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
