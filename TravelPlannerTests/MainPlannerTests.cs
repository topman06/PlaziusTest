using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TravelPlanner;

namespace TravelPlannerTests
{
    [TestFixture]
    public class MainPlannerTests
    {
        ITravelPlanner planner;

        [SetUp]
        public void Init()
        {
            planner = new MainPlanner();
        }

        [Test]
        [TestCaseSource(typeof(TestCasesDataProvider), nameof(TestCasesDataProvider.GetTestCards))]
        public bool MainPlanner_PlanMyTravel_RightSorting(List<TravelCard> notSortedCards, List<TravelCard> sortedCards)
        {
            var methodResult = planner.PlanMyTravel(notSortedCards);

            for (int i = 0; i < sortedCards.Count; i++)
                if(sortedCards[i] != methodResult[i])
                    return false;

            return true;            
        }

        [Test]
        public void MainPlanner_PlanMyTravel_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => planner.PlanMyTravel(null));
        }
    }

    public static class TestCasesDataProvider
    {
        public static IEnumerable<TestCaseData> GetTestCards()
        {
            yield return new TestCaseData(new List<TravelCard>
            {
                new TravelCard("Владивосток", "Варшава"),
                new TravelCard("Волгоград", "Осло"),
                new TravelCard("Варшава", "Волгоград"),
                new TravelCard("Москва", "Владивосток")
            },
            new List<TravelCard>
            {
                new TravelCard("Москва", "Владивосток"),
                new TravelCard("Владивосток", "Варшава"),
                new TravelCard("Варшава", "Волгоград"),
                new TravelCard("Волгоград", "Осло")
            }).Returns(true);

            yield return new TestCaseData(new List<TravelCard>
            {
                new TravelCard("D", "E"),
                new TravelCard("A", "B"),
                new TravelCard("C", "D"),
                new TravelCard("B", "C")
            },
            new List<TravelCard>
            {
                new TravelCard("A", "B"),
                new TravelCard("B", "C"),
                new TravelCard("C", "D"),
                new TravelCard("D", "E")
            }).Returns(true);
        }
    }
}
