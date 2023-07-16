using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IndivdualProject.Views;
using IndivdualProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows;

namespace IndivdualProject.ViewModels
{
    public partial class MainWindowVM:ObservableObject
    {
        [ObservableProperty]
        public string stID;

        [ObservableProperty]
        public string stFirstName;

        [ObservableProperty]
        public string stLastName;

        [ObservableProperty]
        public string stAddress;

        [ObservableProperty]
        public string stBirthday;

        [ObservableProperty]
        public string stGender;

        [ObservableProperty]
        public string stDepartment;

        [ObservableProperty]
        public BitmapImage stImg;

        [ObservableProperty]
        public Student selectStudent;

        public ObservableCollection<Student> _students = new ObservableCollection<Student>();

        public ObservableCollection<Student> students { get { return _students; } set { _students = value; } }

        public int countList { get; set; }

        public MainWindowVM()
        {
            BitmapImage img1 = new BitmapImage(new Uri("Img/1.png", UriKind.Relative));
            BitmapImage img2 = new BitmapImage(new Uri("Img/2.png", UriKind.Relative));
            BitmapImage img3 = new BitmapImage(new Uri("Img/3.png", UriKind.Relative));
            BitmapImage img4 = new BitmapImage(new Uri("Img/4.png", UriKind.Relative));

            students = new ObservableCollection<Student>()
            {
                new Student(01,"John","Soap","England","Male","07/01/1998","Electrical",img1)
                {
                    modules = new List<Module>()
                    {
                        new Module("EE3301", "Analog Electronics", 3, "A"),
                        new Module("EE3302", "Data Structures and Algorithms", 3, "B"),
                    }
                },
                new Student(02,"Cpt","Price","England","Male","13/05/1972","Electrical",img2) 
                {
                    modules = new List<Module>()
                    {
                        new Module("EE3301", "Analog Electronics", 3, "B-"),
                        new Module("EE3302", "Data Structures and Algorithms", 3, "B+")
                    }
                },
                new Student(03,"Simon","Ghost","America","Male","12/02/1980","Computer",img3) 
                {
                    modules= new List<Module>()
                    {
                        new Module("EE3301", "Analog Electronics", 3, "A"),
                        new Module("EE3305", "Signals and Systems", 3, "B")
                    }
                },

                new Student(04,"Miller","Sandman","America","Male","04/04/1983","Computer",img4)
                { 
                    modules= new List<Module>()
                    {
                        new Module("EE3301", "Analog Electronics", 3, "C"),
                        new Module("EE3305", "Signals and Systems", 3, "C"),
                    }
                }
            };

            countList = students.Count;
        }

        [RelayCommand]
        public void addWindowOpen()
        {
            var vm = new AddWindowVM();
            var newWindow = new AddWindow(vm);
            newWindow.ShowDialog();

            if(vm.FirstName != null && vm.BDay != null)
            {
                StFirstName = vm.FirstName;
                StLastName = vm.LastName;
                StAddress = vm.Address;
                StBirthday = vm.BDay.ToString().Substring(0,10);
                StGender = vm.Gender;
                StDepartment = vm.Department;
                StImg = vm.SelectedImg;
                countList++;

                Student newStudent = new Student(countList, StFirstName, StLastName, StAddress, StGender, StBirthday,  StDepartment, StImg);

                if(vm.allModules != null)
                {
                    newStudent.modules = vm.allModules.ToList();
                }
                
                students.Add(newStudent);

                MessageBoxResult messageBoxResult = MessageBox.Show("New Student Added", "Modules", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        [RelayCommand]
        public void EditWindowOpen()
        {
            if(SelectStudent != null)
            {
                var vm = new EditWindowVM(SelectStudent);
                var newWindow = new EditWindow(vm);
                newWindow.ShowDialog();

                if (vm.FnameE != null && vm.isClose == true)
                {
                    StID = SelectStudent.ID;
                    StFirstName = vm.FnameE;
                    StLastName = vm.LnameE;
                    StAddress = vm.AddressE;
                    StBirthday = vm.BDayE.ToString().Substring(0,10);
                    StGender = vm.GenderE;
                    StDepartment = vm.DepartmentE;
                    StImg = vm.SelectedImgE;

                    Student newStudent = new Student(StID, StFirstName, StLastName, StAddress, StGender, StBirthday, StDepartment, StImg);

                    if (vm.allModulesE != null)
                    {
                        newStudent.modules = vm.allModulesE.ToList();
                    } 

                    int index = students.IndexOf(SelectStudent);

                    students[index] = newStudent;

                    MessageBoxResult messageBoxResult = MessageBox.Show("Student details edited","Edit Student", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Select a student to edit","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        public void deleteStudent()
        {
            if(SelectStudent != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to delete the student permenantly?","Student Deletion",MessageBoxButton.YesNo,MessageBoxImage.Warning);

                if(messageBoxResult == MessageBoxResult.Yes)
                {
                    students.Remove(SelectStudent);
                    MessageBoxResult messageBoxResult1 = MessageBox.Show("Student Deleted!","Student Deletion");
                }
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Select a student to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
