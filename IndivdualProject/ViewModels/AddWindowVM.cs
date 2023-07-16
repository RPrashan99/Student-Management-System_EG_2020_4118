using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace IndivdualProject.ViewModels
{
    public partial class AddWindowVM:ObservableObject
    {
        [ObservableProperty]
        public string? firstName;

        [ObservableProperty]
        public string? lastName;

        [ObservableProperty]
        public string? address;

        [ObservableProperty]
        public string? gender;

        [ObservableProperty]
        public DateTime? bDay;

        [ObservableProperty]
        public string? department;

        [ObservableProperty]
        public BitmapImage? selectedImg;

        [ObservableProperty]
        public Image img;

        [ObservableProperty]
        public string mdID;

        [ObservableProperty]
        public string mdResult;

        public ObservableCollection<Module> _allModules = new ObservableCollection<Module>();

        public ObservableCollection<Module> allModules { get { return _allModules; } }

        public List<Module> modules; //store all the modules

        //public List<string> results;

        public ObservableCollection<string> genders = new ObservableCollection<string>();

        public ObservableCollection<string> Genders
        {
            get { return genders; }
            set { genders = value; }
        }

        public ObservableCollection<string> results = new ObservableCollection<string>();

        public ObservableCollection<string> Results
        {
            get { return results; }
            set { results = value; }
        }

        public Action closeAction { get; internal set; }

        public AddWindowVM()
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

            Results = new ObservableCollection<string>()
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

            //SelectedImg = new BitmapImage(new Uri("Img/1.png", UriKind.Relative));
        }

        [RelayCommand]
        public void addStudent()
        {
            if(FirstName != null)
            {
                closeAction();
            }
        }

        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                SelectedImg = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        [RelayCommand]
        public void addModules()
        {       
            if(modules.Any(m => m.moduleID == MdID))
            {
                if(allModules != null && allModules.Any(m => m.moduleID == MdID))
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Module already added!","Modules", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    Module newMod = modules.Find(m => m.moduleID == MdID);

                    string mdResultUp = MdResult.ToUpper();

                    if (Results.Any(r => r.Equals(MdResult) /*|| r.Equals(mdResultUp)*/))
                    {
                        newMod.moduleResult = MdResult;
                        allModules.Add(newMod);
                        MessageBoxResult messageBoxResult = MessageBox.Show("Module added!","Modules", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("Module not added, enter valid result","Modules", MessageBoxButton.OK, MessageBoxImage.Warning);
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
