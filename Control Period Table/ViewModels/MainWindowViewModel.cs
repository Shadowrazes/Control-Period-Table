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

        ObservableCollection<Student> studentList;

        public MainWindowViewModel()
        {
            studentList = new ObservableCollection<Student>(students);
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

        public List<Student> Students
        {
            get => students;
        }
    }
}
