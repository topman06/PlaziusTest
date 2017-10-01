using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    public class MainPlanner : ITravelPlanner
    {
        public List<TravelCard> PlanMyTravel(List<TravelCard> travelCards)
        {
            if (travelCards == null)
                throw new ArgumentNullException(nameof(travelCards));

            if (travelCards.Count <= 1)
                return travelCards;

            var travelMap = new Dictionary<string, TravelCard>();
            var reverseTravelMap = new Dictionary<string, TravelCard>();

            //Словари с ключами из полей To и From исходного списка
            travelCards.ForEach(t =>
            {
                travelMap.Add(t.From, t);
                reverseTravelMap.Add(t.To, t);
            });

            var result = new LinkedList<TravelCard>();
            result.AddFirst(travelCards[0]);
            var controlCard = travelCards[0];

            //Растим список поочередно в разных направлениях
            while (reverseTravelMap.TryGetValue(controlCard.From, out controlCard))
                result.AddFirst(controlCard);

            controlCard = travelCards[0];
            while (travelMap.TryGetValue(controlCard.To, out controlCard))
                result.AddLast(controlCard);

            return result.ToList();
        }
    }
}
