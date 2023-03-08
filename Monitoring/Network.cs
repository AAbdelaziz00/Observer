using NativeWifi;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace Obser
{
    class Network
    {
        static PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
        static string instance = performanceCounterCategory.GetInstanceNames()[0];

        PerformanceCounter _NetUpload = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instance);
        PerformanceCounter _NetDownload = new PerformanceCounter("Network Interface", "Bytes Received/sec", instance);

        private string SSID;
        private string signal;

        protected internal string setLocalIP()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            return Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
#pragma warning restore CS0618 // Type or member is obsolete
        }

        protected internal string setPublicIP()
        {
            try
            {
                string address = "";
                WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
                using (WebResponse response = request.GetResponse())
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    address = stream.ReadToEnd();
                }

                int first = address.IndexOf("Address: ") + 9;
                int last = address.LastIndexOf("</body>");
                address = address.Substring(first, last - first);
                return address;
            }
            catch (WebException)
            {
                return "Offline";
                throw;
            }
        }

        protected internal string setDownload()
        {
            return (_NetDownload.NextValue() / 1024).ToString("0.##") + " KB/sec";
        }

        protected internal string setUpload()
        {
            return (_NetUpload.NextValue() / 1024 ).ToString("0.##") + " KB/sec";
        }
        
        protected internal string wifiSSID()
        {
            try
            {
                WlanClient wlan = new WlanClient();
                foreach (WlanClient.WlanInterface wlanInterface in wlan.Interfaces)
                {
                    Wlan.Dot11Ssid ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
                    SSID = GetStringForSSID(ssid);
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            }catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                SSID = "offline";
            }
            return SSID;
        }

        static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
        }

        protected internal string wifiSignal()
        {
            try
            {
                WlanClient client = new WlanClient();
                foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
                {
                    Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                    foreach (Wlan.WlanAvailableNetwork network in networks)
                    {
                        signal = (network.wlanSignalQuality).ToString() + "%";
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            }catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                signal = "offline";
            }
            return signal;
        }
    }
}