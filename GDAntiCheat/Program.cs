using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GDAntiCheat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started! Loading data...");
            var set = new HashSet<string>()
            {
                "Idle",
                "System",
                "Registry",
                "smss",
                "csrss",
                "wininit",
                "services",
                "lsass",
                "svchost",
                "fontdrvhost",
                "WUDFHost",
                "winlogon",
                "dwm",
                "IntelCpHDCPSvc",
                "igfxCUIServiceN",
                "Memory Compression",
                "audiodg",
                "spoolsv",
                "wlanext",
                "conhost",
                "OfficeClickToRun",
                "ScpService",
                "esif_uf",
                "OneApp.IGCC.WinService",
                "LMS",
                "RstMwService",
                "sqlwriter",
                "WMIRegistrationService",
                "jhi_service",
                "AggregatorHost",
                "ctfmon",
                "gamingservices",
                "gamingservicesnet",
                "dptf_helper",
                "sihost",
                "PresentationFontCache",
                "taskhostw",
                "igfxEMN",
                "explorer",
                "SearchHost",
                "StartMenuExperienceHost",
                "RuntimeBroker",
                "dasHost",
                "dllhost",
                "YourPhone",
                "LockApp",
                "SearchIndexer",
                "TextInputHost",
                "SecurityHealthSystray",
                "SecurityHealthService",
                "OneDrive",
                "IGCCTray",
                "ScpTrayApp",
                "SystemSettings",
                "ApplicationFrameHost",
                "UserOOBEBroker",
                "ShellExperienceHost",
                "SystemSettingsBroker",
                "Video.UI",
                "Discord",
                "SgrmBroker",
                "Widgets",
                "msedgewebview2",
                "GameBar",
                "GameBarFTServer",
                "msedge",
                "cmd",
                "PAD.BrowserNativeMessageHost",
                "Microsoft.Photos",
                "MsMpEng",
                "MsMpEngCP",
                "NisSrv",
                "WmiPrvSE",
                "devenv",
                "PerfWatson2",
                "Microsoft.ServiceHub.Controller",
                "ServiceHub.VSDetouredHost",
                "ServiceHub.IdentityHost",
                "ServiceHub.SettingsHost",
                "ServiceHub.Host.CLR.x86",
                "SearchFilterHost",
                "ServiceHub.ThreadedWaitDialog",
                "ServiceHub.RoslynCodeAnalysisService",
                "MSBuild",
                "ServiceHub.Host.CLR.x64",
                "ServiceHub.Host.CLR",
                "ServiceHub.TestWindowStoreHost",
                "VBCSCompiler",
                "ServiceHub.DataWarehouseHost",
                "WebViewHost",
                "Notepad",
                "smartscreen",
                "Code",
                "powershell",
                "cpptools",
                "vsls-agent",
                "SearchProtocolHost",
                "StandardCollector.Service",
                "obs64",
                "steam",
                "steamwebhelper",
                "steamservice",
                "VsDebugConsole",
                "FileCoAuth",
                "TrustedInstaller",
                "MoUsoCoreWorker",
                "GameBarPresenceWriter",
                "backgroundTaskHost"
            };
            Console.WriteLine("Done! This program will now perfrom checking every 10 seconds.");
            Console.WriteLine("------------------");
            while (true)
            {
                Console.WriteLine("Checking all running processes...");
                var allproc = Process.GetProcesses();
                var numberOfGDInstances = 0;
                int nProcessID = Process.GetCurrentProcess().Id;
                foreach (Process proc in allproc)
                {
                    var name = proc.ProcessName;
                    if (name == "Geometry Dash" || name == "GeometryDash")
                    {
                        numberOfGDInstances++;
                        if (numberOfGDInstances > 1)
                        {
                            proc.Kill();
                            numberOfGDInstances--;
                        }
                    }
                    else if (name == "GDAntiCheat")
                    {
                        if (proc.Id != nProcessID)
                        {
                            proc.Kill();
                            Console.WriteLine("Killed duplicated GDAntiCheat instance.");
                        }
                    }
                    else if (!set.Contains(name))
                    {
                        Console.WriteLine(name);
                        try
                        {
                            proc.Kill();
                            Console.WriteLine(name);
                        }
                        catch
                        {
                            Console.WriteLine("Cannot kill " + name + ". Maybe access is denied.");
                        }
                    }
                }
                if(numberOfGDInstances == 0)
                {
                    Console.WriteLine("Geometry Dash is not running.");
                }
                Console.WriteLine("Done!");
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}