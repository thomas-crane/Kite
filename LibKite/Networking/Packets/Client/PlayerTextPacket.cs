namespace LibKite.Networking.Packets.Client
{
    public class PlayerTextPacket : Packet
    {
        public string Text;

        public override PacketType Type
        { get { return PacketType.PLAYERTEXT; } }

        public override void Read(PacketReader r)
        {
            Text = r.ReadString();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Text);
        }
    }
}
