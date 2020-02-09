﻿#region Using

using System;

#endregion

namespace Emotion.Game.Time
{
    public class Every : ITimer
    {
        public float Progress
        {
            get => _timePassed / _delay;
        }

        public float CountProgress
        {
            get => _count < 0 ? 0 : _currentCount / _count;
        }

        private float _timePassed;
        private int _currentCount;

        private float _delay;
        private Action _function;
        private int _count;
        private Action _after;

        internal Every(float delay, Action function, int count = -1, Action after = null)
        {
            _delay = delay;
            _function = function;
            _count = count;
            _after = after;
        }

        public void Update(float timePassed)
        {
            _timePassed += timePassed;

            while (timePassed >= _delay)
            {
                timePassed -= _delay;

                CallFunc();

                // Check if the current count is sufficient.
                if (_currentCount >= _count && _count > 0) _after?.Invoke();
            }
        }

        public void End()
        {
            if (_count > 0)
                for (int i = _currentCount; i <= _count; i++)
                {
                    CallFunc();
                }

            _after?.Invoke();
        }

        public void Restart()
        {
            _currentCount = 0;
            _timePassed = 0;
        }

        /// <summary>
        /// Increment count and call callback.
        /// </summary>
        private void CallFunc()
        {
            _function?.Invoke();
            _currentCount++;
        }
    }
}