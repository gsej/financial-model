// using System.Text.Json;
//
// namespace Console;
//
// public static class DecimalExtensions
// {
//     public static string ToRoundedString(this decimal d, int decimalPlaces) {
//         return d.ToString("N" + decimalPlaces);
//     }
// }
//
// public interface IOutputYear
// {
//     public IEnumerable<string> Output(IEnumerable<YearRecord> years);
// }
//
// public class JsonOutputYear : IOutputYear
// {
//     public IEnumerable<string> Output(IEnumerable<YearRecord> years)
//     {
//         var output = new List<string>();
//         var jsonOptions = new JsonSerializerOptions
//         {
//             WriteIndented = true
//         };
//
//         var json = JsonSerializer.Serialize(years, jsonOptions);
//         output.Add(json);
//         System.Console.WriteLine(json);
//         return output;
//     }
//     
// }
//
// public class CsvOutputYear : IOutputYear
// {
//     public IEnumerable<string> Output(IEnumerable<YearRecord> years)
//     {
//         var outputYears = new List<string>();
//         outputYears.Add(Header());
//         foreach (var year in years)
//         {
//             outputYears.Add(Output(year));
//         }
//
//         foreach (var year in outputYears)
//         {
//             System.Console.WriteLine(year);
//         }
//         return outputYears;
//         
//     }
//
//     private string Header()
//     {
//         var output =
//             string.Format("{0,12},", nameof(YearRecord.CalendarYear)) +
//             string.Format("{0,4},", nameof(YearRecord.Age)) +
//             string.Format("{0,12},", nameof(YearRecord.YearNumber)) +
//          //   string.Format("{0,12},", nameof(YearRecord.PriorYear)) +
//             string.Format("{0,18},", nameof(YearRecord.AnnualContribution)) +
//           //  string.Format("{0,11},", nameof(YearRecord.StartOfYear)) +
//          //   string.Format("{0,16},", nameof(YearRecord.InvestmentReturn)) +
//         //    string.Format("{0,11},", nameof(YearRecord.EndOfYear)) +
//             string.Format("{0,9},", nameof(YearRecord.MinimalRiskAllocationPercentage)) +
//             string.Format("{0,11}", nameof(YearRecord.EquityAllocationPercentage));//+
//         //    string.Format("{0,9},", nameof(YearRecord.MinimalRiskAllocationAmount)) +
//         //    string.Format("{0,11},", nameof(YearRecord.EquityAllocationAmount));
//         
//         return output;
//     }
//
//     private string Output(YearRecord year)
//     {
//         var output =
//             string.Format("{0,12},", year.CalendarYear) +
//             string.Format("{0,4},", year.Age) +
//             string.Format("{0,12},", year.YearNumber) +
//           //  string.Format("{0,12},", year.PriorYear.ToRoundedString(2)) +
//             string.Format("{0,18},", year.AnnualContribution.ToRoundedString(2)) +
//            // string.Format("{0,11},", year.StartOfYear.ToRoundedString(2)) +
//            // string.Format("{0,16},", year.InvestmentReturn.ToRoundedString(2)) +
//             //string.Format("{0,11},", year.EndOfYear.ToRoundedString(2)) +
//             string.Format("{0,9},", year.MinimalRiskAllocationPercentage.ToRoundedString(2)) +
//             string.Format("{0,11}", year.EquityAllocationPercentage.ToRoundedString(2));// +
//         //    string.Format("{0,9},", year.MinimalRiskAllocationAmount.ToRoundedString(2)) +
//         //    string.Format("{0,11},", year.EquityAllocationAmount.ToRoundedString(2));
//
//         return output;
//     }
//     
//     
// }
//
