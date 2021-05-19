using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using IoT_Control_center.Pages;
using System.Windows.Controls;
using System.IO;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace IoT_Control_center
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StaticData SD;
        public static ControlPage controlPage = new ControlPage();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new List<Page>() {controlPage};
            BaseFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            BaseFrame.NavigationService.Navigate(controlPage);
            var y = File.ReadAllText(@"AppData\staticRes.json");
            SD = y == "" ? new StaticData() : JsonConvert.DeserializeObject<StaticData>(y);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        { 
            var y = JsonConvert.SerializeObject(SD, Formatting.Indented);
            File.WriteAllText(@"AppData\staticRes.json", y, Encoding.UTF8);
            controlPage.Window_Closing(null, null);   

        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            BaseFrame.Navigate(new SettingsPage(SD));
        }
    }
}