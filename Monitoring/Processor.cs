using System;
using System.Management;
namespace Obser
{
    public class Processor
    {   
        
        protected internal string PhysicalProcessors()
        {
            string PhysicalProcessors = "";
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                PhysicalProcessors = item["NumberOfProcessors"].ToString();
            }

            return PhysicalProcessors;
        }

        protected internal string Cores()
        {
            int coreCount = 0;
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }

            return (coreCount).ToString();
        }
        
        protected internal string LogicalProcesors()
        {
            return Environment.ProcessorCount.ToString();
            
        }

        protected internal string CPUSpeed()
        {
            double FINALCPUSpeed = 0;
            var searcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
            foreach (var item in searcher.Get())
            {
                double clockSpeed = ((uint)item["MaxClockSpeed"]);
                FINALCPUSpeed = clockSpeed / 1000;
                
            }
            return (FINALCPUSpeed).ToString("0.##") + "GHz";
        }
    }
}
