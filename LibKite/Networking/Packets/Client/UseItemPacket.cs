﻿using LibKite.Networking.Packets.DataObjects;

namespace LibKite.Networking.Packets.Client
{
    public class UseItemPacket : Packet
    {
        public int Time;
        public SlotObject SlotObject;
        public Location ItemUsePos;
        public byte UseType;

        public override PacketType Type
        { get { return PacketType.USEITEM; } }

        public override void Read(PacketReader r)
        {
            Time = r.ReadInt32();
            SlotObject = (SlotObject)new SlotObject().Read(r);
            ItemUsePos = (Location)new Location().Read(r);
            UseType = r.ReadByte();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Time);
            SlotObject.Write(w);
            ItemUsePos.Write(w);
            w.Write(UseType);
        }
    }
}
