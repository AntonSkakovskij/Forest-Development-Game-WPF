using MyForest.ForestItems;

namespace MyForest.Factrories;

public class ForestItemFlyweightFactory
{
    //контейнер, що зберігає незмінні частини об'єкту в залежності від типу об'єкту
    private readonly Dictionary<ForestItemsType, ForestItemFlyweight> _factionToCosmetics;

    public ForestItemFlyweightFactory()
    {
        _factionToCosmetics = new Dictionary<ForestItemsType, ForestItemFlyweight>();
    }
    
    // метод створює/повертає  незмінні частини об'єкту(використовується для економії пам'яті)
    public ForestItemFlyweight Create(ForestItemsType factionItemsType)
    {
        if (!_factionToCosmetics.ContainsKey(factionItemsType))
        {
            switch (factionItemsType)
            {
                case ForestItemsType.Oak:
                    _factionToCosmetics.Add(factionItemsType, new ForestItemFlyweight(20,8,20,2,"Oak"));
                    break;
                case ForestItemsType.Pine:
                    _factionToCosmetics.Add(factionItemsType, new ForestItemFlyweight(15,6,5,3,"Pine"));
                    break;
                case ForestItemsType.Birch:
                    _factionToCosmetics.Add(factionItemsType, new ForestItemFlyweight(10,4,10,4,"Birch"));
                    break;
                case ForestItemsType.Bear:
                    _factionToCosmetics.Add(factionItemsType, new ForestItemFlyweight(30,8,20,3,"Bear"));
                    break;
                case ForestItemsType.Deer:
                    _factionToCosmetics.Add(factionItemsType, new ForestItemFlyweight(20,6,10,5,"Deer"));
                    break;
                case ForestItemsType.Boar:
                    _factionToCosmetics.Add(factionItemsType, new ForestItemFlyweight(25,4,17,4,"Boar"));
                    break;
                default:
                    throw new Exception("unknown faction");
            }
        }
        return _factionToCosmetics[factionItemsType];
    }
}