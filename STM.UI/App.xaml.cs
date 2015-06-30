using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace STM.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                do
                {
                    var loginWindow = new LoginWindow();
                    if (loginWindow.LoginLogic())
                    {
                        break;
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unexpected error occured: {0}", ex.Message), "STM", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                //Close application
                this.Shutdown();
            }
        }
    }
}
