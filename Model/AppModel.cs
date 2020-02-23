using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WhiskyTest.Model
{
    public class AppModel : INotifyPropertyChanged
    {
        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        // Members
        private Profile profile;
        private PhraseSet phraseSet;

        // Properties
        public Profile Profile { get { return profile; } set { profile = value; OnPropertyChanged(); } }
        public PhraseSet PhraseSet { get { return phraseSet; } set { phraseSet = value; OnPropertyChanged(); } }

        // Example
        public AppModel()
        {
            Profile = Profile.GenerateExample(1);
            PhraseSet = Profile.CategorySet[0].PhraseSets[0];
        }
    }

    public class Profile
    {
        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        // Members
        private string title = "New Profile";
        private string subTitle = "new title";
        private ObservableCollection<Category> categorySet = new ObservableCollection<Category>();

        // Properties
        public string Title { get { return title; } set { title = value; OnPropertyChanged(); } }
        public string SubTitle { get { return subTitle; } set { subTitle = value; OnPropertyChanged(); } }
        public ObservableCollection<Category> CategorySet { get { return categorySet; } set { categorySet = value; OnPropertyChanged(); } }

        // Example
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
        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        // Members
        private string title = "New Category";
        private string subTitle = "New Category Description";
        private ObservableCollection<PhraseSet> phraseSets = new ObservableCollection<PhraseSet>();

        // Properties
        public string Title { get { return title; } set { title = value; OnPropertyChanged(); } }
        public string SubTitle { get { return subTitle; } set { subTitle = value; OnPropertyChanged(); } }
        public ObservableCollection<PhraseSet> PhraseSets { get { return phraseSets; } set { phraseSets = value; OnPropertyChanged(); } }

        // Example
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
        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        // Members
        private string title = "New PhraseSet";
        private string description = "New Description";
        private ObservableCollection<Phrase> phrases = new ObservableCollection<Phrase>();

        // Properties
        public string Title { get { return title; } set { title = value; OnPropertyChanged(); } }
        public string Description { get { return description; } set { description = value; OnPropertyChanged(); } }
        public ObservableCollection<Phrase> Phrases { get { return phrases; } set { phrases = value; OnPropertyChanged(); } }

        // Example
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
        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        // Members
        private string left = "New Left";
        private string right = "New Right";

        // Properties
        public string Left { get { return left; } set { left = value; OnPropertyChanged(); } }
        public string Right { get { return right; } set { right = value; OnPropertyChanged(); } }

        // Example
        public static Phrase GenerateExample(int i)
        {
            return new Phrase() { Left = "New Left " + i, Right = "New Right " + i };
        }
    }
}
