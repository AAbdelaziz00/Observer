using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Obser
{
    public partial class Settings : Form
    {
        /*------Location of Saved Settings for individaul setting-----*/
        const string ColorSetPath = @"C:\Users\Abu\Downloads\Obser\Settings\Appearance.txt";
        const string WindowSetPath = @"C:\Users\Abu\Downloads\Obser\Settings\Application.txt";
        const string SectionSet = @"C:\Users\Abu\Downloads\Obser\Settings\Active_Monitors.txt";
        const string grapBNbar = @"C:\Users\Abu\Downloads\Obser\Settings\Graphs_Progress.txt";
        /*-----------------------------------------------------------*/

        /*------------------------All Controls-------------------------*/
        protected internal List<Label> HeadlineLabels = new List<Label>();
        protected internal List<Label> Sub_HeadlineLabel = new List<Label>();
        protected internal List<Label> ReadingLabel = new List<Label>();
        protected internal List<Panel> SectionPanels = new List<Panel>();
        protected internal List<Control> barGRA = new List<Control>();
        protected internal List<Timer> GetTimers = new List<Timer>();
        protected internal Button sbBTN;
        /*-------------------------------------------------------------*/
        
        private static ColorCust colorCust = new ColorCust();
        private static ArraCust arraCust = new ArraCust();
        private static About about = new About();
        
        
        protected internal Color windowColor;
        protected internal int winSize = 691;
        protected internal int btnSetY = 661;

        protected internal double opacity = 1.00;
        private double[] perValues = new double[] {
            1.00, 0.75, 0.5, 0.25
        };

        private ToolTip toolTip = new ToolTip();
        protected internal Boolean ModifieTime = false;

        /*-------------------------------------------*/
        private Boolean[] getSectStat = new Boolean[7];
        private Boolean[] SectChange = new Boolean[7];
        private Boolean[] SubSectChange = new Boolean[4];
        /*
         * private Boolean[] SectChange = new Boolean[8]; 
         * this will watch wach if there's an actual chnage 
         * or modification applied to the sections 
        --------------------------------------------*/

        private string[] Savedcolor = new string[5];
        private string[] colors = new string[5];

        private int page = 0;

        private string[] WinSet = new string[2];

        private int xOffset; private int yOffset;
        private bool mouseUP;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
            );

        public Settings()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


            arraCust.GetCheckboxes(); arraCust.GetOpacity();
        }
        
        /*-----Setting Managements----*/
        private void LSectSet()
        {
            try
            {
                if (File.Exists(SectionSet))
                {
                    string read; int x = 0;
                    using (StreamReader fileReader = File.OpenText(SectionSet))
                    {
                        while ((read = fileReader.ReadLine()) != null)
                        {
                            getSectStat[x] = Convert.ToBoolean(read);
                            x++;
                        }

                        if (x == 0)
                        {
                            while ((read = fileReader.ReadLine()) == null)
                            {
                                getSectStat[x] = true;
                                x++;
                            }
                        }

                        int X1 = 0;
                        foreach (bool LOG in getSectStat)
                        {

                            SectChange[X1] = LOG;
                            X1++;
                        }
                        SetSettings();
                    }
                }
                else { File.Create(SectionSet); LSectSet(); }

                if (File.Exists(grapBNbar))
                {
                    string read; int x = 0;
                    using (StreamReader fReader = File.OpenText(grapBNbar))
                    {
                        while ((read = fReader.ReadLine()) != null)
                        {
                            SubSectChange[x] = Convert.ToBoolean(read);
                            x++;
                        }

                        SetSettings();
                    }
                }
                else File.Create(grapBNbar);
            }
            catch (Exception e)
            {
                String fileName = "C:\\Exceptions Log - " + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";

                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }
                else
                {
                    using (StreamWriter sW = new StreamWriter(fileName))
                    {
                        sW.WriteLine(e.ToString());
                    };
                }
            }
        }
        private void LWinSet()
        {
            try
            {
                if (File.Exists(WindowSetPath))
                {
                    using (StreamReader fileReader = File.OpenText(WindowSetPath))
                    {
                        string settings; int x = 0;
                        while ((settings = fileReader.ReadLine()) != null && x != 2)
                        {
                            if (x == 0)
                            {
                                switch (settings.ToString())
                                {
                                    case "":
                                        opacity = 1.00;
                                        arraCust.Opacity[0].Checked = true;
                                        break;
                                    case "1":
                                        opacity = 1.00;
                                        arraCust.Opacity[0].Checked = true;
                                        break;
                                    case "0.75":
                                        opacity = 0.75;
                                        arraCust.Opacity[1].Checked = true;
                                        break;
                                    case "0.50":
                                        opacity = 0.50;
                                        arraCust.Opacity[2].Checked = true;
                                        break;
                                    case "0.25":
                                        opacity = 0.25;
                                        arraCust.Opacity[3].Checked = true;
                                        break;

                                }                        
                                x++;
                            }
                            else if (x == 1)
                            {
                                windowColor = ColorTranslator.FromHtml(settings);
                                if (settings == "#000000")
                                {
                                    colorCust.WindowColor = Color.Transparent;
                                    colorCust.WinHex.Text = settings;
                                    colorCust.BCStatus(_BC: 1, status: true);
                                }
                                else
                                {
                                    colorCust.WinColorView.BackColor = ColorTranslator.FromHtml(settings);
                                    colorCust.WinHex.Text = settings;
                                }
                                x++;
                            }
                        }
                    }
                }
                else { File.Create(WindowSetPath); LWinSet(); }
            }
            catch(Exception e)
            {
                String fileName = "C:\\Exceptions Log - " + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";

                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }
                else
                {
                    using (StreamWriter sW = new StreamWriter(fileName))
                    {
                        sW.WriteLine(e.ToString());
                    };
                }
            }
        }
        private void LColorSet()
        {
            try
            {
                if (File.Exists(ColorSetPath))
                {
                    int x = 0;
                    using (StreamReader readSavedSettings = File.OpenText(ColorSetPath))
                    {

                        string color;
                        while ((color = readSavedSettings.ReadLine()) != null)
                        {
                            Savedcolor[x] = color; x++;
                        }
                    }
                    SetSettings();
                }
                else
                { File.Create(ColorSetPath); LColorSet(); }

            }
            catch (Exception e)
            {
                String fileName = "C:\\Exceptions Log - " + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";

                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }
                else
                {
                    using (StreamWriter sW = new StreamWriter(fileName))
                    {
                        sW.WriteLine(e.ToString());
                    };
                }
            }
        }

        private void SetSettings()
        {
            arraCust.status = getSectStat;
            int x = 0;
            foreach (Panel section in SectionPanels)
            {
                switch (getSectStat[x])
                {
                    case true:
                        SectionPanels[x].Visible = true;
                        break;
                    case false:
                        SectionPanels[x].Visible = false;
                        break;
                }
                x++;
            }

            for(int xsub = 0; xsub != 4;)
            {
                if (SubSectChange[xsub] == false)
                {
                    barGRA[xsub].Visible = false;
                    arraCust.BarGraph[xsub].Checked = false;
                }else
                {
                    barGRA[xsub].Visible = true;
                    arraCust.BarGraph[xsub].Checked = true;
                }
                xsub++;
            }

            SectionChecker();

            sbBTN.BackColor = ColorTranslator.FromHtml(Savedcolor[4]);
            colorCust.SBColorView.BackColor = ColorTranslator.FromHtml(Savedcolor[4]);
            colorCust.SBHex.Text = Savedcolor[4];

            foreach (Label label in HeadlineLabels)
            {
                colorCust.HeHex.Text = Savedcolor[0];
                label.ForeColor = ColorTranslator.FromHtml(Savedcolor[0]);
                colorCust.HeaderColor = ColorTranslator.FromHtml(Savedcolor[0]);

               
                if (Savedcolor[3] == "#FFFFFF")
                {
                    //#FFFFFF IS hex color of transparent
                    label.BackColor = Color.Transparent;
                    colorCust.HeaderBackColor = Color.Transparent;
                    colorCust.HBHex.Text = Savedcolor[3];
                    colorCust.BCStatus(_BC: 2, status: true);
                }
                else
                {
                    label.BackColor = ColorTranslator.FromHtml(Savedcolor[3]);
                    colorCust.HeaderBackColor = ColorTranslator.FromHtml(Savedcolor[3]);
                    colorCust.HBHex.Text = Savedcolor[3];
                }
            }

            foreach (Label label in Sub_HeadlineLabel)
            {
                label.ForeColor = ColorTranslator.FromHtml(Savedcolor[1]);
                colorCust.SubHex.Text = Savedcolor[1];
                colorCust.SubColor = ColorTranslator.FromHtml(Savedcolor[1]);

            }

            foreach (Label label in ReadingLabel)
            {
                label.ForeColor = ColorTranslator.FromHtml(Savedcolor[2]);
                colorCust.ReadHex.Text = Savedcolor[2];
                colorCust.ReadColor = ColorTranslator.FromHtml(Savedcolor[2]);
            }
        }
        protected internal void LoadUserSettings()
        {
            string folderPath = @"C:\Users\Abu\Downloads\Obser\Settings";
            bool isExist = Directory.Exists(folderPath);

            string subfolderPath = @"C:\Users\Abu\Downloads\Obser\Logs";
            bool isSubExist = Directory.Exists(subfolderPath);


            if (!isExist)
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!isSubExist)
            {
                Directory.CreateDirectory(subfolderPath);
            }

            LSectSet();            
            LWinSet();
            LColorSet();
        }

        private void _SectionSet()
        {
            if (File.Exists(SectionSet))
            {
                using (StreamWriter fileWriter = new StreamWriter(SectionSet))
                {
                    foreach (bool isActive in getSectStat)
                    {
                        fileWriter.WriteLine(isActive.ToString());
                    }
                }
            }
            else { File.Create(SectionSet); }
        }
        private void _SubSectSet()
        {
            if (File.Exists(grapBNbar))
            {
                using(StreamWriter fileWriter = new StreamWriter(grapBNbar))
                {
                    foreach(bool isActive in SubSectChange)
                    {
                        fileWriter.WriteLine(isActive.ToString());
                    }
                }
            }
        }
        protected internal void _WinSet()
        {
            if (File.Exists(WindowSetPath))
            {
                using (StreamWriter FileWriter = new StreamWriter(WindowSetPath))
                {
                    foreach (string settings in WinSet)
                    {
                        FileWriter.WriteLine(settings);
                    }
                }
            }
            else { File.Create(WindowSetPath); }
        }
        private void _ColorSet(Color c, int position)
        {
            if (File.Exists(ColorSetPath))
            {
                using (StreamReader fileCheck = File.OpenText(ColorSetPath))
                {
                    string ChangedColors; int x = 0;
                    while ((ChangedColors = fileCheck.ReadLine()) != null)
                    {
                        colors[x] = ChangedColors; x++;
                    }
                }

                using (StreamWriter file = new StreamWriter(ColorSetPath))
                {
                    colors[position] = HexConverter(c);

                    foreach (string changedColors in colors)
                    {
                        file.WriteLine(changedColors);
                    }
                }
            }
            else { File.Create(ColorSetPath); }
        } 
        /* ------------------------ */

        protected internal Color SetColor()
        {
            if (ModifieTime)
            {
                ModifieTime = false;
                return colorCust.WindowColor;
            }
            else
            {
                return windowColor;
            }
        }
        
        /*------Change appliers------*/
        private void SectionStatus()
        {
            for (int x = 0; x != 7;)
            {
                if (arraCust.checkBoxes[x].Checked)
                {
                    switch (x)
                    {
                        case 0:
                            GetTimers[0].Enabled = true;
                            break;
                        case 3:
                            GetTimers[1].Enabled = true;
                            break;
                        case 4:
                            GetTimers[2].Enabled = true;
                            break;
                        case 5:
                            GetTimers[3].Enabled = true;
                            break;
                        case 6:
                            GetTimers[4].Enabled = true;
                            break;
                    }
                    SectionPanels[x].Visible = true;
                    getSectStat[x] = true;
                }
                else
                {
                    switch (x)
                    {
                        case 0:
                            GetTimers[0].Enabled = false;
                            break;
                        case 3:
                            GetTimers[1].Enabled = false;
                            break;
                        case 4:
                            GetTimers[2].Enabled = false;
                            break;
                        case 5:
                            GetTimers[3].Enabled = false;
                            break;
                        case 6:
                            GetTimers[4].Enabled = false;
                            break;
                    }
                    SectionPanels[x].Visible = false;
                    getSectStat[x] = false;
                }
                x++;
            }
            
            _SectionSet();

            // after change it needs to equal the original again
            //SectChange = getSectStat;   
            SectionChecker();
           
            /*
             * does the checkes if panel is modified from true to false or false to true
             * to determine what needs to be done
             */
        }
        private void WindowOpacity()
        {
            for (int x = 0; x < 4;)
            {
                if (arraCust.Opacity[x].Checked)
                {
                    opacity = perValues[x];
                    WinSet[0] = perValues[x].ToString();
                    x = 6;
                    _WinSet();
                }
                else
                {
                    WinSet[0] = "1.00";
                }
                x++;
            }
        }
        private void InfoSetting()
        {
            foreach (Label label in HeadlineLabels)
            {
                label.ForeColor = colorCust.HeaderColor;
                _ColorSet(colorCust.HeaderColor, 0);
            }

            foreach (Label label in Sub_HeadlineLabel)
            {
                label.ForeColor = colorCust.SubColor;
                _ColorSet(colorCust.SubColor, 1);
            }

            foreach (Label label in ReadingLabel)
            {
                label.ForeColor = colorCust.ReadColor;
                _ColorSet(colorCust.ReadColor, 2);
            }

            if (!colorCust.HBackOFF.Checked)
            {
                foreach (Label label in HeadlineLabels)
                {
                    label.BackColor = colorCust.HeaderBackColor;
                    _ColorSet(colorCust.HeaderBackColor, 3);
                }
            }
            else if (colorCust.HBackOFF.Checked)
            {
                foreach (Label label in HeadlineLabels)
                {
                    label.BackColor = Color.Transparent;
                    _ColorSet(Color.Transparent, 3);
                }
            }

            _ColorSet(colorCust.SBColor, 4);
        }
        private void QuickSetup()
        {
            if (colorCust.offWinBC.Checked)
            {
                colorCust.WindowColor = Color.Black;
            }
            else if (!colorCust.offWinBC.Checked)
            {
                colorCust.WindowColor = colorCust.WinColorView.BackColor;
            }

            foreach (Label label in HeadlineLabels)
            {
                colorCust.HeaderColorView.BackColor = label.ForeColor;
            }

            foreach (Label label in Sub_HeadlineLabel)
            {
                colorCust.SubHeadingColorView.BackColor = label.ForeColor;
            }

            foreach (Label label in ReadingLabel)
            {
                colorCust.ReadingColorView.BackColor = label.ForeColor;
            }

            foreach (Label label in HeadlineLabels)
            {
                colorCust.HeadBackColorView.BackColor = label.BackColor;
            }
        }
        /*---------------------------*/

        /*---------------------Section Arragement Managments-------------------
         * IncArr() (increase arrangement) only get callled when the 
         * section statues gets modified from false to true
         * #gets_activated (x, y+70)
         * while DecArr() (decrease arrangement) gets called when panel goes from
         * true to false; #gets_deactivate (x, y-70) */

        Boolean _Startup = true;
        private void SectionChecker()
        {
            if (_Startup)
            {
                for (int x = 0; x != 7;)
                {
                    if (getSectStat[x] == false)
                    {
                        DecrArr(x);
                    }
                    x++;
                }
                _Startup = false;
            }
            else
            {
                for (int x = 0; x != 7;)
                {
                    if (getSectStat[x] != SectChange[x])
                    {
                        if (SectChange[x] == false && getSectStat[x] == true)
                        {
                            IncArr(x);
                        }
                        else
                        {
                            DecrArr(x);
                        }
                    }
                    x++;
                }
            }

            int X2 = 0;
            foreach (bool log in getSectStat)
            {
                SectChange[X2] = log;
                X2++;
            }
        }
        private void IncArr(int position, int set = 0)
        {
            int decYby = SectionPanels[position].Height;
            winSize += decYby; btnSetY += decYby; position++;
            while (position != 7)
            {
                SectionPanels[position].Location = new Point(SectionPanels[position].Location.X, SectionPanels[position].Location.Y + decYby);
                position++;
            }
        }
        private void DecrArr(int position)
        {
            int decYby = SectionPanels[position].Height;
            winSize -= decYby; btnSetY -= decYby; position++;
            while (position != 7)
            {
                SectionPanels[position].Location = new Point(SectionPanels[position].Location.X, SectionPanels[position].Location.Y - decYby);
                position++;
            }
        }
        /*---------------------------------------------------------------------*/
        
        private void Settings_Load(object sender, EventArgs e)
        {
            Task _CBThread = new Task(arraCust.GetCheckboxes);
            _CBThread.Start();

            Task _QuickSetup = new Task(QuickSetup);
            _QuickSetup.Start();
        }
        private static String HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        
        private void MenuBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUP = false;
        }
        private void MenuBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseUP)
            {
                this.SetDesktopLocation(MousePosition.X - xOffset, MousePosition.Y - yOffset);
            }
        }
        private void MenuBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseUP = true;
            xOffset = e.X;
            yOffset = e.Y;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BTNs_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name.ToString())
            {
                case "Apperance":
                    page = 1;
                    Modifiy.Enabled = true;
                    PanelROOT.Controls.Remove(Menu);
                    PanelROOT.Controls.Add(colorCust);
                    break;
                case "Arrangement":
                    page = 2;
                    Modifiy.Enabled = true;
                    PanelROOT.Controls.Remove(Menu);
                    PanelROOT.Controls.Add(arraCust);
                    break;
                case "Update":
                    Modifiy.Enabled = false;
                    page = 3;
                    PanelROOT.Controls.Remove(Menu);
                    PanelROOT.Controls.Add(about);
                    break;
                default:
                    page = 0;
                    Modifiy.Enabled = false;
                    PanelROOT.Controls.Remove(colorCust);
                    PanelROOT.Controls.Remove(arraCust);
                    PanelROOT.Controls.Remove(about);
                    PanelROOT.Controls.Add(Menu);
                    break;
            }
        }
        private void Modifiy_Click(object sender, EventArgs e)
        {
            //Sets time when change has occured
            ModifieTime = true;
            Task _WindowOpacity = new Task(WindowOpacity);
            if (page == 1)
            {
                sbBTN.BackColor = colorCust.SBColor;

                if (colorCust.offWinBC.Checked)
                {
                    WinSet[1] = HexConverter(Color.Black);
                    colorCust.WindowColor = Color.Black;
                }
                else if (!colorCust.offWinBC.Checked)
                {
                    WinSet[1] = HexConverter(colorCust.WindowColor);
                    colorCust.WindowColor = colorCust.WinColorView.BackColor;
                }
                _WinSet();
                _WindowOpacity.Start();

                Task _InfoSetting = new Task(InfoSetting);
                _InfoSetting.Start();
            }
            else if (page == 2)
            {
                
                _WindowOpacity.Start();
                
                for (int x = 0; x != 4;)
                {
                    switch (x)
                    {
                        case 0:
                            if (arraCust.BarGraph[x].Checked)
                            {
                                barGRA[x].Visible = true;
                                SubSectChange[x] = true;
                            }
                            else
                            {
                                barGRA[x].Visible = false;
                                SubSectChange[x] = false;
                            }
                            break;
                        case 1:
                            if (arraCust.BarGraph[x].Checked)
                            {
                                barGRA[x].Visible = true;
                                SubSectChange[x] = true;
                            }
                            else
                            {
                                barGRA[x].Visible = false;
                                SubSectChange[x] = false;
                            }
                            break;
                        case 2:
                            if (arraCust.BarGraph[x].Checked)
                            {
                                barGRA[x].Visible = true;
                                SubSectChange[x] = true;
                            }
                            else
                            {
                                barGRA[x].Visible = false;
                                SubSectChange[x] = false;
                            }
                            break;
                        case 3:
                            if (arraCust.BarGraph[x].Checked)
                            {
                                barGRA[x].Visible = true;
                                SubSectChange[x] = true;
                            }
                            else
                            {
                                barGRA[x].Visible = false;
                                SubSectChange[x] = false;
                            }
                            break;
                    }
                    x++;
                }
                SectionStatus();
                _SubSectSet();
            }
            else if (page == 3){}                          
        }

        private void Close_MouseEnter(object sender, EventArgs e)
        {
            Close.BackgroundImage = Properties.Resources.iconss;
        }
        private void Close_MouseLeave(object sender, EventArgs e)
        {
            Close.BackgroundImage = Properties.Resources.circle_16_1_;
        }
        private void Modifiy_MouseHover(object sender, EventArgs e)
        {            
            toolTip.Show("Apply", Modifiy);
        }
    }
}