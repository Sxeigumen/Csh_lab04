using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        class Car
        {
            public string Name { get; set; }
            public int ProductionYear { get; set; }
            public int MaxSpeed { get; set; }

            public Car(string _name, int _year, int _speed)
            {
                Name = _name;
                ProductionYear = _year;
                MaxSpeed = _speed;
            }
            public void print()
            {
                Console.WriteLine(Name);
                Console.WriteLine(ProductionYear);
                Console.WriteLine(MaxSpeed);
                Console.WriteLine("\n");
            }
        }

        public enum CarComparerType
        {
            ProductionYear,
            MaxSpeed,
            Name
        }

        class CarComparer : IComparer<Car>
        {
            private CarComparerType _carComparerType;
            public CarComparer(CarComparerType comparerType)
            {
                _carComparerType = comparerType;
            }
            public int Compare(Car car1, Car car2)
            {   
                if (_carComparerType == CarComparerType.Name)
                {
                    if (car1.Name.CompareTo(car2.Name) != 0)
                    {
                        return car1.Name.CompareTo(car2.Name);
                    }
                    return 0;
                }

                if (_carComparerType == CarComparerType.ProductionYear)
                {
                    if (car1.ProductionYear.CompareTo(car2.ProductionYear) != 0)
                    {
                        return car1.ProductionYear.CompareTo(car2.ProductionYear);
                    }
                    return 0;
                }

                if (_carComparerType == CarComparerType.MaxSpeed)
                {
                    if (car1.MaxSpeed.CompareTo(car2.MaxSpeed) != 0)
                    {
                        return car1.MaxSpeed.CompareTo(car2.MaxSpeed);
                    }
                    return 0;
                }
                return 0;
            }
        }
        static void Main(string[] args)
        {
            Car car1 = new Car("Zhiga", 1990, 150);
            Car car2 = new Car("Mercedes", 2000, 180);
            Car car3 = new Car("BMW", 1980, 100);
            Car car4 = new Car("Kia", 2013, 160);
            List<Car> collection = new List<Car> { car1, car2, car3, car4 };

            collection.Sort(new CarComparer(CarComparerType.Name));
            Console.WriteLine("Сортировка по имени");
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i].print();
            }
            Console.WriteLine("=================");

            collection.Sort(new CarComparer(CarComparerType.ProductionYear));
            Console.WriteLine("Сортировка по году производства");
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i].print();
            }
            Console.WriteLine("=================");

            collection.Sort(new CarComparer(CarComparerType.MaxSpeed));
            Console.WriteLine("Сортировка по скорости");
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i].print();
            }
            Console.WriteLine("=================");
        }
    }
}
