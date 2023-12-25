using System.Reflection;
using System.Runtime.CompilerServices;

namespace Console;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public sealed class OrderAttribute : Attribute
{
    private readonly int order_;

    public OrderAttribute([CallerLineNumber] int order = 0)
    {
        order_ = order;
    }

    public int Order
    {
        get { return order_; }
    }
}

public class YearRecord
{
    [Order] public int CalendarYear { get; }

    [Order] public int Age { get; }

    [Order] public int YearNumber { get; }

    [Order] public decimal PriorYear { get; }

    [Order] public decimal AnnualContribution { get; }

    [Order] public decimal StartOfYear { get; }

    [Order] public decimal InvestmentReturn { get; }

    [Order] public decimal EndOfYear { get; }

    [Order] public decimal MinimalRiskAllocationPercentage { get; }

    [Order] public decimal EquityAllocationPercentage { get; }

    [Order] public decimal MinimalRiskAllocationAmount { get; }

    [Order] public decimal EquityAllocationAmount { get; }


    public YearRecord(int calendarYear, int age, int yearNumber, decimal annualContribution)
    {
        Age = age;
        YearNumber = yearNumber;
        CalendarYear = calendarYear;
        AnnualContribution = annualContribution;

        StartOfYear = PriorYear + AnnualContribution;
        
        MinimalRiskAllocationPercentage = Configuration.MinimalRiskAllocation;
        MinimalRiskAllocationAmount = MinimalRiskAllocationPercentage * StartOfYear;

        EquityAllocationPercentage = Configuration.EquityAllocation;
        EquityAllocationAmount = EquityAllocationPercentage * StartOfYear;
        
        InvestmentReturn = MinimalRiskAllocationAmount * Configuration.MinimalRiskGrowth + 
                           EquityAllocationAmount * Configuration.EquityGrowth;
        
        EndOfYear = StartOfYear + InvestmentReturn;
    }

    public YearRecord(YearRecord previousYear)
    {
        // TODO: some of these fields should be rendered in the spreadsheet as calculated cells
        /// rather than as ones calculated in code. Perhaps
        Age = previousYear.Age + 1;
        YearNumber = previousYear.YearNumber + 1;
        CalendarYear = previousYear.CalendarYear + 1;
        AnnualContribution = previousYear.AnnualContribution * (1 + Configuration.IncreaseInContribution);
        PriorYear = previousYear.EndOfYear;

        StartOfYear = PriorYear + AnnualContribution;
        
        MinimalRiskAllocationPercentage = Configuration.MinimalRiskAllocation;
        MinimalRiskAllocationAmount = MinimalRiskAllocationPercentage * StartOfYear;

        EquityAllocationPercentage = Configuration.EquityAllocation;
        EquityAllocationAmount = EquityAllocationPercentage * StartOfYear;
        
        InvestmentReturn = MinimalRiskAllocationAmount * Configuration.MinimalRiskGrowth + 
                           EquityAllocationAmount * Configuration.EquityGrowth;

        EndOfYear = StartOfYear + InvestmentReturn;
    }

    public static IList<string> GetHeaders()
    {
        var properties = from property in typeof(YearRecord).GetProperties()
            where Attribute.IsDefined(property, typeof(OrderAttribute))
            orderby ((OrderAttribute)property
                .GetCustomAttributes(typeof(OrderAttribute), false)
                .Single()).Order
            select property;

        var headers = properties.Select(property => property.Name).ToList();
        return headers;
    }

    public IList<PropertyInfo> GetValues()
    {
        var properties = from property in typeof(YearRecord).GetProperties()
            where Attribute.IsDefined(property, typeof(OrderAttribute))
            orderby ((OrderAttribute)property
                .GetCustomAttributes(typeof(OrderAttribute), false)
                .Single()).Order
            select property;

        return properties.ToList();
        //
        // var values = new List<string>();
        //
        // foreach (var property in properties)
        // {
        //     if (property.PropertyType == typeof(decimal))
        //     {
        //         decimal d = (decimal)property.GetValue(this, null);
        //         values
        //             .Add("X");
        //     }
        //     else
        //     {
        //         values.Add(property.GetValue(this, null).ToString());
        //     }
        //     
        // }
        //
        // return values;
    }
}