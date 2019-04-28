﻿namespace LibKite.Networking.Packets.Server
{
    public class QuestObjIdPacket : Packet
    {
        public int ObjectId;

        public override PacketType Type
        { get { return PacketType.QUESTOBJID; } }

        public override void Read(PacketReader r)
        {
            ObjectId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(ObjectId);
        }
    }
}
