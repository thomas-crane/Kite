﻿namespace LibKite.Networking.Packets.Server
{
    public class VerifyEmailDialogPacket : Packet
    {
        public override PacketType Type
        { get { return PacketType.VERIFYEMAILDIALOG; } }

        public override void Read(PacketReader r)
        {
        }

        public override void Write(PacketWriter w)
        {
        }
    }
}
