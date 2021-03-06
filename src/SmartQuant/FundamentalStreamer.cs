﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;
using System.IO;

namespace SmartQuant
{
    public class FundamentalStreamer : ObjectStreamer
    {
        public FundamentalStreamer()
        {
            this.typeId = DataObjectType.Fundamental;
            this.type = typeof(Fundamental);
        }

        public override object Read(BinaryReader reader)
        {
            return new Fundamental(reader);
        }

        public override void Write(BinaryWriter writer, object obj)
        {
            (obj as Fundamental).Write(writer);
        }
    }
}
