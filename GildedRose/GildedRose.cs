using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePassesATafkal80Etc = "Backstage passes to a TAFKAL80ETC concert";
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            UpdateItem(item);
        }
    }

    private static void UpdateItem(Item item)
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
}