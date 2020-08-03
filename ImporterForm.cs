using Macroscop_FaceDB_Importer.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Macroscop_FaceDB_Importer
{
    public partial class ImporterForm : Form
    {
        private static string LogFile = $"{nameof(Macroscop_FaceDB_Importer)}.log";

        public static bool MacroscopSecureConnection;
        public static ushort MacroscopPort { get; private set; }
        public static string MacroscopAddress { get; private set; }
        public static string MacroscopLogin { get; private set; }
        public static string MacroscopPassword { get; private set; }
        public static ModuleTypes MacroscopModule { get; private set; }

        public static Dictionary<string, int> NameMask;
        public static Regex imageNameMask;

        public delegate void LogMessageDelegate(string message);
        public delegate void ProgressBarDelegate(int value);
        public delegate void ImportStatus(bool importInProgress);
        public delegate void SetNameMaskDelegate();

        private Thread ImportThread;

        private List<string> parsedName;
        private static Dictionary<string, int> NamesRegMatchCollectionIndex;

        public ImporterForm()
        {
            InitializeComponent();
            OnLoad();
        }

        private void ProgressBar_ValueChanger(int value)
        {
            Invoke(new Action(() => {
                this.progressBar.Value = value;
            }));
        }

        private void LogMessage_Receiver(string message)
        {
            message = $"[{DateTime.Now}] {message}";
            message += "\n\n";

            Invoke(new Action(() => {
                this.richTextBoxLogs.Text += message;
                this.richTextBoxLogs.SelectionStart = richTextBoxLogs.Text.Length;
                this.richTextBoxLogs.ScrollToCaret();
            }));

            File.AppendAllText(LogFile, message);
        }

        private void buttonImagesDir_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxImagesDir.Text = folderBrowserDialog.SelectedPath;
                textBoxNamesReg_OnText_Changed(sender, e);
            }
        }

        private void Bind_comboBoxModuleType_Item()
        {
            List<ModuleTypes> modules = new List<ModuleTypes>();
            foreach (ModuleTypes type in Enum.GetValues(typeof(ModuleTypes)))
                modules.Add(type);

            this.comboBoxModuleType.DataSource = modules;
        }

        private void Set_buttonConnectionSecure_Tooltip()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.buttonConnectionSecure, "Use an encrypted connection");
        }

        private void OnLoad()
        {
            using (FileStream log = File.Create(LogFile)) { };

            Bind_comboBoxModuleType_Item();
            Set_buttonConnectionSecure_Tooltip();

            MacroscopSecureConnection = false;
            this.buttonConnectionSecure.BackgroundImage = Resources._unlock;
            this.Icon = Resources.favicon;
            // this.numericUpDownPort.Controls.RemoveAt(0);
            this.numericUpDownPort.Maximum = 65535;
            this.numericUpDownPort.Minimum = 0;
            this.numericUpDownPort.Value = 8080;
            this.progressBar.Maximum = 0;

            MacroscopPort = (ushort)this.numericUpDownPort.Value;
            MacroscopAddress = this.textBoxAddress.Text;
            MacroscopLogin = this.textBoxLogin.Text;
            MacroscopPassword = this.textBoxPassword.Text;
            MacroscopModule = (ModuleTypes)this.comboBoxModuleType.SelectedValue;

            Importer.LogMessage += LogMessage_Receiver;
            Importer.PrograssBarValue += ProgressBar_ValueChanger;
            Importer.ImportInProgress += ImportInProgress;
            RequestBuilder.SetNameMask += SetNameMask;
        }

        private void ImportInProgress(bool importInProgress)
        {
            switch (importInProgress)
            {
                case true:
                    LogMessage_Receiver($"Import of {this.progressBar.Maximum} images started.");

                    Invoke(new Action(() => {
                        this.buttonStartImport.Text = "Abort";
                    }));

                    break;
                case false:
                    LogMessage_Receiver($"Import of {this.progressBar.Maximum} images is complete.\nSuccessfully imported {Importer.SuccessCounter} images.");
                    if (Importer.ImagesToImport.Count > Importer.SuccessCounter)
                    {
                        FileInfo logFileInfo = new FileInfo(LogFile);
                        LogMessage_Receiver($"Failed to import some images. Logs: {(logFileInfo.FullName)}");
                    }

                    Invoke(new Action(() => {
                        this.buttonStartImport.Text = "Import";
                    }));

                    break;
            }

            Invoke(new Action(() => {
                this.textBoxAddress.Enabled = !importInProgress;
                this.numericUpDownPort.Enabled = !importInProgress;
                this.buttonConnectionSecure.Enabled = !importInProgress;
                this.textBoxLogin.Enabled = !importInProgress;
                this.textBoxPassword.Enabled = !importInProgress;
                this.comboBoxModuleType.Enabled = !importInProgress;
                this.textBoxImagesDir.Enabled = !importInProgress;
                this.buttonImagesDir.Enabled = !importInProgress;
                this.textBoxNamesReg.Enabled = !importInProgress;
                this.comboBoxFirstName.Enabled = !importInProgress;
                this.comboBoxPatronymic.Enabled = !importInProgress;
                this.comboBoxSecondName.Enabled = !importInProgress;
            }));
        }

        private void textBoxNamesReg_OnText_Changed(object sender, EventArgs e)
        {
            switch (this.textBoxNamesReg.Text)
            {
                case "":
                    Invoke(new Action(() => {
                        this.comboBoxFirstName.DataSource = null;
                        this.comboBoxPatronymic.DataSource = null;
                        this.comboBoxSecondName.DataSource = null;
                    }));

                    break;

                // case @"([А-я]{3,})":
                   // break;

                default:
                    FindImages();

                    if (Importer.ImagesToImport is null)
                        break;

                    try
                    {
                        imageNameMask = new Regex(this.textBoxNamesReg.Text);
                        MatchCollection matches = imageNameMask.Matches(Importer.ImagesToImport.First<FileInfo>().Name);
                        if (matches.Count > 0)
                        {
                            parsedName = new List<string>();
                            NamesRegMatchCollectionIndex = new Dictionary<string, int>();
                            int counter = 0;

                            foreach (Match match in matches)
                            {
                                counter++;

                                if (match.Groups.Count > 0)
                                {
                                    if (NamesRegMatchCollectionIndex.TryAdd(match.Groups[0].Value, counter - 1))
                                    {
                                        parsedName.Add(match.Groups[1].Value);
                                        continue;
                                    }
                                }

                                if (NamesRegMatchCollectionIndex.TryAdd(match.Value, counter - 1))
                                    parsedName.Add(match.Value);
                            }

                            if (parsedName.Count > 0)
                            {
                                parsedName.RemoveAll(s => s == "");
                                parsedName.Add("");

                                Invoke(new Action(() =>
                                {
                                    this.comboBoxFirstName.DataSource = new List<string>(parsedName);
                                    this.comboBoxPatronymic.DataSource = new List<string>(parsedName);
                                    this.comboBoxSecondName.DataSource = new List<string>(parsedName);
                                }));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogMessage_Receiver(ex.Message);

                        Invoke(new Action(() => {
                            this.comboBoxFirstName.DataSource = null;
                            this.comboBoxPatronymic.DataSource = null;
                            this.comboBoxSecondName.DataSource = null;
                        }));
                    }

                    break;
            }
        }

        private void SetNameMask()
        {
            NameMask = new Dictionary<string, int>();

            Invoke(new Action(() =>
            {
                NameMask.Add("first_name", NamesRegMatchCollectionIndex.GetValueOrDefault(this.comboBoxFirstName.Text));
                NameMask.Add("patronymic", NamesRegMatchCollectionIndex.GetValueOrDefault(this.comboBoxPatronymic.Text));
                NameMask.Add("second_name", NamesRegMatchCollectionIndex.GetValueOrDefault(this.comboBoxSecondName.Text));
            }));
        }

        private void buttonStartImport_Click(object sender, EventArgs e)
        {
            FindImages();

            if (ImportThread is null ||
                ImportThread.ThreadState.HasFlag(ThreadState.Stopped))
            {
                ImportThread = new Thread(Importer.Import)
                {
                    IsBackground = true
                };
                ImportThread.Start();
            }
            else
                Importer.DoWork = false;
        }

        private void FindImages()
        {
            try
            {
                DirectoryInfo imagesDir = new DirectoryInfo(this.textBoxImagesDir.Text);
                Importer.ImagesToImport = imagesDir.GetFiles().Where(s => s.Extension == ".jpg" || s.Extension == ".png" || s.Extension == ".bmp").ToList();

                Invoke(new Action(() => {
                    this.progressBar.Maximum = Importer.ImagesToImport.Count;
                }));
            }
            catch
            {
                 // LogMessage_Receiver(ex.Message);
            }
        }

        private void textBoxAddress_OnText_Changed(object sender, EventArgs e)
        {
            MacroscopAddress = this.textBoxAddress.Text;
        }

        private void numericUpDownPort_OnValue_Changed(object sender, EventArgs e)
        {
            MacroscopPort = (ushort)this.numericUpDownPort.Value;
        }

        private void textBoxLogin_OnText_Changed(object sender, EventArgs e)
        {
            MacroscopLogin = this.textBoxLogin.Text;
        }

        private void textBoxPassword_OnText_Changed(object sender, EventArgs e)
        {
            MacroscopPassword = this.textBoxPassword.Text;
        }

        private void comboBoxModuleType_OnSelectedValue_Changed(object sender, EventArgs e)
        {
            MacroscopModule = (ModuleTypes)this.comboBoxModuleType.SelectedValue;
        }

        private void buttonConnectionSecure_Click(object sender, EventArgs e)
        {
            MacroscopSecureConnection = !MacroscopSecureConnection;

            switch (MacroscopSecureConnection)
            {
                case true:
                    this.buttonConnectionSecure.BackgroundImage = Resources._lock;
                    break;
                case false:
                    this.buttonConnectionSecure.BackgroundImage = Resources._unlock;
                    break;
            }
        }
    }
}
