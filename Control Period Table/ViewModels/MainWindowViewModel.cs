using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using Control_Period_Table.Models;

namespace Control_Period_Table.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        List<Student> students = new List<Student>() { new Student(), new Student() };
        List<ItemAverageScore> itemsAverage = new List<ItemAverageScore>() { new ItemAverageScore(), new ItemAverageScore(), new ItemAverageScore() };

        ObservableCollection<Student> studentList;
        ObservableCollection<ItemAverageScore> itemsAverageList;

        public MainWindowViewModel()
        {
            studentList = new ObservableCollection<Student>(students);
            itemsAverageList = new ObservableCollection<ItemAverageScore>(itemsAverage);
            Add = ReactiveCommand.Create(() => add());
            RemoveSelected = ReactiveCommand.Create(() => Remove());
        }

        public void add()
        {
            studentList.Add(new Student());
        }

        public void Remove()
        {
            List<Student> removeList = new List<Student>();
            foreach (var item in StudentList)
            {
                if(item.IsSelected)
                    removeList.Add(item);
            }
            foreach (var item in removeList)
            {
                StudentList.Remove(item);
            }
        }

        public void RefreshAverageList()
        {
            for(int i = 0; i < studentList.Count; i++)
            {

            }
        }

        public ReactiveCommand<Unit, Unit> Add { get; }
        public ReactiveCommand<Unit, Unit> RemoveSelected { get; }
        public ObservableCollection<Student> StudentList
        {
            get => studentList;
            set
            {
                this.RaiseAndSetIfChanged(ref studentList, value); 
            }
        }

        public ObservableCollection<ItemAverageScore> ItemsAverageList { get; }

        public List<Student> Students
        {
            get => students;
        }
    }
}
