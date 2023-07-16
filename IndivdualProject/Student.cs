using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace IndivdualProject
{
    public class Student
    {
        public int Num { get; set; }

        public string _id { get; set; }
        public string ID
        {
            get 
            { 
                if(_id != null)
                {
                    return _id;
                }
                else
                {
                    return "ST" + Num.ToString();
                }
            }

            set { ID = _id; }
        }

        public string fName { get; set; }
        public string lName { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
        public string department { get; set; }
        public string gpa 
        { 
            get
            {
                double numGPV = 0;
                int Tcredits = 0;

                if(modules != null)
                {
                    foreach (Module mod in modules)
                    {
                        numGPV += mod.gpv;
                        Tcredits += mod.moduleCredits;
                    }
                }
                else
                {
                    numGPV = 0;
                    Tcredits = 1;
                }

                double gpaN = numGPV / Tcredits;

                return gpaN.ToString("0.##");
                
            }

            set
            {
                gpa = value;
            }
        }

        public List<Module> modules { get; set; }
        public BitmapImage bImage{ get; set; }

        public string fullName
        {
            get { return fName+ " " + lName; }
        }

        public Student()
        {

        }

        public Student(int num,string fname, string lastname, string adds, string gdr, string bday, string departM, BitmapImage img)
        {
            Num = num;
            fName = fname;
            lName = lastname;
            address = adds;
            gender = gdr;
            birthday = bday;
            department = departM;
            bImage = img;
        }

        public Student(string id, string fname, string lastname, string adds, string gdr, string bday, string departM, BitmapImage img)
        {
            _id = id;
            fName = fname;
            lName = lastname;
            address = adds;
            gender = gdr;
            birthday = bday;
            department = departM;
            bImage = img;
        }
    }
}
