using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 日曆
{
    internal class savediary
    {
        // 讀取日記的方法
        public static DiaryEntry LoadDiary(string fileName)
        {
            // 檢查日記文件是否存在
            if (File.Exists(fileName))
            {
                // 讀取日記文件內容
                string json = File.ReadAllText(fileName);

                // 將 JSON 反序列化為 DiaryEntry 對象
                return JsonConvert.DeserializeObject<DiaryEntry>(json);
            }
            else
            {
                // 如果日記文件不存在，則返回空
                return null;
            }
        }
    }
}
