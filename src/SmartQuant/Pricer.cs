// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;

namespace SmartQuant
{
    public class Pricer
    {
        private Framework framework;

        public Pricer(Framework framework)
        {
            this.framework = framework;
        }

        public virtual double GetPrice(Position position)
        {
            return 0.0;
        }
    }
}
