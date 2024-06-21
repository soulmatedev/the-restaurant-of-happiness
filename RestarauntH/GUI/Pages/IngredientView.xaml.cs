using Database;
using RestarauntH.GUI.Windows;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RestarauntH.GUI.Pages
{
    public partial class IngredientView : Page, INotifyPropertyChanged
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

        public IngredientView(RestarauntHEntities entities)
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

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OpenCreateIngredientWindow(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateIngredientView(database);
            createWindow.IngredientCreated += CreateWindow_IngredientCreated;
            createWindow.ShowDialog();
        }

        private void CreateWindow_IngredientCreated(object sender, Ingredient e)
        {
            Ingredients.Add(e);
        }

        private void DeleteIngredient(object sender, RoutedEventArgs e)
        {
            if (SelectedIngredient != null)
            {
                try
                {
                    database.Ingredients.Remove(SelectedIngredient);
                    database.SaveChanges();
                    Ingredients.Remove(SelectedIngredient);
                    MessageBox.Show("Ингредиент успешно удален.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении ингредиента: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ингредиент для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
