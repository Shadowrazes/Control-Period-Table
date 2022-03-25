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

            this.FindControl<DataGrid>("Table").CellEditEnded += delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                ObservableCollection<Student> studentList = context.StudentList;

                if (context != null)
                {
                    context.StudentList = new ObservableCollection<Student>();
                    context.StudentList = studentList;
                }
            };
        }
    }
}
