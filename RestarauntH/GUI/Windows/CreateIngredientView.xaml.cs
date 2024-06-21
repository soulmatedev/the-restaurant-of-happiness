using Database;
using System;
using System.Windows;

namespace RestarauntH.GUI.Windows
{
    public partial class CreateIngredientView : Window
    {
        private readonly RestarauntHEntities database;

        public event EventHandler<Ingredient> IngredientCreated;

        public CreateIngredientView(RestarauntHEntities entities)
        {
            InitializeComponent();
            database = entities;
        }

        private void CreateIngredient_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = nameValue.Text.Trim();
                decimal protein = decimal.Parse(proteinValue.Text.Trim());
                decimal fat = decimal.Parse(fatValue.Text.Trim());
                decimal carbohydrate = decimal.Parse(carbohydrateValue.Text.Trim());

                Ingredient newIngredient = new Ingredient
                {
                    Name = name,
                    Protein = protein,
                    Fat = fat,
                    Carbohydrate = carbohydrate,
                };

                database.Ingredients.Add(newIngredient);
                database.SaveChanges();

                IngredientCreated?.Invoke(this, newIngredient);

                MessageBox.Show("Ингредиент успешно создан.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании ингредиента: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
