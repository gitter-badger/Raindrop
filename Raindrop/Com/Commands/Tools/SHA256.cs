using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Com.Commands
{
    public static class SHA256
    {
        public static string Name = "sha256";
        public static string Info = "Generates a SHA256 hash from a string";
        public static bool NeedsParam = true;

        public static void Run(string str)
        {
            Apps.User.CryptoTool.HashSHA256(str);
        }
    }
}
