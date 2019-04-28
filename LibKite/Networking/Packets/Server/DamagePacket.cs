﻿using LibKite.Utilities;
using System.Collections.Generic;

namespace LibKite.Networking.Packets.Server
{
    public class DamagePacket : Packet
    {
        public int TargetId;
        public ConditionEffects Effects;
        public ushort Damage;
        public bool Killed;
        public byte BulletId;
        public int ObjectId;
        public bool armorPierce;

        public override PacketType Type
        { get { return PacketType.DAMAGE; } }

        public override void Read(PacketReader r)
        {
            TargetId = r.ReadInt32();
            byte c = r.ReadByte();
            Effects = 0;
            for (int i = 0; i < c; i++)
                Effects |= (ConditionEffects)(1 << r.ReadByte());
            Damage = r.ReadUInt16();
            Killed = r.ReadBoolean();
            armorPierce = r.ReadBoolean();
            BulletId = r.ReadByte();
            ObjectId = r.ReadInt32();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(TargetId);
            List<byte> eff = new List<byte>();
            for (byte i = 1; i < 255; i++)
                if ((Effects & (ConditionEffects)(1 << i)) != 0)
                    eff.Add(i);
            w.Write((byte)eff.Count);
            foreach (byte i in eff) w.Write(i);
            w.Write(Damage);
            w.Write(Killed);
            w.Write(armorPierce);
            w.Write(BulletId);
            w.Write(ObjectId);
        }
    }
}
