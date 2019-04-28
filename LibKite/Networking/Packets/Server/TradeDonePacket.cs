﻿namespace LibKite.Networking.Packets.Server
{
    public class TradeDonePacket : Packet
    {
        /*
		TradeSuccessful = 0
		PlayerCanceled = 1
		*/

        public int Result;
        public string Message;

        public override PacketType Type
        { get { return PacketType.TRADEDONE; } }

        public override void Read(PacketReader r)
        {
            Result = r.ReadInt32();
            Message = r.ReadString();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Result);
            w.Write(Message);
        }
    }
}
