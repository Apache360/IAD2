using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAD2
{
    class PassengerRaw
    {
        public int id { get; set; }
        public string isDrowned { get; set; }
        public string passengerClass { get; set; }
        public string sex { get; set; }
        public string age { get; set; }
        public string paidFare { get; set; }

        public PassengerRaw(int id, string isDrowned, string passengerClass, string sex, string age, string paidFare)
        {
            this.id = id;
            this.isDrowned = isDrowned;
            this.passengerClass = passengerClass;
            this.sex = sex;
            this.age = age;
            this.paidFare = paidFare;
        }

        public override string ToString()
        {
            return id + " " + isDrowned + " " + passengerClass + " " + sex + " " + age + " " + paidFare;
        }
    }
}
