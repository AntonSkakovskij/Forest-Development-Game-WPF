using System.Windows.Media.Imaging;
using MyForest;
using MyForest.ForestItems;
using MyForest.Observer;
using MyForest.Strategy;

interface IForestItem
{
    public void showStats();
}

public abstract class ForestItem: IForestItem, ISubject
{
    protected ForestItemFlyweight _forestItemFlyweight;

    
    protected int health;
    protected int growthLevel;
    
    protected System.Timers.Timer growthTimer;
    
    
    private List<IObserver> _observers = new List<IObserver>();
    
    public void Attach(IObserver observer)
    {
        Console.WriteLine("За " + _forestItemFlyweight.forestItemName +" спостергає " + observer.GetObserverName());
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        Console.WriteLine("Від об'єкта " + _forestItemFlyweight.forestItemName + " прогнано " + observer.GetObserverName());
        this._observers.Remove(observer);
    }

    // Trigger an update in each subscriber.
    public void Notify()
    {
        /*Console.WriteLine(_forestItemFlyweight.forestItemName + ": is growing . . .");*/

        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
    
    
    //встановлення незмінної частини
    public ForestItem(ForestItemFlyweight flyweight)
    {
        _forestItemFlyweight = flyweight;
    }
    
    public int GetCoinsCost()
    { 
        return _forestItemFlyweight.coinCost;
    }
    
    public int GetGrowthLevel()
    { 
        return growthLevel;
    }

    public string GetForestItemName()
    {
        return _forestItemFlyweight.forestItemName;
    }

    public void SetGrowthLevel(int growthLevel)
    {
        this.growthLevel = growthLevel;
        
        for (int i = 1; i < growthLevel; i++)
        {
            health += _forestItemFlyweight.healthIncome;
        }
    }

    // метод, що ініціалізує таймер для кожного елмента цього класу
    protected void StartGrowth()
    {
        growthTimer = new System.Timers.Timer(UserManager.getUserProfile().GetGameSpeed() / _forestItemFlyweight.growthSpeed); 
        growthTimer.Elapsed += (sender, e) => Grow();
        growthTimer.Start();
    }

    protected void StopGrowth()
    {
      growthTimer.Stop();
    }
    
    //метод, що використовується для зміни інтервалу таймера, що впливає на швидкість росту
    public void UpdateGrowthInterval()
    {
        double previousInterval = growthTimer.Interval; // Зберігаємо попереднє значення інтервалу таймера
        growthTimer.Stop();
        double newInterval = UserManager.getUserProfile().GetGameSpeed() / _forestItemFlyweight.growthSpeed; // Отримуємо новий інтервал зі зміненою швидкістю
        growthTimer.Interval = newInterval;
        double remainingTime = previousInterval - growthTimer.Interval; // Вираховуємо залишковий час до наступного виклику Grow()
    
        // Переконуємось, що залишковий час не від'ємний та не більший нового інтервалу
        if (remainingTime > 0 && remainingTime < newInterval)
        {
            // Відновлюємо таймер з збереженої точки
            growthTimer.Start();
            growthTimer.Interval = remainingTime;
        }
        else
        {
            // Якщо залишковий час неправильний, просто запускаємо таймер з новим інтервалом
            growthTimer.Start();
        }
    }
    
    //метод росту 
    protected void Grow()
    {
      foreach (var cell in ForestMap.ForestMapInstance.pointToCell.Values)
      {
          if (cell.ForestItem == this)
          {
              cell.Dispatcher.Invoke(()=>
              {
                  if (growthLevel < 5)
                  {
                      growthLevel += 1;
                      health += _forestItemFlyweight.healthIncome;

                      if (cell.ForestItem is Animal)
                      {
                          UserManager.getUserProfile().AnimalCoinsIncome(cell.ForestItem.GetCoinsCost());
                      }
                      else if (cell.ForestItem is Tree)
                      {
                          UserManager.getUserProfile().TreeCoinsIncome(cell.ForestItem.GetCoinsCost());
                      }
                      
                      
                      //встановлюємо нову картинку 
                      cell.CellBodyImage.Source = DisplayItself();  //можливоя як шаблонний метод
                      Notify();
                  }
                  else
                  {
                      StopGrowth();
                  }
              });
          }
      }
      
    }
    public ForestItem DeepCopy()
    { 
      ForestItem clone = (ForestItem)this.MemberwiseClone();
      clone._forestItemFlyweight.forestItemName = new string(this._forestItemFlyweight.forestItemName);
      return clone;
    }

    //метод для виводу інформації про елемент в вікно при натиску на елемент
    public void OutputItselfInfo(ForestItemInfoWindow infoWindow)
    {
      infoWindow.ForestItemName.Text += _forestItemFlyweight.forestItemName;
      infoWindow.ForestItemHealth.Text +=  health.ToString();
      infoWindow.ForestItemLevel.Text += growthLevel.ToString();
    }
    //метод для виводу інформації в консоль
    public void OutputItselfInfo()
    {
        Console.Write("Name: " + _forestItemFlyweight.forestItemName);
        Console.Write("   Health: " + health);
        Console.Write("   Level: " + growthLevel);
    }
    
    public void Destroy()
    {
        _forestItemFlyweight = null;
        
        if (growthTimer != null && growthTimer.Enabled)
        {
            growthTimer.Stop();
            growthTimer.Dispose(); // Звільняємо ресурси, які використовує таймер
        }
        
        growthTimer = null;
    }

    
    public abstract BitmapImage DisplayItself();


    // метод декоратора
    public virtual void showStats()
    {
        Console.WriteLine(new String('_',40));
        Console.Write("Health: "+this.health);
        Console.Write("Level: "+this.growthLevel);
        Console.Write("Name: "+this._forestItemFlyweight.forestItemName);
    }
}


// базовий декоратор класу ForestItem
class ForestItemDecorator : IForestItem
{
    private IForestItem _forestItem;
    
    public ForestItemDecorator(IForestItem forestItem)
    {
        _forestItem = forestItem;
    }

    public virtual void showStats()
    {
        _forestItem.showStats();
    }
}

//декоратор класу ForestItem для встановлення типу щагрощи на Елемент лісу
class ForestItemProblemDecorator : ForestItemDecorator
{
    private ForestItemThreat _forestItemThreat;
    
    public ForestItemProblemDecorator(IForestItem forestItem, ForestItemThreat forestItemThreat) : base(forestItem)
    {
        _forestItemThreat = forestItemThreat;
    }
    public override void showStats()
    {
        base.showStats();
        Console.Write("Threat: " + _forestItemThreat);
    }
}

public enum ForestItemThreat
{
    Fire,
    Poacher,
    Illness
}

public enum ForestItemsType
{
    Oak,
    Pine,
    Birch,
    Deer,
    Bear,
    Boar
}