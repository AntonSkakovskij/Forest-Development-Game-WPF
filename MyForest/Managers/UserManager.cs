
    using System.Windows;
    using MyForest;
    using MyForest.Factrories;
    using MyForest.ForestItems;

    class UserManager
    {
        /// <summary>
        ///
        ///   treeCoins: використовується для покупки дерев
        ///            - валюта отримується завдяки росту дерев
        ///
        ///
        ///   animalCoins: використовується для покупки тварин
        ///              - валюта отримується завдяки росту тварин
        ///
        ///
        ///   money: використовується для того чоб боротися з різними негативними подіями
        ///        - валюта отримується завдяки швидкості захисту лісу від негативних подій:
        ///          швидко:_ к-сть отриманою валюти перевищує кількість витраченої
        ///          середньо:_ к-сть отриманою валюти дорівньоє кількість витраченої
        ///          повільно:_ к-сть отриманою валюти є меншою а ніж кількість витраченої
        ///        - також рандомно поповнюється завдяки росту дерев
        /// 
        /// 
        /// </summary>
        
        
        private static UserManager instance;

        private static readonly object lockObject = new object();
        
        private string UserName { get; set; }
        public int treeCoins { get; set; }
        public int animalCoins { get; set; }
        
        private double GameSpeed { get; set; }
        
        public ForestItemFlyweightFactory ForestItemFlyweightFactory { get; set; }

        private UserManager()
        {
            UserName = "Truba";
            treeCoins = 100;
            animalCoins = 100;
            GameSpeed = 180000; //60000 - хвилина
            ForestItemFlyweightFactory = new ForestItemFlyweightFactory();
        }
        
        public static UserManager getUserProfile()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new UserManager();
                    }
                }
            }
            return instance;
        }

        
        //метод для встановлення дефолтних значень профілю
        public void SetDefaultValues()
        {

            GameSpeed = 180000;
            animalCoins = 100;
            treeCoins = 100;

            UpdateMainWindowTreeCoins();
            UpdateMainWindowAnimalCoins();
        }

        public void UpdateMainWindowTreeCoins()
        {
            MainWindow.WindowInstance.TreeCoins.Text = UserManager.getUserProfile().treeCoins.ToString();
        }

        public void UpdateMainWindowAnimalCoins()
        {
            MainWindow.WindowInstance.AnimalCoins.Text = UserManager.getUserProfile().animalCoins.ToString();
        }
        
        public void UpdateMainWindowGameSpeed()
        {
           
            MainWindow.WindowInstance.GameSpeed.Text = "Game speed: " + (180000 / GameSpeed).ToString("0.00") + "x";
        }
        
        //встановлення(покупка) дерева
        public bool PurchaseTree(int cost)
        {
            if (treeCoins >= cost)
            {
                treeCoins -= cost;
                UpdateMainWindowTreeCoins();
                return true; // Покупка успішна
            }
            else
            {
                return false; // Недостатньо грошей
            }
        }

        public void TreeCoinsIncome(int coinsIncome)
        {
            treeCoins += coinsIncome;
            UpdateMainWindowTreeCoins();
        }

        //встановлення(покупка) тварини
        public bool PurchaseAnimal(int cost)
        {
            if (animalCoins >= cost)
            {
                animalCoins -= cost;
                UpdateMainWindowAnimalCoins();
                return true;// Покупка успішна
            }
            else
            {
                return false;// Недостатньо грошей
            }
        }

        public void AnimalCoinsIncome(int coinsIncome)
        {
            animalCoins += coinsIncome;
            UpdateMainWindowAnimalCoins();
        }

        public double GetGameSpeed()
        {
            return GameSpeed;
        }

        //метод зміни швидкості гри 
        public void SetGameSpeed(double newGameSpeed)
        {
            if (newGameSpeed <= 0)
            {
                MessageBox.Show("You can increase game speed more");
                return;
            }
            GameSpeed = newGameSpeed;
            foreach (var cell in ForestMap.ForestMapInstance.pointToCell.Values)
            {
                if (cell.ForestItem != null)
                {
                    cell.Dispatcher.Invoke(() =>
                    {
                        cell.ForestItem.UpdateGrowthInterval();
                    });
                }
            }
        }
    }
