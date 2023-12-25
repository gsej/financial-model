using ClosedXML.Excel;


namespace Console;

public class ExcelOutput : IDisposable
{
    private int _currentRow = 2;
    private int _rowForSavingsAt67 = 0;

    private XLWorkbook _workbook;
    private IXLWorksheet _worksheet;

    public ExcelOutput()
    {

    }

    public void Output(IList<YearRecord> years)
    {
        _workbook = new XLWorkbook();
        {
            var worksheet = _workbook.Worksheets.Add("Sample Sheet");
            _worksheet = worksheet;
            
            AddConfigurationHeaders(worksheet);
            AddColumnHeaders(worksheet, YearRecord.GetHeaders());
            
            AddYears(worksheet, years);
            
          
        }
    }

    private void AddConfigurationHeaders(IXLWorksheet worksheet)
    {
        worksheet.Cell($"B{_currentRow}").SetValue("Minimal Risk");
        worksheet.Cell($"C{_currentRow}").SetValue("Equities");

        _currentRow++;
        
        worksheet.Cell($"A{_currentRow}").SetValue("Return");
        
        worksheet.Cell($"B{_currentRow}")
            .SetValue(Configuration.MinimalRiskGrowth)
            .Style.NumberFormat.Format = Format.Percentage;

        worksheet.Cell($"C{_currentRow}")
            .SetValue(Configuration.EquityGrowth)
            .Style.NumberFormat.Format = Format.Percentage;

        _currentRow++;
        
        worksheet.Cell($"A{_currentRow}").SetValue("Allocation");
        
        worksheet.Cell($"B{_currentRow}")
            .SetValue(Configuration.MinimalRiskAllocation)
            .Style.NumberFormat.Format = Format.Percentage;

        worksheet.Cell($"C{_currentRow}")
            .SetValue(Configuration.EquityAllocation)
            .Style.NumberFormat.Format = Format.Percentage;
        
         _currentRow++;
         _currentRow++;
         _currentRow++;
        
         worksheet.Cell($"A{_currentRow}").SetValue("Start of First Year");
         worksheet.Cell($"B{_currentRow}")
             .SetValue(Configuration.StartOfFirstYear)
             .Style.NumberFormat.Format = Format.Currency;
         _currentRow++;
         
         worksheet.Cell($"A{_currentRow}").SetValue("Annual Contribution");
         worksheet.Cell($"B{_currentRow}")
             .SetValue(Configuration.AnnualContribution)
             .Style.NumberFormat.Format = Format.Currency;
         _currentRow++;
        
        worksheet.Cell($"A{_currentRow}").SetValue("Increase in contribution");
        worksheet.Cell($"B{_currentRow}")
            .SetValue(Configuration.IncreaseInContribution)
            .Style.NumberFormat.Format = Format.Percentage;
        _currentRow++;
        
        worksheet.Cell($"A{_currentRow}").SetValue("Savings at 67");
        _rowForSavingsAt67 = _currentRow;
        
        _currentRow++;
        _currentRow++;
    }

    private void AddColumnHeaders(IXLWorksheet worksheet, IList<string> headers)
    {
        for (var i = 0; i < headers.Count(); i++)
        {
            worksheet.Cell($"{Columns.ColumnsLetters[i]}{_currentRow}")
                .SetValue(headers[i]);
        }

        _currentRow++;
    }

    private void AddYears(IXLWorksheet worksheet, IList<YearRecord> yearRecords)
    {
        for (var i = 0; i < yearRecords.Count(); i++)
        {
            var propertyInfos = yearRecords[i].GetValues();

            for (var c = 0; c < propertyInfos.Count; c++)
            {
                var yearRecord = yearRecords[i];
                var propertyValue = propertyInfos[c].GetValue(yearRecord, null);
                var cell = worksheet.Cell($"{Columns.ColumnsLetters[c]}{_currentRow}");
                if (propertyInfos[c].PropertyType == typeof(decimal))
                {
                    cell
                        .SetValue((decimal)propertyValue)
                        .Style.NumberFormat.Format = Format.Currency;
                }
                else
                {
                    cell.SetValue(propertyValue.ToString());
                }
            }

            _currentRow++;
        }
    }

    public void WriteSavingsAt67(decimal savingsAt67)
    {
        _worksheet.Cell($"B{_rowForSavingsAt67}")
            .SetValue(savingsAt67)
            .Style.NumberFormat.Format = Format.Currency;
        
    }

    public void Save()
    {
        _workbook.SaveAs("HelloWorld.xlsx");
    }

    public void Dispose()
    {
        _workbook.Dispose();
    }
}