using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client
{
    public class MyCompare : IComparer<Category>
    {

        public int Compare(Category x, Category y)
        {
            if (x.Id < y.Id)
            {
                return -1;
            }
            else if (x.Id > y.Id)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
