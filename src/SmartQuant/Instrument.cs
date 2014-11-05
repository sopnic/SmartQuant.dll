﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace SmartQuant
{
    public class Instrument
    {
        [Browsable(false)]
        public ObjectTable Fields { get; private set; }

        [Browsable(false)]
        public Instrument Parent { get; set; }

        [Category("Appearance")]
        [Description("Instrument symbol")]
        public string Symbol { get; private set; }

        [Category("Appearance")]
        [Description("Unique instrument id in SmartQuant framework")]
        public int Id { get; set; }

        [Category("Appearance")]
        [Description("Instrument Type (Stock, Futures, Option, Bond, ETF, Index, etc.)")]
        public InstrumentType Type { get; private set; }

        [Category("Appearance")]
        [Description("Instrument description")]
        public string Description { get; set; }

        [Category("Appearance")]
        [Description("Instrument exchange")]
        public string Exchange { get; set; }

        [Category("Appearance")]
        [Description("Instrument currency code (USD, EUR, RUR, CAD, etc.)")]
        public byte CurrencyId { get; set; }

        [Category("FX")]
        [Description("Base currency code")]
        public byte CCY1 { get; set; }

        [Category("FX")]
        [Description("Counter currency code")]
        public byte CCY2 { get; set; }

        [Category("TickSize")]
        [Description("Instrument tick size")]
        [DefaultValue(0)]
        public double TickSize { get; set; }

        [Category("Derivative")]
        [Description("Instrument maturity")]
        public DateTime Maturity { get; set; }


        [Category("Derivative")]
        [Description("Contract Value Factor by which price must be adjusted to determine the true nominal value of one futures/options contract. (Qty * Price) * Factor = Nominal Value")]
        [DefaultValue(0)]
        public double Factor { get; set; }

        [Category("Derivative")]
        [Description("Instrument strike price")]
        [DefaultValue(0)]
        public double Strike { get; set; }

        [Category("Derivative")]
        [Description("Option type : put or call")]
        public PutCall PutCall { get; set; }

        [Category("Margin")]
        [Description("Initial margin (used in simulations)")]
        [DefaultValue(0)]
        public double Margin { get; set; }

        [Category("Display")]
        [Description("C# price format string (example: F4 - show four decimal numbers for Forex contracts)")]
        [DefaultValue("F2")]
        public string PriceFormat { get; set; }

        public AltIdList AltId { get; private set; }

        public List<Leg> Legs { get; private set; }

        [Browsable(false)]
        public Bid Bid { get; private set; }

        [Browsable(false)]
        public Ask Ask { get; private set; }

        [Browsable(false)]
        public Trade Trade { get; private set; }

        [Browsable(false)]
        public Bar Bar { get; private set; }

        public IDataProvider DataProvider { get; private set; }

        public IExecutionProvider ExecutionProvider { get; private set; }

        private Instrument()
        {
            Exchange = "";
            PriceFormat = "F2";
            AltId = new AltIdList();
            Legs = new List<Leg>();
            Fields = new ObjectTable();
        }

        public Instrument(Instrument instrument)
            : this()
        {
        }

        public Instrument(InstrumentType type, string symbol, string description = "", byte currencyId = global::SmartQuant.CurrencyId.USD)
            : this()
        {
            Type = type;
            Symbol = symbol;
            Description = description;
            CurrencyId = currencyId;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Description) ? Symbol : string.Format("{0}({1})", Symbol, Description);
        }

        public Instrument Clone(string symbol = null)
        {
            var instrument = new Instrument(this);
            if (symbol != null)
                instrument.Symbol = symbol;
            return instrument;
        }
    }
}