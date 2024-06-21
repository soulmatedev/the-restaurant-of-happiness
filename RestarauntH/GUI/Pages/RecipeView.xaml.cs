using Database;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RestarauntH.GUI.Pages
{
    public partial class RecipeView : Page, INotifyPropertyChanged
    {
        private readonly RestarauntHEntities database;
        private Ingredient _selectedIngredient;
        private Ingredient _selectedRecipeIngredient;

        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<Ingredient> RecipeIngredients { get; set; }

        public Ingredient SelectedIngredient
        {
            get => _selectedIngredient;
            set
            {
                _selectedIngredient = value;
                OnPropertyChanged(nameof(SelectedIngredient));
            }
        }

        public Ingredient SelectedRecipeIngredient
        {
            get => _selectedRecipeIngredient;
            set
            {
                _selectedRecipeIngredient = value;
                OnPropertyChanged(nameof(SelectedRecipeIngredient));
            }
        }

        public RecipeView(RestarauntHEntities entities)
        {
            InitializeComponent();
            database = entities;

            Ingredients = new ObservableCollection<Ingredient>(database.Ingredients.ToList());
            RecipeIngredients = new ObservableCollection<Ingredient>();

            DataContext = this;
        }

        private void MoveToRecipe_Clicked(object sender, RoutedEventArgs e)
        {
            if (SelectedIngredient != null)
            {
                RecipeIngredients.Add(SelectedIngredient);
                Ingredients.Remove(SelectedIngredient);
                SelectedIngredient = null;
            }
        }

        private void MoveToIngredients_Clicked(object sender, RoutedEventArgs e)
        {
            if (SelectedRecipeIngredient != null)
            {
                Ingredients.Add(SelectedRecipeIngredient);
                RecipeIngredients.Remove(SelectedRecipeIngredient);
                SelectedRecipeIngredient = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
