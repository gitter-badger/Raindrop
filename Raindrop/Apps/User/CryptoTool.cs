using System;
using Security = Raindrop.System.Security;
using System.Collections.ObjectModel;
using Raindrop.System.Security;

namespace Raindrop.Apps.User
{
    class CryptoTool
    {
        public static void HashMD5(string tohash)
        {
            string Hash = Security.MD5.hash(tohash);
            Console.WriteLine();
            Console.WriteLine("This is the result in MD5.");
            Console.WriteLine(" - " + Hash);
        }

        public static void HashSHA256(string tohash)
        {
            string Hash = Security.Sha256.hash(tohash);
            Console.WriteLine();
            Console.WriteLine("This is the result in SHA256.");
            Console.WriteLine(" - " + Hash);
        }
    }
}
