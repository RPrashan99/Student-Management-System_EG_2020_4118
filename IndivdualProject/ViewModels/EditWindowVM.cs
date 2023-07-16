using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace IndivdualProject.ViewModels
{
    public partial class EditWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string? idE;

        [ObservableProperty]
        public string? fnameE;

        [ObservableProperty]
        public string? lnameE;

        [ObservableProperty]
        public string? addressE;

        [ObservableProperty]
        public string? bDayE;

        [ObservableProperty]
        public string? genderE;

        [ObservableProperty]
        public string? departmentE;

        [ObservableProperty]
        public BitmapImage? selectedImgE;

        [ObservableProperty]
        public string? mdIDE;

        [ObservableProperty]
        public string? mdResultE;

        public ObservableCollection<Module> _allModulesE = new ObservableCollection<Module>();

        public ObservableCollection<Module> allModulesE { get { return _allModulesE; } }

        public ObservableCollection<string> genders = new ObservableCollection<string>();

        public ObservableCollection<string> Genders
        {
            get { return genders; }
            set { genders = value; }
        }

        public List<Module> modules;

        public List<string> results;

        public Action? closeEditAction { get; internal set; }

        public bool isClose = false; // to prevent the edit student being called without pressing edit button

        public EditWindowVM()
        {

        }

        public EditWindowVM(Student student)
        {
            modules = new List<Module>()
            {
                new Module("EE3301", "Analog Electronics", 3, "DNF"),
                new Module("EE3302", "Data Structures and Algorithms", 3, "DNF"),
                new Module("EE3305", "Signals and Systems", 3, "F"),
                new Module("EE3203", "Electrical and Electronic Measurements", 3, "DNF"),
                new Module("EE3206", "GUI Programming", 3, "DNF"),
                new Module("EE3151", "Programming Project", 3, "DNF")
            };

            results = new List<string>()
            {
                new string("A+"),
                new string("A"),
                new string("A-"),
                new string("B+"),
                new string("B"),
                new string("B-"),
                new string("C+"),
                new string("C"),
                new string("C-"),
                new string("F")
            };

            Genders = new ObservableCollection<string>()
            {
                new string("Male"),
                new string("Female")
            };

            FnameE = student.fName;
            LnameE = student.lName;
            AddressE = student.address;
            BDayE = student.birthday;
            GenderE = student.gender;
            DepartmentE = student.department;
            SelectedImgE = student.bImage;
            IdE = student.ID;

            if (student.modules != null)
            {
                foreach (Module n in student.modules)
                {
                    allModulesE.Add(n);
                }
            }
        }

        [RelayCommand]
        public void EditStudent()
        {
            if (FnameE != null)
            {
                isClose = true;
                closeEditAction();
            }
        }

        [RelayCommand]
        public void UploadNewPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                SelectedImgE = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        [RelayCommand]
        public void EditModules()
        {
            if (allModulesE.Any(m => m.moduleID == MdIDE))
            {
                Module editmodule = allModulesE.First(m => m.moduleID == MdIDE);
                int index = allModulesE.IndexOf(editmodule);

                allModulesE[index].moduleResult = MdResultE;

                MessageBoxResult messageBoxResult = MessageBox.Show("Module result changed!", "Modules", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (modules.Any(m => m.moduleID == MdIDE))
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Module Not Found\n Do you want to add new module?", "Module", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Module newMod = modules.Find(m => m.moduleID == MdIDE);

                    string mdResultUp = MdResultE.ToUpper();

                    if (results.Any(r => r.Equals(MdResultE) || r.Equals(mdResultUp)))
                    {
                        newMod.moduleResult = MdResultE;
                        allModulesE.Add(newMod);
                        MessageBoxResult messageBoxResult1 = MessageBox.Show("Module added!", "Modules", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBoxResult messageBoxResult1 = MessageBox.Show("Module not added, enter valid result", "Modules", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Module Not Found, check module ID", "Modules", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
