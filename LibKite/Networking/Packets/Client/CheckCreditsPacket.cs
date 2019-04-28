namespace LibKite.Networking.Packets.Client
{
    public class CheckCreditsPacket : Packet
    {
        public override PacketType Type
        { get { return PacketType.CHECKCREDITS; } }

        public override void Read(PacketReader r)
        {
        }

        public override void Write(PacketWriter w)
        {
        }
    }
}
