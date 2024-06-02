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
        // 定義顯示的全文本
        private string fullText = "哈囉你好,歡迎來到我們的應用程式 !!!";
        // 當前顯示的字符索引
        private int currentIndex = 0;
        // 流星列表，用於存儲流星物件
        private List<Meteor> meteors = new List<Meteor>();
        // 隨機數生成器
        private Random rand = new Random();
        // 流星動畫的計時器
        private System.Windows.Forms.Timer meteorTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            //monthCalendar1.DateSelected += monthCalendar1_DateChanged;

            // 初始化流星
            InitializeMeteors();
            this.DoubleBuffered = true; // 減少閃爍
        }

        // 初始化自定義組件
        private void InitializeCustomComponents()
        {
            // 初始化文字動畫的計時器
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

        // 文字動畫計時器事件處理方法
        private void timer2_Tick(object sender, EventArgs e)
        {
            // 檢查是否還有未顯示的字符
            if (currentIndex < fullText.Length)
            {
                label2.Text += fullText[currentIndex]; // 顯示當前字符
                currentIndex++; // 更新當前顯示的字符索引
            }
            else
            {
                timer2.Stop(); // 如果所有字符都已顯示，停止定時器
            }
        }

        // 月曆日期選擇事件處理方法
        public void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start != e.End)
            {
                DateTime selectedDate = monthCalendar1.SelectionStart; // 獲取選擇的日期
                choice choiceForm = new choice(selectedDate); // 創建新的選擇表單
                choiceForm.ShowDialog(); // 以對話框形式顯示表單
            }
        }

        // 記憶按鈕點擊事件處理方法
        private void memory_Click(object sender, EventArgs e)
        {
            memorycs memoryForm = new memorycs(); // 創建新的記憶表單
            memoryForm.Show(); // 顯示表單
        }

        // 繪製事件處理方法
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 設定背景顏色為星空漸層
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Black, ColorTranslator.FromHtml("#003D79"), 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle); // 用漸變顏色填充背景
            }

            // 繪製流星
            foreach (var meteor in meteors)
            {
                Pen pen = new Pen(Color.White); // 設置流星顏色
                e.Graphics.DrawLine(pen, meteor.StartX, meteor.StartY, meteor.StartX + meteor.Length, meteor.StartY + meteor.Length); // 繪製流星
            }
        }

        // 流星動畫計時器事件處理方法
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
                    meteors[i] = GenerateMeteor(); // 重新生成流星
                }
            }
            // 觸發重繪
            this.Invalidate();
        }

        // 初始化流星的方法
        private void InitializeMeteors()
        {
            int numMeteors = 10; // 設定流星數量
            for (int i = 0; i < numMeteors; i++)
            {
                meteors.Add(GenerateMeteor()); // 生成並添加流星到列表中
            }
        }

        // 生成流星的方法
        private Meteor GenerateMeteor()
        {
            int startX = rand.Next(this.Width); // 流星起始位置 X 座標
            int startY = rand.Next(this.Height); // 流星起始位置 Y 座標
            int length = rand.Next(10, 50); // 流星的長度
            int speed = rand.Next(1, 5); // 流星的速度
            return new Meteor(startX, startY, length, speed); // 返回生成的流星
        }
    }

    // 流星類別，表示每顆流星的屬性和行為
    public class Meteor
    {
        public int StartX { get; set; } // 流星的起始 X 座標
        public int StartY { get; set; } // 流星的起始 Y 座標
        public int Length { get; set; } // 流星的長度
        public int Speed { get; set; } // 流星的速度

        // 構造函數，初始化流星的位置、長度和速度
        public Meteor(int startX, int startY, int length, int speed)
        {
            StartX = startX;
            StartY = startY;
            Length = length;
            Speed = speed;
        }
    }
}
