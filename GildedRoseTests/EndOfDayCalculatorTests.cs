using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class EndOfDayCalculatorTests
{
    [Test]
    public void Update_NormalItemBeforeSellDate()
    {
        var testItem = new Item { Name = "Normal Item", SellIn = 1, Quality = 10 };
        EndOfDayCalculator.Update(testItem);

        Assert.That(testItem.SellIn, Is.EqualTo(0));
        Assert.That(testItem.Quality, Is.EqualTo(9));
    }

    [Test]
    public void Update_NormalItemAfterSellDate()
    {
        var testItem = new Item { Name = "Normal Item", SellIn = 0, Quality = 10 };
        EndOfDayCalculator.Update(testItem);

        Assert.That(testItem.SellIn, Is.EqualTo(-1));
        Assert.That(testItem.Quality, Is.EqualTo(8));
    }
}