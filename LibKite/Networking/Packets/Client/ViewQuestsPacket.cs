﻿namespace LibKite.Networking.Packets.Client
{
    public class ViewQuestsPacket : Packet
    {
        public override PacketType Type
        { get { return PacketType.VIEWQUESTS; } }

        public override void Read(PacketReader r)
        {
        }

        public override void Write(PacketWriter w)
        {
        }
    }
}
