﻿using LibKite.Networking.Packets.DataObjects;

namespace LibKite.Networking.Packets.Server
{
    public class GotoPacket : Packet
    {
        public int ObjectId;
        public Location Location;

        public override PacketType Type
        { get { return PacketType.GOTO; } }

        public override void Read(PacketReader r)
        {
            ObjectId = r.ReadInt32();
            Location = (Location)new Location().Read(r);
        }

        public override void Write(PacketWriter w)
        {
            w.Write(ObjectId);
            Location.Write(w);
        }
    }
}
