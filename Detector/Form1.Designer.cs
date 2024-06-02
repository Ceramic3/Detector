namespace Detector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            startButton = new Button();
            stopDetectingButton = new Button();
            warningLabel = new Label();
            label1 = new Label();
            addDirectoryButton = new Button();
            removeDirectoryButton = new Button();
            directoryListView = new ListView();
            panel1 = new Panel();
            relaxedLabel = new Label();
            moderateLabel = new Label();
            strictLabel = new Label();
            strictnessModifier = new TrackBar();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)strictnessModifier).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.White;
            startButton.Cursor = Cursors.Hand;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.Font = new Font("Segoe Script", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startButton.Location = new Point(12, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(776, 49);
            startButton.TabIndex = 0;
            startButton.Text = "Start Detecting";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // stopDetectingButton
            // 
            stopDetectingButton.BackColor = Color.White;
            stopDetectingButton.Font = new Font("Segoe Script", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stopDetectingButton.Location = new Point(12, 12);
            stopDetectingButton.Name = "stopDetectingButton";
            stopDetectingButton.Size = new Size(776, 49);
            stopDetectingButton.TabIndex = 1;
            stopDetectingButton.Text = "Detection in Progress...";
            stopDetectingButton.UseVisualStyleBackColor = false;
            stopDetectingButton.Click += stopDetectingButton_Click;
            // 
            // warningLabel
            // 
            warningLabel.AutoSize = true;
            warningLabel.BackColor = SystemColors.ScrollBar;
            warningLabel.Location = new Point(7, 203);
            warningLabel.Name = "warningLabel";
            warningLabel.Size = new Size(670, 15);
            warningLabel.TabIndex = 2;
            warningLabel.Text = "WARNING: Detector does not PREVENT malware from running. This is simply to be used as a post-analysis / future prevention.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ScrollBar;
            label1.Location = new Point(7, 218);
            label1.Name = "label1";
            label1.Size = new Size(285, 15);
            label1.TabIndex = 3;
            label1.Text = "This is a Detector, not a Preventor. For now, at least ;)";
            // 
            // addDirectoryButton
            // 
            addDirectoryButton.Cursor = Cursors.Hand;
            addDirectoryButton.FlatAppearance.BorderSize = 0;
            addDirectoryButton.Location = new Point(12, 67);
            addDirectoryButton.Name = "addDirectoryButton";
            addDirectoryButton.Size = new Size(115, 23);
            addDirectoryButton.TabIndex = 4;
            addDirectoryButton.Text = "Add Directory";
            addDirectoryButton.UseVisualStyleBackColor = true;
            addDirectoryButton.Click += addDirectoryButton_Click;
            // 
            // removeDirectoryButton
            // 
            removeDirectoryButton.Cursor = Cursors.Hand;
            removeDirectoryButton.FlatAppearance.BorderSize = 0;
            removeDirectoryButton.Location = new Point(133, 67);
            removeDirectoryButton.Name = "removeDirectoryButton";
            removeDirectoryButton.Size = new Size(115, 23);
            removeDirectoryButton.TabIndex = 5;
            removeDirectoryButton.Text = "Remove Directory";
            removeDirectoryButton.UseVisualStyleBackColor = true;
            removeDirectoryButton.Click += removeDirectoryButton_Click;
            // 
            // directoryListView
            // 
            directoryListView.LabelWrap = false;
            directoryListView.Location = new Point(12, 96);
            directoryListView.Name = "directoryListView";
            directoryListView.Size = new Size(776, 99);
            directoryListView.TabIndex = 6;
            directoryListView.UseCompatibleStateImageBehavior = false;
            directoryListView.View = View.List;
            directoryListView.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ScrollBar;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(relaxedLabel);
            panel1.Controls.Add(moderateLabel);
            panel1.Controls.Add(strictLabel);
            panel1.Controls.Add(warningLabel);
            panel1.Controls.Add(strictnessModifier);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(5, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(791, 243);
            panel1.TabIndex = 7;
            // 
            // relaxedLabel
            // 
            relaxedLabel.AutoSize = true;
            relaxedLabel.Location = new Point(699, 67);
            relaxedLabel.Name = "relaxedLabel";
            relaxedLabel.Size = new Size(48, 15);
            relaxedLabel.TabIndex = 5;
            relaxedLabel.Text = "Relaxed";
            // 
            // moderateLabel
            // 
            moderateLabel.AutoSize = true;
            moderateLabel.Location = new Point(699, 67);
            moderateLabel.Name = "moderateLabel";
            moderateLabel.Size = new Size(58, 15);
            moderateLabel.TabIndex = 5;
            moderateLabel.Text = "Moderate";
            // 
            // strictLabel
            // 
            strictLabel.AutoSize = true;
            strictLabel.Location = new Point(699, 67);
            strictLabel.Name = "strictLabel";
            strictLabel.Size = new Size(34, 15);
            strictLabel.TabIndex = 5;
            strictLabel.Text = "Strict";
            // 
            // strictnessModifier
            // 
            strictnessModifier.BackColor = SystemColors.ScrollBar;
            strictnessModifier.Location = new Point(589, 63);
            strictnessModifier.Maximum = 2;
            strictnessModifier.Name = "strictnessModifier";
            strictnessModifier.Size = new Size(104, 45);
            strictnessModifier.TabIndex = 4;
            strictnessModifier.Scroll += strictnessModifier_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(265, 67);
            label2.Name = "label2";
            label2.Size = new Size(318, 15);
            label2.TabIndex = 6;
            label2.Text = "For now only changes process creation check timer ------>";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 251);
            Controls.Add(directoryListView);
            Controls.Add(removeDirectoryButton);
            Controls.Add(addDirectoryButton);
            Controls.Add(startButton);
            Controls.Add(stopDetectingButton);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Detector - 1.0";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)strictnessModifier).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button startButton;
        private Button stopDetectingButton;
        private Label warningLabel;
        private Label label1;
        private Button addDirectoryButton;
        private Button removeDirectoryButton;
        private ListView directoryListView;
        private Panel panel1;
        private TrackBar strictnessModifier;
        private Label relaxedLabel;
        private Label moderateLabel;
        private Label strictLabel;
        private Label label2;
    }
}
