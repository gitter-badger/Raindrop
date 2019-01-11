using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Com.Commands
{
    public static class MD5
    {
        public static string Name = "md5";
        public static string Info = "Generates a MD5 hash from a string";
        public static bool NeedsParam = true;

        public static void Run(string str)
        {
            Apps.User.CryptoTool.HashMD5(str);
        }
    }
}
