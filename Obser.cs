using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
namespace Obser
{
    public partial class Obser : Form
    {
        private static Processor processor = new Processor();
        private static Settings settings = new Settings();
        private static SysInfo sysInfo = new SysInfo();
        private static SysLoad SysLoad = new SysLoad();
        private static Storage storage = new Storage();
        private static Network network = new Network();
        private static tProcesses tP = new tProcesses();
        private static Video video = new Video();
        private static RAMs ram = new RAMs();
        
        private static Thread cpuThread;    private double[] cpuArray = new double[30];
        private static Thread transThread;  private double[] transArray = new double[30];
        
        private Label[,] pLabels = new Label[5, 2]; private string[,] Processes;

        Boolean isRunning = true;
        public Obser()
        {
            InitializeComponent();           
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            this.SetDesktopLocation(screenWidth - 171, 0);

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("Monitor", Application.ExecutablePath.ToString());
        }

        private void GetCPUPerformanceCounters()
        {

            var cpuPerfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            while (true)
            {
                cpuArray[cpuArray.Length - 1] = Math.Round(cpuPerfCounter.NextValue(), 0);

                Array.Copy(cpuArray, 1, cpuArray, 0, cpuArray.Length - 1);

                if (cpuChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                }
                Thread.Sleep(1000);
            }
        }
        private void UpdateCpuChart()
        {
            cpuChart.Series["Series1"].Points.Clear();

            for (int i = 0; i < cpuArray.Length - 1; ++i)
            {
                cpuChart.Series["Series1"].Points.AddY(cpuArray[i]);
            }
        }
        private void SetCPUChart()
        {
            cpuChart.ChartAreas[0].AxisY.Maximum = 100;
            cpuChart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            cpuChart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            cpuChart.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            cpuChart.ChartAreas[0].AxisX.Interval = 0;

            cpuChart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Transparent;
            cpuChart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            cpuChart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            cpuChart.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;

            cpuChart.ChartAreas[0].AxisX.LineWidth = 0;
            cpuChart.ChartAreas[0].AxisY.LineWidth = 0;

            cpuThread = new Thread(new ThreadStart(this.GetCPUPerformanceCounters));
            cpuThread.IsBackground = true;
            cpuThread.Start();
            cpuChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            cpuChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
        }

        private void GetTransPerformanceCounters()
        {

            var transPerfCounter = storage.diskTransfersPerformanceCounter;

            while (true)
            {
                transArray[transArray.Length - 1] = Math.Round(transPerfCounter.NextValue(), 0);

                Array.Copy(transArray, 1, transArray, 0, transArray.Length - 1);

                if (transChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateTransChart(); });
                }
                Thread.Sleep(1000);
            }
        }
        private void UpdateTransChart()
        {
            transChart.Series["Series1"].Points.Clear();

            for (int i = 0; i < cpuArray.Length - 1; ++i)
            {
                transChart.Series["Series1"].Points.AddY(transArray[i]);
            }
        }
        private void SetTransChart()
        {
            transChart.ChartAreas[0].BackColor = this.BackColor;

            transChart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            transChart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            transChart.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            transChart.ChartAreas[0].AxisX.Interval = 0;

            transChart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Transparent;
            transChart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            transChart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            transChart.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;

            transChart.ChartAreas[0].AxisX.LineWidth = 0;
            transChart.ChartAreas[0].AxisY.LineWidth = 0;

            transThread = new Thread(new ThreadStart(this.GetTransPerformanceCounters));
            transThread.IsBackground = true;
            transThread.Start();
            transChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            transChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
        }

        private void GetHeadlineLabels()
        {
            settings.HeadlineLabels.Add(label1);        settings.HeadlineLabels.Add(label6);
            settings.HeadlineLabels.Add(label13);       settings.HeadlineLabels.Add(label5);
            settings.HeadlineLabels.Add(label16);       settings.HeadlineLabels.Add(label36);
            settings.HeadlineLabels.Add(label31);
        }
        private void GetSubHeadlineLabel()
        {
            settings.Sub_HeadlineLabel.Add(label2);     settings.Sub_HeadlineLabel.Add(label3);
            settings.Sub_HeadlineLabel.Add(label4);     settings.Sub_HeadlineLabel.Add(label18);
            settings.Sub_HeadlineLabel.Add(label21);    settings.Sub_HeadlineLabel.Add(label22);
            settings.Sub_HeadlineLabel.Add(label19);    settings.Sub_HeadlineLabel.Add(label20);
            settings.Sub_HeadlineLabel.Add(label14);    settings.Sub_HeadlineLabel.Add(label15);
            settings.Sub_HeadlineLabel.Add(label9);     settings.Sub_HeadlineLabel.Add(label7);
            settings.Sub_HeadlineLabel.Add(label27);    settings.Sub_HeadlineLabel.Add(label28);
            settings.Sub_HeadlineLabel.Add(label35);    settings.Sub_HeadlineLabel.Add(label34);
            settings.Sub_HeadlineLabel.Add(label33);    settings.Sub_HeadlineLabel.Add(label32);
            settings.Sub_HeadlineLabel.Add(label30);    settings.Sub_HeadlineLabel.Add(label29);
            settings.Sub_HeadlineLabel.Add(label25);    settings.Sub_HeadlineLabel.Add(label12);
            settings.Sub_HeadlineLabel.Add(label26);    settings.Sub_HeadlineLabel.Add(label8);
            settings.Sub_HeadlineLabel.Add(label10);
        }
        private void GetReadingLabel()
        {
            settings.ReadingLabel.Add(Hostname);             settings.ReadingLabel.Add(Uptime);
            settings.ReadingLabel.Add(NumRunningProcesses);  settings.ReadingLabel.Add(MainDRIVE);
            settings.ReadingLabel.Add(ReadSpeed);            settings.ReadingLabel.Add(WriteSpeed);
            settings.ReadingLabel.Add(CPU);                  settings.ReadingLabel.Add(LocalIP);
            settings.ReadingLabel.Add(PublicIP);             settings.ReadingLabel.Add(Temp);
            settings.ReadingLabel.Add(TransferSpeed);        settings.ReadingLabel.Add(NumLogiProc);
            settings.ReadingLabel.Add(NumPhycProc);          settings.ReadingLabel.Add(CORES);
            settings.ReadingLabel.Add(CPUSpeed);             settings.ReadingLabel.Add(SSID);
            settings.ReadingLabel.Add(signal);               settings.ReadingLabel.Add(ramType);
            settings.ReadingLabel.Add(ramSize);              settings.ReadingLabel.Add(_Down);
            settings.ReadingLabel.Add(_Up);                  settings.ReadingLabel.Add(NumPhycProc);
            settings.ReadingLabel.Add(NumLogiProc);          settings.ReadingLabel.Add(CPUSpeed);
            settings.ReadingLabel.Add(CORES);                settings.ReadingLabel.Add(ramType);
            settings.ReadingLabel.Add(ramSize);              settings.ReadingLabel.Add(ramt);
            settings.ReadingLabel.Add(proc1);                settings.ReadingLabel.Add(proc2);
            settings.ReadingLabel.Add(proc3);                settings.ReadingLabel.Add(proc4);
            settings.ReadingLabel.Add(proc5);                settings.ReadingLabel.Add(pVal1);
            settings.ReadingLabel.Add(pVal2);                settings.ReadingLabel.Add(pVal3);
            settings.ReadingLabel.Add(pVal4);                settings.ReadingLabel.Add(pVal5);
            settings.ReadingLabel.Add(resolution);           settings.ReadingLabel.Add(CpuType);
            settings.ReadingLabel.Add(VideoType);
        }
        private void GetSectionPanels()
        {
            settings.SectionPanels.Add(_SysInfoPanel);       settings.SectionPanels.Add(_RamPanel);
            settings.SectionPanels.Add(_ProcPanel);          settings.SectionPanels.Add(_StogPanel);
            settings.SectionPanels.Add(_SysLoadPanel);       settings.SectionPanels.Add(_TpPanel);
            settings.SectionPanels.Add(_NetPanel);
        }
        private void GetpLabels()
        {
            pLabels[0, 0] = proc1;
            pLabels[0, 1] = pVal1;

            pLabels[1, 0] = proc2;
            pLabels[1, 1] = pVal2;

            pLabels[2, 0] = proc3;
            pLabels[2, 1] = pVal3;

            pLabels[3, 0] = proc4;
            pLabels[3, 1] = pVal4;

            pLabels[4, 0] = proc5;
            pLabels[4, 1] = pVal5;
        }
        private void GetBarGrah()
        {
            settings.barGRA.Add(driveUsage);        settings.barGRA.Add(RAMUsage);
            settings.barGRA.Add(cpuChart);          settings.barGRA.Add(transChart);        
        }
        private void GetTimers()
        {
            settings.GetTimers.Add(_SysInfo);       settings.GetTimers.Add(_Storage);
            settings.GetTimers.Add(_SysLoad);       settings.GetTimers.Add(_TProcc);
            settings.GetTimers.Add(_Network);       settings.GetTimers.Add(WindoMang);

        }

        private async void SetRam()
        {
            Task<string> setRamtype = new Task<string>(ram.SetRamType);
            setRamtype.Start();
            ramType.Text = await setRamtype;

            Task<string> setRamSize = new Task<string>(ram.SetRamSize);
            setRamSize.Start();
            ramSize.Text = await setRamSize;
        }
        private async void SetProc()
        {
            CpuType.Text = GetComponents("Win32_Processor", "Name");

            Task<string> _phyProc = new Task<string>(processor.PhysicalProcessors);
            _phyProc.Start();
            NumPhycProc.Text = await _phyProc;

            Task<string> _logiProc = new Task<string>(processor.LogicalProcesors);
            _logiProc.Start();
            NumLogiProc.Text = await _logiProc;

            Task<string> _Cores = new Task<string>(processor.Cores);
            _Cores.Start();
            CORES.Text = await _Cores;

            Task<string> _CoreSpeed = new Task<string>(processor.CPUSpeed);
            _CoreSpeed.Start();
            CPUSpeed.Text = await _CoreSpeed;
        }
        private void SetVideo()
        {
            resolution.Text = video.SetVideo();
            VideoType.Text = GetComponents("Win32_VideoController", "Name");

        }
        private void SetTP()
        {
            for (int x = 0; x != 5;)
            {
                pLabels[x, 0].Text = Processes[x, 0];
                pLabels[x, 1].Text = Processes[x, 1];
                x++;
            }
        }

        private string HardwareVesion;
        private string GetComponents(string HardwareClass, string Syntax)
        {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", " SELECT * FROM " + HardwareClass);
            foreach (ManagementObject ManagOBJECT in managementObjectSearcher.Get())
            {
                HardwareVesion = ManagOBJECT[Syntax].ToString();
            }

            return HardwareVesion;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread bgThread = new Thread(new ThreadStart(BGKeyboard));
            bgThread.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            bgThread.Start();

            settings.sbBTN = SettingsForm;

            SetVideo();                 SetCPUChart();
            SetTransChart();

            SetRam();                   SetProc();

            GetHeadlineLabels();        GetSubHeadlineLabel();
            GetReadingLabel();          GetSectionPanels();
            GetpLabels();               GetBarGrah();
            GetTimers();

            settings.LoadUserSettings();

            this.Opacity = settings.opacity;     this.BackColor = settings.windowColor;
        }

        void BGKeyboard()
        {
            Boolean status = false ;
            while(isRunning){
                Thread.Sleep(40);
                if ((Keyboard.GetKeyStates(Key.LeftAlt) & KeyStates.Down) > 0 && status == false)
                {
                    this.TopMost = true;
                    status = true;
                }
                if((Keyboard.GetKeyStates(Key.LeftAlt) & KeyStates.Down) > 0 && status == true)
                {
                    this.TopMost = false;
                    status = false;
                }
            }
        }

        private async void _SysInfo_Tick(object sender, EventArgs e)
        {
            Task<string> _Hostname = new Task<string>(sysInfo.SetHostname);
            _Hostname.Start();
            Hostname.Text = await _Hostname;

            Task<string> _nRunProc = new Task<string>(sysInfo.SetnRunProc);
            _nRunProc.Start();
            NumRunningProcesses.Text = await _nRunProc;

            Task<string> getUptimeTask = new Task<string>(sysInfo.SetUpTime);
            getUptimeTask.Start();
            Uptime.Text = await getUptimeTask;

            Task<string> _TempTask = new Task<string>(sysInfo.Temperatures);
            _TempTask.Start();
            Temp.Text = await _TempTask;

        }
        private async void _SysLoad_Tick(object sender, EventArgs e)
        {
            Task<string> setRAMTask = new Task<string>(SysLoad.ramMANAGMENT);
            setRAMTask.Start();
            ramt.Text = await setRAMTask;

            Task<string> setCPUTask = new Task<string>(SysLoad.cpuMANAGMENT);
            setCPUTask.Start();
            CPU.Text = await setCPUTask;

            Task<int> setRAMUseTask = new Task<int>(SysLoad.setPecentaegRAMuse);
            setRAMUseTask.Start();
            RAMUsage.Value = await setRAMUseTask;
        }
        private async void _Network_Tick(object sender, EventArgs e)
        {
            Task<string> setLocalIpTask = new Task<string>(network.setLocalIP);
            setLocalIpTask.Start();
            LocalIP.Text = await setLocalIpTask;

            Task<string> setPublicIPTask = new Task<string>(network.setPublicIP);
            setPublicIPTask.Start();
            PublicIP.Text = await setPublicIPTask;

            Task<string> setDown = new Task<string>(network.setDownload);
            setDown.Start();
            _Down.Text = await setDown;

            Task<string> setUp = new Task<string>(network.setUpload);
            setUp.Start();
            _Up.Text = await setUp;

            Task<string> setSSID = new Task<string>(network.wifiSSID);
            setSSID.Start();
            SSID.Text = await setSSID;

            Task<string> setSignal = new Task<string>(network.wifiSignal);
            setSignal.Start();
            signal.Text = await setSignal;
        }
        private async void _Storage_Tick(object sender, EventArgs e)
        {
            Task<string> setStorgaeTask = new Task<string>(storage.StorageSpace);
            setStorgaeTask.Start();
            MainDRIVE.Text = await setStorgaeTask;

            Task<string> setReadSpeedTask = new Task<string>(storage.setReadSpeed);
            setReadSpeedTask.Start();
            ReadSpeed.Text = await setReadSpeedTask;

            Task<string> setWriteSpeedTask = new Task<string>(storage.setWriteSpeed);
            setWriteSpeedTask.Start();
            WriteSpeed.Text = await setWriteSpeedTask;

            Task<string> setTransferSpeedTask = new Task<string>(storage.setTransferSpeed);
            setTransferSpeedTask.Start();
            TransferSpeed.Text = await setTransferSpeedTask;


            Task<int> setDriveUsageTask = new Task<int>(storage.setCPUUsage);
            setDriveUsageTask.Start();
            driveUsage.Value = await setDriveUsageTask;
        }
        private void WindoMang_Tick(object sender, EventArgs e)
        {
            try
            {
                SettingsForm.Location = new Point(SettingsForm.Location.X, settings.btnSetY);
                this.Height = settings.winSize;

                this.Opacity = settings.opacity;
                settings.windowColor = this.BackColor;
                this.BackColor = settings.SetColor();

                transChart.ChartAreas[0].BackColor = this.BackColor;
                cpuChart.ChartAreas[0].BackColor = this.BackColor;
            }
            catch { };
        }
        private async void _TProcc_Tick(object sender, EventArgs e)
        {
            Task<String[,]> GettP = new Task<String[,]>(tP.GetTP);
            GettP.Start();

            Processes = await GettP;
            SetTP();

        }
        private void SettingsForm_Click(object sender, EventArgs e)
        {
            if (settings.IsDisposed)
            {
                settings = new Settings();
            }
            else
            {
                settings.Show();
            }
        }
    }
}