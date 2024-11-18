namespace _2B_3;

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
        button1 = new Button();
        label1 = new Label();
        pictureBox1 = new PictureBox();
        splitContainer1 = new SplitContainer();
        textBox2 = new TextBox();
        textBox1 = new TextBox();
        button2 = new Button();
        button3 = new Button();
        label2 = new Label();
        button4 = new Button();
        splitContainer2 = new SplitContainer();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
        splitContainer2.SuspendLayout();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        button1.BackColor = Color.FromArgb(255, 128, 255);
        button1.FlatStyle = FlatStyle.Popup;
        button1.Location = new Point(603, 12);
        button1.Name = "button1";
        button1.Size = new Size(63, 39);
        button1.TabIndex = 0;
        button1.Text = "すすむ";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
        label1.Location = new Point(12, 16);
        label1.Name = "label1";
        label1.Size = new Size(0, 20);
        label1.TabIndex = 1;
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
        pictureBox1.Image = Properties.Resources.東方標準化機構之印;
        pictureBox1.Location = new Point(672, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(100, 100);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 2;
        pictureBox1.TabStop = false;
        // 
        // splitContainer1
        // 
        splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        splitContainer1.Location = new Point(12, 118);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(textBox2);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(textBox1);
        splitContainer1.Size = new Size(760, 321);
        splitContainer1.SplitterDistance = 380;
        splitContainer1.TabIndex = 3;
        // 
        // textBox2
        // 
        textBox2.AcceptsReturn = true;
        textBox2.BorderStyle = BorderStyle.None;
        textBox2.Dock = DockStyle.Fill;
        textBox2.Font = new Font("游明朝", 11.25F);
        textBox2.Location = new Point(0, 0);
        textBox2.Multiline = true;
        textBox2.Name = "textBox2";
        textBox2.ReadOnly = true;
        textBox2.ScrollBars = ScrollBars.Vertical;
        textBox2.ShortcutsEnabled = false;
        textBox2.Size = new Size(380, 321);
        textBox2.TabIndex = 1;
        textBox2.Text = "資料の引用元：\r\n^1 https://ja.wikipedia.org/wiki/宿題\r\n^2 https://en.wikipedia.org/wiki/Homework";
        // 
        // textBox1
        // 
        textBox1.AcceptsReturn = true;
        textBox1.BorderStyle = BorderStyle.None;
        textBox1.Dock = DockStyle.Fill;
        textBox1.Font = new Font("游明朝", 11.25F);
        textBox1.Location = new Point(0, 0);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ScrollBars = ScrollBars.Vertical;
        textBox1.Size = new Size(376, 321);
        textBox1.TabIndex = 0;
        textBox1.KeyDown += textBox1_KeyDown;
        // 
        // button2
        // 
        button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        button2.BackColor = Color.Gainsboro;
        button2.FlatStyle = FlatStyle.Popup;
        button2.Location = new Point(534, 12);
        button2.Name = "button2";
        button2.Size = new Size(63, 39);
        button2.TabIndex = 4;
        button2.Text = "もどる";
        button2.UseVisualStyleBackColor = false;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        button3.BackColor = Color.Gainsboro;
        button3.Enabled = false;
        button3.FlatStyle = FlatStyle.Popup;
        button3.Location = new Point(534, 57);
        button3.Name = "button3";
        button3.Size = new Size(132, 23);
        button3.TabIndex = 5;
        button3.Text = "フォントを変更する";
        button3.UseVisualStyleBackColor = false;
        button3.Click += button3_Click;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label2.AutoSize = true;
        label2.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
        label2.Location = new Point(603, 90);
        label2.Name = "label2";
        label2.Size = new Size(0, 15);
        label2.TabIndex = 6;
        // 
        // button4
        // 
        button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        button4.BackColor = Color.PowderBlue;
        button4.Enabled = false;
        button4.FlatStyle = FlatStyle.Popup;
        button4.Location = new Point(534, 86);
        button4.Name = "button4";
        button4.Size = new Size(63, 23);
        button4.TabIndex = 7;
        button4.Text = "一時停止";
        button4.UseVisualStyleBackColor = false;
        button4.Click += button4_Click;
        // 
        // splitContainer2
        // 
        splitContainer2.BackColor = Color.Teal;
        splitContainer2.Dock = DockStyle.Bottom;
        splitContainer2.Location = new Point(0, 445);
        splitContainer2.Name = "splitContainer2";
        // 
        // splitContainer2.Panel1
        // 
        splitContainer2.Panel1.BackColor = Color.Turquoise;
        splitContainer2.Panel1MinSize = 0;
        // 
        // splitContainer2.Panel2
        // 
        splitContainer2.Panel2.BackColor = Color.Silver;
        splitContainer2.Panel2MinSize = 0;
        splitContainer2.Size = new Size(784, 16);
        splitContainer2.SplitterDistance = 25;
        splitContainer2.SplitterWidth = 1;
        splitContainer2.TabIndex = 8;
        // 
        // Form1
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(784, 461);
        Controls.Add(splitContainer2);
        Controls.Add(button4);
        Controls.Add(label2);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(splitContainer1);
        Controls.Add(pictureBox1);
        Controls.Add(label1);
        Controls.Add(button1);
        Name = "Form1";
        Text = "試験輔助和英文校正系之効用(2B_====3)";
        FormClosed += Form1_FormClosed;
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        splitContainer1.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
        splitContainer2.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Label label1;
    private PictureBox pictureBox1;
    private SplitContainer splitContainer1;
    private Button button2;
    private TextBox textBox1;
    private TextBox textBox2;
    private Button button3;
    private Label label2;
    private Button button4;
    private SplitContainer splitContainer2;
}
