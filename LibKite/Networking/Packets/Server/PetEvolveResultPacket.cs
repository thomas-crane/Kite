﻿namespace LibKite.Networking.Packets.Server
{
    public class PetEvolveResultPacket : Packet
    {
        public int PetId;
        public int SkinId1;
        public int SkinId2;

        public override PacketType Type
        { get { return PacketType.EVOLVEPET; } }

        public override void Read(PacketReader r)
        {
            PetId = r.ReadInt32();
            SkinId1 = r.ReadInt32();
            SkinId2 = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(PetId);
            w.Write(SkinId1);
            w.Write(SkinId2);
        }
    }
}
