using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Services
{
    public class HTMLSender
    {
        int value1;
        int value2;

        public int Value1 { get => value1; set => value1 = value; }
        public int Value2 { get => value2; set => value2 = value; }

        public HTMLSender()
        {
            Random rand = new Random();
            Value1 = rand.Next(0, 10);
            Value2 = rand.Next(0, 10);
        }
        public int add()
        {
            return Value1 + Value2;
        }
        public int sub()
        {
            return Value1 - Value2;
        }
        public int mult()
        {
            return Value1 * Value2;
        }
        public double div()
        {
            try
            {
                double result = (double)Value1 / (double)Value2;
                return result;
            }
            catch (DivideByZeroException)
            {
                Console.Write("error");
                return -1;
            }
        }
    }
}
