﻿#region Using

using System;
using Emotion.Common;
using Emotion.Game.Time.Routines;

#endregion

namespace Emotion.Game.Time
{
    public class After : ITimer, IRoutineWaiter
    {
        public virtual float Delay { get; set; }

        public virtual float Progress
        {
            get => _timePassed / Delay;
        }

        protected float _timePassed;
        protected Action _function;

        public After(float delay, Action function = null)
        {
            Delay = delay;
            _function = function;
        }

        public virtual void Update(float timePassed)
        {
            if (Finished) return;

            _timePassed += timePassed;
            if (_timePassed >= Delay) End();
        }

        public virtual void End()
        {
            _timePassed = Delay;
            _function?.Invoke();
            Finished = true;
        }

        public virtual void Restart()
        {
            _timePassed = 0;
            Finished = false;
        }

        #region Routine Waiter API

        public bool Finished { get; protected set; }

        public void Update()
        {
            Update(Engine.DeltaTime);
        }

        #endregion

        public override string ToString()
        {
            return $"Delay: {Delay}, Progress: {Math.Round(Progress, 2)}, Finished: {Finished}";
        }
    }
}