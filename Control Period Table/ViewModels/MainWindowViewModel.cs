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
            //Test = ReactiveCommand.Create<Student, ObservableCollection<Student>>((note) => StudentList = new ObservableCollection<Student>(new List<Student>() { note }));
            Add = ReactiveCommand.Create(() => add());
        }

        public void add()
        {
            studentList.Add(new Student());
        }


        //public ReactiveCommand<Student, ObservableCollection<Student>> Test { get; }
        public ReactiveCommand<Unit, Unit> Add { get; }
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
