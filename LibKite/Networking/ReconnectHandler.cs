﻿using LibKite.GameData.DataStructures;
using LibKite.Networking.Packets;
using LibKite.Networking.Packets.Client;
using LibKite.Networking.Packets.DataObjects;
using LibKite.Networking.Packets.Server;
using LibKite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibKite.Networking
{
    public class ReconnectHandler
    {
        private Proxy _proxy;
        public static event ChangeServerHandler ChangeDefault;
        public delegate void ChangeServerHandler(ServerStructure server);

        public void Attach(Proxy proxy)
        {
            _proxy = proxy;
            proxy.HookPacket<CreateSuccessPacket>(OnCreateSuccess);
            proxy.HookPacket<ReconnectPacket>(OnReconnect);
            proxy.HookPacket<HelloPacket>(OnHello);
            proxy.HookPacket<FailurePacket>((client, packet) => Console.WriteLine(packet.ErrorMessage));

            proxy.HookCommand("con", OnConnectCommand);// - Crazy Client overrides this anyways
            proxy.HookCommand("connect", OnConnectCommand);// - Crazy Client overrides this anyways too
            proxy.HookCommand("server", OnConnectCommand);
            proxy.HookCommand("recon", OnReconCommand);
            proxy.HookCommand("drecon", OnDreconCommand);
        }

        private void OnHello(Client client, HelloPacket packet)
        {
            client.State = _proxy.GetState(client, packet.Key);
            client.State.LastHello = packet;
            if (client.State.ConRealKey.Length != 0)
            {
                packet.Key = client.State.ConRealKey;
                client.State.ConRealKey = new byte[0];
            }
            client.Connect(packet);
            packet.Send = false;
        }

        private void OnCreateSuccess(Client client, CreateSuccessPacket packet)
        {
            if (true)
            {
                PluginUtils.Delay(1000, () =>
                {
                    string message = "Welcome to K Relay!";
                    string server = "";
                    if (GameData.GameData.Servers.Map.Where(s => s.Value.Address == client.State.ConTargetAddress).Any())
                    {
                        server = GameData.GameData.Servers.Match(s => s.Address == client.State.ConTargetAddress).Name;
                    }

                    if (server != "")
                    {
                        message += "\\n" + server;
                    }

                    client.SendToClient(PluginUtils.CreateNotification(client.ObjectId, message));
                });
            }
        }

        private void OnReconnect(Client client, ReconnectPacket ppacket)
        {
            ReconnectPacket packet = CloneReconnectPacket(client, ppacket);

            client.State.LastReconnect = CloneReconnectPacket(client, packet);
            packet.Send = false;
            if (packet.Host.Contains(".com"))
            {
                packet.Host = Dns.GetHostEntry(packet.Host).AddressList[0].ToString();
            }

            if (packet.Name.ToLower().Contains("nexusportal"))
            {
                client.State.LastRealm = CloneReconnectPacket(client, packet);
            }
            else if (packet.Name != "" && !packet.Name.Contains("vault") && packet.GameId != -2)
            {
                client.State.LastDungeon = CloneReconnectPacket(client, packet);
            }

            if (packet.Port != -1)
            {
                client.State.ConTargetPort = packet.Port;
            }

            if (packet.Host != "")
            {
                client.State.ConTargetAddress = packet.Host;
            }

            if (packet.Key.Length != 0)
            {
                client.State.ConRealKey = packet.Key;
            }

            // Tell the client to connect to the proxy
            ppacket.Key = Encoding.UTF8.GetBytes(client.State.GUID);
            ppacket.Host = "localhost";
            ppacket.Port = 2050;
            //client.SendToClient(packet);
        }

        public static ReconnectPacket CloneReconnectPacket(Client client, ReconnectPacket packet)
        {
            ReconnectPacket clone = (ReconnectPacket)Packet.Create(PacketType.RECONNECT);
            clone.IsFromArena = false;
            clone.GameId = packet.GameId;
            clone.Host = packet.Host == "" ? client.State.ConTargetAddress : packet.Host;
            clone.Port = packet.Port == -1 ? client.State.ConTargetPort : packet.Port;
            clone.Key = packet.Key;
            clone.Stats = packet.Stats;
            clone.KeyTime = packet.KeyTime;
            clone.Name = packet.Name;

            return clone;
        }

        private void OnConnectCommand(Client client, string command, string[] args)
        {
            if (args.Length == 0)
            {
                /*
                string LastConnection = ((MapInfoPacket)client.State["MapInfo"]).Name;
                string Text = GameData.GameData.Servers.Map.Single(x => x.Value.Address == Proxy.DefaultServer).Value.Name + ", ";

                Text = LastConnection == "Realm of the Mad God" ? client.State.LastReconnect.Name.Split('.').Last() : LastConnection;
                Text += GameData.GameData.Servers.Map.Where(x => x.Value.Address == client.State.ConTargetAddress).Count() == 0 ? client.State.LastRealm.Name.Split('.').Last() : LastConnection;

                TextPacket tpacket = (TextPacket)Packet.Create(PacketType.TEXT);
                tpacket.BubbleTime = 184;
                tpacket.NumStars = -1;
                tpacket.ObjectId = -1;
                tpacket.Name = "";
                tpacket.Recipient = "";
                tpacket.CleanText = "";
                tpacket.Text = Text;
                client.SendToClient(tpacket);
                */
            }
            else if (args.Length == 1)
            {
                string serverNameUpper = args[0].ToUpper();

                IEnumerable<ServerStructure> servers = GameData.GameData.Servers.Map.Where(x => x.Key == serverNameUpper || x.Value.Name.ToUpper() == serverNameUpper).Select(x => x.Value);

                if (servers.Count() == 1)
                {
                    ServerStructure server = servers.First();

                    ChangeDefault(server);

                    ReconnectPacket reconnect = (ReconnectPacket)Packet.Create(PacketType.RECONNECT);
                    reconnect.Host = server.Address;
                    reconnect.Port = 2050;
                    reconnect.GameId = -2;
                    reconnect.Name = "Nexus";
                    reconnect.IsFromArena = false;
                    reconnect.Key = new byte[0];
                    reconnect.KeyTime = 0;
                    reconnect.Stats = string.Empty;
                    SendReconnect(client, reconnect);
                }
                else
                {
                    client.SendToClient(PluginUtils.CreateOryxNotification("K Relay", "Unknown server!"));
                }
            }
        }

        public static void ChangeDefaultServer(ServerStructure server)
        {
            ChangeDefault(server);
        }

        private void OnReconCommand(Client client, string command, string[] args)
        {
            if (client.State.LastRealm != null)
            {
                SendReconnect(client, client.State.LastRealm);
            }
            else
            {
                client.SendToClient(PluginUtils.CreateOryxNotification("K Relay", "Last realm is unknown!"));
            }
        }

        private void OnDreconCommand(Client client, string command, string[] args)
        {
            if (client.State.LastDungeon != null)
            {
                SendReconnect(client, client.State.LastDungeon);
            }
            else
            {
                client.SendToClient(PluginUtils.CreateOryxNotification("K Relay", "Last dungeon is unknown!"));
            }
        }

        public static void SendReconnect(Client client, ReconnectPacket reconnect)
        {
            string host = reconnect.Host;
            int port = reconnect.Port;
            byte[] key = reconnect.Key;
            client.State.ConTargetAddress = host;
            client.State.ConTargetPort = port;
            client.State.ConRealKey = key;
            reconnect.Key = Encoding.UTF8.GetBytes(client.State.GUID);
            reconnect.Host = "localhost";
            reconnect.Port = 2050;

            client.SendToClient(reconnect);

            reconnect.Key = key;
            reconnect.Host = host;
            reconnect.Port = port;
        }
    }
}
