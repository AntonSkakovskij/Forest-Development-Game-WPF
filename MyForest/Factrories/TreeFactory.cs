// Фабрика для створення дубів

using MyForest.ForestItems;

// фабрики для створення різних дереп
class OakTreeFactory : ForestFactory
{
    public override Tree CreateForestItem()
    {
        //отримання незмінної частини об'єкта за допомогою Фабрики легковика
        ForestItemFlyweight forestItemFlyweight =
            UserManager.getUserProfile().ForestItemFlyweightFactory.Create(ForestItemsType.Oak);
        return new OakTree(forestItemFlyweight);
    }
}

// Фабрика для створення сосонь
class PineTreeFactory : ForestFactory
{
    public override Tree CreateForestItem()
    {
        //отримання незмінної частини об'єкта за допомогою Фабрики легковика
        ForestItemFlyweight forestItemFlyweight =
            UserManager.getUserProfile().ForestItemFlyweightFactory.Create(ForestItemsType.Pine);
        return new PineTree(forestItemFlyweight);
    }
}

// Фабрика для створення беріз
class BirchTreeFactory : ForestFactory
{
    public override Tree CreateForestItem()
    {
        //отримання незмінної частини об'єкта за допомогою Фабрики легковика
        ForestItemFlyweight forestItemFlyweight =
            UserManager.getUserProfile().ForestItemFlyweightFactory.Create(ForestItemsType.Birch);
        return new BirchTree(forestItemFlyweight);
    }
}  
