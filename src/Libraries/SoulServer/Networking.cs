﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SoulServer;
using SoulEngine.Events;
using System.Net;
using SoulEngine.Enums;

namespace SoulEngine
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    // Public Repository: https://github.com/Cryru/SoulEngine                   //
    // SoulServer - A TCP server for use with SoulEngine.                       //
    // Public Repository: https://github.com/Cryru/SoulServer                   //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Networking and Multiplayer support with SoulServer. EXPERIMENTAL 
    /// </summary>
    public static class Networking
    {
        #region "Declarations"
        private static UdpClient Client;
        private static byte[] buffer;
        /// <summary>
        /// The login authentification hash.
        /// </summary>
        public static string Hash;
        /// <summary>
        /// The status of the connection between the client and the server.
        /// </summary>
        public static NetworkStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                //This assignment is done because the event listeners might use the status value.
                NetworkStatus old = value;
                status = value;
                ESystem.Add(new Event(EType.NETWORK_STATUSCHANGED, status, old));
                Debugging.Logger.Add("Network status changed " + old + " -> " + status);
            }
        }
        private static NetworkStatus status = NetworkStatus.Disabled;
        #endregion

        /// <summary>
        /// Sets up networking.
        /// </summary>
        public static void Setup()
        {
            status = NetworkStatus.None;
            buffer = new byte[1024];
            Scripting.ScriptEngine.ExposeFunction("connect", (Func<string, int, string, string, bool>) Connect);
        }

        /// <summary>
        /// Connects to the SoulServer on the provided IP and Port.
        /// </summary>
        /// <param name="IP">The IP of the server.</param>
        /// <param name="Port">The port of the server.</param>
        /// <param name="Username">The username to login with.</param>
        /// <param name="Password">The password login with.</param>
        /// <returns>A boolean that signifies whether the connection was successful.</returns>
        public static bool Connect(string IP, int Port, string Username, string Password)
        {
            //Check if already connected.
            if (Status != NetworkStatus.Connected && Settings.Networking)
            {
                try
                {
                    //Generate a socket to connect through.
                    Client = new UdpClient();
                    Client.Connect(new IPEndPoint(IPAddress.Parse(IP), Port));
                    //Generate a hash to authentificate with and send it to the server.
                    Send(new ServerMessage(MType.AUTHENTIFICATION, Soul.Encryption.MD5(Username + Password)));
                    //Start listening for messages.
                    Client.BeginReceive(ReceivedMessage, null);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        #region "Async Callbacks"
        /// <summary>
        /// When the server has sent us a message.
        /// </summary>
        private static void ReceivedMessage(IAsyncResult AR)
        {
            IPEndPoint receivedIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] receivedBytes = Client.EndReceive(AR, ref receivedIpEndPoint);

            //Get message.
            string message = Encoding.UTF8.GetString(receivedBytes);

            //If authentification message then this must be the hash to encrypt future correspondence.
            if(message.Length > 1 && message.Substring(0, 1) == "0" && (Hash == "" || Hash == null))
            {
                Hash = new ServerMessage(message).Data;
                Status = NetworkStatus.Connected;
            }
            else
            {
                string decryptMsg = Soul.Encryption.TryDecrypt(message, Hash, supressInvalidKey: true);

                //Check if any decryption occured.
                if(decryptMsg != message)
                {
                    ServerMessage msg = new ServerMessage(decryptMsg);
                    ESystem.Add(new Event(EType.NETWORK_MESSAGE, msg.Type, msg.Data));
                }
            }

            //Continue listening for packages.
            Client.BeginReceive(ReceivedMessage, null);
        }

        /// <summary>
        /// The callback for when a sending operation is complete.
        /// </summary>
        private static void SendEndCallback(IAsyncResult AR)
        {
            try
            {
                Client.EndSend(AR);
            }
            catch (Exception e)
            {
                Status = NetworkStatus.Disconnected;
            }
        }
        #endregion

        #region "Publics"
        /// <summary>
        /// Sends data to the connected server.
        /// </summary>
        /// <param name="Message">The message to send.</param>
        public static void Send(ServerMessage Message)
        {
            //Check if networking is on, and we have a client.
            if (!Settings.Networking || Client == null) return;

            try
            {
                string messageStr = Message.ToString();
                //Check if we have a hash to encrypt with.
                if (Hash != "" && Hash != null) messageStr = Soul.Encryption.Encrypt(messageStr, Hash);
                //Convert the string into bytes.
                byte[] send = Encoding.UTF8.GetBytes(messageStr.ToString());
                //Start sending, call the sent method.
                Client.BeginSend(send, send.Length, new AsyncCallback(SendEndCallback), null);
            }
            catch (Exception e)
            {
                Status = NetworkStatus.Disconnected;
            }
        }
        #endregion
    }
}