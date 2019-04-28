using LibKite.Networking.Packets.DataObjects;

namespace LibKite.Networking.Packets.Server
{
    public class PicPacket : Packet
    {
        public BitmapData BitmapData;

        public override PacketType Type
        { get { return PacketType.PIC; } }

        public override void Read(PacketReader r)
        {
            BitmapData = (BitmapData)BitmapData.Read(r);
        }

        public override void Write(PacketWriter w)
        {
            BitmapData.Write(w);
        }
    }
}
