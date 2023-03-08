using System.Collections.Generic;
using System.Windows.Forms;
namespace Obser
{
    public partial class About : UserControl
    {
        protected internal List<Panel> CustPanels = new List<Panel>();
        protected internal List<Panel> barPanels = new List<Panel>();
        protected internal List<Panel> SidePanel = new List<Panel>();
        protected internal List<Button> btns = new List<Button>();

        private static Settings GetSettings = new Settings();
        public About()
        {
            InitializeComponent();
        }
    }
}
