using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 日曆
{
    public partial class memorycs : Form
    {
        public memorycs()
        {
            InitializeComponent();
            // 設置 memoListBox 的繪製事件處理方法
            memoListBox.DrawItem += memoListBox_DrawItem;
            // 設置靜態漸層背景
            SetStaticGradientBackground();
        }

        // 設置靜態漸層背景的方法
        private void SetStaticGradientBackground()
        {
            // 定義極光顏色
            Color[] auroraColors = {
                Color.FromArgb(150, 0, 40, 80), 
                Color.FromArgb(150, 0, 120, 60), 
                Color.FromArgb(150, 0, 80, 100) 
            };

            // 創建線性漸層筆刷
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Black, Color.Black, 0F);
            ColorBlend blend = new ColorBlend();
            blend.Positions = new float[] { 0, 0.5f, 1 };
            blend.Colors = auroraColors;
            brush.InterpolationColors = blend;

            // 設置表單的背景為線性漸層筆刷
            this.BackgroundImage = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(this.BackgroundImage);
            g.FillRectangle(brush, this.ClientRectangle);
        }

        // 保存按鈕點擊事件處理方法
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 初始化備忘錄文件夾
            InitializeDiariesFolder();
            // 創建備忘錄條目
            getset entry = new getset
            {
                title = this.title.Text,
                Memo = Memo.Text,
                Date = DateTime.Today // 記錄當前日期，不包含時間
            };

            // 創建存儲文件夾的路徑
            string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");

            // 如果文件夾不存在，則創建
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // 創建文件路徑
            string filePath = Path.Combine(folderPath, this.title.Text + ".json");

            // 創建 JSON 格式的字符串
            string json = JsonConvert.SerializeObject(entry);

            // 寫入文件
            File.WriteAllText(filePath, json);

            // 提示用戶保存成功
            MessageBox.Show("備忘錄儲存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 更新備忘錄列表框
            memoListBox.Items.Add($"{entry.title} ({entry.Date:yyyy-MM-dd})");

            // 清空輸入框
            this.title.Text = null;
            Memo.Text = null;
        }

        // 定義備忘錄文件夾名稱常量
        public const string memoryfolder = "memory";

        // 初始化備忘錄文件夾的方法
        private static void InitializeDiariesFolder()
        {
            if (!Directory.Exists(memoryfolder))
            {
                Directory.CreateDirectory(memoryfolder);
            }
        }

        // 備忘錄列表框點擊事件處理方法
        private void MemoListBox_Click(object sender, EventArgs e)
        {
            // 從 ListBox 選擇的項中提取標題，忽略日期部分
            string selectedItem = memoListBox.SelectedItem.ToString();
            string selectedTitle = selectedItem.Substring(0, selectedItem.LastIndexOf(" (")); // 去掉日期部分

            // 創建存儲文件夾的路徑
            string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");
            // 創建文件路徑
            string filePath = Path.Combine(folderPath, selectedTitle + ".json");

            // 如果文件存在，讀取文件內容並顯示
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                getset entry = JsonConvert.DeserializeObject<getset>(json);

                // 顯示備忘錄內容到 UI 中
                this.title.Text = entry.title;
                Memo.Text = entry.Memo;
            }
            else
            {
                MessageBox.Show("文件未找到。");
            }
        }

        // 清空按鈕點擊事件處理方法
        private void button1_Click(object sender, EventArgs e)
        {
            this.title.Text = ""; // 清空標題文本框
            Memo.Text = ""; // 清空備忘錄文本框
        }

        // 表單載入事件處理方法
        private void Form1_Load(object sender, EventArgs e)
        {
            // 創建存儲文件夾的路徑
            string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");

            // 如果文件夾存在，則加載其中的文件
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath, "*.json");
                foreach (var file in files)
                {
                    string json = File.ReadAllText(file);
                    getset entry = JsonConvert.DeserializeObject<getset>(json);
                    memoListBox.Items.Add($"{entry.title} ({entry.Date:yyyy-MM-dd})");
                }
            }
        }

        // 刪除按鈕點擊事件處理方法
        private void deletebutton3_Click(object sender, EventArgs e)
        {
            if (memoListBox.SelectedItem != null)
            {
                // 從 ListBox 選擇的項中提取標題，忽略日期部分
                string selectedItem = memoListBox.SelectedItem.ToString();
                string selectedTitle = selectedItem.Substring(0, selectedItem.LastIndexOf(" (")); // 去掉日期部分

                // 創建存儲文件夾的路徑
                string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");
                // 創建文件路徑
                string filePath = Path.Combine(folderPath, selectedTitle + ".json");

                // 如果文件存在，刪除文件並更新列表框
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    memoListBox.Items.Remove(selectedItem);
                    this.title.Text = "";
                    Memo.Text = "";
                    MessageBox.Show("備忘錄已刪除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("文件未找到。");
                }
            }
            else
            {
                MessageBox.Show("請選擇要刪除的備忘錄。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // memoListBox 的自定義繪製事件處理方法
        private void memoListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // 獲取當前項的文本
            string itemText = memoListBox.Items[e.Index].ToString();

            // 分離標題和日期
            int indexOfDate = itemText.LastIndexOf(" (");
            string title = itemText.Substring(0, indexOfDate);
            string date = itemText.Substring(indexOfDate);

            // 繪製背景
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds); // 選中的背景色
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds); // 默認背景色
            }

            // 定義字體和顏色
            Font titleFont = e.Font;
            Font dateFont = new Font(e.Font.FontFamily, e.Font.Size - 4);
            Brush titleBrush = new SolidBrush(e.ForeColor);
            Brush dateBrush = Brushes.Gray;

            // 如果項被選中，則改變文字顏色和字體粗細
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                titleFont = new Font(e.Font, FontStyle.Bold);
                dateFont = new Font(e.Font.FontFamily, e.Font.Size - 2, FontStyle.Bold);
                titleBrush = new SolidBrush(Color.FromArgb(0, 121, 121)); // #007979
                dateBrush = new SolidBrush(Color.FromArgb(0, 121, 121)); // #007979
            }

            // 繪製標題
            e.Graphics.DrawString(title, titleFont, titleBrush, e.Bounds.X, e.Bounds.Y);

            // 計算日期部分的繪製位置
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            float dateX = e.Bounds.X + titleSize.Width + 5; // 5 是間隔
            float dateY = e.Bounds.Y;

            // 繪製日期
            e.Graphics.DrawString(date, dateFont, dateBrush, dateX, dateY);

            // 繪製焦點矩形框
            e.DrawFocusRectangle();
        }

        // 添加按鈕點擊事件處理方法
        private void addbutton_Click(object sender, EventArgs e)
        {
            title.Text = ""; // 清空標題文本框
            Memo.Text = ""; // 清空備忘錄文本框
        }
    }
}
