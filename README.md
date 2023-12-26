# pension-predictor
Implements the Lars Kroijer pension prediction spreadsheet but with code (removing need for Excel).

In his video series (https://www.youtube.com/watch?v=1LUIQa5hgMg) Lars creates a spreadsheet predicting the performance of a 
portfolio comprising a growth component (e.g. an equities fund) and a minimal risk component (e.g. short term gilts). He runs the 
model 1000 times, and shows the spread of outcomes. His spreadsheet uses features available in Excel (e.g. datatables) but not
in LibreOffice, and as I use Linux, I decided to replicate this in code.

The console app here takes a set of input parameters, runs the model a certain number of times and produces a set of outputs which can
be used as the basis for further analysis. 
