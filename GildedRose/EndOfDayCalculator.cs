namespace GildedRoseKata;

public static class EndOfDayCalculator
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePassesATafkal80Etc = "Backstage passes to a TAFKAL80ETC concert";
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

    public static void Update(Item item)
    {
        if (IsConjured(item))
        {
            UpdateConjured(item);
        }
        else
        {
            UpdateNormalBrieBackstageSulfuras(item);
        }
    }

    private static bool IsConjured(Item item)
    {
        const string conjuredManaCake = "Conjured Mana Cake";
        return item.Name == conjuredManaCake;
    }

    private static void UpdateNormalBrieBackstageSulfuras(Item item)
    {
        if (item.Name != AgedBrie && item.Name != BackstagePassesATafkal80Etc)
        {
            if (item.Quality > 0)
            {
                if (item.Name != SulfurasHandOfRagnaros)
                {
                    item.Quality -= 1;
                }
            }
        }
        else
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.Name == BackstagePassesATafkal80Etc)
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }

        if (item.Name != SulfurasHandOfRagnaros)
        {
            item.SellIn -= 1;
        }

        if (item.SellIn < 0)
        {
            if (item.Name != AgedBrie)
            {
                if (item.Name != BackstagePassesATafkal80Etc)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != SulfurasHandOfRagnaros)
                        {
                            item.Quality -= 1;
                        }
                    }
                }
                else
                {
                    item.Quality -= item.Quality;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }
    }
    
    private static void UpdateConjured(Item item)
    {
        item.SellIn -= 1;
        item.Quality -= item.SellIn >= 0 ? 2 : 4;
        if (item.Quality < 0) item.Quality = 0;
    }
}