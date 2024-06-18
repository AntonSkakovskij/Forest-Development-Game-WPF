namespace MyForest.Strategy;

public interface IDisplaySubsystemStrategy
{
    public void DisplayAllSubsystemForestItems();
}

public class DisplayTreeSubsystemStrategy : IDisplaySubsystemStrategy
{
    //метод, що виводить в консоль всі елементи типу Tree на карті
    public void DisplayAllSubsystemForestItems()
    {
        Console.WriteLine("TREES LIST:");
        foreach (var cell in ForestMap.ForestMapInstance.pointToCell.Values)
        {
            if (cell.ForestItem is Tree)
            {
                cell.ForestItem.OutputItselfInfo();
                Console.WriteLine("   Position " + cell.CellId);
                Console.WriteLine(new String('_', 50));
            }
        }

    }
}
public class DisplayAnimalSubsystemStrategy : IDisplaySubsystemStrategy
{
    //метод, що виводить в консоль всі елементи типу Animal на карті
    public void DisplayAllSubsystemForestItems()
    {
        Console.WriteLine("ANIMALS LIST:");
        foreach (var cell in ForestMap.ForestMapInstance.pointToCell.Values)
        {
            if (cell.ForestItem is Animal)
            {
                cell.ForestItem.OutputItselfInfo();
                Console.WriteLine("   Position " + cell.CellId);
                Console.WriteLine(new String('_', 50));
            }
        }
        
    }
}