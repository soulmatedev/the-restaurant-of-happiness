using RestarauntH.GUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntH.GUI
{
    internal class PageController
    {
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
    }
}
