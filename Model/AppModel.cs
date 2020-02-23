using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyTest.Model
{
    public class AppModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Profile profile;
        private PhraseSet phraseSet;

        public Profile Profile { get { return profile; } set { profile = value; OnPropertyChanged(); } }
        public PhraseSet PhraseSet { get { return phraseSet; } set { phraseSet = value; OnPropertyChanged(); } }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AppModel()
        {
            Profile = Profile.GenerateExample(1);
            PhraseSet = Profile.CategorySet[0].PhraseSets[0];
        }
    }

    public class Profile
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title = "New Profile";
        private string subTitle = "new title";
        private ObservableCollection<Category> categorySet = new ObservableCollection<Category>();

        public string Title { get { return title; } set { title = value; OnPropertyChanged(); } }
        public string SubTitle { get { return subTitle; } set { subTitle = value; OnPropertyChanged(); } }
        public ObservableCollection<Category> CategorySet { get { return categorySet; } set { categorySet = value; OnPropertyChanged(); } }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static Profile GenerateExample(int i)
        {
            Profile profile = new Profile();
            profile.Title = "New Profile " + i;
            Enumerable.Range(0, 5).ToList().ConvertAll(Category.GenerateExample).ForEach(x => profile.CategorySet.Add(x));
            return profile;
        }
    }

    public class Category
    {
        private string title = "New Category";
        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get { return title; } set { title = value; OnPropertyChanged(); } }
        private ObservableCollection<PhraseSet> phraseSets = new ObservableCollection<PhraseSet>();

        public ObservableCollection<PhraseSet> PhraseSets { get { return phraseSets; } set { phraseSets = value; OnPropertyChanged(); } }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public static Category GenerateExample(int i)
        {
            Category category = new Category();

            category.Title = "New Category " + i;
            Enumerable.Range(0, 5).ToList().ConvertAll(PhraseSet.GenerateExample).ForEach(x => category.PhraseSets.Add(x));

            return category;
        }
    }

    public class PhraseSet : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title = "New PhraseSet";
        private ObservableCollection<Phrase> phrases = new ObservableCollection<Phrase>();

        public string Title { get { return title; } set { title = value; OnPropertyChanged(); } }
        public ObservableCollection<Phrase> Phrases { get { return phrases; } set { phrases = value; OnPropertyChanged(); } }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static PhraseSet GenerateExample(int i)
        {
            PhraseSet sheet = new PhraseSet();
            sheet.Title = "New PhraseSet " + i;
            Enumerable.Range(0, 5).ToList().ConvertAll(Phrase.GenerateExample).ForEach(x => sheet.Phrases.Add(x));
            return sheet;
        }
    }

    public class Phrase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string left = "New Left";
        private string right = "New Right";

        public string Left { get { return left; } set { left = value; OnPropertyChanged(); } }
        public string Right { get { return right; } set { right = value; OnPropertyChanged(); } }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static Phrase GenerateExample(int i)
        {
            return new Phrase() { Left = "New Left " + i, Right = "New Right " + i };
        }
    }
}
