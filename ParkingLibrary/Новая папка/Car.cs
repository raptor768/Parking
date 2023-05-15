using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLibrary.Новая_папка
{
    internal class Car
    {
        internal string mark { get; private set; } = "";
        internal string model { get; private set; } = "";
        internal string sertificate { get; private set; } = "";
        internal string year { get; private set; } = "";
        internal string color { get; private set; } = "";
        internal string number { get; private set; } = "";

        public Car(string mark, string model, string sertificate, string year, string color, string number)
        {
            this.mark = mark;
            this.model = model;
            this.sertificate = sertificate; 
            this.year = year;
            this.color = color;
            this.number = number;   
        }
    }
}
