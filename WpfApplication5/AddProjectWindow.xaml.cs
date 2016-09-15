using System;
using System.Windows;

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {
        public Project Project { get; private set; }

        public MainWindow MainWindow { get; private set; }

        public AddProjectWindow(MainWindow window)
        {
            InitializeComponent();

            MainWindow = window;
        }

        private void OnCreateClick(Object sender, RoutedEventArgs e)
        {
            Project = new Project();

            Project.ProjectName = textBox.Text;
            Project.Element = textBox_Copy.Text;

            Project.IsPrivate = (bool)checkBox.IsChecked;

            // Database Function
            MainWindow.DatabaseManager.SaveProject(Project);
            MainWindow.RefreshLijstDoos();
            Close();
        }
    }
}
