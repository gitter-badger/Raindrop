using Raindrop.System.Utils;
using System;
using static Cosmos.HAL.PCIDevice;

namespace Raindrop.Com.Commands
{
    public static class Lspci
    {
        public static string Name = "lspci";
        public static string Info = "Lists PCI Devices";
        public static bool NeedsParam = false;

        public static void Run()
        {
            int count = 0;
            foreach (Cosmos.HAL.PCIDevice device in Cosmos.HAL.PCI.Devices)
            {
                Console.WriteLine(Conversion.D2(device.bus) + ":" + Conversion.D2(device.slot) + ":" 
                    + Conversion.D2(device.function) + " - " + "0x" + Conversion.D4(Conversion.DecToHex(device.VendorID)) 
                    + ":0x" + Conversion.D4(Conversion.DecToHex(device.DeviceID)) + " : " + 
                    DeviceClass.GetTypeString(device) + ": " + DeviceClass.GetDeviceString(device));
                count++;
                if (count == 19)
                {
                    Console.ReadKey();
                    count = 0;
                }
            }
        }
    }
}
