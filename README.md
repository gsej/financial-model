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

This is a simple model which assumes a single portfolio with a fixed annual growth rate. It's based on part 1 of the video series: [https://www.youtube.com/watch?v=1LUIQa5hgMg](https://www.youtube.com/watch?v=1LUIQa5hgMg)


