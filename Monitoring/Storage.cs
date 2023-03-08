using System;
using System.Diagnostics;
namespace Obser
{
    public class Storage
    {

        private PerformanceCounter diskPercentage = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total");
        private PerformanceCounter diskReadsPerformanceCounter = new PerformanceCounter("PhysicalDisk", "Disk Reads/sec", "_Total");
        private PerformanceCounter diskWritesPerformanceCounter = new PerformanceCounter("PhysicalDisk", "Disk Writes/sec", "_Total");
        protected internal PerformanceCounter diskTransfersPerformanceCounter = new PerformanceCounter("PhysicalDisk", "Disk Transfers/sec" , "_Total");

        protected internal double freeSpace;
        protected internal double totalSpace;

        protected internal string StorageSpace()
        {
            foreach (System.IO.DriveInfo Drive in System.IO.DriveInfo.GetDrives())
            {
                if (Drive.IsReady && Drive.Name == "C:\\") 
                {
                    freeSpace = (Drive.TotalFreeSpace);
                    totalSpace = (Drive.TotalSize);
                    
                }
            }
            return ((totalSpace - freeSpace)/ 1073741824).ToString("0.##") + " GB  / " + (totalSpace/ 1073741824).ToString("0.##") + " GB";
        }
     
        protected internal string setReadSpeed()
        {
            return ((this.diskReadsPerformanceCounter.NextValue() * 100).ToString("0.##") + " KB/s" +  Environment.NewLine);
        }

        protected internal string setWriteSpeed()
        {
            return ((this.diskWritesPerformanceCounter.NextValue() * 100).ToString("0.##")+ " KB/s" + Environment.NewLine);
        }
        protected internal string setTransferSpeed()
        {
            return (this.diskTransfersPerformanceCounter.NextValue()* 100).ToString("0.##") + " KB/s" + Environment.NewLine;
        }
        protected internal int setCPUUsage()
        {
            return (100 - ((int)diskPercentage.NextValue()));
        }
    }
}
