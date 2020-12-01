using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAD2
{
    class Passenger
    {
        public int id { get; set; }
        public bool isDrowned { get; set; }
        public int passengerClass { get; set; }
        public string sex { get; set; }
        public double age { get; set; }
        public double paidFare { get; set; }

        public Passenger(int id, bool isDrowned, int passengerClass, string sex, double age, double paidFare)
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
            return id.ToString() + " " + isDrowned.ToString() + " " + passengerClass + " " + sex + " " + age + " " + paidFare;
        }

        public Passenger Clone()
        {
            return new Passenger (id,isDrowned,passengerClass,sex,age,paidFare);
        }
    }
}
