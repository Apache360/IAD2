using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAD2
{
    class DataManager
    {
        public char[] data = null;
        public List<Passenger> passengerList= new List<Passenger>();
        public List<Passenger> passengerTemp= new List<Passenger>();
        public List<PassengerRaw> passengerRawList = new List<PassengerRaw>();

        public void setData(FileStream fileStream)
        {
            data = new char[fileStream.Length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (char)fileStream.ReadByte();
            }
        }

        public void processRawData()
        {
            passengerRawList = new List<PassengerRaw>();
            int id = 0, tagCounter = 0;
            string isDrowned = "", passengerClass = "", sex = "", age = "", paidFare = "";

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == ',')
                {
                    tagCounter++;
                }
                else
                {
                    if (data[i] == '\n')
                    {
                        passengerRawList.Add(new PassengerRaw(id, isDrowned, passengerClass, sex,age,paidFare));
                        tagCounter = 0;
                        isDrowned= passengerClass= sex=age = paidFare="";
                        id++;
                    }
                    else
                    {
                        switch (tagCounter)
                        {
                            case 0:
                                isDrowned += data[i];
                                break;
                            case 1:
                                passengerClass += data[i];
                                break;
                            case 2:
                                sex += data[i];
                                break;
                            case 3:
                                age += data[i];
                                break;
                            case 4:
                                paidFare += data[i];
                                break;
                            default:
                                break;
                        }
                    }


                }

            }
        }

        public void processData()
        {
            bool isDrowned=false;
            int passengerClass=0;
            string sex="";
            double age=0;
            double paidFare =0;

            for (int i = 0; i < passengerRawList.Count; i++)
            {
                try
                {
                    try
                    {
                        isDrowned = Convert.ToBoolean(Convert.ToInt32(passengerRawList[i].isDrowned));
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    try
                    {
                        passengerClass = Convert.ToInt32(passengerRawList[i].passengerClass);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    try
                    {
                        sex = passengerRawList[i].sex;
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    try
                    {
                        age = Double.Parse(passengerRawList[i].age, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    try
                    {
                        paidFare = Double.Parse(passengerRawList[i].paidFare, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    passengerList.Add(new Passenger(passengerRawList[i].id, isDrowned, passengerClass,sex, age, paidFare));
                    passengerRawList.RemoveAt(i);
                    i--;


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void removeAnomalies()
        {
            passengerTemp = new List<Passenger>();
            Random random = new Random();

            for (int i = 0; i < passengerList.Count; i++)
            {
                if (passengerList[i].passengerClass < 1 || passengerList[i].passengerClass > 3)
                {
                    passengerTemp.Add(passengerList[i].Clone());
                    passengerList[i].passengerClass = random.Next(1, 3);
                }
                else
                {
                    if (passengerList[i].passengerClass == 3&& (passengerList[i].paidFare < 0 || passengerList[i].paidFare > 70))
                    {
                        passengerTemp.Add(passengerList[i].Clone());
                        passengerList[i].paidFare = random.Next(0,35);

                    }
                    if (passengerList[i].passengerClass == 2 && (passengerList[i].paidFare < 10|| passengerList[i].paidFare > 80))
                    {
                        passengerTemp.Add(passengerList[i].Clone());
                        passengerList[i].paidFare = random.Next(10, 80);
                    }
                    if (passengerList[i].passengerClass == 1 && (passengerList[i].paidFare < 25 || passengerList[i].paidFare > 1000))
                    {
                        passengerTemp.Add(passengerList[i].Clone());
                        passengerList[i].paidFare = random.Next(25, 1000);
                    }
                }

                if (passengerList[i].age < 0.083 || passengerList[i].age > 200)
                {
                    passengerTemp.Add(passengerList[i].Clone());
                    passengerList[i].age = random.Next(1, 100);
                }

                if (passengerList[i].sex !="female" && passengerList[i].sex != "male")
                {
                    passengerTemp.Add(passengerList[i].Clone());
                    passengerList[i].sex = "male";
                }
                if (passengerList[i].paidFare >1000)
                {
                    passengerList[i].paidFare= random.Next(0, 500);
                }
            }
        }

        public void showData()
        {
            for (int i = 0; i < passengerList.Count; i++)
            {
                Console.WriteLine(passengerList[i].ToString());
            }
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < passengerRawList.Count; i++)
            {
                Console.WriteLine(passengerRawList[i].ToString());
            }
        }
    }
}
