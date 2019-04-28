﻿namespace LibKite.Networking.Packets.Client
{
    public class LoadPacket : Packet
    {
        public int CharacterId;
        public bool IsFromArena;

        public override PacketType Type
        { get { return PacketType.LOAD; } }

        public override void Read(PacketReader r)
        {
            CharacterId = r.ReadInt32();
            IsFromArena = r.ReadBoolean();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(CharacterId);
            w.Write(IsFromArena);
        }
    }
}
