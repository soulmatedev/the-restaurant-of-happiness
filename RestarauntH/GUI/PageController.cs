using Database;
using RestarauntH.GUI.Windows;
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

        private static MenuWindow menuWindow;
        public static MenuWindow MenuWindow

        {
            get
            {
                if (menuWindow == null)
                {
                    menuWindow = new MenuWindow();
                }
                return menuWindow;
            }
        }

        private static IngredientWindow ingredientWindow;
        public static IngredientWindow IngredientWindow

        {
            get
            {
                if (ingredientWindow == null)
                {
                    ingredientWindow = new IngredientWindow(Database);
                }
                return ingredientWindow;
            }
        }
    }
}
