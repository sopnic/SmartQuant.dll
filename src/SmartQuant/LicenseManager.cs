﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;

namespace SmartQuant
{
    public class LicenseManager
    {
        public LicenseInfo GetLicense()
        {
            return new LicenseInfo();
        }

        public string GetHardwareID()
        {
            throw new NotImplementedException();
        }

        public void LoadLicense(byte[] license)
        {
            throw new NotImplementedException();
        }

        internal LicenseManager()
        {
        }
    }
}

