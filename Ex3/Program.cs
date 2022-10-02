using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
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
            MaxSpeed
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

            class CarCatalog
        {
            public List<Car> collection = new List<Car>();
            public CarCatalog(params Car[] cars)
            {
                for (int i = 0; i < cars.Length; ++i)
                {
                    collection.Add(cars[i]);
                }
            }
            public IEnumerator<Car> GetEnumerator()
            {
                for(int i = 0; i < collection.Count; ++i)
                {
                    yield return collection[i];
                }
            }

            public IEnumerable<Car> Reverse()
            {
                for (int i = collection.Count - 1; i >= 0; --i)
                {
                    yield return collection[i];
                }
            }

            public IEnumerable<Car> YearProduct()
            {
                collection.Sort(new CarComparer(CarComparerType.ProductionYear));
                for (int i = 0; i < collection.Count; ++i)
                {
                    yield return collection[i];
                }
            }

            public IEnumerable<Car> Speed()
            {
                collection.Sort(new CarComparer(CarComparerType.MaxSpeed));
                for (int i = 0; i < collection.Count; ++i)
                {
                    yield return collection[i];
                }
            }

        }
        static void Main(string[] args)
        {
            Car car1 = new Car("Zhiga", 1990, 150);
            Car car2 = new Car("Mercedes", 2000, 180);
            Car car3 = new Car("BMW", 1980, 100);
            Car car4 = new Car("Kia", 2013, 160);

            CarCatalog ct = new CarCatalog(car1, car2, car3, car4);

            foreach(Car elem in ct)
            {
                elem.print();
            }
            Console.WriteLine("=================");

            foreach (Car elem in ct.Reverse())
            {
                elem.print();
            }
            Console.WriteLine("=================");


            Console.WriteLine("Prod Year");
            foreach (Car elem in ct.YearProduct())
            {
                elem.print();
            }
            Console.WriteLine("=================");

            Console.WriteLine("Max Speed");
            foreach (Car elem in ct.Speed())
            {
                elem.print();
            }
            Console.WriteLine("=================");

        }
    }
}
