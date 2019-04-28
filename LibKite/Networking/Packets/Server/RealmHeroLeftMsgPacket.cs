
namespace LibKite.Networking.Packets.Server {
    class RealmHeroLeftMsgPacket: Packet {
        int Heros;
        public override PacketType Type 
        { get { return PacketType.REALMHEROLEFTMSG; } }

        public override void Read(PacketReader r) {
            Heros = r.ReadInt32();
        }

        public override void Write(PacketWriter w) {
            w.Write(Heros);
        }
    }
}
