﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    public interface ITravelPlanner
    {
        List<TravelCard> PlanMyTravel(List<TravelCard> travelCards);
    }
}
