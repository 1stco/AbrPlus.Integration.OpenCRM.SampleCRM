namespace AbrPlus.Integration.OpenCRM.SampleCRM.Client.UI
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
            tableLayoutPanel1 = new TableLayoutPanel();
            checkBox_AutomaticReconnect = new CheckBox();
            textBox_URL = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btn_Start = new Button();
            btn_Stop = new Button();
            configuration = new GroupBox();
            EventGroup = new GroupBox();
            listBox_Events = new ListBox();
            tableLayoutPanel1.SuspendLayout();
            configuration.SuspendLayout();
            EventGroup.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(checkBox_AutomaticReconnect, 1, 1);
            tableLayoutPanel1.Controls.Add(textBox_URL, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(619, 61);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBox_AutomaticReconnect
            // 
            checkBox_AutomaticReconnect.Dock = DockStyle.Fill;
            checkBox_AutomaticReconnect.Location = new Point(103, 33);
            checkBox_AutomaticReconnect.Name = "checkBox_AutomaticReconnect";
            checkBox_AutomaticReconnect.Size = new Size(294, 25);
            checkBox_AutomaticReconnect.TabIndex = 4;
            checkBox_AutomaticReconnect.UseVisualStyleBackColor = true;
            // 
            // textBox_URL
            // 
            textBox_URL.Dock = DockStyle.Fill;
            textBox_URL.Location = new Point(103, 3);
            textBox_URL.Name = "textBox_URL";
            textBox_URL.Size = new Size(294, 23);
            textBox_URL.TabIndex = 4;
            textBox_URL.Text = "https://localhost:7074/OpenCRMHub";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(94, 31);
            label2.TabIndex = 4;
            label2.Text = "AutoReconect:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 30);
            label1.TabIndex = 3;
            label1.Text = "URL:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn_Start
            // 
            btn_Start.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Start.Location = new Point(12, 101);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(75, 23);
            btn_Start.TabIndex = 1;
            btn_Start.Text = "Connect";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += Start_Click;
            // 
            // btn_Stop
            // 
            btn_Stop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Stop.Enabled = false;
            btn_Stop.Location = new Point(93, 101);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Size = new Size(75, 23);
            btn_Stop.TabIndex = 2;
            btn_Stop.Text = "Disconnect";
            btn_Stop.UseVisualStyleBackColor = true;
            btn_Stop.Click += btn_Stop_Click;
            // 
            // configuration
            // 
            configuration.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            configuration.Controls.Add(tableLayoutPanel1);
            configuration.Location = new Point(12, 12);
            configuration.Name = "configuration";
            configuration.Size = new Size(625, 83);
            configuration.TabIndex = 3;
            configuration.TabStop = false;
            configuration.Text = "configuration";
            // 
            // EventGroup
            // 
            EventGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EventGroup.Controls.Add(listBox_Events);
            EventGroup.Location = new Point(12, 130);
            EventGroup.Name = "EventGroup";
            EventGroup.Size = new Size(622, 253);
            EventGroup.TabIndex = 4;
            EventGroup.TabStop = false;
            EventGroup.Text = "Event List";
            // 
            // listBox_Events
            // 
            listBox_Events.Dock = DockStyle.Fill;
            listBox_Events.FormattingEnabled = true;
            listBox_Events.ItemHeight = 15;
            listBox_Events.Location = new Point(3, 19);
            listBox_Events.Name = "listBox_Events";
            listBox_Events.Size = new Size(616, 231);
            listBox_Events.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 395);
            Controls.Add(EventGroup);
            Controls.Add(btn_Start);
            Controls.Add(btn_Stop);
            Controls.Add(configuration);
            Name = "MainForm";
            Text = "SampleCRM";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            configuration.ResumeLayout(false);
            EventGroup.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_Start;
        private Button btn_Stop;
        private CheckBox checkBox_AutomaticReconnect;
        private TextBox textBox_URL;
        private Label label2;
        private Label label1;
        private GroupBox configuration;
        private GroupBox EventGroup;
        private ListBox listBox_Events;
    }
}
