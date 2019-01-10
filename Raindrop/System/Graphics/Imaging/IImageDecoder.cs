using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.System.Graphics.Imaging
{
    public interface IImageDecoder
    {
        int[] Map { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        string MagicNumber { get; set; }

        void Load(byte[] raw);

        string ReadMagicNumber(byte[] raw);
    }
}
