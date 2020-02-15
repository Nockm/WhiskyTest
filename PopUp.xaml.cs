using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WhiskyTest
{
    /// <summary>
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : Window
    {
        public List<PopUpItem> PopUpItems { get; set; }

        public PopUp()
        {
            InitializeComponent();
            DataContext = this;
            PopUpItems = GeneratePopUpItems();
        }

        private List<PopUpItem> GeneratePopUpItems()
        {
            return Enumerable.Range(0, 5).ToList().ConvertAll(
                x => new PopUpItem
                {
                    Title = String.Format("Title {0}", x),
                    Content = String.Format("Content {0}", x),
                }
            );
        }
    }

    public class PopUpItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
