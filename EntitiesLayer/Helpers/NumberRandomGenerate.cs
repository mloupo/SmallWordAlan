using System;

namespace CrearAnimales.EntitiesLayer.Helpers
{
    public class NumberRandomGenerate
    {
        private static Random _random = new Random();

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }

}

