using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFLocalizeExtension.Engine;

namespace STM.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public bool LoginLogic()
        {
            return (bool)this.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentCulture == CultureInfo.InvariantCulture && Thread.CurrentThread.CurrentUICulture == CultureInfo.InvariantCulture)
            {

                var ci = new CultureInfo("pl");
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                LocalizeDictionary.Instance.Culture = ci;
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                LocalizeDictionary.Instance.Culture = CultureInfo.InvariantCulture;
            }
        }
    }
}
