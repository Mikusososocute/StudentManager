using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerModel
{
    public class PageSearchInfo
    {
        public int TotalCount { get; set; }

        public List<StuInfo> DataList { get; set; }

        /// <summary>
        /// 成功状态（200表示成功）
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public string ResultMsg { get; set; }
    }
}
