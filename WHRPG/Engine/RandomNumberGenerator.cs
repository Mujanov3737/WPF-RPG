using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Engine
{
    public static class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        //Will get a random number between the two input values passed through
        //This code is a "non-deterministic" way of getting a random number. Much more random, less of a pattern.
        public static int NumberBetween(int minimumValue, int maxiumumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            //Using Math.Max and subtracting 0.00000001 to make sure "multiplier" can't possibly
            //be "1", otherwise it will cause problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            int range = maxiumumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);

        }

        /*  Significantly simpler way of getting a random number, but much less "random"
         
        private static readonly Random _simplerGen = new Random();
        public static int SimpleNumberBetween(int minimumValue, int maximumValue)
        {
            return _simplerGen.Next(minimumValue, maximumValue + 1)
        }
        */

    }
}
