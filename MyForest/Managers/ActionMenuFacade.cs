using System.Security.Cryptography;
using System.Windows;
using MyForest.Strategy;

namespace MyForest.Managers;


// клас Фасад, що реалізує методи виводу, видалення та генерації об'єктів на карті
public class ActionMenuFacade
{
    private Subsystem treeSubsystem;
    private Subsystem animalSubsystem;

    public ActionMenuFacade(Subsystem treeSubsystem, Subsystem animalSubsystem)
    {
        this.treeSubsystem = treeSubsystem;
        this.animalSubsystem = animalSubsystem;
    }
   
    //метод, що видаляє всі елементи, а також встановлює дефолтні значення профіля
    public void ResetGameProgress()
    {
        treeSubsystem.DeleteAllSubsystemForestItems();
        animalSubsystem.DeleteAllSubsystemForestItems();
        UserManager.getUserProfile().SetDefaultValues();
        
    }
    
    //метод, що виводить всі елементи в консоль
    public void DisplayAllForestItems()
    {
        animalSubsystem.DisplayAllSubsystemForestItems();
        treeSubsystem.DisplayAllSubsystemForestItems();
    }
    
    //метод, що рандомно генерує елементи різного рівня на карті 
    public void GenerateForest()
    {
        ResetGameProgress();
        
        foreach (var cell in ForestMap.ForestMapInstance.pointToCell.Values)
        {
            int random = RandomNumberGenerator.GetInt32(1, 4);
            int random2;
            ForestFactory ForestFactory = null;
            switch (random)
            {
                case 1:
                    random2 = RandomNumberGenerator.GetInt32(1, 3);
                    switch (random2)
                    {
                        case 1:
                            ForestFactory = new PineTreeFactory();
                            break;
                        case 2:
                            ForestFactory = new BirchTreeFactory();
                            break;
                        case 3:
                            ForestFactory = new OakTreeFactory();
                            break;
                    }
                    break;
                case 2:
                    random2 = RandomNumberGenerator.GetInt32(1, 7);
                    switch (random2)
                    {
                        case 1:
                            ForestFactory = new BearFactory();
                            break;
                        case 2:
                            ForestFactory = new BoarFactory();
                            break;
                        case 3:
                            ForestFactory = new DeerFactory();
                            break;
                        default:
                            cell.ForestItem = null;
                            break;
                    }
                    break;
                default:
                    cell.ForestItem = null;
                    break;
            }

            if (ForestFactory != null)
            {
                
                cell.ForestItem = ForestFactory.CreateForestItem();

                if (cell.ForestItem is Animal)
                {
                    random2 = RandomNumberGenerator.GetInt32(1, 3);
                    cell.ForestItem.SetGrowthLevel(random2);
                }
                else if(cell.ForestItem is Tree)
                {
                    random2 = RandomNumberGenerator.GetInt32(1, 4);
                    cell.ForestItem.SetGrowthLevel(random2);
                }
                cell.CellBodyImage.Source = cell.ForestItem.DisplayItself();
                cell.IsOccupied = true;
            }
        }
        
        DisplayAllForestItems();
    }
}


/// <summary>
/// Не використовувати цей код при реальній реалізаціЇ
/// В даному фрагментів застосовано демонстраційни приклад реалізації поведінкового патерну Стратегія
/// </summary>
public class Subsystem
{
    protected IDeleteSubsystemStrategy _deleteSubsystemStrategy;
    protected IDisplaySubsystemStrategy _displaySubsystemStrategy;
    
    public void SetDeleteStrategy(IDeleteSubsystemStrategy strategy)
    {
        _deleteSubsystemStrategy = strategy;
    }
    
    public void SetDisplayStrategy(IDisplaySubsystemStrategy strategy)
    {
        _displaySubsystemStrategy = strategy;
    }

    // Метод видалення, який викликається залежно від обраної стратегії
    public void DeleteAllSubsystemForestItems()
    {
        // Перевірка на наявність стратегії
        if (_deleteSubsystemStrategy != null)
        {
            _deleteSubsystemStrategy.DeleteAllSubsystemForestItems();
        }
        else
        {
            // Викидання винятку або дефолтна поведінка
        }
    }
    
    // Метод виведення, який викликається залежно від обраної стратегії
    public void DisplayAllSubsystemForestItems()
    {
        // Перевірка на наявність стратегії
        if (_displaySubsystemStrategy != null)
        {
            _displaySubsystemStrategy.DisplayAllSubsystemForestItems();
        }
        else
        {
            // Викидання винятку або дефолтна поведінка
        }
    }
}

public class AnimalSubsystem: Subsystem{ }

public class TreeSubsystem: Subsystem{ }