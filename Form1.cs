using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 日曆
{
    public partial class Form1 : Form
    {
        private string fullText = "哈囉你好,歡迎來到我們的應用程式 !!!";
        private int currentIndex = 0;
        private List<Meteor> meteors = new List<Meteor>();
        private Random rand = new Random();

        private System.Windows.Forms.Timer meteorTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            //monthCalendar1.DateSelected += monthCalendar1_DateChanged;

            // 初始化流星
            InitializeMeteors();
            this.DoubleBuffered = true;

        }
        private void InitializeCustomComponents()
        {
            // 初始化 Timer
            timer2 = new System.Windows.Forms.Timer();
            timer2.Interval = 100; // 設置定時器間隔，單位是毫秒
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

            // 初始化流星動畫定時器
            meteorTimer = new System.Windows.Forms.Timer();
            meteorTimer.Interval = 15; // 流星動畫定時器間隔
            meteorTimer.Tick += new EventHandler(MeteorTimer_Tick);
            meteorTimer.Start();

            // 設置 Label 和 PictureBox 背景透明
            label2.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;

            // 確保 Label 和 PictureBox 的父控件是 Form
            this.Controls.Add(label2);
            this.Controls.Add(pictureBox1);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // 檢查是否還有未顯示的字符
            if (currentIndex < fullText.Length)
            {
                label2.Text += fullText[currentIndex];
                currentIndex++;
            }
            else
            {
                timer2.Stop(); // 如果所有字符都已顯示，停止定時器
            }
        }


        public void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start != e.End)
            {
                DateTime selectedDate = monthCalendar1.SelectionStart;
                choice choiceForm = new choice(selectedDate);
                choiceForm.ShowDialog();
                
            }

        }

        private void memory_Click(object sender, EventArgs e)
        {
            memorycs memoryForm = new memorycs();
            memoryForm.Show();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 設定背景顏色為星空漸層
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Black, ColorTranslator.FromHtml("#003D79"), 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            // 繪製流星
            foreach (var meteor in meteors)
            {
                Pen pen = new Pen(Color.White);
                e.Graphics.DrawLine(pen, meteor.StartX, meteor.StartY, meteor.StartX + meteor.Length, meteor.StartY + meteor.Length);
            }
        }

        private void MeteorTimer_Tick(object sender, EventArgs e)
        {
            // 更新流星的位置
            for (int i = 0; i < meteors.Count; i++)
            {
                meteors[i].StartX += meteors[i].Speed;
                meteors[i].StartY += meteors[i].Speed;

                // 如果流星超出邊界，重新生成
                if (meteors[i].StartX > this.Width || meteors[i].StartY > this.Height)
                {
                    meteors[i] = GenerateMeteor();
                }
            }
            // 觸發重繪
            this.Invalidate();
        }
        private void InitializeMeteors()
        {
            int numMeteors = 10; // 設定流星數量
            for (int i = 0; i < numMeteors; i++)
            {
                meteors.Add(GenerateMeteor());
            }
        }

        private Meteor GenerateMeteor()
        {
            int startX = rand.Next(this.Width); // 流星起始位置 X 座標
            int startY = rand.Next(this.Height); // 流星起始位置 Y 座標
            int length = rand.Next(10, 50); // 流星的長度
            int speed = rand.Next(1, 5); // 流星的速度
            return new Meteor(startX, startY, length, speed);
        }

    }
    public class Meteor
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int Length { get; set; }
        public int Speed { get; set; }

        public Meteor(int startX, int startY, int length, int speed)
        {
            StartX = startX;
            StartY = startY;
            Length = length;
            Speed = speed;
        }
    }
}