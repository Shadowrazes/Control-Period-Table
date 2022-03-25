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

            this.FindControl<DataGrid>("Table").CurrentCellChanged += delegate
            {
                ObservableCollection<Student> studentList = this.FindControl<DataGrid>("Table").Items as ObservableCollection<Student>;
                var context = this.DataContext as MainWindowViewModel;
                if (context != null)
                {
                    context.StudentList = studentList;
                    this.FindControl<DataGrid>("Table").Items = context.StudentList;
                }
            };
        }

        public void CommonClickHandler(object? sender, RoutedEventArgs e)
        {
            var source = e.Source as DataGrid;
            switch (source.Name)
            {
                case "YesButton":
                    // do something here ...
                    break;
                case "NoButton":
                    // do something ...
                    break;
                case "CancelButton":
                    // do something ...
                    break;
            }
            e.Handled = true;
        }
    }
}
