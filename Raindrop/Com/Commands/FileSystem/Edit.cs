using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Raindrop.Com.Commands
{
    public static class Edit
    {
        public static string Name = "edit";
        public static string Info = "Edits an file";
        public static bool NeedsParam = true;

        public static void Run(string edit, short startIndex = 0, short count = 5)
        {
            string file = edit;//edit.Remove(startIndex, count);
            if (File.Exists(Kernel.currentDirectory + file))
            {
                Apps.User.Editor application = new Apps.User.Editor();
                application.Start(file, Kernel.currentDirectory);
            }
            else
            {
                CustomConsole.WriteLineError("This file doesn't exist");
            }
        }
    }
}
