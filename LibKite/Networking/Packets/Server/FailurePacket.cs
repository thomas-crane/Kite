﻿namespace LibKite.Networking.Packets.Server
{
    public class FailurePacket : Packet
    {
        public int ErrorId;
        public string ErrorMessage;

        public override PacketType Type
        { get { return PacketType.FAILURE; } }

        public override void Read(PacketReader r)
        {
            ErrorId = r.ReadInt32();
            ErrorMessage = r.ReadString();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(ErrorId);
            w.Write(ErrorMessage);
        }
    }
}
