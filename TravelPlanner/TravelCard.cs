using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    public class TravelCard
    {
        public string From { get; private set; }
        public string To { get; private set; }

        public TravelCard(string from, string to)
        {
            if (string.IsNullOrWhiteSpace(from))
                throw new ArgumentNullException(nameof(from));

            if (string.IsNullOrWhiteSpace(to))
                throw new ArgumentNullException(nameof(to));

            From = from;
            To = to;
        }

        public static bool operator == (TravelCard left, TravelCard right)
        {
            return (left?.From == right?.From && left?.To == right?.To);
        }

        public static bool operator !=(TravelCard left, TravelCard right)
        {
            return (left?.From != right?.From || left?.To != right?.To);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
