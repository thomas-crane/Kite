﻿namespace LibKite.Networking.Packets.Client
{
    public class SetConditionPacket : Packet
    {
        public byte ConditionEffect;
        public float ConditionDuration;

        public override PacketType Type
        { get { return PacketType.SETCONDITION; } }

        public override void Read(PacketReader r)
        {
            ConditionEffect = r.ReadByte();
            ConditionDuration = r.ReadSingle();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(ConditionEffect);
            w.Write(ConditionDuration);
        }
    }
}
