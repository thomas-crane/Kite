﻿using LibKite.Networking.Packets.DataObjects;

namespace LibKite.Networking.Packets.Client
{
    public class ReskinPetPacket : Packet
    {
        public int PetId;
        public int NewPetType;
        public SlotObject Item;

        public override PacketType Type
        { get { return PacketType.RESKINPET; } }

        public override void Read(PacketReader r)
        {
            PetId = r.ReadInt32();
            NewPetType = r.ReadInt32();
            Item = (SlotObject)new SlotObject().Read(r);
        }

        public override void Write(PacketWriter w)
        {
            w.Write(PetId);
            w.Write(NewPetType);
            Item.Write(w);
        }
    }
}
