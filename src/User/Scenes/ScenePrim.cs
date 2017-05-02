﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoulEngine.Objects;
using SoulEngine.Objects.Components;
using SoulEngine.Events;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace SoulEngine
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    // Public Repository: https://github.com/Cryru/SoulEngine                   //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// The first scene to load.
    /// </summary>
    public class ScenePrim : Scene
    {
        #region "Declarations"
        #endregion

        public override void Start()
        {
            AddObject("scrollbar_test", UIObject.Scrollbar());

            GetObject("scrollbar_test").Size = new Vector2(100, 15);
            GetObject("scrollbar_test").CenterObject();

            AddObject("button_test", UIObject.Button());
            GetObject("button_test").Size = new Vector2(50, 50);
            GetObject("button_test").CenterObject();
            GetObject("button_test").Y += 200;
        }

        public override void Update()
        {

        }
    }
}
