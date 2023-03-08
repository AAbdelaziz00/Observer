using System;
using System.Drawing;
using System.Windows.Forms;
namespace Obser
{
    public partial class ColorCust : UserControl
    {
        private static Settings settings = new Settings();
        private static About GetAbout = new About();

        protected internal Color WindowColor;
        protected internal Color HeaderColor;
        protected internal Color HeaderBackColor;
        protected internal Color ReadColor;
        protected internal Color SubColor;
        protected internal Color SBColor;
       
        public ColorCust()
        {
            InitializeComponent();
        }

        private void HeaderBTN_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                if (ColorPicker.Color == Color.Black)
                {
                    HeaderColorView.BackColor = ColorTranslator.FromHtml("#000001");
                    HeHex.Text = HexConverter(ColorPicker.Color);
                }
                else
                {
                    HeaderColorView.BackColor = ColorPicker.Color;
                    HeHex.Text = HexConverter(ColorPicker.Color);
                }
                HeaderColor = HeaderColorView.BackColor;
            }
        }
        private void ReadingBTN_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                if (ColorPicker.Color == Color.Black)
                {
                    ReadingColorView.BackColor = ColorTranslator.FromHtml("#000001");
                    ReadHex.Text = HexConverter(ColorPicker.Color);
                }
                else
                {
                    ReadingColorView.BackColor = ColorPicker.Color;
                    ReadHex.Text = HexConverter(ColorPicker.Color);
                }
                ReadColor = ReadingColorView.BackColor;
            }
        }
        private void SubHeadingBTN_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                if (ColorPicker.Color == Color.Black)
                {
                    SubHeadingColorView.BackColor = ColorTranslator.FromHtml("#000001");
                    SubHex.Text = HexConverter(ColorPicker.Color);
                }
                else
                {
                    SubHeadingColorView.BackColor = ColorPicker.Color;
                    SubHex.Text = HexConverter(ColorPicker.Color);
                }
                SubColor = SubHeadingColorView.BackColor;
            }
        }
        private void HeadersBackBTN_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                if (ColorPicker.Color == Color.Black)
                {
                    HeadBackColorView.BackColor = ColorTranslator.FromHtml("#000001");
                    HBHex.Text = HexConverter(ColorPicker.Color);
                }
                else
                {
                    HeadBackColorView.BackColor = ColorPicker.Color;
                    HBHex.Text = HexConverter(ColorPicker.Color);
                }

                HeaderBackColor = HeadBackColorView.BackColor;
            }
        }     
       
        protected internal void BCStatus(int _BC, bool status)
        {
            switch (_BC)
            {
                case 1:
                    if (status == true)
                    {
                        offWinBC.Checked = true;
                    }
                    break;
                case 2:
                    if (status == true)
                    {
                        HBackOFF.Checked = true;
                    }
                    break;
            }
        }
        private void Window_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                if (ColorPicker.Color == Color.Black)
                {
                    WinColorView.BackColor = ColorTranslator.FromHtml("#000001");
                    WinHex.Text = HexConverter(ColorPicker.Color);
                }
                else
                {
                    WinColorView.BackColor = ColorPicker.Color;
                    WinHex.Text = HexConverter(ColorPicker.Color);
                }

                WindowColor = WinColorView.BackColor;
            }
        }
        private void Customization_Load(object sender, EventArgs e)
        {
            HeadBackColorView.BackColor = HeaderBackColor;
        }

        private static String HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private void EntereKeyPressed(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if(e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    switch (tb.Name)
                    {
                        case "HeHex":
                            HeaderColorView.BackColor = ColorTranslator.FromHtml(HeHex.Text);
                            HeaderColor = HeaderColorView.BackColor;
                            break;
                        case "HBHex":
                            HeadBackColorView.BackColor = ColorTranslator.FromHtml(HBHex.Text);
                            HeaderBackColor = HeadBackColorView.BackColor;
                            break;
                        case "WinHex":
                            WinColorView.BackColor = ColorTranslator.FromHtml(WinHex.Text);
                            WindowColor = WinColorView.BackColor;
                            break;
                        case "ReadHex":
                            ReadingColorView.BackColor = ColorTranslator.FromHtml(ReadHex.Text);
                            ReadColor = ReadingColorView.BackColor;
                            break;
                        case "SubHex":
                            SubHeadingColorView.BackColor = ColorTranslator.FromHtml(SubHex.Text);
                            SubColor = SubHeadingColorView.BackColor;
                            break;
                        case "SBHex":
                            SBColorView.BackColor = ColorTranslator.FromHtml(SBHex.Text);
                            break;
                    }
                }
                catch { MessageBox.Show("Unrecognized Hex Code"); }
            }
        }

        private void SBbtn_Click(object sender, EventArgs e)
        {
            if(ColorPicker.ShowDialog() == DialogResult.OK)
            {
                SBColorView.BackColor = ColorPicker.Color;
                SBHex.Text = HexConverter(ColorPicker.Color);
                SBColor = ColorPicker.Color;
            }
        }
    }
}