using fSS.Properties;
using MetroFramework.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fSS
{
    public partial class Form1 : MetroForm
    {
        private static Form1 form = null;


        private Control[] folderButtons;

        public Form1()
        {
            InitializeComponent();
            folderButtons = new Control[] { metroButton1, metroButton2, metroButton3, metroButton4, metroButton5, metroButton6, metroButton7, metroButton8, metroButton9, metroButton10, metroButton11, metroButton12, metroButton13, metroButton14, metroButton15, metroButton16, metroButton17, metroButton18};
            form = this;
        }
        public void addtoListBox(string added)
        {

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        const int EM_SETCUEBANNER = 0x1501;


        private void Form1_Load(object sender, EventArgs e)
        {
            SendMessage(metroTextBox1.Handle, EM_SETCUEBANNER, 1, "Password");
            Theme = MetroFramework.MetroThemeStyle.Dark;
            foreach(Control control in folderButtons)
            {
                metroToolTip1.SetToolTip(control, metroToolTip1.GetToolTip(control).Replace("{x}", Environment.UserName));
            }
            metroProgressBar1.Value = 100;
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(0);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(1);

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(2);

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(3);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(4);

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/joshey_r");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton1));
        }
        private void messageBoxClick(object sender, EventArgs e)
        {
            metro.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton2));
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton3));
        }
        private void metroButton4_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton4));
        }
        private void metroButton5_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton5));
        }
        private void metroButton6_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton6));
        }
        private void metroButton12_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton12));
        }
        private void metroButton11_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton11));
        }
        private void metroButton10_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton10));
        }
        private void metroButton9_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton9));
        }
        private void metroButton8_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton8));
        }
        private void metroButton7_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton7));
        }
        private void metroButton18_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton18));
        }
        private void metroButton17_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton17));
        }
        private void metroButton16_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton16));
        }
        private void metroButton15_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton15));
        }
        private void metroButton14_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton14));
        }
        private void metroButton13_Click(object sender, EventArgs e)
        {
            openDirectory(metroToolTip1.GetToolTip(metroButton13));
        }


        private void openDirectory(string text)
        {
            if (Directory.Exists(text))
            {
                Process.Start("explorer.exe", text);
            }
            else
            {
                showMessageBox("Could not find \"" + text + "\".");
            }
        }

        private MetroMessageBox metro = new MetroMessageBox();
        private MetroFramework.Controls.MetroButton ok = new MetroFramework.Controls.MetroButton();
        private MetroFramework.Controls.MetroLabel the_text = new MetroFramework.Controls.MetroLabel();
        private void showMessageBox(string text)
        {
            ok.Focus();

            ok.Click += new EventHandler(messageBoxClick);
            ok.Location = new Point(315, 65);
            ok.Text = "OK";

            the_text.Location = new Point(10, 30);
            the_text.Text = text;
            the_text.Size = new Size(370, 19);

            metro.Controls.Add(ok);
            metro.Controls.Add(the_text);
            metro.Theme = MetroFramework.MetroThemeStyle.Dark;
            metro.Style = MetroFramework.MetroColorStyle.Red;
            metroStyleManager2.Owner = metro;
            metro.MaximizeBox = false;
            metro.MinimizeBox = false;
            metro.Resizable = false;
            metro.Size = new Size(400, 100);
                metro.ShowDialog();
        }


        private void startScan()
        {
            metroButton19.Enabled = false;
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                int failedChecks = 0;

                // Cheat Smasher Test
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => updateCheatSmasher(Resources._1c, true)));
                }

                Thread.Sleep(2000);

                if (cheatSmasherCheck()) {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateCheatSmasher(Resources._1d, false)));
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateCheatSmasher(Resources._1e, false)));
                    }
                }
                //File Analysis Test
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => updateFileAnalysis(Resources._2c, true)));
                }

                Thread.Sleep(2000);

                if (fileAnalysisCheck())
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateFileAnalysis(Resources._2d, false)));
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateFileAnalysis(Resources._2e, false)));
                    }
                }

                //Vape Finder Test
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => updateVapeFinder(Resources._2c, true)));
                }

                Thread.Sleep(2000);

                if (vapeFinderCheck())
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateVapeFinder(Resources._2d, false)));
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateVapeFinder(Resources._2e, false)));
                    }
                }

                //Anti Clicker Test
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => updateAntiClicker(Resources._2c, true)));
                }

                Thread.Sleep(2000);

                if (antiClickerCheck())
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateAntiClicker(Resources._2d, false)));
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateAntiClicker(Resources._2e, false)));
                    }
                }

                //Valux Checker Test
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => updateValuxChecker(Resources._2c, true)));
                }

                Thread.Sleep(2000);

                if (valuxCheckerCheck())
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateValuxChecker(Resources._2d, false)));
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateValuxChecker(Resources._2e, false)));
                    }
                }

                //Death Scan Test
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => updateDeathScan(Resources._3c, true)));
                }

                Thread.Sleep(2000);

                if (deathScanCheck())
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateDeathScan(Resources._3d, false)));
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => updateDeathScan(Resources._3e, false)));
                    }
                }


                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => checkResult(true, 1)));
                }

            }).Start();
        }

        private bool cheatSmasherCheck()
        {
            return true;
        }
        private bool fileAnalysisCheck()
        {
            return false;
        }
        private bool vapeFinderCheck()
        {
            return false;
        }
        private bool antiClickerCheck()
        {
            return true;
        }
        private bool valuxCheckerCheck()
        {
            return false;
        }
        private bool deathScanCheck()
        {
            return true;
        }


        private void checkResult(bool success, int check)
        {
            metroButton19.Enabled = true;
        }



        private void updateCheatSmasher(Image img, bool shown)
        {
            pictureBox25.BackgroundImage = img;
            metroProgressSpinner1.Visible = shown;
        }
        private void updateFileAnalysis(Image img, bool shown)
        {
            pictureBox26.BackgroundImage = img;
            metroProgressSpinner2.Visible = shown;
        }
        private void updateVapeFinder(Image img, bool shown)
        {
            pictureBox27.BackgroundImage = img;
            metroProgressSpinner3.Visible = shown;

        }
        private void updateAntiClicker(Image img, bool shown)
        {
            pictureBox28.BackgroundImage = img;
            metroProgressSpinner4.Visible = shown;

        }
        private void updateValuxChecker(Image img, bool shown)
        {
            pictureBox29.BackgroundImage = img;
            metroProgressSpinner5.Visible = shown;

        }
        private void updateDeathScan(Image img, bool shown)
        {
            pictureBox30.BackgroundImage = img;
            metroProgressSpinner6.Visible = shown;

        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            startScan();
        }

        private void GetSubKeys(RegistryKey SubKey)
        {
            foreach (string sub in SubKey.GetSubKeyNames())
            {
                MessageBox.Show(sub);
                RegistryKey local = Registry.Users;
                local = SubKey.OpenSubKey(sub, true);
                GetSubKeys(local);
            }
        }

        private List<string> GetRegistrySubKeys()
        {
            List<string> valuesBynames = new List<string>();
            const string REGISTRY_ROOT = @"Software\Microsoft\Windows\CurrentVersion\Explorer\UserAssist\{CEBFF5CD-ACE2-4F4F-9178-9926F41749EA}\Count\";
            
            using (RegistryKey rootKey = Registry.CurrentUser.OpenSubKey(REGISTRY_ROOT))
            {
                if (rootKey != null)
                {
                    string[] valueNames = rootKey.GetValueNames();
                    foreach (string currSubKey in valueNames)
                    {
                        object value = rootKey.GetValue(currSubKey);
                        valuesBynames.Add(currSubKey);
                    }
                }
                rootKey.Close();
            }
            return valuesBynames;
        }

        private void metroButton21_Click(object sender, EventArgs e)
        {
            
        }
        private void loadUserAssistLogs()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\UserAssist");
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => progressBarTo(key.GetSubKeyNames().Length)));
                }

                foreach (var v in key.GetSubKeyNames())
                {
                    Console.WriteLine(v);


                    RegistryKey productKey = key.OpenSubKey(v + "\\Count");
                    if (productKey != null)
                    {
                        foreach (var value in productKey.GetValueNames())
                        {
                            Regex r = new Regex(@"^(([a-zA-Z]\:)|(\\))(\\{1}|((\\{1})[^\\]([^/:*?<>""|]*))+)$");
                            if(r.IsMatch(value) && value.EndsWith(""))
                            this.Invoke(new Action(() => addToListBox(value)));
                            Registry.CurrentUser.DeleteValue(v + "\\Count" + "\\" + value);
                            Console.WriteLine(v + "\\Count" + "\\" + value);

                        }
                    }
                    this.Invoke(new Action(() => progressBarInc()));
                }
                this.Invoke(new Action(() => finishedLoading()));
            }).Start();
        }

        private void addToListBox(string str)
        {
            listBox1.Items.Add(Transform(str));
        }
        private void progressBarInc()
        {
            metroProgressBar2.Value++;
        }
        private void progressBarTo(int to)
        {
            metroProgressBar2.Maximum = to;

        }
        private void finishedLoading()
        {
            listBox1.Show();
            metroProgressBar2.Hide();
            metroLabel11.Hide();
        }

        public static string Transform(string value)
        {
            char[] array = value.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }

        private void metroTabPage5_Click(object sender, EventArgs e)
        {
        }

        private void metroTabPage5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked)
            {

                temp = listBox1.Items;
                listBox1.Items.Clear();
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(temp);
            }
        }
        ListBox.ObjectCollection temp;

        private void metroLabel11_Click(object sender, EventArgs e)
        {
                    }

        private void metroButton20_Click(object sender, EventArgs e)
        {
        }

        private void metroTabPage4_Click(object sender, EventArgs e)
        {

        }
        bool clicked = false;

        private void metroTabPage4_Paint(object sender, PaintEventArgs e)
        {
            if (clicked == false)
                loadUserAssistLogs();

            clicked = true;
        }

        private void metroButton22_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();

            new Thread(() =>
            {
                memoryCheck.run(frm);
            }
            ).Start();
        }

        public void incrementProgressBar()
        {
            progressBar1.Value = progressBar1.Value + 1;
        }

        public void setProgressBar(int amm)
        {
            progressBar1.Maximum = amm;
            progressBar1.Value = 0;
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
          //  list = listBox1.Items;
            listBox1.Items.Clear();

            foreach(string str in list)
            {
                if (str.Contains(metroTextBox1.Text))
                {
                    listBox1.Items.Add(str);
                }
            }
        }
        List<string> list;

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
