using System.Windows;

namespace MyForest;


// клас для виводу інформаці про елемент лісу при натиску на елемент
public partial class ForestItemInfoWindow : Window
{
    public ForestItemInfoWindow()
    {
        InitializeComponent();
    }
    private void Close_Click(object sender, RoutedEventArgs e)
    {
        this.Close(); // Закриття поточного вікна
    }
}