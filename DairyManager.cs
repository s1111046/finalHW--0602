using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace 日曆
{
    internal class DairyManager
    {
        // 定義存儲日記條目的文件夾常量
        public const string DiariesFolder = "diaries";
        // 定義存儲記帳條目的文件夾常量
        public const string accountingFolder = "accounting";

        // 靜態構造函數，在類第一次使用時調用，用於初始化文件夾
        static DairyManager()
        {
            InitializeFolder(DiariesFolder); // 初始化日記文件夾
            InitializeFolder(accountingFolder); // 初始化記帳文件夾
        }

        // 檢查指定日期的日記文件是否存在
        public static bool DiaryExists(DateTime selectedDate)
        {
            InitializeDiariesFolder(selectedDate); // 確保文件夾存在
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json"; // 生成文件名，格式為 yyyy-MM-dd.json
            string filePath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), fileName); // 生成文件路徑
            return File.Exists(filePath); // 檢查文件是否存在
        }

        // 檢查指定日期的記帳文件是否存在
        public static bool AccountingExists(DateTime selectedDate)
        {
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json"; // 生成文件名，格式為 yyyy-MM-dd.json
            string filePath = Path.Combine(accountingFolder, fileName); // 生成文件路徑
            return File.Exists(filePath); // 檢查文件是否存在
        }

        // 保存日記條目到文件
        public static void SaveToFile(DiaryEntry entry, DateTime selectedDate)
        {
            InitializeDiariesFolder(selectedDate); // 確保文件夾存在
            string jsonString = JsonConvert.SerializeObject(entry); // 將日記條目序列化為 JSON 字符串
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json"; // 生成文件名，格式為 yyyy-MM-dd.json
            string filePath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), fileName); // 生成文件路徑
            File.WriteAllText(filePath, jsonString); // 將 JSON 字符串寫入文件
        }

        // 保存記帳條目到文件
        public static void accoutingSaveToFile(List<accountingentery> entries, DateTime selectedDate)
        {
            InitializeFolder(accountingFolder); // 確保文件夾存在
            string jsonString = JsonConvert.SerializeObject(entries, Formatting.Indented); // 將記帳條目列表序列化為格式化的 JSON 字符串
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json"; // 生成文件名，格式為 yyyy-MM-dd.json
            string filePath = Path.Combine(accountingFolder, fileName); // 生成文件路徑
            File.WriteAllText(filePath, jsonString); // 將 JSON 字符串寫入文件
        }

        // 從文件加載記帳條目
        public static List<accountingentery> LoadFromFile(DateTime selectedDate)
        {
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json"; // 生成文件名，格式為 yyyy-MM-dd.json
            string filePath = Path.Combine(accountingFolder, fileName); // 生成文件路徑
            if (File.Exists(filePath)) // 檢查文件是否存在
            {
                string json = File.ReadAllText(filePath); // 讀取文件內容
                return JsonConvert.DeserializeObject<List<accountingentery>>(json); // 將 JSON 字符串反序列化為記帳條目列表並返回
            }
            return new List<accountingentery>(); // 如果文件不存在，返回一個空的記帳條目列表
        }

        // 初始化日記文件夾，按日期創建子文件夾
        private static void InitializeDiariesFolder(DateTime selectedDate)
        {
            string folderPath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd")); // 生成文件夾路徑
            if (!Directory.Exists(folderPath)) // 檢查文件夾是否存在
            {
                Directory.CreateDirectory(folderPath); // 創建文件夾
            }
        }

        // 初始化指定路徑的文件夾
        private static void InitializeFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath)) // 檢查文件夾是否存在
            {
                Directory.CreateDirectory(folderPath); // 創建文件夾
            }
        }
    }
}
