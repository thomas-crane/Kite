using LibKite.Networking.Packets.DataObjects;
using LibKite.Utilities;

namespace LibKite.Networking.Packets.Server
{
    public class ShowEffectPacket : Packet
    {
        public EffectType EffectType;
        public int TargetId;
        public Location PosA;
        public Location PosB;
        public ARGB Color;
        public float Duration;

        public override PacketType Type
        { get { return PacketType.SHOWEFFECT; } }

        public override void Read(PacketReader r)
        {
            EffectType = (EffectType)r.ReadByte();
            TargetId = r.ReadInt32();
            PosA = (Location)new Location().Read(r);
            PosB = (Location)new Location().Read(r);
            Color = ARGB.Read(r);
            Duration = r.ReadSingle();
        }

        public override void Write(PacketWriter w)
        {
            w.Write((byte)EffectType);
            w.Write(TargetId);
            PosA.Write(w);
            PosB.Write(w);
            Color.Write(w);
            w.Write(Duration);
        }
    }
}
