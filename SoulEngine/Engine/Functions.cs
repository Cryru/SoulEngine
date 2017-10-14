﻿// SoulEngine - https://github.com/Cryru/SoulEngine

using System;

namespace Soul.Engine
{
    /// <summary>
    /// Generic helper functions.
    /// </summary>
    public static class Functions
    {
        private static Random _generator = new Random();
        /// <summary>
        /// Generates a random number within the specified range.
        /// </summary>
        /// <param name="min">The smallest the number can be.</param>
        /// <param name="max">The highest the number can be.</param>
        /// <returns></returns>
        public static int GenerateRandomNumber(int min = 0, int max = 100)
        {
            //We add one because by Random.Next does not include max.
            return _generator.Next(min, max + 1);
        }
    }
}