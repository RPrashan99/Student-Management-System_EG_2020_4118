using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndivdualProject
{
    public class Module
    {
        public string moduleID { get; set; }
        public string moduleName { get; set; }
        public int moduleCredits { get; set; }
        public string moduleResult { get; set; }
        public double gpv 
        { 
            get
            {
                double ngpv = 0;
                if (moduleResult == "A+")
                {
                    ngpv = moduleCredits * 4.0;
                }
                else if (moduleResult == "A")
                {
                    ngpv = moduleCredits * 4.0;
                }
                else if (moduleResult == "A-")
                {
                    ngpv = moduleCredits * 3.7;
                }
                else if (moduleResult == "B+")
                {
                    ngpv = moduleCredits * 3.3;
                }
                else if (moduleResult == "B")
                {
                    ngpv = moduleCredits * 3.0;
                }
                else if (moduleResult == "B-")
                {
                    ngpv = moduleCredits * 2.7;
                }
                else if (moduleResult == "C+")
                {
                    ngpv = moduleCredits * 2.3;
                }
                else if (moduleResult == "C")
                {
                    ngpv = moduleCredits * 2.0;
                }
                else if (moduleResult == "C-")
                {
                    ngpv = moduleCredits * 1.7;
                }
                else
                {
                    ngpv = 0;
                }

                return ngpv;
            }

            set { gpv = value; } 
        }

        public Module(string moduleID, string moduleName, int moduleCredits, string moduleResult)
        {
            this.moduleID = moduleID;
            this.moduleName = moduleName;
            this.moduleCredits = moduleCredits;
            this.moduleResult = moduleResult;

        }
    }
}
