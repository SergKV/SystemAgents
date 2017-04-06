using Microsoft.VisualBasic.Devices;
using Microsoft.Web.Administration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentDoJo2
{
    public class Logic
    {
        string applications = "abcdefjhi";
        string memory = "jklmnop";
        string webSites = "qrstuvwxyz";

        public List<string> LetterSelection(string v)
        {
            List<string> tmpData = new List<string>();
            string tmp = v.ToLower();

            if (applications.Contains(tmp[0]))
            {
                string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
                {
                    foreach (string subkey_name in key.GetSubKeyNames())
                    {
                        using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                        {
                            try
                            {
                                string tmps = subkey.GetValue("DisplayName").ToString();
                                tmpData.Add(tmps);
                            }
                            catch (Exception e)
                            { }
                        }
                    }
                }
            }
            else if(memory.Contains(tmp[0]))
            {
                ComputerInfo CI = new ComputerInfo();
                ulong mem = ulong.Parse(CI.TotalPhysicalMemory.ToString());
                tmpData.Add("\nRAM IS :" + (mem / (1024 * 1024) + " MB").ToString() + "\n\r");

                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady)
                    {
                        tmpData.Add(String.Format("Disk Name :{0} \n\r\t Disk Free Space: {1}", drive.Name, drive.TotalFreeSpace / (1024 * 1024) + " MB"));
                    }
                }                
            }
            else if(webSites.Contains(tmp[0]))
            {
                var iisManager = new ServerManager();
                SiteCollection sites = iisManager.Sites;   
                           
                foreach(var item in sites)
                {
                    tmpData.Add(String.Format("Site name: {0} \n\r\t Site binding: {1}", item.Name, item.Bindings));
                }
            }
            else
            {
                tmpData.Add(String.Format("Entered data was: {0}", v));
            }
            return tmpData;
        }
    }
}
