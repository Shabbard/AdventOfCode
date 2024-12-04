using FluentAssertions;

namespace Day1;

public class HistorianHysteria
{
    private readonly List<int> _testCaseList1 = [3, 4, 2, 1, 3, 3];
    private readonly List<int> _testCaseList2 = [4, 3, 5, 3, 9, 3];

    [Test]
    public void Part1Test()
    {
        var totalDistance = GetTotalDistance(_testCaseList1, _testCaseList2);

        totalDistance.Should().Be(11);
    }

    [Test]
    public void Part2Test()
    {
        var totalDistance = GetSimilarityScore(_testCaseList1, _testCaseList2);

        totalDistance.Should().Be(31);
    }

    [Test]
    public void Part1Solution()
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        var lines = File.ReadAllLines("input");
        foreach (var line in lines )
        {
            var col = line.Split().Where(x => !string.IsNullOrWhiteSpace(x));
            list1.Add(int.Parse(col.First()));
            list2.Add(int.Parse(col.Last()));
        }

        var totalDistance = GetTotalDistance(list1, list2);

        Console.WriteLine(totalDistance);
    }

    [Test]
    public void Part2Solution()
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        var lines = File.ReadAllLines("input");
        foreach (var line in lines )
        {
            var col = line.Split().Where(x => !string.IsNullOrWhiteSpace(x));
            list1.Add(int.Parse(col.First()));
            list2.Add(int.Parse(col.Last()));
        }

        var totalDistance = GetSimilarityScore(list1, list2);

        Console.WriteLine(totalDistance);
    }

    private static int GetTotalDistance(List<int> list1, List<int> list2)
    {
        var orderedList1 = list1.Order().ToList();
        var orderedList2 = list2.Order().ToList();

        return orderedList1.Select((t, i) => int.Abs(orderedList1.ElementAt(i) - orderedList2.ElementAt(i))).Sum();
    }

    private static int GetSimilarityScore(List<int> list1, List<int> list2)
    {
        return (from elementAt in list1.Select((t1, i) => (int)list1.ElementAt(i)) let appearsInList2Count = list2.Count(x => x.Equals(elementAt)) select appearsInList2Count * elementAt).Sum();
    }
}
