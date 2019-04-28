﻿using LibKite.Networking.Packets;
using LibKite.Networking.Packets.Server;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace LibKite.Utilities
{
    public static class PluginUtils
    {
        /// <summary>
        /// Executes an action and properly catches and logs any exceptions.
        /// </summary>
        /// <param name="action">Operation to execute</param>
        /// <param name="errorProvider">Name of the sender if an exception occurs</param>
        /// <returns>If the operation was successful or not</returns>
        public static bool ProtectedInvoke(Action action, string errorProvider)
        {
            return ProtectedInvoke(action, errorProvider, null);
        }

        /// <summary>
        /// Executes an action and properly catches and logs any exceptions.
        /// </summary>
        /// <param name="action">Operation to execute</param>
        /// <param name="errorProvider">Name of the sender if an exception occurs</param>
        /// <param name="filteredException">The Type of exeception you wish to ignore/not log</param>
        /// <returns>If the operation was successful or not</returns>
        public static bool ProtectedInvoke(Action action, string errorProvider, Type filteredException)
        {
#if DEBUG
            action();
            return true;
#else
            try
            {
                action();
                return true;
            }
            catch (Exception e)
            {
                if (e.GetType() != filteredException)
                {
                    LogPluginException(e, errorProvider);
                }
                return false;
            }
#endif
        }

        /// <summary>
        /// Logs a formatted exception log including target site and exception details.
        /// </summary>
        /// <param name="e">Exception to log</param>
        /// <param name="caller">Name of operation that failed</param>
        public static void LogPluginException(Exception e, string caller)
        {
            MethodBase site = e.TargetSite;
            string methodName = site == null ? "<null method reference>" : site.Name;
            string className = site == null ? "" : site.ReflectedType.Name;

            Log("Error", "An exception was thrown\nwithin {0} \nat {1}\n\n{2}",
                caller, className + "." + methodName,
#if DEBUG
                e);
#else
                e.Message);
#endif
        }

        /// <summary>
        /// Logs a formatted string containing a sender and message.
        /// </summary>
        /// <param name="sender">Name of the module/system that is logging the message</param>
        /// <param name="message">Message to be logged</param>
        public static void Log(string sender, string message)
        {
            if (sender.Length > 13)
            {
                sender = sender.Substring(0, 13);
            }
            sender += "]";
            Console.WriteLine(string.Format("[{0,-15} {1}", sender, message));
        }

        /// <summary>
        /// Logs a formatted string containing a sender and message.
        /// </summary>
        /// <param name="sender">Name of the module/system that is logging the message</param>
        /// <param name="message">Message to be logged</param>
        /// <param name="list">Objects to be formatted into message</param>
        public static void Log(string sender, string message, params object[] list)
        {
            string formatted = string.Format(message, list);
            Log(sender, formatted);
        }

        /// <summary>
        /// Waits the specified amount of ms then invokes the callback.
        /// (Wait time is accurate down to ~50ms measurements)
        /// </summary>
        /// <param name="ms">Amount of time to wait</param>
        /// <param name="callback">Action to be invoked</param>
        public static void Delay(int ms, Action callback)
        {
            Task.Run(() =>
            {
                Thread.Sleep(ms);
                callback();
            });
        }

        /// <summary>
        /// Displays a notification above a specified object.
        /// </summary>
        /// <param name="objectId">Object to display the notification on</param>
        /// <param name="message">Message of the notification</param>
        /// <returns></returns>
        public static NotificationPacket CreateNotification(int objectId, string message)
        {
            return CreateNotification(objectId, 0x00FFFF, message);
        }

        /// <summary>
        /// Displays a notification above a specified object.
        /// </summary>
        /// <param name="objectId">Object to display the notification on</param>
        /// <param name="message">Message of the notification</param>
        /// <param name="color">Color of the notification text</param>
        /// <returns></returns>
        public static NotificationPacket CreateNotification(int objectId, int color, string message)
        {
            NotificationPacket notif = (NotificationPacket)Packet.Create(PacketType.NOTIFICATION);
            notif.ObjectId = objectId;
            notif.Message = "{\"key\":\"blank\",\"tokens\":{\"data\":\"" + message + "\"}}";
            notif.Color = color;
            return notif;
        }

        /// <summary>
        /// Creates an in-game message with the Oryx format and coloring.
        /// </summary>
        /// <param name="sender">Message sender</param>
        /// <param name="message">Message text</param>
        /// <returns></returns>
        public static TextPacket CreateOryxNotification(string sender, string message)
        {
            TextPacket tpacket = (TextPacket)Packet.Create(PacketType.TEXT);
            tpacket.BubbleTime = 0;
            tpacket.CleanText = message;
            tpacket.Name = "";
            tpacket.NumStars = -1;
            tpacket.ObjectId = -1;
            tpacket.Recipient = "";
            tpacket.Text = "<" + sender + "> " + message;
            return tpacket;
        }

        /// <summary>
        /// Creates an in-game message with the announcement format and coloring.
        /// </summary>
        /// <param name="message">Message text</param>
        /// <returns></returns>
        public static TextPacket CreateAnnouncement(string message)
        {
            TextPacket tpacket = Packet.Create<TextPacket>(PacketType.TEXT);
            tpacket.BubbleTime = 0;
            tpacket.CleanText = message;
            tpacket.Name = string.Empty;
            tpacket.NumStars = -1;
            tpacket.ObjectId = -1;
            tpacket.Recipient = string.Empty;
            tpacket.Text = message;
            return tpacket;
        }
    }
}
