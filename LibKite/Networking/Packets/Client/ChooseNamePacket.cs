﻿namespace LibKite.Networking.Packets.Client
{
    public class ChooseNamePacket : Packet
    {
        public string Name;

        public override PacketType Type
        { get { return PacketType.CHOOSENAME; } }

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
