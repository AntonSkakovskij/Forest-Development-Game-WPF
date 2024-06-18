namespace MyForest.ForestItems;


//клас, що зберігає властивті незмінної частини класу ForestItem
public class ForestItemFlyweight
{
    public int coinCost { get; set; }
    public int coinIncome { get; set; }
    public int healthIncome { get; set; }
    public int growthSpeed { get; set; }
    public string forestItemName { get; set; }


    public ForestItemFlyweight(int coinCost, int coinIncome, int healthIncome, int growthSpeed, string forestItemName)
    {
        this.coinCost = coinCost;
        this.coinIncome = coinIncome;
        this.healthIncome = healthIncome;
        this.growthSpeed = growthSpeed;
        this.forestItemName = forestItemName;
    }
}