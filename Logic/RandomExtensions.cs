using System;

namespace Logic
{
    public static class RandomExtensions
    {
        public static decimal NextDecimal(this Random random)
        {
            return new Random().Next(10000) / 13.6m;
        }
    }
}
