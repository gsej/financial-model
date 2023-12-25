using DocumentFormat.OpenXml.Wordprocessing;

namespace Console;

class Program
{
    static void Main(string[] args)
    {
        var years = new List<YearRecord>();
        YearRecord previousYear = null;
        for (var yearNumber = 0; yearNumber < Configuration.YearsToCover; yearNumber++)
        {
            if (yearNumber == 0)
            {
                var year = new YearRecord(
                    Configuration.StartCalendarYear,
                    Configuration.InitialAge,
                    yearNumber,
                    Configuration.AnnualContribution
                );

                years.Add(year);
                previousYear = year;
            }
            else
            {
                var year = new YearRecord(previousYear);
                ;
                years.Add(year);
                previousYear = year;
            }
        }

        using var excelOutput = new ExcelOutput();
        excelOutput.Output(years);


        // year at age 67:
        var year67 = years.SingleOrDefault(year => year.Age == 67);

        if (year67 != null)
        {
            excelOutput.WriteSavingsAt67(year67.EndOfYear);
            //     System.Console.WriteLine($"At age 67 balance is {year67.EndOfYear}");
        }


        excelOutput.Save();
    }
}