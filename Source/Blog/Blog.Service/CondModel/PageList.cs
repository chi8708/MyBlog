using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.CondModel
{
    public class PageList
    {
        public PageList() 
        {
            if (PageIndex<=0)
            {
                PageIndex = 1;
            }
            if (PageSize<=0)
            {
                PageSize = 10;
            }
        }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
