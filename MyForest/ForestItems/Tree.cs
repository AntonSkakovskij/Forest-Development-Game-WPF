// Абстрактний клас для всіх дерев

using System.Windows.Media.Imaging;
using MyForest.ForestItems;

//базовий клас для видів дерев
public abstract class Tree: ForestItem
{
    protected Tree(ForestItemFlyweight flyweight):base(flyweight)
    {
    }
}

class OakTree : Tree
{
    //функція передає в базовий клас незмінну частину об'єкта
    public OakTree(ForestItemFlyweight flyweight) : base(flyweight)
    {
        growthLevel = 1;
        health = 20;
        
        StartGrowth();
    }

    //метод, що повертає картинку в залежності від рівня дерева
    public override BitmapImage DisplayItself()
    {
        Uri imagePath = null;
        
        switch (growthLevel)
        {
            case 1:
                imagePath = new Uri("./Resources/trees/oak/oak1.png", UriKind.Relative);
                break;
            case 2:
                imagePath = new Uri("./Resources/trees/oak/oak2.png", UriKind.Relative);
                break;
            case 3:
                imagePath = new Uri("./Resources/trees/oak/oak3.png", UriKind.Relative);
                break;
            case 4:
                imagePath = new Uri("./Resources/trees/oak/oak4.png", UriKind.Relative);
                break;
            case 5:
                imagePath = new Uri("./Resources/trees/oak/oak5.png", UriKind.Relative);
                break;
                
        }
        return new BitmapImage(imagePath);
    }
}

class BirchTree : Tree
{
    //функція передає в базовий клас незмінну частину об'єкта
    public BirchTree(ForestItemFlyweight flyweight) : base(flyweight)
    {
        growthLevel = 1;
        health = 10;
        
        StartGrowth();
    }
    
    //метод, що повертає картинку в залежності від рівня дерева
    public override BitmapImage DisplayItself()
    {
        Uri imagePath = null;
        
        switch (growthLevel)
        {
            case 1:
                imagePath = new Uri("./Resources/trees/birch/birch1.png", UriKind.Relative);
                break;
            case 2:
                imagePath = new Uri("./Resources/trees/birch/birch2.png", UriKind.Relative);
                break;
            case 3:
                imagePath = new Uri("./Resources/trees/birch/birch3.png", UriKind.Relative);
                break;
            case 4:
                imagePath = new Uri("./Resources/trees/birch/birch4.png", UriKind.Relative);
                break;
            case 5:
                imagePath = new Uri("./Resources/trees/birch/birch5.png", UriKind.Relative);
                break;
                
        }
        return new BitmapImage(imagePath);
    }
}

class PineTree : Tree
{
    //функція передає в базовий клас незмінну частину об'єкта
    public PineTree(ForestItemFlyweight flyweight) : base(flyweight)
    {
        growthLevel = 1;
        health = 15;
        
        
        StartGrowth();
    }
    
    //метод, що повертає картинку в залежності від рівня дерева
    public override BitmapImage DisplayItself()
    {
        Uri imagePath = null;
        
        switch (growthLevel)
        {
            case 1:
                imagePath = new Uri("./Resources/trees/pine/pine1.png", UriKind.Relative);
                break;
            case 2:
                imagePath = new Uri("./Resources/trees/pine/pine2.png", UriKind.Relative);
                break;
            case 3:
                imagePath = new Uri("./Resources/trees/pine/pine3.png", UriKind.Relative);
                break;
            case 4:
                imagePath = new Uri("./Resources/trees/pine/pine4.png", UriKind.Relative);
                break;
            case 5:
                imagePath = new Uri("./Resources/trees/pine/pine5.png", UriKind.Relative);
                break;
        }
        return new BitmapImage(imagePath);
    }
}


