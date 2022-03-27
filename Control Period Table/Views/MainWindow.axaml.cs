using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using Control_Period_Table.Models;
using Control_Period_Table.ViewModels;

namespace Control_Period_Table.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<MenuItem>("LoadBtn").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Search File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? filePath = await taskPath;

                if (filePath != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.LoadFile(string.Join(@"\", filePath));
                }
            };

            this.FindControl<MenuItem>("SaveBtn").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Search File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? filePath = await taskPath;

                if (filePath != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.SaveFile(string.Join(@"\", filePath));
                }
            };

            this.FindControl<MenuItem>("ExitBtn").Click += delegate
            {
                Close();
            };
        }

        private void CellEdited(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext as MainWindowViewModel;
            ObservableCollection<Student> studentList = context.StudentList;

            if (context != null)
            {
                context.RefreshAverageList();
                context.RefreshStudentAverage();
                //context.StudentList = new ObservableCollection<Student>();
                //context.StudentList = studentList;
            }
        }

        private async void AboutPage(object control, RoutedEventArgs arg)
        {
            await new About().ShowDialog((Window)this.VisualRoot);
        }
    }
}
