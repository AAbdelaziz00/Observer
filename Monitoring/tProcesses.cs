using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace Obser
{
    class tProcesses
    {
        private List<string> _pNAME = new List<string>();
        private List<int> _pUSAGE = new List<int>();
        
        string[] pNameSORT = new string[20];
        int[] pUsageSORT = new int[20];

        String[,] Proccesses = new String[5,2];

        private PerformanceCounter ProccessPC = new PerformanceCounter("Process", "Working Set - Private");
        private Process[] processCollection = Process.GetProcesses();

        Dictionary<string, int> _TopProc = new Dictionary<string, int>();
        
        protected internal String[,] GetTP()
        {
            try
            {
                _TopProc.Clear();

                foreach (Process p in processCollection)
                {
                    ProccessPC.InstanceName = p.ProcessName;
                    _pNAME.Add(ProccessPC.InstanceName);
                    _pUSAGE.Add((Convert.ToInt32(ProccessPC.NextValue()) / (int)(1048576)));
                }
                
                ProccessPC.Close();
                ProccessPC.Dispose();

                for (int x = 0; x != 20;)
                {
                    int max = _pUSAGE.Max();
                    int n = _pUSAGE.IndexOf(max);

                    pNameSORT[x] = _pNAME[n];
                    pUsageSORT[x] = _pUSAGE[n];

                    _pUSAGE.RemoveAt(n);
                    _pNAME.RemoveAt(n);
                    x++;
                }

                int c = 0;
                foreach (string procc in pNameSORT)
                {
                    if (!_TopProc.ContainsKey(procc) && c <= 4)
                    {
                        _TopProc.Add(procc, pUsageSORT[c]);

                        Proccesses[c, 0] = procc;
                        Proccesses[c, 1] = pUsageSORT[c] + "MB";
                        c++;
                    }
                    else { }                  
                }
                return Proccesses;
            }
            catch { GetTP(); for (int ii = 0; ii != 1;) {
                } return null; };
        }
    }
}
