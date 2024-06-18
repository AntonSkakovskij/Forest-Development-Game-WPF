using MyForest.ForestItems;


// фабрики для створення різних тварин
class BearFactory : ForestFactory
{
    public override Animal CreateForestItem()
    {
        
        //отримання незмінної частини об'єкта за допомогою Фабрики легковика
        ForestItemFlyweight forestItemFlyweight =
            UserManager.getUserProfile().ForestItemFlyweightFactory.Create(ForestItemsType.Bear);

        return new Bear(forestItemFlyweight);
    }
}
class DeerFactory : ForestFactory
{
    public override Animal CreateForestItem()
    {
        //отримання незмінної частини об'єкта за допомогою Фабрики легковика
        ForestItemFlyweight forestItemFlyweight =
            UserManager.getUserProfile().ForestItemFlyweightFactory.Create(ForestItemsType.Deer);

        return new Deer(forestItemFlyweight);
    }
}
class BoarFactory : ForestFactory
{
    public override Animal CreateForestItem()
    {
        //отримання незмінної частини об'єкта за допомогою Фабрики легковика
        ForestItemFlyweight forestItemFlyweight =
            UserManager.getUserProfile().ForestItemFlyweightFactory.Create(ForestItemsType.Boar);

        return new Boar(forestItemFlyweight);
    }
}