using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class AnimalTest
    {
        static Dictionary<Type, double> CalculateAverageAge(List<Animal> listOfAnimals)
        {
            Dictionary<Type, double> result = new Dictionary<Type, double>();
            var average =
                from animal in listOfAnimals
                group animal by animal.GetType() into grouped
                select grouped;
            foreach (var gr in average)
                result.Add(gr.Key, gr.Average(x => x.Age));
            return result;
        }

        static double CalculateAverageAge(List<Animal> listOfAnimals, Type theType)
        {
            var average =
                from animal in listOfAnimals
                where animal.GetType() == theType
                select animal;
            return average.Average(x => x.Age);
        }
        static void Main()
        {
            Kitten kitty1 = new Kitten("Kotence", 2, Genders.female);
            Kitten kitty2 = new Kitten("Pisence", 1, Genders.female);
            Kitten kitty3 = new Kitten("Kote", 3, Genders.female);
            Tomcat tomcat1 = new Tomcat("Kotarak", 5, Genders.male);
            Tomcat tomcat2 = new Tomcat("Tom", 8, Genders.male);
            Tomcat tomcat3 = new Tomcat("Kotka", 6, Genders.male);
            Frog frog1 = new Frog("Jaba", 3, Genders.female);
            Frog frog2 = new Frog("Kermit", 2, Genders.male);
            Frog frog3 = new Frog("Drug jabok", 4, Genders.male);
            Dog dog1 = new Dog("Kuchka", 7, Genders.female);
            Dog dog2 = new Dog("Pes", 10, Genders.male);
            Dog dog3 = new Dog("Balkan", 8, Genders.male);
            List<Animal> animals = new List<Animal>();
            animals.Add(kitty1);
            animals.Add(frog3);
            animals.Add(dog1);
            animals.Add(tomcat3);
            animals.Add(dog3);
            animals.Add(frog1);
            animals.Add(dog2);
            animals.Add(kitty3);
            animals.Add(frog2);
            animals.Add(tomcat1);
            animals.Add(kitty2);
            animals.Add(tomcat2);
            foreach (Animal animal in animals)
                Console.WriteLine(animal.MakeSound());
            Console.WriteLine();
            Dictionary<Type, double> averageAge = new Dictionary<Type, double>();
            averageAge = CalculateAverageAge(animals); // this return list of pairs (dictionary) "name-value" for each breed of animal.
            Console.WriteLine("Average ages ot all animals:");
            foreach (var animal in averageAge)
            {
                Console.WriteLine("{0}: {1}", animal.Key.Name, animal.Value);
            }
            Console.WriteLine();
            Console.WriteLine("Another way to get average age (for dogs) : {0}", CalculateAverageAge(animals, typeof(Dog)));
        }
    }
}
