﻿using Raindrop.System.Utils;

namespace Raindrop.System.Graphics.Imaging.Decoders
{
    public class CIFDecoder : IImageDecoder
    {
        public int[] Map { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public string MagicNumber { get; set; }

        public CIFDecoder()
        {
            MagicNumber = "CIF"; // Magic number
        }

        public void Load(byte[] raw)
        {
            BinaryReader str = new BinaryReader(raw);

            Width = str.GetInt32();
            Height = str.GetInt32();
            Map = new int[Width * Height];

            for (int i = 0; i < Width * Height; i++)
            {
                Map[i] = str.GetInt32();// Read hex value of pixle
            }
        }

        public string ReadMagicNumber(byte[] raw)
        {
            // RWStream str = new RWStream(raw);
            return "CIF";//str.ReadString();//magicnumber
        }
    }
}
