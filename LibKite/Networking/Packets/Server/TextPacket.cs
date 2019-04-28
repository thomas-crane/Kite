﻿namespace LibKite.Networking.Packets.Server
{
    public class TextPacket : Packet
    {
        public string Name;
        public int ObjectId;
        public int NumStars;
        public byte BubbleTime;
        public string Recipient;
        public string Text;
        public string CleanText;
        public bool isSupporter;

        public override PacketType Type
        { get { return PacketType.TEXT; } }

        public override void Read(PacketReader r)
        {
            Name = r.ReadString();
            ObjectId = r.ReadInt32();
            NumStars = r.ReadInt32();
            BubbleTime = r.ReadByte();
            Recipient = r.ReadString();
            Text = r.ReadString();
            CleanText = r.ReadString();
            isSupporter = r.ReadBoolean();
        }

        public override void Write(PacketWriter w)
        {
            w.Write(Name);
            w.Write(ObjectId);
            w.Write(NumStars);
            w.Write(BubbleTime);
            w.Write(Recipient);
            w.Write(Text);
            w.Write(CleanText);
            w.Write(isSupporter);
        }
    }
}
