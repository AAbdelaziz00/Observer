using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Net;
namespace Obser
{
    public class SysInfo
    {              
        protected internal string SetnRunProc()
        {
            int count = 0;
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                count++;
            }
            return count.ToString();
        }

        protected internal string SetHostname()
        {
            return (Dns.GetHostName()).ToString();
        } 
        protected internal string SetUpTime()
        {
            using (var uptime = new PerformanceCounter("System", "System Up Time"))
            {
                uptime.NextValue();       //Call this an extra time before reading its value
                return ((uptime.NextValue()) / 3600).ToString("0") + " minutes";
            }
        }
        protected internal string Temperatures()
        {
            string _Temp = "";
            try
            {
                List<SysInfo> result = new List<SysInfo>(); 
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
                foreach (ManagementObject obj in searcher.Get())
                {
                    Double temp = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                    temp = (((temp - 2732) / 10.0) * 1.8) + 32;
                    _Temp = temp.ToString() + " F";
                }
                return _Temp;
            }
            catch
            {
                return "erro";
            }
        }
    }
}