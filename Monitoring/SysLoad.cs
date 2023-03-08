using System.Diagnostics;
namespace Obser
{
    public class SysLoad
    {
        private static PerformanceCounter cpuperfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        private static PerformanceCounter ramPerfCounter = new PerformanceCounter("Memory", "Available Bytes");
        private static PerformanceCounter percentageRAMuse = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        
        protected internal string ramMANAGMENT()
        {
            
            double ACTUALtotalRAM = (new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory);
            string FINALTotalRAM = (ACTUALtotalRAM / 1073741824).ToString("0.##");
            
            double ACTUALAvalibleRAM = new Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory;
            double FinalRAMUse = ((ACTUALtotalRAM - ACTUALAvalibleRAM) / 1073741824);
            string FINALAvalibelRAMtoGB = FinalRAMUse.ToString("0.##") + " GB";

            string PercentageUse = "" +( (FinalRAMUse / (ACTUALtotalRAM /1073741824))* 100).ToString("0.##");
            return FINALAvalibelRAMtoGB + " / " + FINALTotalRAM +  "   " + PercentageUse +"%";
        }
        protected internal string cpuMANAGMENT()
        {
            return cpuperfCounter.NextValue().ToString("0.##") + "%";
        }
        protected internal int setPecentaegRAMuse()
        {
            return (int)percentageRAMuse.NextValue();
        }
    }
}