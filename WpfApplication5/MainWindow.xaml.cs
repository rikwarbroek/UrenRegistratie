using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Project> Projects = new List<Project>();

        public DatabaseManager DatabaseManager { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            DatabaseManager = new DatabaseManager(new DatabaseConnection());

            //Projects.Add(new Project());
            //Projects.Add(new Project());
            RefreshLijstDoos();
        }

        public void RefreshLijstDoos()
        {
            LijstDoos.ItemsSource = null; LijstDoos.ItemsSource = Projects; LijstDoos.Items.Refresh();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Width < 1020)
            {
                Calendar.Visibility = Visibility.Collapsed;
            }
            else
            {
                Calendar.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Check if the Time has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Project_TimeChanged(object sender, EventArgs e)
        {
            Project project = (Project)sender;

            //TO DO 1 project updaten.
            List<Project> OtherList = new List<Project>();
            foreach (Project strCol in LijstDoos.Items)
            {
                OtherList.Add(strCol);
            }
            foreach (var Item in LijstDoos.Items)
            {
                if (OtherList.Contains(project))
                {
                    LijstDoos.Items.Refresh();
                }
            }
        }

        /// <summary>
        /// Starts the Timer of a <see cref="Project"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Projects)
            {
                item.Stop();
            }
            Button button = (Button)sender;
            Project project = (Project)button.DataContext;
            project.Start();
            project.TimeChanged += Project_TimeChanged;
        }

        /// <summary>
        /// Stops the timer of a <see cref="Project"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Project project = (Project)button.DataContext;
            project.Stop();
            LijstDoos.Items.Refresh();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProjectWindow w = new AddProjectWindow(this);
            w.Show();
        }
    }
}
