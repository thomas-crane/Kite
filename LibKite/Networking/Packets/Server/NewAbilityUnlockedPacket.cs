﻿using LibKite.Utilities;

namespace LibKite.Networking.Packets.Server
{
    public class NewAbilityUnlockedPacket : Packet
    {
        public Ability AbilityType;

        public override PacketType Type
        { get { return PacketType.NEWABILITYUNLOCKED; } }

        public override void Read(PacketReader r)
        {
            AbilityType = (Ability)r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write((int)Type);
        }
    }
}
