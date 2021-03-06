﻿namespace LibKite.Networking.Packets.Client
{
    public class CreatePacket : Packet
    {
        public ushort ClassType;
        public ushort SkinType;

        public override PacketType Type
        { get { return PacketType.CREATE; } }

        public override void Read(PacketReader r)
        {
            ClassType = r.ReadUInt16();
            SkinType = r.ReadUInt16();
        }

        public override void Write(PacketWriter w)
        {
            w.Write((ushort)ClassType);
            w.Write((ushort)SkinType);
        }
    }
}
