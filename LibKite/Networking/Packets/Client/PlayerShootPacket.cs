﻿using LibKite.Networking.Packets.DataObjects;

namespace LibKite.Networking.Packets.Client
{
    public class PlayerShootPacket : Packet
    {
        public int Time;
        public byte BulletId;
        public short ContainerType;
        public Location Position;
        public float Angle;

        public override PacketType Type
        { get { return PacketType.PLAYERSHOOT; } }

        public override void Read(PacketReader r)
        {
            Time = r.ReadInt32();
            BulletId = r.ReadByte();
            ContainerType = r.ReadInt16();
            Position = (Location)new Location().Read(r);
            Angle = r.ReadSingle();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Time);
            w.Write(BulletId);
            w.Write(ContainerType);
            Position.Write(w);
            w.Write(Angle);
        }
    }
}
