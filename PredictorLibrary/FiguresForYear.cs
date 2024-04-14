using System.ComponentModel;
using System.Data;
using System.Text.Json;
using System.Text.Json.Nodes;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

namespace PredictorLibrary;

public class MoneyConverter : DefaultTypeConverter
{
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        if (value is double d)
        {
            return d.ToString("F2");
        }
        
        return base.ConvertToString(value, row, memberMapData); 
   }
}


public class PercentageConverter : DefaultTypeConverter
{
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        if (value is double d)
        {
            return d.ToString("P1");
        }
        
        return base.ConvertToString(value, row, memberMapData); 
    }
}

public class FiguresForYearMap : ClassMap<FiguresForYear>
{
    public FiguresForYearMap()
    {
        Map(f => f.Year).Name("Year (Jan to Dec)");
        Map(f => f.Age);
        Map(f => f.Index).Name("Number of years");
        Map(f => f.AmountAtEndOfPriorYear).Name("End of prior year").TypeConverter<MoneyConverter>();
        Map(f => f.AnnualContribution).Name("Annual contribution");
        Map(f => f.AmountAtStartOfYear).Name("Start of year").TypeConverter<MoneyConverter>();
        Map(f => f.ReturnAmount).Name("Investment return").TypeConverter<MoneyConverter>();
        Map(f => f.AmountAtEndOfYear).Name("End of year").TypeConverter<MoneyConverter>();
        Map(f => f.Blank0).Name("");
        Map(f => f.MinimalRiskAllocation).Name("Minimal Risk Allocation").TypeConverter<PercentageConverter>();
        Map(f => f.GrowthAllocation).Name("Growth Allocation").TypeConverter<PercentageConverter>();
        Map(f => f.Blank1).Name("");
        Map(f => f.MinimalRiskAmount).Name("Minimal Risk Amount").TypeConverter<MoneyConverter>();
        Map(f => f.GrowthAmount).Name("Growth Amount").TypeConverter<MoneyConverter>();
        
        Map(f => f.Blank2).Name("");
        Map(f => f.MinimalRiskReturn).Name("Minimal Risk Return").TypeConverter<PercentageConverter>();
        Map(f => f.GrowthReturn).Name("Growth Return").TypeConverter<PercentageConverter>();
        
        Map(f => f.Blank3).Name("");
        Map(f => f.MinimalRiskReturnAmount).Name("Minimal Risk Return Amount").TypeConverter<MoneyConverter>();
        Map(f => f.GrowthReturnAmount).Name("Growth Return Amount").TypeConverter<MoneyConverter>();
        
    }
}

public record FiguresForYear(
    int Index,
    int Year,
    int Age,
    double AmountAtEndOfPriorYear,
    double AnnualContribution, // Notionally applied at the start of each year
    double AmountAtStartOfYear,
    double MinimalRiskAllocation,
    double GrowthAllocation,
    double MinimalRiskReturn,
    double GrowthReturn // Notionally applied at end of each year
)
{
    public string Blank0 => string.Empty;
    public string Blank1 => string.Empty;
    public string Blank2 => string.Empty;
    public string Blank3 => string.Empty;
    public string Blank4 => string.Empty;
    public string Blank5 => string.Empty;

    public double MinimalRiskAmount => AmountAtStartOfYear * MinimalRiskAllocation;
    public double GrowthAmount => AmountAtStartOfYear * GrowthAllocation;
    
    public double MinimalRiskReturnAmount => MinimalRiskAmount * MinimalRiskReturn;
    public double GrowthReturnAmount => GrowthAmount * GrowthReturn;
    
    public double ReturnAmount => MinimalRiskReturnAmount + GrowthReturnAmount;

    public double AmountAtEndOfYear => AmountAtStartOfYear + ReturnAmount;
}