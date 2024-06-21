using Database;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.ComponentModel;
using System.Linq;

namespace RestarauntH.GUI.Windows
{
    public partial class IngredientWindow : Page, INotifyPropertyChanged
    {
        private readonly RestarauntHEntities database;
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        private Ingredient _selectedIngredient;
        public Ingredient SelectedIngredient
        {
            get => _selectedIngredient;
            set
            {
                _selectedIngredient = value;
                OnPropertyChanged(nameof(SelectedIngredient));
            }
        }

        public IngredientWindow(RestarauntHEntities entities)
        {
            InitializeComponent();
            database = entities;
            Ingredients = new ObservableCollection<Ingredient>(database.Ingredients.ToList());
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GoBack(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
