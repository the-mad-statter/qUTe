using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace qUTe
{
    public partial class ServerControlForm : Form
    {
        private Boolean ErrorState_ini; // used to stop server from starting if an ini was not copied correctly
        private List<Process> ServerProcesses; // contains all instances of attempted server starts (may be running or may have crashed at any given time point)
        private static readonly String[] serverStatusMessage = { "Server Stopped", "Server Running" }; // static messages for the server status label
        private String teamID;
        private String gameCode;

        public ServerControlForm()
        {
            InitializeComponent();

            Thread th = new Thread(new ThreadStart(DoSplash));
            th.Start();
            Thread.Sleep(3000);
            th.Abort();
            Thread.Sleep(1000);

            label_serverstatus.Text = serverStatusMessage[0];
            ErrorState_ini = false;
            ServerProcesses = new List<Process>();
        }

        private void DoSplash()
        {
            Splash sp = new Splash();
            sp.ShowDialog();
        }

        private DialogResult settingsCheck()
        {
            DialogResult dr = MessageBox.Show("You are about to run the following:" + Environment.NewLine + Environment.NewLine +
                                              "Team: " + textBox_teamid.Text + Environment.NewLine + Environment.NewLine +
                                              "Game: " + comboBox_game.SelectedItem.ToString(),
                                              "Settings Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                teamID = textBox_teamid.Text;
                gameCode = comboBox_game.SelectedIndex.ToString();
            }
            return dr;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            switch (comboBox_game.SelectedIndex)
            {
                case 0: // Basic Training - Practice
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("ROOtator.ini", qUTe.Properties.Resources.BTP_ROOtator);
                            copy_ini("BTP_S1.ini", qUTe.Properties.Resources.BTP_S1);
                            startServer("DM-BasicTraining?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=ROOtator.MutRoos,OLStats.MutOLGameStats?bAutoNumBots=False?NumBots=0 -lanplay -server -ini=BTP_S1.ini -log=BTP_S1.log");
                            copy_ini("ROOtator.ini", qUTe.Properties.Resources.BTP_ROOtator);
                            copy_ini("BTP_S2.ini", qUTe.Properties.Resources.BTP_S2);
                            startServer("DM-BasicTraining?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=ROOtator.MutRoos,OLStats.MutOLGameStats?bAutoNumBots=False?NumBots=0 -lanplay -server -ini=BTP_S2.ini -log=BTP_S2.log");
                            copy_ini("ROOtator.ini", qUTe.Properties.Resources.BTP_ROOtator);
                            copy_ini("BTP_S3.ini", qUTe.Properties.Resources.BTP_S3);
                            startServer("DM-BasicTraining?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=ROOtator.MutRoos,OLStats.MutOLGameStats?bAutoNumBots=False?NumBots=0 -lanplay -server -ini=BTP_S3.ini -log=BTP_S3.log");
                        }
                        break;
                    }
                case 1: // Baseline Skill Assessment 1
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("BSA1_S1.ini", qUTe.Properties.Resources.BSA1_S1);
                            startServer("DM-1on1_Practice?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=OLStats.MutOLGameStats?DMTeam=xgame.DMRosterConfigured?Demorec=" + teamID + "A" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=BSA1_S1.ini -log=BSA1_S1.log");
                            copy_ini("BSA1_S2.ini", qUTe.Properties.Resources.BSA1_S2);
                            startServer("DM-1on1_Practice?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=OLStats.MutOLGameStats?DMTeam=xgame.DMRosterConfigured?Demorec=" + teamID + "B" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=BSA1_S2.ini -log=BSA1_S2.log");
                            copy_ini("BSA1_S3.ini", qUTe.Properties.Resources.BSA1_S3);
                            startServer("DM-1on1_Practice?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=OLStats.MutOLGameStats?DMTeam=xgame.DMRosterConfigured?Demorec=" + teamID + "C" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=BSA1_S3.ini -log=BSA1_S3.log");
                        }
                        break;
                    }
                case 2: // Baseline Skill Assessment 2
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("BSA2_S1.ini", qUTe.Properties.Resources.BSA2_S1);
                            startServer("DM-1on1_Practice?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=OLStats.MutOLGameStats?DMTeam=xgame.DMRosterConfigured?Demorec=" + teamID + "A" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=BSA2_S1.ini -log=BSA2_S1.log");
                            copy_ini("BSA2_S2.ini", qUTe.Properties.Resources.BSA2_S2);
                            startServer("DM-1on1_Practice?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=OLStats.MutOLGameStats?DMTeam=xgame.DMRosterConfigured?Demorec=" + teamID + "B" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=BSA2_S2.ini -log=BSA2_S2.log");
                            copy_ini("BSA2_S3.ini", qUTe.Properties.Resources.BSA2_S3);
                            startServer("DM-1on1_Practice?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=OLStats.MutOLGameStats?DMTeam=xgame.DMRosterConfigured?Demorec=" + teamID + "C" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=BSA2_S3.ini -log=BSA2_S3.log");
                        }
                        break;
                    }
                case 3: // Basic Training - Vehicles
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("ROOtator.ini", qUTe.Properties.Resources.BTV_ROOtator);
                            copy_ini("VehicleStuff.ini", qUTe.Properties.Resources.BTV_VehicleStuff);
                            copy_ini("BTV_S1.ini", qUTe.Properties.Resources.BTV_S1);
                            startServer("DM-VehicleTraining?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=ROOtator.MutRoos,VehicleStuff.VehicleStuff,OLStats.MutOLGameStats?bAutoNumBots=False?NumBots=0 -lanplay -server -ini=BTV_S1.ini -log=BTV_S1.log");
                            copy_ini("ROOtator.ini", qUTe.Properties.Resources.BTV_ROOtator);
                            copy_ini("VehicleStuff.ini", qUTe.Properties.Resources.BTV_VehicleStuff);
                            copy_ini("BTV_S2.ini", qUTe.Properties.Resources.BTV_S2);
                            startServer("DM-VehicleTraining?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=ROOtator.MutRoos,VehicleStuff.VehicleStuff,OLStats.MutOLGameStats?bAutoNumBots=False?NumBots=0 -lanplay -server -ini=BTV_S2.ini -log=BTV_S2.log");
                            copy_ini("ROOtator.ini", qUTe.Properties.Resources.BTV_ROOtator);
                            copy_ini("VehicleStuff.ini", qUTe.Properties.Resources.BTV_VehicleStuff);
                            copy_ini("BTV_S3.ini", qUTe.Properties.Resources.BTV_S3);
                            startServer("DM-VehicleTraining?BonusVehicles=false?Game=iPak.DeathMatchAR?Mutator=ROOtator.MutRoos,VehicleStuff.VehicleStuff,OLStats.MutOLGameStats?bAutoNumBots=False?NumBots=0 -lanplay -server -ini=BTV_S3.ini -log=BTV_S3.log");
                        }
                        break;
                    }
                case 4: // Basic Training - Onslaught
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("VehicleStuff.ini", qUTe.Properties.Resources.BTO_VehicleStuff);
                            copy_ini("BTO.ini", qUTe.Properties.Resources.BTO);
                            startServer("ONS-OnslaughtPractice?LinkSetup=Middle_Path?BonusVehicles=false?Game=iPak.ONSOnslaughtGameNO?Mutator=VehicleStuff.VehicleStuff,OLStats.MutOLGameStats?bAutoNumBots=False?NumBots=0 -lanplay -server -ini=BTO.ini -log=BTO.log");
                        }
                        break;
                    }
                case 5: // Test Game 1 - Easy
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("VehicleStuff.ini", qUTe.Properties.Resources.TG1E_VehicleStuff);
                            copy_ini("TG1E.ini", qUTe.Properties.Resources.TG1E);
                            startServer("ONS-Game_1A?LinkSetup=Middle_Path?BonusVehicles=false?Game=iPak.ONSOnslaughtGameNO?Mutator=VehicleStuff.VehicleStuff,OLStats.MutOLGameStats?VsBots=true?Demorec=" + teamID + "ABC" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=TG1E.ini -log=TG1E.log");
                        }
                        break;
                    }
                case 6: // Test Game 1 - Medium
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("VehicleStuff.ini", qUTe.Properties.Resources.TG1M_VehicleStuff);
                            copy_ini("TG1M.ini", qUTe.Properties.Resources.TG1M);
                            startServer("ONS-Game_1B?LinkSetup=Middle_Path?BonusVehicles=false?Game=iPak.ONSOnslaughtGameNO?Mutator=VehicleStuff.VehicleStuff,OLStats.MutOLGameStats?VsBots=true?Demorec=" + teamID + "ABC" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=TG1M.ini -log=TG1M.log");
                        }
                        break;
                    }
                case 7: // Test Game 1 - Hard
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("VehicleStuff.ini", qUTe.Properties.Resources.TG1H_VehicleStuff);
                            copy_ini("TG1H.ini", qUTe.Properties.Resources.TG1H);
                            startServer("ONS-Game_1C?LinkSetup=Middle_Path?BonusVehicles=false?Game=iPak.ONSOnslaughtGameNO?Mutator=VehicleStuff.VehicleStuff,OLStats.MutOLGameStats?VsBots=true?Demorec=" + teamID + "ABC" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=TG1H.ini -log=TG1H.log");
                        }
                        break;
                    }
                case 8: // Test Game 2
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("VehicleStuff.ini", qUTe.Properties.Resources.TG2_VehicleStuff);
                            copy_ini("TG2.ini", qUTe.Properties.Resources.TG2);
                            startServer("ONS-Game_2-3?LinkSetup=Middle_Path?BonusVehicles=false?Game=iPak.ONSOnslaughtGameNO?Mutator=VehicleStuff.VehicleStuff,OLStats.MutOLGameStats?VsBots=true?Demorec=" + teamID + "ABC" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=TG2.ini -log=TG2.log");
                        }
                        break;
                    }
                case 9: // Test Game 3
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("VehicleStuff.ini", qUTe.Properties.Resources.TG3_VehicleStuff);
                            copy_ini("TG3.ini", qUTe.Properties.Resources.TG3);
                            startServer("ONS-Game_2-3?LinkSetup=Middle_Path?BonusVehicles=false?Game=iPak.ONSOnslaughtGameNO?Mutator=VehicleStuff.VehicleStuff,OLStats.MutOLGameStats?VsBots=true?Demorec=" + teamID + "ABC" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=TG3.ini -log=TG3.log");
                        }
                        break;
                    }
                case 10: // Test Game 4
                    {
                        if (settingsCheck() == DialogResult.OK)
                        {
                            copy_ini("VehicleStuff.ini", qUTe.Properties.Resources.TG4_VehicleStuff);
                            copy_ini("TG4.ini", qUTe.Properties.Resources.TG4);
                            startServer("ONS-Game_4?LinkSetup=Big_H?BonusVehicles=false?Game=iPak.ONSOnslaughtGameNO?Mutator=VehicleStuff.VehicleStuff,OLStats.MutOLGameStats?VsBots=true?Demorec=" + teamID + "ABC" + "_" + gameCode + "_" + DemoRecDateTime() + " -lanplay -server -ini=TG4.ini -log=TG4.log");
                        }
                        break;
                    }
            }

        }

        private void comboBox_game_SelectedIndexChanged(object sender, EventArgs e)
        {
            // apparently necessary to define this function
        }

        private void copy_ini(String newIniName, String iniContents)
        {
            try
            {
                String sIniPath = Path.Combine("C:\\Unreal Anthology\\UT2004\\System\\", newIniName);
                FileStream fs = new FileStream(sIniPath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(iniContents);
                sw.Flush();
                fs.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception fe)
            {
                DialogResult dr = MessageBox.Show("There was an error copying an ini file." + Environment.NewLine + fe.ToString(),
                                                  "Error Copying INI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorState_ini = true;
            }
        }

        private void startServer(String serverArgs)
        {
            if (ErrorState_ini == false)
            {
                Process p = new Process();
                p.StartInfo.FileName = "C:\\Unreal Anthology\\UT2004\\System\\UT2004.exe";
                p.StartInfo.Arguments = serverArgs;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                ServerProcesses.Add(p);
                label_serverstatus.Text = serverStatusMessage[1];
            }
            ErrorState_ini = false; // reset to false after the server has either started or failed to start
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process p in ServerProcesses)
                    if (!p.HasExited)
                        p.Kill();
                ServerProcesses.Clear();
            }
            catch (Exception pke)
            {
                MessageBox.Show(pke.ToString(), "Process Kill Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label_serverstatus.Text = serverStatusMessage[0];
        }

        private String DemoRecDateTime()
        {
            DateTime d = DateTime.Now;
            String year = d.Year.ToString();
            String month = d.Month.ToString();
            if (month.Length < 2)
                month = "0" + month;
            String day = d.Day.ToString();
            if (day.Length < 2)
                day = "0" + day;
            String hour = d.Hour.ToString();
            if (hour.Length < 2)
                hour = "0" + hour;
            String minute = d.Minute.ToString();
            if (minute.Length < 2)
                minute = "0" + minute;
            String second = d.Second.ToString();
            if (second.Length < 2)
                second = "0" + second;
            String millisecond = d.Millisecond.ToString();
            if (millisecond.Length < 2)
                millisecond = "0" + millisecond;
            if (millisecond.Length < 3)
                millisecond = "0" + millisecond;
            return year + "_" + month + "_" + day + "-" + hour + "_" + minute + "_" + second + "_" + millisecond;
        }
    }
}
/*
starting a process with alternate options that might be of interest
 * 
Process p = new Process();
p.StartInfo.FileName = "C:\\Unreal Anthology\\UT2004\\System\\UT2004.exe";
p.StartInfo.UseShellExecute = false;
p.StartInfo.Arguments = "DM-2PP?Game=iPak.DeathMatchAR?Mutator=ROOtator.MutRoos?bAutoNumBots=False?NumBots=0?";
p.StartInfo.RedirectStandardOutput = true;
p.Start();
textBox1.Text = p.StandardOutput.ReadToEnd();
*/