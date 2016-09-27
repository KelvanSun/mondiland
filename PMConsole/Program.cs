using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mondiland.Obj;

using Seagull.BarTender.Print;


namespace Mondiland.PMConsole
{

    
    class Program
    {

        

        static void Main(string[] args)
        {

            Engine m_engine_console = new Engine(true);

            string str_printName = "TEC B-462-R";
            
                      
            Console.WriteLine("欢迎使用控制台打印系统!");

            ProductObject product = new ProductObject("C1101-1");

            product.Print(m_engine_console,
                          str_printName,
                          ProductObject.PrintType.TagCODE93,
                          1,
                          1);

        }
    }
}
