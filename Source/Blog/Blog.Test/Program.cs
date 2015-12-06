using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var type=typeof(EntityBase);
            var entities= type.Assembly.GetTypes().Where(p => p.BaseType == type);
        }
    }
}
