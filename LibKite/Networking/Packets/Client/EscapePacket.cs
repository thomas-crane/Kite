﻿namespace LibKite.Networking.Packets.Client
{
    public class EscapePacket : Packet
    {
        public override PacketType Type
        { get { return PacketType.ESCAPE; } }

        public override void Read(PacketReader r)
        {
        }

        public override void Write(PacketWriter w)
        {
        }
    }
}
