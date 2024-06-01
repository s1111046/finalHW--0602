using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace 日曆
{
    internal class DairyManager
    {
        // 定义存储日记条目的文件夹常量
        public const string DiariesFolder = "diaries";
        // 定义存储记账条目的文件夹常量
        public const string accountingFolder = "accounting";

        // 静态构造函数，在类第一次使用时调用，用于初始化文件夹
        static DairyManager()
        {
            InitializeFolder(DiariesFolder); // 初始化日记文件夹
            InitializeFolder(accountingFolder); // 初始化记账文件夹
        }

        // 检查指定日期的日记文件是否存在
        public static bool DiaryExists(DateTime selectedDate)
        {
            InitializeDiariesFolder(selectedDate); // 确保文件夹存在
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json"; // 生成文件名
            string filePath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), fileName); // 生成文件路径
            return File.Exists(filePath); // 检查文件是否存在
        }

        // 检查指定日期的记账文件是否存在
        public static bool AccountingExists(DateTime selectedDate)
        {
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json"; // 生成文件名
            string filePath = Path.Combine(accountingFolder, fileName); // 生成文件路径
            return File.Exists(filePath); // 检查文件是否存在
        }

        // 保存日记条目到文件
        public static void SaveToFile(DiaryEntry entry, DateTime selectedDate)
        {
            InitializeDiariesFolder(selectedDate); // 确保文件夹存在
            string jsonString = JsonConvert.SerializeObject(entry); // 将日记条目序列化为JSON字符串
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json"; // 生成文件名
            string filePath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd"), fileName); // 生成文件路径
            File.WriteAllText(filePath, jsonString); // 将JSON字符串写入文件
        }

        // 保存记账条目到文件
        public static void accoutingSaveToFile(List<accountingentery> entries, DateTime selectedDate)
        {
            InitializeFolder(accountingFolder); // 确保文件夹存在
            string jsonString = JsonConvert.SerializeObject(entries, Formatting.Indented); // 将记账条目列表序列化为格式化的JSON字符串
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json"; // 生成文件名
            string filePath = Path.Combine(accountingFolder, fileName); // 生成文件路径
            File.WriteAllText(filePath, jsonString); // 将JSON字符串写入文件
        }

        // 从文件加载记账条目
        public static List<accountingentery> LoadFromFile(DateTime selectedDate)
        {
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json"; // 生成文件名
            string filePath = Path.Combine(accountingFolder, fileName); // 生成文件路径
            if (File.Exists(filePath)) // 检查文件是否存在
            {
                string json = File.ReadAllText(filePath); // 读取文件内容
                return JsonConvert.DeserializeObject<List<accountingentery>>(json); // 将JSON字符串反序列化为记账条目列表并返回
            }
            return new List<accountingentery>(); // 如果文件不存在，返回一个空的记账条目列表
        }

        // 初始化日记文件夹，按日期创建子文件夹
        private static void InitializeDiariesFolder(DateTime selectedDate)
        {
            string folderPath = Path.Combine(DiariesFolder, selectedDate.ToString("yyyy-MM-dd")); // 生成文件夹路径
            if (!Directory.Exists(folderPath)) // 检查文件夹是否存在
            {
                Directory.CreateDirectory(folderPath); // 创建文件夹
            }
        }

        // 初始化指定路径的文件夹
        private static void InitializeFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath)) // 检查文件夹是否存在
            {
                Directory.CreateDirectory(folderPath); // 创建文件夹
            }
        }
    }
}
