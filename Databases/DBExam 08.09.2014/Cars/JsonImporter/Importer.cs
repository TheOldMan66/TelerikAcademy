namespace JsonImporter
{
    using System;
    using System.Linq;
    using CarCorp.Model;
    using CarCorp.Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.IO;


    class Importer
    {
        static void Main(string[] args)
        {
            // Task 5:
            var db = new CarCorpDBContext();

            // Task 6:
            string dirPath = @"..\..\..\Data.Json.Files\";
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            FileInfo[] jsonFiles = dir.GetFiles("*.json");
            string fileAsString = "";
            foreach (var fileName in jsonFiles)
            {
                using (StreamReader sr = new StreamReader(dirPath + fileName))
                {
                    fileAsString = sr.ReadToEnd();
                }
                Car[] cars = JsonConvert.DeserializeObject<Car[]>(fileAsString);

                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model + " " + car.Price);
                }
                Console.ReadLine();
                foreach (var car in cars)
                {
                    Dealer dlr = new Dealer();
                    dlr.Name = car.Dealer.Name;
                    car.Dealer = dlr;
                    if (db.Dealers.Where(d => d.Name == dlr.Name).Count() == 0)
                    {
                        db.Dealers.Add(dlr);
                    }
                    Manufacturer mfg = new Manufacturer();
                    mfg.Name= car.Manufacturer.Name;
                    car.Manufacturer = mfg;
                    if (db.Manufacturers.Where(m => m.Name == mfg.Name).Count() == 0)
                    {
                        db.Manufacturers.Add(mfg);
                    }
                    db.Cars.Add(car);
                    Console.WriteLine(car);
                }
                db.SaveChanges();
            }

        }
    }
}
