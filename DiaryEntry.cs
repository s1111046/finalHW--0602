using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 日曆
{
    // 定義日記條目類別
    internal class DiaryEntry
    {
        // 日期屬性
        public DateTime Date { get; set; }
        // 心情屬性
        public string Mood { get; set; }
        // 天氣屬性
        public string Weather { get; set; }
        // 內容屬性
        public string Context { get; set; }
        // 新增的選擇顏色屬性
        public Color SelectedColor { get; set; }
        // 照片文件名列表屬性
        public List<string> PhotoFileNames { get; set; }

        // 重寫 ToString 方法，返回包含日期、心情、天氣和內容的字符串
        public override string ToString()
        {
            return $"日期: {Date}, 心情: {Mood}, 天氣: {Weather}, 內容: {Context}";
        }
    }
}
