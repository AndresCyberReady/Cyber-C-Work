namespace Cyber_C_
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            button2 = new Button();
            progressBar1 = new ProgressBar();
            statusStrip1 = new StatusStrip();
            fileCountLabel = new ToolStripStatusLabel();
            scanStatusLabel = new ToolStripStatusLabel();
            fileSizeLabel = new ToolStripStatusLabel();
            timeScanLabel = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(629, 230);
            button1.Name = "button1";
            button1.Size = new Size(147, 48);
            button1.TabIndex = 0;
            button1.Text = "Load Hashes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(640, 12);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(0, 15);
            linkLabel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Snap ITC", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(568, 12);
            label1.Name = "label1";
            label1.Size = new Size(249, 48);
            label1.TabIndex = 2;
            label1.Text = "CyberDash";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(359, 320);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(763, 223);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.ForeColor = Color.DarkGreen;
            label2.Location = new Point(359, 292);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 4;
            label2.Text = "Status:";
            label2.Click += label2_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.Location = new Point(1047, 291);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(359, 166);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(763, 33);
            progressBar1.TabIndex = 6;
            progressBar1.Visible = false;
            progressBar1.Click += progressBar1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { fileCountLabel, scanStatusLabel, fileSizeLabel, timeScanLabel });
            statusStrip1.Location = new Point(0, 590);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1450, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // fileCountLabel
            // 
            fileCountLabel.Name = "fileCountLabel";
            fileCountLabel.Size = new Size(118, 17);
            fileCountLabel.Text = "toolStripStatusLabel1";
            // 
            // scanStatusLabel
            // 
            scanStatusLabel.Name = "scanStatusLabel";
            scanStatusLabel.Size = new Size(118, 17);
            scanStatusLabel.Text = "toolStripStatusLabel2";
            // 
            // fileSizeLabel
            // 
            fileSizeLabel.Name = "fileSizeLabel";
            fileSizeLabel.Size = new Size(118, 17);
            fileSizeLabel.Text = "toolStripStatusLabel1";
            fileSizeLabel.Click += toolStripStatusLabel1_Click;
            // 
            // timeScanLabel
            // 
            timeScanLabel.Name = "timeScanLabel";
            timeScanLabel.Size = new Size(118, 17);
            timeScanLabel.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1450, 612);
            Controls.Add(statusStrip1);
            Controls.Add(progressBar1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(linkLabel1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private LinkLabel linkLabel1;
        private Label label1;
        private RichTextBox richTextBox1;
        private Label label2;
        private Button button2;
        private ProgressBar progressBar1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel fileCountLabel;
        private ToolStripStatusLabel scanStatusLabel;
        private ToolStripStatusLabel fileSizeLabel;
        private ToolStripStatusLabel timeScanLabel;
    }
}
