using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace STG_Installer.Pages
{
    public partial class Panel2_Installation : UserControl
    {
        STG_MainForm _parent;
        string InstallationDirectory;
        Thread installationThread;
        public delegate void SetProgresDelegate(string text);
        public delegate void RunFinishDelagate();

        string[] FilesCD1 = {
                "SUPP.Z",
                "GENS\\AMARGOS1.DAT",
                "GENS\\ANTILIOS.DAT",
                "GENS\\BERSUS.DAT",
                "GENS\\COMBAT.DAT",
                "GENS\\COMMON.DAT",
                "GENS\\EPSION.DAT",
                "GENS\\MUSIC.1",
                "GENS\\OPTIONS.DAT",
                "GENS\\QURASH.DAT",
                "GENS\\STELLAR.DAT",
                "GENS\\MOVIE\\MOV_01.AVI",
                "GENS\\MOVIE\\MOV_02.AVI",
                "GENS\\MOVIE\\MOV_03.AVI",
                "GENS\\MOVIE\\MOV_05.AVI",
                "GENS\\MOVIE\\MOV_07.AVI",
                "GENS\\MOVIE\\MOV_08.AVI",
                "GENS\\MOVIE\\MOV_18.AVI"
            };

        string[] FilesCD2 = {
                "GENS\\AMARGOS2.DAT",
                "GENS\\ARVADA1.DAT",
                "GENS\\COMBAT.DAT",
                "GENS\\COMMON.DAT",
                "GENS\\ENTERP.DAT",
                "GENS\\GALORN1.DAT",
                "GENS\\GALORN2.DAT",
                "GENS\\HALEE1.DAT",
                "GENS\\MUSIC.2",
                "GENS\\OPTIONS.DAT",
                "GENS\\STELLAR.DAT",
                "GENS\\VERID1.DAT",
                "GENS\\MOVIE\\MOV_02.AVI",
                "GENS\\MOVIE\\MOV_06.AVI",
                "GENS\\MOVIE\\MOV_09.AVI",
                "GENS\\MOVIE\\MOV_10.AVI",
                "GENS\\MOVIE\\MOV_13.AVI",
                "GENS\\MOVIE\\MOV_14.AVI",
                "GENS\\MOVIE\\MOV_15.AVI",
                "GENS\\MOVIE\\MOV_16.AVI"
            };
        string[] LocalFiles = {
                "Stuff\\Compatibility\\Generations.sdb",
                "Stuff\\Codec\\ICCVID.DLL",
                "Stuff\\Codec\\OEMSETUP.INF",
                "Stuff\\i3comp.exe"
            };

        string[] PossibleMissing =  {
                "Stuff\\PossibleMissingFiles\\Ereg.aps",
                "Stuff\\PossibleMissingFiles\\Ereg2_32.dll",
                "Stuff\\PossibleMissingFiles\\EREGLB32.DLL",
                "Stuff\\PossibleMissingFiles\\eregreg2.ini",
                "Stuff\\PossibleMissingFiles\\mission1.wri",
                "Stuff\\PossibleMissingFiles\\reg.inf",
                "Stuff\\PossibleMissingFiles\\Reg2_32.exe",
                "Stuff\\PossibleMissingFiles\\VB40032.DLL",
                "Stuff\\PossibleMissingFiles\\WEXY43ZZ.LLK",
        };

        public Panel2_Installation(STG_MainForm _parent, string InstallationDirectory)
        {
            Logger.AppendLog("Initializing second page!");
            InitializeComponent();
            this._parent = _parent;
            this.InstallationDirectory = InstallationDirectory;
            Logger.AppendLog("Installation directory is: " + InstallationDirectory);
        }

        private void Panel2_Installation_Load(object sender, EventArgs e)
        {
            int TotalFiles = FilesCD1.Length + FilesCD2.Length + LocalFiles.Length + PossibleMissing.Length;
            InstallationProgressBar.Maximum = TotalFiles;
            Logger.AppendLog("Preparing and starting installation thread!");
            installationThread = new Thread(InstallationThreadFunction);
            installationThread.Start();
        }

        private void InstallationThreadFunction()
        {
            try
            {
                Logger.AppendLog("Installation thread started!");
                string PathToCD;

                Logger.AppendLog("Getting path for CD1...");
                PathToCD = GetPathToCD(FilesCD1);
                while (PathToCD == "")
                {
                    var res = MessageBox.Show("Please insert CD1 of Star Trek Generations and click OK", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.Cancel)
                    {
                        Logger.AppendLog("Installation was cancelled!");
                        return;
                    }
                    PathToCD = GetPathToCD(FilesCD1);
                }
                Logger.AppendLog("CD1 path is: " + PathToCD);
                CopyFilesWithInvoke(PathToCD, FilesCD1);

                Logger.AppendLog("Getting path for CD2...");
                PathToCD = GetPathToCD(FilesCD2);
                while (PathToCD == "")
                {
                    var res = MessageBox.Show("Please insert CD2 of Star Trek Generations and click OK", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.Cancel)
                    {
                        Logger.AppendLog("Installation was cancelled!");
                        return;
                    }
                    PathToCD = GetPathToCD(FilesCD2);
                }
                Logger.AppendLog("CD2 path is: " + PathToCD);
                CopyFilesWithInvoke(PathToCD, FilesCD2);

                //var RootPath = Directory.GetCurrentDirectory();
                InvokeProgress("Self-extracting additional files...");
                SelfExtractEmbededElements();

                //Reg
                InvokeProgress("Setting registry entries");
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microprose\\Star Trek Generations\\1.0", "Path", InstallationDirectory, RegistryValueKind.String);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microprose\\Star Trek Generations\\1.0", "CDPath", Path.Combine(InstallationDirectory, "GENS"), RegistryValueKind.String);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microprose\\Star Trek Generations\\1.0", "InstallSet", "MAX", RegistryValueKind.String);

                //Compatibility fix
                InvokeProgress("Installing compatibility fixes");
                InstallFix(InstallationDirectory, "Generations.sdb");

                //Extract Z
                InvokeProgress("Extracting executables");
                ExtractZLibrary(InstallationDirectory, Path.Combine(InstallationDirectory, "SUPP.Z"));
                ExtractZLibrary(InstallationDirectory, Path.Combine(InstallationDirectory, "possible_missing.z"));

                //MoveFilesToData
                InvokeProgress("Moving some files to DATA folder and creating additional directories");
                MoveToData();
                InvokeFinish();
            }
            catch(Exception e)
            {
                Logger.AppendLog("EXCEPTION: " + e);
                MessageBox.Show(e.ToString(), "EXCEPTION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void SelfExtractEmbededElements()
        {
            //Extractor for Z files
            File.WriteAllBytes(Path.Combine(InstallationDirectory, "i3comp.exe"), Properties.Resources.i3comp);
            //Video codec
            File.WriteAllBytes(Path.Combine(InstallationDirectory, "ICCVID.DLL"), Properties.Resources.ICCVID);
            //Compatibility profile Generations.sdb
            File.WriteAllBytes(Path.Combine(InstallationDirectory, "Generations.sdb"), Properties.Resources.GenerationsSDB);
            //Possible missing stuff
            File.WriteAllBytes(Path.Combine(InstallationDirectory, "possible_missing.z"), Properties.Resources.possible_missing);
        }

        private void MoveToData()
        {
            var dataDir = Path.Combine(InstallationDirectory, "DATA");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            File.Move(Path.Combine(InstallationDirectory, "GENS", "COMMON.DAT"), Path.Combine(dataDir, "COMMON.DAT"));
            File.Move(Path.Combine(InstallationDirectory, "GENS", "OPTIONS.DAT"), Path.Combine(dataDir, "OPTIONS.DAT"));

            var worldDir = Path.Combine(InstallationDirectory, "WORLD");
            if (!Directory.Exists(worldDir))
                Directory.CreateDirectory(worldDir);

            var saveDir = Path.Combine(InstallationDirectory, "SAVEGAME");
            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);
        }

        private void CleanUp()
        {
            if (File.Exists(Path.Combine(InstallationDirectory, "SUPP.Z")))
                File.Delete(Path.Combine(InstallationDirectory, "SUPP.Z"));

            if (File.Exists(Path.Combine(InstallationDirectory, "possible_missing.z")))
                File.Delete(Path.Combine(InstallationDirectory, "possible_missing.z"));


        }

        private void ExtractZLibrary(string rootPath, string ZLibary)
        {
            var i3AbsoluteLoc = Path.Combine(rootPath, "i3comp.exe");
            File.Move(i3AbsoluteLoc, Path.Combine(rootPath, "i3comp.exe"));
            Process proc = new Process();
            proc.StartInfo.FileName = Path.Combine(rootPath, "i3comp.exe");
            proc.StartInfo.WorkingDirectory = rootPath;
            proc.StartInfo.Arguments = string.Format("-d \"{0}\"", ZLibary);
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            string output = "";
            proc.OutputDataReceived += (send, arg) =>
            {
                output += string.Join("\n", arg.Data) + "\n";
            };
            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            Logger.AppendLog("ZLib output was: " + output);
            File.Move(Path.Combine(rootPath, "i3comp.exe"), i3AbsoluteLoc);
        }

        private void InstallFix(string rootPath, string file)
        {
            var sdbFile = Path.Combine(rootPath, file);
            Process proc = new Process();
            proc.StartInfo.FileName = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "system32", "sdbinst.exe");
            proc.StartInfo.Arguments = "-q \"" + sdbFile + "\"";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            string output = "";
            proc.OutputDataReceived += (send, arg) =>
            {
                output += string.Join("\n", arg.Data) + "\n";
            };

            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            MessageBox.Show(output, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InvokeProgress(string text)
        {
            if(this.InvokeRequired)
            {
                Logger.AppendLog("Progress Invoke: " + text);
                SetProgresDelegate d = new SetProgresDelegate(InvokeProgress);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.RB_Output.AppendText(text + "\n");
                if(InstallationProgressBar.Value + 1 < InstallationProgressBar.Maximum)
                    this.InstallationProgressBar.Value++;
            }
        }

        private void InvokeFinish()
        {
            if (this.InvokeRequired)
            {
                RunFinishDelagate d = new RunFinishDelagate(InvokeFinish);
                this.Invoke(d, new object[] { });
                Logger.AppendLog("Finished!");
            }
            else
            {
                this.RB_Output.AppendText("Finished!\n");
                this.InstallationProgressBar.Value = InstallationProgressBar.Maximum;
                MessageBox.Show("Finished! You should be able to run the game now by starting stg.exe!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(InstallationDirectory);
                Environment.Exit(0);
            }
        }

        private void CopyFilesWithInvoke(string rootPath, string[] files)
        {
            foreach(var file in files)
            {
                string from = Path.Combine(rootPath, file);
                string to = Path.Combine(InstallationDirectory, file);
                InvokeProgress(string.Format("Copying \"{0}\" to \"{1}\"", from, to));

                if(!File.Exists(to))
                {
                    var dir = Path.GetDirectoryName(to);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    File.Copy(from, to);

                }
            }
        }

        private string GetPathToCD(string[] files)
        {
            var LogicalDrives = DriveInfo.GetDrives();
            foreach(var logicalDrive in LogicalDrives)
            {
                if(logicalDrive.DriveType == DriveType.CDRom && logicalDrive.IsReady)
                {
                    if (IsCorrectCD(logicalDrive.RootDirectory.FullName, files))
                        return logicalDrive.RootDirectory.FullName;
                }
            }
            return "";
        }

        private bool IsCorrectCD(string CDPath, string[] files)
        {
            foreach(var file in files)
            {
                if (!File.Exists(Path.Combine(CDPath, file)))
                    return false;
            }
            return true;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.installationThread.Abort();
        }

        private void RB_Output_TextChanged(object sender, EventArgs e)
        {
            RB_Output.SelectionStart = RB_Output.Text.Length;
            RB_Output.ScrollToCaret();
        }
    }
}
