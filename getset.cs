using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 日曆
{
    internal class getset
    {
        // 定义属性，自动实现的属性
        public string title { get; set; }
        public string Memo { get; set; }
        public DateTime Date { get; set; } // 添加日期属性

        // 重写ToString方法，返回包含标题和说明的字符串
        public override string ToString()
        {

            return $"標題: {title}，說明: {Memo}"; ;
        }
    }
}
