﻿using System;

namespace SmartQuant
{
    public class Leg
    {
        public Instrument Instrument { get; set; }

        public double Weight { get; set; }

        public Leg(Instrument instrument, double weight = 1)
        {
            Instrument = instrument;
            Weight = weight;
        }
    }
}

