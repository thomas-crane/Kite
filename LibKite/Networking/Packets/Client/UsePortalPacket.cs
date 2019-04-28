﻿namespace LibKite.Networking.Packets.Client
{
    public class UsePortalPacket : Packet
    {
        public int ObjectId;

        public override PacketType Type
        { get { return PacketType.USEPORTAL; } }

        public override void Read(PacketReader r)
        {
            this.ObjectId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(ObjectId);
        }
    }
}
