﻿namespace LibKite.Networking.Packets.Server
{
    public class NameResultPacket : Packet
    {
        public bool Success;
        public string ErrorText;

        public override PacketType Type
        { get { return PacketType.NAMERESULT; } }

        public override void Read(PacketReader r)
        {
            Success = r.ReadBoolean();
            ErrorText = r.ReadString();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Success);
            w.Write(ErrorText);
        }
    }
}
