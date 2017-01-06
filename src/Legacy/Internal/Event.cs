﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulEngine.Legacy.Objects.Internal
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    //                                                                          //
    // Copyright © 2016 Vlad Abadzhiev - TheCryru@gmail.com                     //
    //                                                                          //
    // For any questions and issues: https://github.com/Cryru/SoulEngine        //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// An object for handling events.
    /// </summary>
    public class Event
    {
        #region "Declarations"
        //A list of events to be invoked when the event is triggered that will not return anything.
        private List<Action> hookedMethods_NoArg = new List<Action>();
        #endregion

        #region "Adding"
        /// <summary>
        /// Adds a method to be invoked when the event is triggered.
        /// This method can also contain a single parameter that will usually the object that called it.
        /// </summary>
        /// <param name="m">The method to be invoked.</param>
        public void Add(Action m)
        {
            hookedMethods_NoArg.Add(m);
        }
        #endregion
        #region "Remove"
        /// <summary>
        /// Removes a method from the list of methods to be triggered.
        /// </summary>
        /// <param name="m">The method to be removed.</param>
        public void Remove(Action m)
        {
            if (hookedMethods_NoArg.IndexOf(m) != -1) hookedMethods_NoArg.Remove(m);
        }
        #endregion
        /// <summary>
        /// Trigger the event.
        /// </summary>
        /// <param name="obj">The object that triggered the event.</param>
        public void Trigger()
        {
            //Trigger events that are hooked without arguments.
            for (int i = 0; i < hookedMethods_NoArg.Count; i++)
            {
                hookedMethods_NoArg[i].Invoke();
            }
        }
        /// <summary>
        /// The number of methods linked to this event.
        /// </summary>
        public int Count()
        {
            return hookedMethods_NoArg.Count;
        }
    }
    /// <summary>
    /// Event with an argument. Can still accept no argument links.
    /// </summary>
    public class Event<T>
    {
        #region "Declarations"
        //A list of events to be invoked when the event is triggered that will return the object that triggered it.
        private List<Action<T>> hookedMethods_Arg = new List<Action<T>>();
        //A list of events to be invoked when the event is triggered that will not return anything.
        private List<Action> hookedMethods_NoArg = new List<Action>();
        #endregion

        #region "Adding"
        /// <summary>
        /// Adds a method to be invoked when the event is triggered.
        /// This method can also contain a single parameter that will usually the object that called it.
        /// </summary>
        /// <param name="m">The method to be invoked.</param>
        public void Add(Action m)
        {
            hookedMethods_NoArg.Add(m);
        }
        /// <summary>
        /// Adds a method to be invoked when the event is triggered.
        /// This method can be without a parameter.
        /// </summary>  
        /// <param name="m">The method to be invoked.</param>
        public void Add(Action<T> m)
        {
            hookedMethods_Arg.Add(m);
        }
        #endregion
        #region "Remove"
        /// <summary>
        /// Removes a method from the list of methods to be triggered.
        /// </summary>
        /// <param name="m">The method to be removed.</param>
        public void Remove(Action m)
        {
            if (hookedMethods_NoArg.IndexOf(m) != -1) hookedMethods_NoArg.Remove(m);
        }
        /// <summary>
        /// Removes a method from the list of methods to be triggered.
        /// </summary>
        /// <param name="m">The method to be removed.</param>
        public void Remove(Action<T> m)
        {
            if (hookedMethods_Arg.IndexOf(m) != -1) hookedMethods_Arg.Remove(m);
        }
        #endregion
        /// <summary>
        /// Trigger the event.
        /// </summary>
        /// <param name="obj">The object that triggered the event.</param>
        public void Trigger(T obj)
        {
            //Trigger events that are hooked with arguments first.
            for (int i = 0; i < hookedMethods_Arg.Count; i++)
            {
                hookedMethods_Arg[i].Invoke(obj);
            }
            //Trigger events that are hooked without arguments.
            for (int i = 0; i < hookedMethods_NoArg.Count; i++)
            {
                hookedMethods_NoArg[i].Invoke();
            }
        }
        /// <summary>
        /// The number of methods linked to this event.
        /// </summary>
        public int Count()
        {
            return hookedMethods_Arg.Count + hookedMethods_NoArg.Count;
        }
    }
    /// <summary>
    /// Event with two argument. Can still accept no argument links.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class Event<T, T2>
    {
        #region "Declarations"
        //A list of events to be invoked when the event is triggered that will return the object that triggered it.
        private List<Action<T, T2>> hookedMethods_Arg = new List<Action<T, T2>>();
        //A list of events to be invoked when the event is triggered that will not return anything.
        private List<Action> hookedMethods_NoArg = new List<Action>();
        #endregion

        #region "Adding"
        /// <summary>
        /// Adds a method to be invoked when the event is triggered.
        /// This method can also contain a single parameter that will usually the object that called it.
        /// </summary>
        /// <param name="m">The method to be invoked.</param>
        public void Add(Action m)
        {
            hookedMethods_NoArg.Add(m);
        }
        /// <summary>
        /// Adds a method to be invoked when the event is triggered.
        /// This method can be without a parameter.
        /// </summary>  
        /// <param name="m">The method to be invoked.</param>
        public void Add(Action<T, T2> m)
        {
            hookedMethods_Arg.Add(m);
        }
        #endregion
        #region "Remove"
        /// <summary>
        /// Removes a method from the list of methods to be triggered.
        /// </summary>
        /// <param name="m">The method to be removed.</param>
        public void Remove(Action m)
        {
            if (hookedMethods_NoArg.IndexOf(m) != -1) hookedMethods_NoArg.Remove(m);
        }
        /// <summary>
        /// Removes a method from the list of methods to be triggered.
        /// </summary>
        /// <param name="m">The method to be removed.</param>
        public void Remove(Action<T, T2> m)
        {
            if (hookedMethods_Arg.IndexOf(m) != -1) hookedMethods_Arg.Remove(m);
        }
        #endregion
        /// <summary>
        /// Trigger the event.
        /// </summary>
        /// <param name="obj">The object that triggered the event.</param>
        public void Trigger(T obj, T2 objTwo)
        {
            //Trigger events that are hooked with arguments first.
            for (int i = 0; i < hookedMethods_Arg.Count; i++)
            {
                hookedMethods_Arg[i].Invoke(obj, objTwo);
            }
            //Trigger events that are hooked without arguments.
            for (int i = 0; i < hookedMethods_NoArg.Count; i++)
            {
                hookedMethods_NoArg[i].Invoke();
            }
        }
        /// <summary>
        /// The number of methods linked to this event.
        /// </summary>
        public int Count()
        {
            return hookedMethods_Arg.Count + hookedMethods_NoArg.Count;
        }
    }
    /// <summary>
    /// Event with three argument. Can still accept no argument links.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class Event<T, T2, T3>
    {
        #region "Declarations"
        //A list of events to be invoked when the event is triggered that will return the object that triggered it.
        private List<Action<T, T2, T3>> hookedMethods_Arg = new List<Action<T, T2, T3>>();
        //A list of events to be invoked when the event is triggered that will not return anything.
        private List<Action> hookedMethods_NoArg = new List<Action>();
        #endregion

        #region "Adding"
        /// <summary>
        /// Adds a method to be invoked when the event is triggered.
        /// This method can also contain a single parameter that will usually the object that called it.
        /// </summary>
        /// <param name="m">The method to be invoked.</param>
        public void Add(Action m)
        {
            hookedMethods_NoArg.Add(m);
        }
        /// <summary>
        /// Adds a method to be invoked when the event is triggered.
        /// This method can be without a parameter.
        /// </summary>  
        /// <param name="m">The method to be invoked.</param>
        public void Add(Action<T, T2, T3> m)
        {
            hookedMethods_Arg.Add(m);
        }
        #endregion
        #region "Remove"
        /// <summary>
        /// Removes a method from the list of methods to be triggered.
        /// </summary>
        /// <param name="m">The method to be removed.</param>
        public void Remove(Action m)
        {
            if (hookedMethods_NoArg.IndexOf(m) != -1) hookedMethods_NoArg.Remove(m);
        }
        /// <summary>
        /// Removes a method from the list of methods to be triggered.
        /// </summary>
        /// <param name="m">The method to be removed.</param>
        public void Remove(Action<T, T2, T3> m)
        {
            if (hookedMethods_Arg.IndexOf(m) != -1) hookedMethods_Arg.Remove(m);
        }
        #endregion
        /// <summary>
        /// Trigger the event.
        /// </summary>
        /// <param name="obj">The object that triggered the event.</param>
        public void Trigger(T obj, T2 objTwo, T3 objThree)
        {
            //Trigger events that are hooked with arguments first.
            for (int i = 0; i < hookedMethods_Arg.Count; i++)
            {
                hookedMethods_Arg[i].Invoke(obj, objTwo, objThree);
            }
            //Trigger events that are hooked without arguments.
            for (int i = 0; i < hookedMethods_NoArg.Count; i++)
            {
                hookedMethods_NoArg[i].Invoke();
            }
        }
        /// <summary>
        /// The number of methods linked to this event.
        /// </summary>
        public int Count()
        {
            return hookedMethods_Arg.Count + hookedMethods_NoArg.Count;
        }
    }
}