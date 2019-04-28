﻿namespace LibKite.Networking.Packets.Server
{
    public class KeyInfoResponsePacket : Packet
    {
        public byte[] Response;

        public override PacketType Type
        { get { return PacketType.KEYINFORESPONSE; } }

        public override void Read(PacketReader r)
        {
            Response = r.ReadBytes((int)r.BaseStream.Length - 5);
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Response);
        }
    }
}
