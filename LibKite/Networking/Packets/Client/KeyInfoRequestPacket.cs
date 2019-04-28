﻿namespace LibKite.Networking.Packets.Client
{
    public class KeyInfoRequestPacket : Packet
    {
        public byte[] Request;

        public override PacketType Type
        { get { return PacketType.KEYINFOREQUEST; } }

        public override void Read(PacketReader r)
        {
            Request = r.ReadBytes((int)r.BaseStream.Length - 5);
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Request);
        }
    }
}
