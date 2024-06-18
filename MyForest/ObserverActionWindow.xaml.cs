using System.Windows;
using MyForest.Observer;

namespace MyForest
{
    public partial class ObserverActionWindow : Window
    {
        private ForestItem _forestItem;
        private IObserver observer;
        private System.Timers.Timer reactionTimer;

        public ObserverActionWindow(IObserver observer, string message, object forestItem)
        {
            InitializeComponent();
            ObserverMessage.Text = message;
            ObserverName.Text = observer.GetObserverName();
            this.observer = observer;
            _forestItem = (ForestItem)forestItem;
            reactionTimer = new System.Timers.Timer(5000); // 5 cек
            reactionTimer.Elapsed += Close_Click;
            reactionTimer.Start();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (sender is System.Timers.Timer)
                {
                    Console.WriteLine(observer.GetObserverName() + " зрозумів, що його помітили і втік");
                    reactionTimer.Stop();
                    reactionTimer.Dispose();
                }
                else
                {
                    _forestItem.Detach(observer);
                }
                Close(); // Закриття поточного вікна
            });
            
        }
    }
}