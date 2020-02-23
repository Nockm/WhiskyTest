using System.Windows;
using WhiskyTest.Model;

namespace WhiskyTest
{
    public partial class MainWindow : Window
    {
        public static AppModel AppModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            AppModel = Util.DataIO.XmlResourceToObj<AppModel>("/SampleData/AppModel.xml");

            DataContext = this;
        }
    }
}
