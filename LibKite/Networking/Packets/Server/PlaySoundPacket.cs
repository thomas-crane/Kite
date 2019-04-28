﻿namespace LibKite.Networking.Packets.Server
{
    public class PlaySoundPacket : Packet
    {
        public int OwnerId;
        public int SoundId;

        public override PacketType Type
        { get { return PacketType.PLAYSOUND; } }

        public override void Read(PacketReader r)
        {
            OwnerId = r.ReadInt32();
            SoundId = r.ReadByte();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(OwnerId);
            w.Write((byte)SoundId);
        }
    }
}
