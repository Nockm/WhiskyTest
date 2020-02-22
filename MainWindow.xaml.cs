using System.Windows;
using WhiskyTest.Model;

namespace WhiskyTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AppModel AppModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            AppModel = new AppModel();

            DataContext = this;
        }
    }
}
