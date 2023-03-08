using System.Management;
using System.Windows.Forms;

namespace Obser
{
    public class Video
    {
        protected internal string SetVideo()
        {
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            return screenWidth + " * " + screenHeight;
        }

        protected internal string videoVersion()
        {
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
            string version = "";
            foreach (ManagementObject mo in objectSearcher.Get())
            {
                version = mo["Name"].ToString();
            }

            return version;
        }
    }
}
