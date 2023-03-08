using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Obser
{
    public partial class ArraCust : UserControl
    {
        protected internal List<CheckBox> checkBoxes = new List<CheckBox>();
        protected internal List<RadioButton> Opacity = new List<RadioButton>();
        protected internal List<CheckBox> BarGraph = new List<CheckBox>();

        protected internal bool[] status;

        public ArraCust()
        {
            InitializeComponent();
        }

        protected internal void SetCBStatus()
        {
            for (int x = 0; x != 7;)
            {
                switch (status[x])
                {
                    case true:
                        checkBoxes[x].Checked = true;
                        break;
                    case false:
                        checkBoxes[x].Checked = false;
                        break;
                }
                x++;
            }
        }

        protected internal void GetOpacity()
        {
            Opacity.Add(per100); Opacity.Add(per75);
            Opacity.Add(per50); Opacity.Add(per25);
        }

        protected internal void GetCheckboxes()
        {
            checkBoxes.Add(checkBox1);      checkBoxes.Add(checkBox2);
            checkBoxes.Add(checkBox3);      checkBoxes.Add(checkBox4);
            checkBoxes.Add(checkBox5);      checkBoxes.Add(checkBox6);
            checkBoxes.Add(checkBox7);

            
            BarGraph.Add(stoBar);           BarGraph.Add(ramBar);
            BarGraph.Add(cpuGra);           BarGraph.Add(trasnGra);
        }

        private void ArraCust_Load(object sender, EventArgs e)
        {
            GetOpacity(); SetCBStatus();
        }
    }
}
