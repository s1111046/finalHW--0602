using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 日曆
{
    internal class getset
    {
        // 定義屬性，使用自動實現的屬性
        public string title { get; set; } 
        public string Memo { get; set; } 
        public DateTime Date { get; set; } 

        // 重寫 ToString 方法，返回包含標題和說明的字串
        public override string ToString()
        {
            return $"標題: {title}，說明: {Memo}";
        }
    }
}
