﻿namespace LibKite.Networking.Packets.Server
{
    public class PingPacket : Packet
    {
        public int Serial;

        public override PacketType Type
        { get { return PacketType.PING; } }

        public override void Read(PacketReader r)
        {
            Serial = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Serial);
        }
    }
}
