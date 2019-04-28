﻿namespace LibKite.Networking.Packets.Server
{
    public class TradeRequestedPacket : Packet
    {
        public string Name;

        public override PacketType Type
        { get { return PacketType.TRADEREQUESTED; } }

        public override void Read(PacketReader r)
        {
            Name = r.ReadString();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Name);
        }
    }
}
