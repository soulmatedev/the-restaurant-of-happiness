using Database;
using RestarauntH.GUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestarauntH.GUI
{
    internal class PageController
    {
        private static RestarauntHEntities database;
        private static RestarauntHEntities Database
        {
            get
            {
                if (database == null)
                {
                    database = new RestarauntHEntities();
                    if (database.Database.Exists() == false)
                    {
                        MessageBox.Show("Подключения к базе данных не было выполнено. Приложения будет завершено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                return database;
            }
        }

        private static MenuView menuView;
        public static MenuView MenuView

        {
            get
            {
                if (menuView == null)
                {
                    menuView = new MenuView();
                }
                return menuView;
            }
        }

        private static RecipeView recipeView;
        public static RecipeView RecipeView

        {
            get
            {
                if (recipeView == null)
                {
                    recipeView = new RecipeView(Database);
                }
                return recipeView;
            }
        }

        private static IngredientView ingredientView;
        public static IngredientView IngredientView

        {
            get
            {
                if (ingredientView == null)
                {
                    ingredientView = new IngredientView(Database);
                }
                return ingredientView;
            }
        }
    }
}
