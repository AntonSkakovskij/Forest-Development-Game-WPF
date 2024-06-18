namespace MyForest.Observer;

public interface IObserver
{
    string GetObserverName();
    void Update(ISubject subject);
}

public interface ISubject
{
    void Attach(IObserver observer);
    
    void Detach(IObserver observer);
    
    void Notify();
}

class Poacher : IObserver
{
    private string PoacherNeme;

    public Poacher(ObserverName name)
    {
        PoacherNeme = name.ToString();
    }
    public string GetObserverName()
    {
        return "Браконьєр " + PoacherNeme;
    }

    public void Update(ISubject subject)
    {            
        if ((subject as Animal).GetGrowthLevel() >= 2)
        {
            string message = "Давайно зловимо цю тваринку";
            ObserverActionWindow window = new ObserverActionWindow(this ,message, subject);
            window.ShowDialog();
        }
    }
}

class Woodcutter : IObserver
{
    private string WoodcutterNeme;

    public Woodcutter(ObserverName name)
    {
        WoodcutterNeme = name.ToString();
    }
    public string GetObserverName()
    {
        return "Лісоруб " + WoodcutterNeme;
    }

    public void Update(ISubject subject)
    {
        if ((subject as Tree).GetGrowthLevel() > 3)
        {
             string message = "Хороша нагода зрубати дерево";
            ObserverActionWindow window = new ObserverActionWindow(this ,message, subject);
            window.ShowDialog();
        }
    }
}

public enum ObserverName
{
    Петро,
    Василь,
    Андрій,
    Коля,
    Олег,
    Костя,
    Антон,
    Іван,
    Юра,
    Максим
}