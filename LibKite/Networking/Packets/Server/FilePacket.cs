﻿namespace LibKite.Networking.Packets.Server
{
    public class FilePacket : Packet
    {
        public string Name;
        public byte[] Bytes;

        public override PacketType Type
        { get { return PacketType.FILE; } }

        public override void Read(PacketReader r)
        {
            Name = r.ReadString();
            Bytes = new byte[r.ReadInt32()];
            Bytes = r.ReadBytes(Bytes.Length);
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Name);
            w.Write(Bytes.Length);
            w.Write(Bytes);
        }
    }
}
