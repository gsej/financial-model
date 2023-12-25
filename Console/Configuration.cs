
namespace Console;

public static class Configuration
{
    public static int YearsToCover = 45;
    public static int StartCalendarYear = 2024;
    public static int InitialAge = 23;

    public static decimal StartOfFirstYear = 4000;
    public static decimal AnnualContribution = 4000;
    public static decimal IncreaseInContribution = 0.03m;

    public static decimal MinimalRiskAllocation = 0.5m;
    public static decimal MinimalRiskGrowth = 0.005m; // i.e. 0.5%    

    public static decimal EquityAllocation = 1 - MinimalRiskAllocation;
    public static decimal EquityGrowth = 0.05m; // i.e. 5%}

}