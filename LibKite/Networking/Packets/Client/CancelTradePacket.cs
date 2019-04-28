namespace LibKite.Networking.Packets.Client
{
    public class CancelTradePacket : Packet
    {
        public override PacketType Type
        { get { return PacketType.CANCELTRADE; } }

        public override void Read(PacketReader r)
        {
        }

        public override void Write(PacketWriter w)
        {
        }
    }
}
