using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MyForest.Observer;


namespace MyForest;

public partial class ForestMapCell: UserControl
{
    public ForestItem ForestItem { get; set; }
    public uint CellId { get; set; }
    public bool IsOccupied { get; set; }


    public ForestMapCell(uint id)
    {
        InitializeComponent();
        this.CellId = id;
        IsOccupied = false;
        this.MouseEnter += new MouseEventHandler(CellMouseHandler);
        this.MouseLeave += new MouseEventHandler(CellMouseHandler);
        this.MouseLeftButtonDown += new MouseButtonEventHandler(CellMouseHandler    );
    }
    
    //виділення клітинки при наведені
    void CellMouseHandler(object sender, MouseEventArgs e)
    {
        if (e.RoutedEvent == Mouse.MouseEnterEvent)
        {
            CellBody.StrokeThickness = 1;
        }
        else if (e.RoutedEvent == Mouse.MouseLeaveEvent)
        {
            CellBody.StrokeThickness = 0;
        }
    }
    
    //метод зміни розмірів клітинки
    public void ChangeSize(double newWidth, double newHeight)
    {
        CellBody.Width = newWidth;
        CellBody.Height = newHeight;
        CellBodyImage.Height = newHeight;
        CellBodyImage.Width = newWidth;
    }
    

    
    //обробник подія на клітинку
    void CellMouseHandler(object sender, MouseButtonEventArgs e)
    {
        
        ListBoxItem selectedTreeItem = (MainWindow.WindowInstance.Trees.SelectedItem as ListBoxItem);
        ListBoxItem selectedAnimalItem = (MainWindow.WindowInstance.Animals.SelectedItem as ListBoxItem);
        
        //якщо не обрано жоден з елементів лістбоксів
        if (selectedTreeItem == null && selectedAnimalItem == null)
        {
            // і клітинка є зайнятой -> виводимо інформаційне вікно
            if (IsOccupied && e.LeftButton == MouseButtonState.Pressed)
            {
                
                double cellWidth = this.CellBody.Width;
                double cellHeight = this.CellBody.Height;
                double windowInstanceLeft = MainWindow.WindowInstance.Left;
                double windowInstanceTop = MainWindow.WindowInstance.Top;
                
                // Відображення вікна ForestItemInfoWindow в центрі ForestMapCell
                ForestItemInfoWindow infoWindow = new ForestItemInfoWindow();
                infoWindow.Left = (CellId % 10 + 1) * cellWidth + windowInstanceLeft + 10;
                infoWindow.Top = (CellId / 10)  * cellHeight + windowInstanceTop - 5;
                ForestItem.OutputItselfInfo(infoWindow);
                infoWindow.ShowDialog();
                return;
            }
            else
            {
                return;
            }
        }
        //якщо обрано
        else
        {
            //але клітинка вже зайнята
            if (IsOccupied)
            {
                return;
            }
        }
        
        //якщо елмент лістбоксу дерев обраний
        if (selectedTreeItem != null)
        {
            //створення фабрики в залежності від типу дерева
            string lbiTreeName = selectedTreeItem.Tag.ToString();
            ForestFactory treeForestFactory = null;
            if (lbiTreeName == "Oak")
            {
                treeForestFactory = new OakTreeFactory();
            }
            else if (lbiTreeName == "Birch")
            {
                treeForestFactory = new BirchTreeFactory();
                
            }
            else if (lbiTreeName == "Pine")
            {
                treeForestFactory = new PineTreeFactory();
            }


            //створюємо елемент з перевіркою чи достатньо коштів
            ForestItem = treeForestFactory.CreateForestItem();
            if (UserManager.getUserProfile().PurchaseTree(ForestItem.GetCoinsCost()))
            {
                int random1 = RandomNumberGenerator.GetInt32(1, 4);
                switch (random1)
                {
                    case 1:
                        int randomNameIndex = RandomNumberGenerator.GetInt32(0, 10); 
                        ObserverName randomObserver = (ObserverName)randomNameIndex;
                        ForestItem.Attach(new Woodcutter(randomObserver));
                        break;
                    default:
                        break;
                }
                CellBodyImage.Source = ForestItem.DisplayItself();
                IsOccupied = true;
            }
            else
            {
                MessageBox.Show("Not enough TreeCoins to buy this item");
                ForestItem = null;
                treeForestFactory = null;
            }
        }
        
        //якщо елмент лістбоксу тварин обраний
        if (selectedAnimalItem != null)
        {
            //створення фабрики в залежності від типу тварини
            string lbiAnimalName = selectedAnimalItem.Tag.ToString();
            ForestFactory animalForestFactory = null;
            if (lbiAnimalName == "Deer")
            {
                animalForestFactory= new DeerFactory();
            }
            else if (lbiAnimalName == "Bear")
            {
                animalForestFactory = new BearFactory();
            }
            else if (lbiAnimalName == "Boar")
            {
                animalForestFactory = new BoarFactory();
            }

            //створюємо елемент з перевіркою чи достатньо коштів
            ForestItem = animalForestFactory.CreateForestItem();
            if (UserManager.getUserProfile().PurchaseAnimal(ForestItem.GetCoinsCost()))
            {
                int random1 = RandomNumberGenerator.GetInt32(1, 5);
                switch (random1)
                {
                    case 1:
                        int randomNameIndex = RandomNumberGenerator.GetInt32(0, 10); 
                        ObserverName randomObserver = (ObserverName)randomNameIndex;
                        ForestItem.Attach(new Poacher(randomObserver));
                        break;
                    default:
                        break;
                }
                CellBodyImage.Source = ForestItem.DisplayItself();
                IsOccupied = true;
            }
            else
            {
                MessageBox.Show("Not enough AnimalCoins to buy this item");
                animalForestFactory = null;
                ForestItem = null;
            }
        }
    }
}

