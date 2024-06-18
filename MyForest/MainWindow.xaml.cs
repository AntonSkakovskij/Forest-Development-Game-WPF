
using System.Windows;
using System.Windows.Input;
using MyForest.Managers;
using MyForest.Strategy;


namespace MyForest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static MainWindow WindowInstance;
    public GameControlMediator ControlMediator;
    
    public MainWindow()
    {
        InitializeComponent();
        WindowInstance = this;
        
        ForestMap.ForestMapInstance = ActiveForestMap;
        ControlMediator = new GameControlMediator();
        
        ControlMediator.Notify(this, "MainWindow_set_default");
        
        MouseLeftButtonDown += new MouseButtonEventHandler(CancelAnyStatus);
    }
    
    //генерація лісу
    private void GenerateForest(object sender, RoutedEventArgs e)
    {
        ControlMediator.Notify(sender,"generate_forest" );
    }

    //деактивація обраних лістбоксайтемів
    private void CancelAnyStatus(object sender, MouseButtonEventArgs e)
    {
        Animals.SelectedItem = null;
        Trees.SelectedItem = null;
    }
    
    //збільшення швидкості гри
    private void IncreaseGameSpeed(object sender, RoutedEventArgs e)
    {
        ControlMediator.Notify(sender,"increase_speed" );
    }
    
    //зменшення швидкості гри
    private void DecreaseGameSpeed(object sender, RoutedEventArgs e)
    {
        ControlMediator.Notify(sender,"decrease_speed" );
    }
    
}
