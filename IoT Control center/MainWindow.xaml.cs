using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace IoT_Control_center
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Equipment> items = new List<Equipment>();
        
        void UpdateHandler(object sender, EventArgs args)
        {
            foreach (Equipment eq in items)
            {
                eq.UpdateProperties();
                eq.LogProps();
            }
        }

        void UpdateTeamsData(object sender, EventArgs args)
        {
            foreach (var data in TeamButtonPanel.Children)
            {
                if ((data as ToggleButton)?.DataContext is TeamData currentData)
                {
                    currentData.UpdatePoliFill();
                    currentData.UpdateManipFill();
                    currentData.UpdateTrL1Fill();
                    currentData.UpdateTrl2Fill();
                }
            }
        }


        DispatcherTimer UpdateIOTimer = new DispatcherTimer();

        private DispatcherTimer TeamsUpdate = new DispatcherTimer();

        private List<TeamData> teams =
            JsonConvert.DeserializeObject<List<TeamData>>(File.ReadAllText(@"AppData\teamsRes.json"));

        private StaticData x;

        public MainWindow()
        {
            TeamsUpdate.Interval = new TimeSpan(0, 0, 0, 3);
            TeamsUpdate.Tick += UpdateTeamsData;
            TeamsUpdate.Start();
            UpdateIOTimer.Interval = new TimeSpan(0, 0, 0, 5);
            UpdateIOTimer.Tick += UpdateHandler;
            UpdateIOTimer.Start();
            var y = File.ReadAllText(@"AppData\staticRes.json");
            x = y == "" ? new StaticData() : JsonConvert.DeserializeObject<StaticData>(y);
            InitializeComponent();
            foreach (var item in teams)
            {
                var tmpButton = new ToggleButton()
                    {Content = $"Team {TeamButtonPanel.Children.Count + 1}", Margin = new Thickness(3), Width = 100};
                tmpButton.DataContext = item;
                tmpButton.Click += SetTeamData;
                TeamButtonPanel.Children.Add(tmpButton);
            }

            
            StaticResPanel.DataContext = x;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var s = ((sender as CheckBox).Parent as Grid).Children[1] as Border;
            s.IsEnabled = !s.IsEnabled;
        }

        private void AddNewTeam(object sender, RoutedEventArgs e)
        {
            teams.Add(new TeamData());

            var tmpButton = new ToggleButton()
                {Content = $"Team {TeamButtonPanel.Children.Count + 1}", Margin = new Thickness(3), Width = 100};

            tmpButton.DataContext = teams.Last();
            tmpButton.Click += SetTeamData;
            TeamButtonPanel.Children.Add(tmpButton);
        }

        private void SetTeamData(object sender, RoutedEventArgs args)
        {
            foreach (var btn in TeamButtonPanel.Children)
            {
                ((ToggleButton) btn).IsChecked = false;
            }

            ((ToggleButton) sender).IsChecked = true;
            TeamDataPanel.DataContext = (sender as ToggleButton).DataContext;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var y = JsonConvert.SerializeObject(x, Formatting.Indented);
            File.WriteAllText(@"AppData\staticRes.json", y, Encoding.UTF8);
            File.WriteAllText(@"AppData\teamsRes.json", JsonConvert.SerializeObject(teams.Where(t => t != new TeamData()), Formatting.Indented));
        }

        private void FromItemLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PropertyToChagePanel.DataContext = (sender as ListBox)?.SelectedItem;
        }

        private void RemoveSelectedTeam(object sender, RoutedEventArgs e)
        {
            TeamButtonPanel.Children.Remove((UIElement) sender);
            teams.Remove(sender as TeamData);
        }
        
    }
}