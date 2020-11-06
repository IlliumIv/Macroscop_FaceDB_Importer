namespace Macroscop_FaceDB_Importer.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPortSeparator = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.buttonConnectionSecure = new System.Windows.Forms.Button();
            this.buttonStartImport = new System.Windows.Forms.Button();
            this.labelModuleType = new System.Windows.Forms.Label();
            this.comboBoxModuleType = new System.Windows.Forms.ComboBox();
            this.groupBoxImages = new System.Windows.Forms.GroupBox();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.labelGroupName = new System.Windows.Forms.Label();
            this.comboBoxSecondName = new System.Windows.Forms.ComboBox();
            this.comboBoxPatronymic = new System.Windows.Forms.ComboBox();
            this.comboBoxFirstName = new System.Windows.Forms.ComboBox();
            this.labelSecondName = new System.Windows.Forms.Label();
            this.labelPatronymic = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelNamesReg = new System.Windows.Forms.Label();
            this.textBoxNamesReg = new System.Windows.Forms.TextBox();
            this.buttonImagesDir = new System.Windows.Forms.Button();
            this.labelImagesDir = new System.Windows.Forms.Label();
            this.textBoxImagesDir = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
            this.progressBar = new Macroscop_FaceDB_Importer.FormsExtension.TextProgressBar();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerUpper = new System.Windows.Forms.SplitContainer();
            this.groupBoxConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.groupBoxImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUpper)).BeginInit();
            this.splitContainerUpper.Panel1.SuspendLayout();
            this.splitContainerUpper.Panel2.SuspendLayout();
            this.splitContainerUpper.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddress.Location = new System.Drawing.Point(69, 22);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(97, 23);
            this.textBoxAddress.TabIndex = 0;
            this.textBoxAddress.Text = "127.0.0.1";
            this.textBoxAddress.TextChanged += new System.EventHandler(this.TextBoxAddress_OnTextChanged);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(6, 25);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(39, 15);
            this.labelAddress.TabIndex = 2;
            this.labelAddress.Text = "Server";
            // 
            // labelPortSeparator
            // 
            this.labelPortSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPortSeparator.AutoSize = true;
            this.labelPortSeparator.Location = new System.Drawing.Point(170, 24);
            this.labelPortSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.labelPortSeparator.Name = "labelPortSeparator";
            this.labelPortSeparator.Size = new System.Drawing.Size(10, 15);
            this.labelPortSeparator.TabIndex = 3;
            this.labelPortSeparator.Text = ":";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogin.Location = new System.Drawing.Point(69, 51);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(212, 23);
            this.textBoxLogin.TabIndex = 4;
            this.textBoxLogin.Text = "root";
            this.textBoxLogin.TextChanged += new System.EventHandler(this.TextBoxLogin_OnTextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(69, 80);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(212, 23);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.TextBoxPassword_OnTextChanged);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(6, 54);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(37, 15);
            this.labelLogin.TabIndex = 6;
            this.labelLogin.Text = "Login";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 83);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(57, 15);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Password";
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.numericUpDownPort);
            this.groupBoxConnection.Controls.Add(this.buttonConnectionSecure);
            this.groupBoxConnection.Controls.Add(this.buttonStartImport);
            this.groupBoxConnection.Controls.Add(this.labelModuleType);
            this.groupBoxConnection.Controls.Add(this.comboBoxModuleType);
            this.groupBoxConnection.Controls.Add(this.textBoxAddress);
            this.groupBoxConnection.Controls.Add(this.labelPortSeparator);
            this.groupBoxConnection.Controls.Add(this.labelLogin);
            this.groupBoxConnection.Controls.Add(this.labelPassword);
            this.groupBoxConnection.Controls.Add(this.labelAddress);
            this.groupBoxConnection.Controls.Add(this.textBoxLogin);
            this.groupBoxConnection.Controls.Add(this.textBoxPassword);
            this.groupBoxConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxConnection.Location = new System.Drawing.Point(0, 0);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(287, 200);
            this.groupBoxConnection.TabIndex = 8;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection";
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPort.Location = new System.Drawing.Point(182, 22);
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(59, 23);
            this.numericUpDownPort.TabIndex = 11;
            this.numericUpDownPort.ValueChanged += new System.EventHandler(this.NumericUpDownPort_OnValueChanged);
            // 
            // buttonConnectionSecure
            // 
            this.buttonConnectionSecure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnectionSecure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonConnectionSecure.FlatAppearance.BorderSize = 0;
            this.buttonConnectionSecure.Location = new System.Drawing.Point(244, 15);
            this.buttonConnectionSecure.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConnectionSecure.Name = "buttonConnectionSecure";
            this.buttonConnectionSecure.Size = new System.Drawing.Size(37, 35);
            this.buttonConnectionSecure.TabIndex = 10;
            this.buttonConnectionSecure.UseVisualStyleBackColor = false;
            this.buttonConnectionSecure.Click += new System.EventHandler(this.ButtonConnectionSecure_Click);
            // 
            // buttonStartImport
            // 
            this.buttonStartImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartImport.Location = new System.Drawing.Point(6, 136);
            this.buttonStartImport.Name = "buttonStartImport";
            this.buttonStartImport.Size = new System.Drawing.Size(275, 25);
            this.buttonStartImport.TabIndex = 5;
            this.buttonStartImport.Text = "Import";
            this.buttonStartImport.UseVisualStyleBackColor = true;
            this.buttonStartImport.Click += new System.EventHandler(this.ButtonStartImport_Click);
            // 
            // labelModuleType
            // 
            this.labelModuleType.AutoSize = true;
            this.labelModuleType.Location = new System.Drawing.Point(7, 112);
            this.labelModuleType.Name = "labelModuleType";
            this.labelModuleType.Size = new System.Drawing.Size(48, 15);
            this.labelModuleType.TabIndex = 9;
            this.labelModuleType.Text = "Module";
            // 
            // comboBoxModuleType
            // 
            this.comboBoxModuleType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxModuleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModuleType.FormattingEnabled = true;
            this.comboBoxModuleType.Location = new System.Drawing.Point(69, 109);
            this.comboBoxModuleType.Name = "comboBoxModuleType";
            this.comboBoxModuleType.Size = new System.Drawing.Size(212, 23);
            this.comboBoxModuleType.TabIndex = 8;
            this.comboBoxModuleType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxModuleType_OnSelectedValueChanged);
            // 
            // groupBoxImages
            // 
            this.groupBoxImages.Controls.Add(this.textBoxGroupName);
            this.groupBoxImages.Controls.Add(this.labelGroupName);
            this.groupBoxImages.Controls.Add(this.comboBoxSecondName);
            this.groupBoxImages.Controls.Add(this.comboBoxPatronymic);
            this.groupBoxImages.Controls.Add(this.comboBoxFirstName);
            this.groupBoxImages.Controls.Add(this.labelSecondName);
            this.groupBoxImages.Controls.Add(this.labelPatronymic);
            this.groupBoxImages.Controls.Add(this.labelFirstName);
            this.groupBoxImages.Controls.Add(this.labelNamesReg);
            this.groupBoxImages.Controls.Add(this.textBoxNamesReg);
            this.groupBoxImages.Controls.Add(this.buttonImagesDir);
            this.groupBoxImages.Controls.Add(this.labelImagesDir);
            this.groupBoxImages.Controls.Add(this.textBoxImagesDir);
            this.groupBoxImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxImages.Location = new System.Drawing.Point(0, 0);
            this.groupBoxImages.Name = "groupBoxImages";
            this.groupBoxImages.Size = new System.Drawing.Size(287, 200);
            this.groupBoxImages.TabIndex = 9;
            this.groupBoxImages.TabStop = false;
            this.groupBoxImages.Text = "Images";
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGroupName.Location = new System.Drawing.Point(101, 167);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(180, 23);
            this.textBoxGroupName.TabIndex = 3;
            this.textBoxGroupName.TextChanged += new System.EventHandler(this.TextBoxGroupName_OnTextChanged);
            // 
            // labelGroupName
            // 
            this.labelGroupName.AutoSize = true;
            this.labelGroupName.Location = new System.Drawing.Point(6, 170);
            this.labelGroupName.Name = "labelGroupName";
            this.labelGroupName.Size = new System.Drawing.Size(40, 15);
            this.labelGroupName.TabIndex = 8;
            this.labelGroupName.Text = "Group";
            // 
            // comboBoxSecondName
            // 
            this.comboBoxSecondName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSecondName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSecondName.FormattingEnabled = true;
            this.comboBoxSecondName.Location = new System.Drawing.Point(101, 138);
            this.comboBoxSecondName.Name = "comboBoxSecondName";
            this.comboBoxSecondName.Size = new System.Drawing.Size(180, 23);
            this.comboBoxSecondName.TabIndex = 11;
            // 
            // comboBoxPatronymic
            // 
            this.comboBoxPatronymic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPatronymic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPatronymic.FormattingEnabled = true;
            this.comboBoxPatronymic.Location = new System.Drawing.Point(101, 109);
            this.comboBoxPatronymic.Name = "comboBoxPatronymic";
            this.comboBoxPatronymic.Size = new System.Drawing.Size(180, 23);
            this.comboBoxPatronymic.TabIndex = 10;
            // 
            // comboBoxFirstName
            // 
            this.comboBoxFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFirstName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFirstName.FormattingEnabled = true;
            this.comboBoxFirstName.Location = new System.Drawing.Point(101, 80);
            this.comboBoxFirstName.Name = "comboBoxFirstName";
            this.comboBoxFirstName.Size = new System.Drawing.Size(180, 23);
            this.comboBoxFirstName.TabIndex = 9;
            // 
            // labelSecondName
            // 
            this.labelSecondName.AutoSize = true;
            this.labelSecondName.Location = new System.Drawing.Point(6, 141);
            this.labelSecondName.Name = "labelSecondName";
            this.labelSecondName.Size = new System.Drawing.Size(81, 15);
            this.labelSecondName.TabIndex = 8;
            this.labelSecondName.Text = "Second Name";
            // 
            // labelPatronymic
            // 
            this.labelPatronymic.AutoSize = true;
            this.labelPatronymic.Location = new System.Drawing.Point(6, 112);
            this.labelPatronymic.Name = "labelPatronymic";
            this.labelPatronymic.Size = new System.Drawing.Size(68, 15);
            this.labelPatronymic.TabIndex = 7;
            this.labelPatronymic.Text = "Patronymic";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(6, 83);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(64, 15);
            this.labelFirstName.TabIndex = 6;
            this.labelFirstName.Text = "First Name";
            // 
            // labelNamesReg
            // 
            this.labelNamesReg.AutoSize = true;
            this.labelNamesReg.Location = new System.Drawing.Point(6, 54);
            this.labelNamesReg.Name = "labelNamesReg";
            this.labelNamesReg.Size = new System.Drawing.Size(75, 15);
            this.labelNamesReg.TabIndex = 4;
            this.labelNamesReg.Text = "Names mask";
            // 
            // textBoxNamesReg
            // 
            this.textBoxNamesReg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNamesReg.Location = new System.Drawing.Point(101, 51);
            this.textBoxNamesReg.Name = "textBoxNamesReg";
            this.textBoxNamesReg.Size = new System.Drawing.Size(180, 23);
            this.textBoxNamesReg.TabIndex = 3;
            this.textBoxNamesReg.Text = "([A-z]*|[А-я]*)";
            this.textBoxNamesReg.TextChanged += new System.EventHandler(this.TextBoxNamesReg_OnTextChanged);
            // 
            // buttonImagesDir
            // 
            this.buttonImagesDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImagesDir.Location = new System.Drawing.Point(206, 20);
            this.buttonImagesDir.Name = "buttonImagesDir";
            this.buttonImagesDir.Size = new System.Drawing.Size(75, 25);
            this.buttonImagesDir.TabIndex = 2;
            this.buttonImagesDir.Text = "Browse";
            this.buttonImagesDir.UseVisualStyleBackColor = true;
            this.buttonImagesDir.Click += new System.EventHandler(this.ButtonImagesDir_Click);
            // 
            // labelImagesDir
            // 
            this.labelImagesDir.AutoSize = true;
            this.labelImagesDir.Location = new System.Drawing.Point(6, 25);
            this.labelImagesDir.Name = "labelImagesDir";
            this.labelImagesDir.Size = new System.Drawing.Size(55, 15);
            this.labelImagesDir.TabIndex = 1;
            this.labelImagesDir.Text = "Directory";
            // 
            // textBoxImagesDir
            // 
            this.textBoxImagesDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImagesDir.Location = new System.Drawing.Point(101, 22);
            this.textBoxImagesDir.Name = "textBoxImagesDir";
            this.textBoxImagesDir.Size = new System.Drawing.Size(99, 23);
            this.textBoxImagesDir.TabIndex = 0;
            // 
            // richTextBoxLogs
            // 
            this.richTextBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLogs.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxLogs.Name = "richTextBoxLogs";
            this.richTextBoxLogs.ReadOnly = true;
            this.richTextBoxLogs.Size = new System.Drawing.Size(578, 53);
            this.richTextBoxLogs.TabIndex = 8;
            this.richTextBoxLogs.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.CustomText = "";
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 53);
            this.progressBar.MinimumSize = new System.Drawing.Size(0, 23);
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.LimeGreen;
            this.progressBar.Size = new System.Drawing.Size(578, 23);
            this.progressBar.TabIndex = 10;
            this.progressBar.TextColor = System.Drawing.Color.Black;
            this.progressBar.TextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.progressBar.VisualMode = Macroscop_FaceDB_Importer.FormsExtension.ProgressBarDisplayMode.CurrProgress;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerUpper);
            this.splitContainerMain.Panel1MinSize = 200;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.richTextBoxLogs);
            this.splitContainerMain.Panel2.Controls.Add(this.progressBar);
            this.splitContainerMain.Panel2MinSize = 0;
            this.splitContainerMain.Size = new System.Drawing.Size(578, 280);
            this.splitContainerMain.SplitterDistance = 200;
            this.splitContainerMain.TabIndex = 11;
            this.splitContainerMain.Text = "splitContainer1";
            // 
            // splitContainerUpper
            // 
            this.splitContainerUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUpper.Location = new System.Drawing.Point(0, 0);
            this.splitContainerUpper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerUpper.Name = "splitContainerUpper";
            // 
            // splitContainerUpper.Panel1
            // 
            this.splitContainerUpper.Panel1.Controls.Add(this.groupBoxConnection);
            this.splitContainerUpper.Panel1MinSize = 287;
            // 
            // splitContainerUpper.Panel2
            // 
            this.splitContainerUpper.Panel2.Controls.Add(this.groupBoxImages);
            this.splitContainerUpper.Panel2MinSize = 287;
            this.splitContainerUpper.Size = new System.Drawing.Size(578, 200);
            this.splitContainerUpper.SplitterDistance = 287;
            this.splitContainerUpper.TabIndex = 0;
            this.splitContainerUpper.Text = "splitContainer1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 286);
            this.Controls.Add(this.splitContainerMain);
            this.MinimumSize = new System.Drawing.Size(600, 325);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Macroscop FaceDB Importer";
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.groupBoxImages.ResumeLayout(false);
            this.groupBoxImages.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerUpper.Panel1.ResumeLayout(false);
            this.splitContainerUpper.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUpper)).EndInit();
            this.splitContainerUpper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelPortSeparator;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.GroupBox groupBoxImages;
        private System.Windows.Forms.Button buttonImagesDir;
        private System.Windows.Forms.Label labelImagesDir;
        private System.Windows.Forms.TextBox textBoxImagesDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label labelNamesReg;
        private System.Windows.Forms.TextBox textBoxNamesReg;
        private System.Windows.Forms.RichTextBox richTextBoxLogs;
        private System.Windows.Forms.Label labelModuleType;
        private System.Windows.Forms.ComboBox comboBoxModuleType;
        private FormsExtension.TextProgressBar progressBar;
        private System.Windows.Forms.Button buttonStartImport;
        private System.Windows.Forms.Button buttonConnectionSecure;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Label labelPatronymic;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.ComboBox comboBoxSecondName;
        private System.Windows.Forms.ComboBox comboBoxPatronymic;
        private System.Windows.Forms.ComboBox comboBoxFirstName;
        private System.Windows.Forms.Label labelSecondName;
        private System.Windows.Forms.SplitContainer splitContainerUpper;
        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.Label labelGroupName;
    }
}

