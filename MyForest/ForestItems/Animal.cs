// Абстрактний клас для всіх тварир

using System.Windows.Media.Imaging;
using MyForest.ForestItems;


//базовий клас для видів тварин
abstract class Animal: ForestItem
{
    protected Animal(ForestItemFlyweight flyweight):base(flyweight)
    {
    }
}


class Bear : Animal
{
    //функція передає в базовий клас незмінну частину об'єкта
    public Bear(ForestItemFlyweight flyweight) : base(flyweight)
    {
        growthLevel = 1;
        health = 40;

        StartGrowth();
    }

    //метод, що повертає картинку в залежності від рівня тварини
    public override BitmapImage DisplayItself()
    {
        Uri imagePath = null;
        
        switch (growthLevel)
        {
            case 1:
                imagePath = new Uri("./Resources/animals/bear/bear1.png", UriKind.Relative);
                break;
            case 2:
                imagePath = new Uri("./Resources/animals/bear/bear2.png", UriKind.Relative);
                break;
            case 3:
                imagePath = new Uri("./Resources/animals/bear/bear3.png", UriKind.Relative);
                break;
            case 4:
                imagePath = new Uri("./Resources/animals/bear/bear4.png", UriKind.Relative);
                break;
            case 5:
                imagePath = new Uri("./Resources/animals/bear/bear5.png", UriKind.Relative);
                break;
                
        }
        return new BitmapImage(imagePath);
    }
}

class Deer : Animal
{
    //функція передає в базовий клас незмінну частину об'єкта
    public Deer(ForestItemFlyweight flyweight) : base(flyweight)
    {
        growthLevel = 1;
        health = 15;
        
        StartGrowth();
    }
    
    //метод, що повертає картинку в залежності від рівня тварини
    public override BitmapImage DisplayItself()
    {
        Uri imagePath = null;
        
        switch (growthLevel)
        {
            case 1:
                imagePath = new Uri("./Resources/animals/deer/deer1.png", UriKind.Relative);
                break;
            case 2:
                imagePath = new Uri("./Resources/animals/deer/deer2.png", UriKind.Relative);
                break;
            case 3:
                imagePath = new Uri("./Resources/animals/deer/deer3.png", UriKind.Relative);
                break;
            case 4:
                imagePath = new Uri("./Resources/animals/deer/deer4.png", UriKind.Relative);
                break;
            case 5:
                imagePath = new Uri("./Resources/animals/deer/deer5.png", UriKind.Relative);
                break;
                
        }
        return new BitmapImage(imagePath);
    }
}


class Boar : Animal
{
    //функція передає в базовий клас незмінну частину об'єкта
    public Boar(ForestItemFlyweight flyweight) : base(flyweight)
    {
        growthLevel = 1;
        health = 25;
        
        StartGrowth();
    }
    
    //метод, що повертає картинку в залежності від рівня тварини
    public override BitmapImage DisplayItself()
    {
        Uri imagePath = null;
        
        switch (growthLevel)
        {
            case 1:
                imagePath = new Uri("./Resources/animals/boar/boar1.png", UriKind.Relative);
                break;
            case 2:
                imagePath = new Uri("./Resources/animals/boar/boar2.png", UriKind.Relative);
                break;
            case 3:
                imagePath = new Uri("./Resources/animals/boar/boar3.png", UriKind.Relative);
                break;
            case 4:
                imagePath = new Uri("./Resources/animals/boar/boar4.png", UriKind.Relative);
                break;
            case 5:
                imagePath = new Uri("./Resources/animals/boar/boar5.png", UriKind.Relative);
                break;
        }
        return new BitmapImage(imagePath);
    }
}