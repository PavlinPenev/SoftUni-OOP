﻿namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal DefaultPrice = 3.50M;
        private const double DefaultMilliliters = 50;
        public Coffee(string name, double caffeine)
            : base(name, DefaultPrice, DefaultMilliliters)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
