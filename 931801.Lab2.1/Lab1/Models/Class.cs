using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class mylist
    {
        public ArrayList values;

        public mylist(int add, int sub,int mult,double div,int value1,int value2 )
        {
            values = new ArrayList();
            values.Add(add);
            values.Add(sub);
            values.Add(mult);
            values.Add(div);
            values.Add(value1);
            values.Add(value2);
        }
    }
}
