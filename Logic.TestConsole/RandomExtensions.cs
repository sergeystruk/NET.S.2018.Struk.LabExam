using System;

namespace Logic.TestConsole
{
    /// <summary>
    /// Class for generating random decimal
    /// </summary>
    public static class RandomExtensions
    {
        public static decimal NextDecimal(this Random random)
        {
            return new Random().Next(10, 100000) / 13.6m;
        }
    }
}
