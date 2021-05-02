using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace disableWindowsAntivirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // disable defender + antispyware
        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey AntiSpywareKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");
            AntiSpywareKey.SetValue("DisableAntiSpyware", 00000001);
            RegistryKey PhishingFilter = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter");
            PhishingFilter.SetValue("EnabledV9", 00000000);
            RegistryKey AppHostKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\AppHost");
            AppHostKey.SetValue("EnableWebContentEvaluation", 00000000);
            MessageBox.Show("WinDefender killed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // disable SmartScreen
        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey SmartScreenKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer");
            SmartScreenKey.SetValue("SmartScreenEnabled", "off");
            RegistryKey SecondSmartScreenKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System");
            SecondSmartScreenKey.SetValue("EnableSmartScreen", 00000000);
            RegistryKey AppInstalling = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\SmartScreen");
            AppInstalling.SetValue("ConfigureAppInstallControl", "Anywhere");
            AppInstalling.SetValue("ConfigureAppInstallControlEnabled", 00000001);
            MessageBox.Show("SmartScreen successfully destroyed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // disable win defender service
        private void button3_Click(object sender, EventArgs e)
        {
            RegistryKey scwscs = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\SecurityHealthService");
            scwscs.SetValue("Start", 00000004);
            RegistryKey wcsecurity = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\wscsvc");
            wcsecurity.SetValue("Start", 00000004);
            MessageBox.Show("WinDefender service killed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
