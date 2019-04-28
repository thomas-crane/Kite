using LibKite.Networking.Packets.DataObjects;
using LibKite.Utilities;

namespace LibKite.Networking.Packets.Client
{
    public class AoEPacket : Packet
    {
        public Location Location;
        public float Radius;
        public ushort Damage;
        public ConditionEffectIndex Effects;
        public float EffectDuration;
        public ushort OriginType;
        public int Color;
        public bool ArmorPierce;

        public override PacketType Type
        { get { return PacketType.AOE; } }

        public override void Read(PacketReader r)
        {
            Location = (Location)new Location().Read(r);
            Radius = r.ReadSingle();
            Damage = r.ReadUInt16();
            Effects = (ConditionEffectIndex)r.ReadByte();
            EffectDuration = r.ReadSingle();
            OriginType = r.ReadUInt16();
            Color = r.ReadInt32();
            ArmorPierce = r.ReadBoolean();
        }

        public override void Write(PacketWriter w)
        {
            Location.Write(w);
            w.Write(Radius);
            w.Write(Damage);
            w.Write((byte)Effects);
            w.Write(EffectDuration);
            w.Write(OriginType);
            w.Write(Color);
            w.Write(ArmorPierce);
        }
    }
}
