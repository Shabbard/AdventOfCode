using FluentAssertions;

namespace Day2;

public class RedNosedReports
{
    private static IEnumerable<Report> GetTestCases()
    {
        yield return new Report([7,6,4,2,1], true) ;
        yield return new Report([1,2,7,8,9], false) ;
        yield return new Report([9,7,6,2,1], false) ;
        yield return new Report([1,3,2,4,5], false) ;
        yield return new Report([8,6,4,4,1], false) ;
        yield return new Report([1,3,6,7,9], true) ;
    }

    [Test]
    [TestCaseSource(nameof(GetTestCases))]
    public void TestIndividualReports(Report report)
    {
        IsReportSafe(report).Should().Be(report.Safe);
    }

    [Test]
    public void Part1Solution()
    {
        var lines = File.ReadAllLines("input");

        var list = lines.Select(line => line.Split().Where(x => !string.IsNullOrWhiteSpace(x))).Select(row => new Report(row.Select(int.Parse).ToList(), false)).ToList();

        var totalDistance = GetSafeReports(list);

        Console.WriteLine(totalDistance);
    }

    private int GetSafeReports(List<Report> reports)
    {
        return reports.Count(IsReportSafe);
    }

    private static bool IsReportSafe(Report report)
    {
        return (LevelsAllIncreasing(report.Levels) ^ LevelsAllDecreasing(report.Levels)) && DifferenceInLevels(report.Levels);
    }

    private static bool LevelsAllIncreasing(List<int> levels)
    {
        for (var i = 0; i < levels.Count - 1; i++)
        {
            if (levels[i] > levels.ElementAt(i + 1))
            {
                return false;
            }
        }

        return true;
    }

    private static bool LevelsAllDecreasing(List<int> levels)
    {
        for (var i = 0; i < levels.Count - 1; i++)
        {
            if (levels[i] < levels.ElementAt(i + 1))
            {
                return false;
            }
        }

        return true;
    }

    private static bool DifferenceInLevels(List<int> levels)
    {
        for (var i = 0; i < levels.Count - 1; i++)
        {
            if (int.Abs(levels[i] - levels.ElementAt(i + 1)) > 3 || int.Abs(levels[i] - levels.ElementAt(i + 1)) < 1)
            {
                return false;
            }
        }

        return true;
    }
}
