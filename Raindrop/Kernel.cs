using Cosmos.HAL;
using Cosmos.System.ExtendedASCII;
using Cosmos.System.FileSystem;
using Cosmos.System.Graphics;
using Raindrop.Shells;
using Raindrop.System.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Color = System.Drawing.Color;
using Raindrop.System;

namespace Raindrop
{
    public class Kernel : Sys.Kernel
    {
        public static Shell current;
        public static CommandManager CM;
        public static bool running = true;
        public static string currentDirectory = @"0:\";
        public static CosmosVFS vFS = new CosmosVFS();
        public static string currentVolume = @"0:\";

        public static Sys.Console cnsl;
        public static TextScreen screen;

        public static string version = "0.0.1";
        public static string revision = "010920190552";

        public static bool ContainsVolumes()
        {
            var vols = vFS.GetVolumes();
            foreach (var vol in vols)
            {
                return true;
            }
            return false;
        }

        protected override void BeforeRun()
        {
            try
            {
                Console.Clear();
                Encoding.RegisterProvider(CosmosEncodingProvider.Instance);
                Console.InputEncoding = Encoding.GetEncoding(437);
                Console.OutputEncoding = Encoding.GetEncoding(437);

                screen = new TextScreen();
                cnsl = new Sys.Console(screen);

                CustomConsole.WriteLineInfo("Booting Raindrop Operating System...");

                #region Register filesystem
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(vFS);
                if (ContainsVolumes())
                {
                    CustomConsole.WriteLineOK("FileSystem Registration");
                }
                else
                {
                    CustomConsole.WriteLineError("FileSystem Registration");
                }
                #endregion

                CM = new CommandManager();
                CustomConsole.WriteLineOK("Raindrop OS started fine.");

                Console.Clear();
                current = new Prompt();
                vFS.CreateDirectory(currentDirectory + @"Test");
                vFS.CreateDirectory(currentDirectory + @"Test\atabo");
                vFS.CreateFile(currentDirectory + @"Test\atabo.rd");
                vFS.CreateFile(currentDirectory + @"Test\passwd.nonono");
                vFS.CreateFile(currentDirectory + @"Test\.hiddenfile.txt");
                vFS.CreateFile(currentDirectory + @"root.conf");
            }
            catch (Exception ex)
            {
                Crash.StopKernel(ex);
            }
        }

        protected override void Run()
        {
            try
            {
                current.Run();
            }
            catch (Exception ex)
            {
                Crash.StopKernel(ex);
            }
        }
    }
}
