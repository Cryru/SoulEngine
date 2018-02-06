﻿// SoulEngine - https://github.com/Cryru/SoulEngine

#region Using

using Soul.Engine;
using Soul.Engine.Scenography;

#endregion

namespace Examples.Basic
{
    public class CoreTest : Scene
    {
        public static void Main()
        {
            Core.Setup(new CoreTest());
        }

        protected override void Setup()
        {
        }
    }
}