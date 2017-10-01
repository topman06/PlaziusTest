using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            var planner = new MainPlanner();

            var cards = new List<TravelCard>(3)
            {
                new TravelCard("Мельбурн", "Варшава"),
                new TravelCard("Берлин", "Осло"),
                new TravelCard("Минск", "Волгоград"),
                new TravelCard("Москва", "Владивосток"),
                new TravelCard("Кельн", "Берлин"),
                new TravelCard("Милан", "Мельбурн"),
                new TravelCard("Осло", "Минск"),
                new TravelCard("Волгоград", "Милан"),
                new TravelCard("Владивосток", "Кельн")
            };

            planner.PlanMyTravel(cards).ForEach(item => Console.WriteLine($"{item.From} -> {item.To}"));

            //Сложность полученного алгоритма О(N)
            Console.ReadKey();
        }
    }
}
