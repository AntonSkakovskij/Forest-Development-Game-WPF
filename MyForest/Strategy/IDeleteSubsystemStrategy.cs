namespace MyForest.Strategy;

public interface IDeleteSubsystemStrategy
{
    public void DeleteAllSubsystemForestItems();
}

public class DeleteAnimalSubsystemStrategy : IDeleteSubsystemStrategy
{
    //метод, що видаляє всі елементи типу Animal на карті
    public void DeleteAllSubsystemForestItems()
    {
        foreach (var cell in ForestMap.ForestMapInstance.pointToCell.Values)
        {
            if (cell.ForestItem is Animal)
            {
                cell.ForestItem.Destroy();
                cell.ForestItem = null;
                cell.CellBodyImage.Source = null;
                cell.IsOccupied = false;
            }
        }
    }
}

public class DeleteTreeSubsystemStrategy : IDeleteSubsystemStrategy
{
    //метод, що видаляє всі елементи типу Tree на карті
    public void DeleteAllSubsystemForestItems()
    {
        
        foreach (var cell in ForestMap.ForestMapInstance.pointToCell.Values)
        {
            if (cell.ForestItem is Tree)
            {
                cell.ForestItem.Destroy();
                cell.ForestItem = null;
                cell.CellBodyImage.Source = null;
                cell.IsOccupied = false;
            }
        }
    }
}
