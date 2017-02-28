﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoulEngine.Enums;
using SoulEngine.Events;

namespace SoulEngine.Objects
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    // Public Repository: https://github.com/Cryru/SoulEngine                   //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Used for timing events independent of FPS, but on real time.
    /// </summary>
    public class Ticker : IDisposable
    {
        #region "Variables"
        #region "Settings"
        /// <summary>
        /// The delay between ticks.
        /// </summary>
        public float Delay;
        #endregion
        #region "Information"
        /// <summary>
        /// The number of times the ticker has ticked.
        /// </summary>
        public int Ticks
        {
            get
            {
                return _Ticks;
            }
        }
        /// <summary>
        /// The limit of how many times the ticker should tick.
        /// If -1 then the ticker will tick forever.
        /// </summary>
        public int Limit;
        /// <summary>
        /// Returns true if the current tick is the last.
        /// </summary>
        public bool isLastTick
        {
            get
            {
                return _Ticks == Limit && _State != TickerState.Done;
            }
        }
        /// <summary>
        /// The total time it would take for all ticks to run.
        /// </summary>
        public int TotalTime
        {
            get
            {
                if (Limit == -1) return -1;
                return Limit * (int)Delay;
            }
        }
        /// <summary>
        /// The time the ticker started.
        /// </summary>
        public DateTime TimeStarted
        {
            get
            {
                return _TimeStarted;
            }
        }
        /// <summary>
        /// The time that has passed since the ticker started in milliseconds.
        /// </summary>
        public float TimeSinceStart
        {
            get
            {
                return Ticks * Delay;
            }
        }
        #endregion
        #region "State"
        /// <summary>
        /// The state of the ticker.
        /// </summary>
        public TickerState State
        {
            get
            {
                return _State;
            }
        }
        /// <summary>
        /// The state of the ticker. Private holder.
        /// </summary>
        protected TickerState _State;
        #endregion
        #region "Private Workings"
        /// <summary>
        /// The variable that records time.
        /// </summary>
        private float time;
        /// <summary>
        /// The number of time the ticker has ticked. Private holder.
        /// </summary>
        private int _Ticks;
        /// <summary>
        /// The time the ticker started.
        /// </summary>
        private DateTime _TimeStarted;
        #endregion
        #endregion

        /// <summary>
        /// Creates a ticker with the specified parameters.
        /// </summary>
        /// <param name="Delay">The delay between ticks.</param>
        /// <param name="Limit">The number of times the ticker should tick. If below 0 it will go on forever.</param>
        public Ticker(float Delay = 100, int Limit = -1, bool startNow = false)
        {
            this.Delay = Delay;
            this.Limit = Limit;

            //Record starting time.
            _TimeStarted = DateTime.Now;

            //Check if ticking should start.
            if (startNow) _State = TickerState.Running; else _State = TickerState.Paused;

            //Add the ticker to the global list.
            ESystem.Add(new Listen(EType.GAME_FRAMESTART, Update, Context.Core));
        }

        /// <summary>
        /// Is run every tick by the Core. Invokes triggers and calculates time passing.
        /// </summary>
        public void Update(Event e)
        {
            switch(_State) //Check which state we are in.
            {
                case TickerState.Paused: //If paused.
                case TickerState.Done: //If done.
                    break; //All three of this don't require any action.

                case TickerState.Running: //If running.

                    //Increment the time by the time that passed since the last frame.
                    time += Context.Core.frameTime;

                    //If enough time has passed then tick.
                    if (time > Delay)
                    {
                        ESystem.Add(new Event(EType.TICKER_TICK, this, _Ticks));
                        time -= Delay;
                        _Ticks++;
                    }

                    //Check if at limit.
                    if (_Ticks == Limit && Limit > 0)
                    {
                        //Set the ticks to the limit, in case they are higher.
                        _Ticks = Limit;

                        //In which case run the ending event.
                        _State = TickerState.Done;
                        ESystem.Add(new Event(EType.TICKER_DONE, this));
                        //Unhook listeners from the object.
                        ESystem.Remove(this);
                        //Unhook object listener from core.
                        ESystem.Remove(Update);
                    }

                    break;
            }
        }

        #region "Operations"
        /// <summary>
        /// Pause the ticker.
        /// </summary>
        public virtual void Pause()
        {
            if (_State == TickerState.Running)
            {
                _State = TickerState.Paused;
            }
        }
        /// <summary>
        /// Start the ticker if paused.
        /// </summary>
        public virtual void Resume()
        {
            if (_State == TickerState.Paused)
            {
                _State = TickerState.Running;
            }
        }
        #endregion

        //Other
        #region "Disposing"
        /// <summary>
        /// Disposing flag to detect redundant calls.
        /// </summary>
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                //Free resources.
                ESystem.Remove(this);

                //Set disposing flag.
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
};