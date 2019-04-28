﻿namespace LibKite.Networking.Packets.DataObjects
{
    public class SlotObject : IDataObject
    {
        public int ObjectId;
        public byte SlotId;
        public int ObjectType;

        public IDataObject Read(PacketReader r)
        {
            ObjectId = r.ReadInt32();
            SlotId = r.ReadByte();
            ObjectType = r.ReadInt32();

            return this;
        }

        public void Write(PacketWriter w)
        {
            w.Write(ObjectId);
            w.Write(SlotId);
            w.Write(ObjectType);
        }

        public object Clone()
        {
            return new SlotObject
            {
                ObjectId = this.ObjectId,
                ObjectType = this.ObjectType,
                SlotId = this.SlotId
            };
        }

        public override string ToString()
        {
            return "{ ObjectId=" + ObjectId + ", SlotId=" + SlotId + ", ObjectType=" + ObjectType + " }";
        }
    }
}
