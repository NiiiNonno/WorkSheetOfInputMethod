using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;

namespace _2B_3;

public partial class Form1 : Form
{
    Model.Nexus _model;

    public Form1()
    {
        _model = new Model() { View = new(this) }.GetNexus();

        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        _model.State = 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        _model.State++;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _model.State--;
    }

    private void button3_Click(object sender, EventArgs e)
    {
        //FontDialogクラスのインスタンスを作成
        var fd = new FontDialog();

        fd.Font = textBox1.Font;
        fd.Color = textBox1.ForeColor;
        fd.FontMustExist = true;
        fd.AllowVerticalFonts = false;
        fd.ShowColor = true;
        fd.ShowEffects = false;

        //ダイアログを表示する
        if (fd.ShowDialog() != DialogResult.Cancel)
        {
            //TextBox1のフォントと色を変える
            textBox1.Font = fd.Font;
            textBox1.ForeColor = fd.Color;
            textBox2.Font = fd.Font;
            textBox2.ForeColor = fd.Color;
        }
    }

    private void button4_Click(object sender, EventArgs e)
    {
        switch (button4.Text)
        {
        case "一時停止":
            _model.Running = false;
            textBox1.Enabled = false;
            button4.Text = "再開";
            break;
        default:
            _model.Running = true;
            textBox1.Enabled = true;
            button4.Text = "一時停止";
            break;
        }
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        _model.Text = textBox1.Text;
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        _model.Dispose();
    }

    public struct Nexus(Form1 form)
    {
        public string Message { set => form.label1.Text = value; }
        public string LeftText { set { form.textBox2.Text = value; form.button3.Enabled = !String.IsNullOrWhiteSpace(value); } }
        public string RightText { set { form.textBox1.Text = value; } }
        public bool Pausable { set => form.button4.Enabled = value; }
        public int Counter { set => form.label2.Text = value.ToString(); }
        public float Mile
        {
            set => form.splitContainer2.SplitterDistance = (int)(form.Width * (value < 0 ? 0 : value > 1 ? 1 : value));
        }
    }
}
