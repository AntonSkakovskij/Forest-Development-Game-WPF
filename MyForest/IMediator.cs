using MyForest.Managers;
using MyForest.Strategy;

namespace MyForest;

public interface IMediator
{
    void Notify(object sender, string eventName);
}

// клас медіатора, що дозволяє зменшити кількість викоиків, організвуваши зручний доступ
public class GameControlMediator : IMediator
{
    private UserManager _userManagerComponent;
    private ActionMenuFacade _menuFacadeComponent;
    
    public GameControlMediator()
    {
        _userManagerComponent = UserManager.getUserProfile();
        
        
        Subsystem treeSubsystem = new TreeSubsystem();
        treeSubsystem.SetDeleteStrategy(new DeleteTreeSubsystemStrategy());
        treeSubsystem.SetDisplayStrategy(new DisplayTreeSubsystemStrategy());
        Subsystem animalSubsystem = new AnimalSubsystem();
        animalSubsystem.SetDeleteStrategy(new DeleteAnimalSubsystemStrategy());
        animalSubsystem.SetDisplayStrategy(new DisplayAnimalSubsystemStrategy());
        _menuFacadeComponent = new ActionMenuFacade(treeSubsystem, animalSubsystem);

    }
    
    public void Notify(object sender, string eventName)
    {
        switch (eventName)
        {
            case "increase_speed":
                _userManagerComponent.SetGameSpeed(_userManagerComponent.GetGameSpeed() - 15000);
                _userManagerComponent.UpdateMainWindowGameSpeed();
                break;
            
            case "decrease_speed":
                _userManagerComponent.SetGameSpeed(_userManagerComponent.GetGameSpeed() + 15000);
                _userManagerComponent.UpdateMainWindowGameSpeed();
                break;
            case "generate_forest":
                _menuFacadeComponent.GenerateForest();
                break;
            case "MainWindow_set_default":
                _userManagerComponent.UpdateMainWindowGameSpeed();
                _userManagerComponent.UpdateMainWindowAnimalCoins();
                _userManagerComponent.UpdateMainWindowTreeCoins();
                break;
        }
        
    }
}