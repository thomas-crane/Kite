﻿namespace LibKite.Networking.Packets.Client
{
    public class ReskinPacket : Packet
    {
        public int SkinId;

        public override PacketType Type
        { get { return PacketType.RESKIN; } }

        public override void Read(PacketReader r)
        {
            SkinId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(SkinId);
        }
    }
}
