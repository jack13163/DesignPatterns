using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class JZKFC : IFactory
    {
        public IMainFood OrderMainFood()
        {
            Console.WriteLine("来一份你们的主食!");
            Hamburger ham = new Hamburger();

            ham.Do();
            ham.Dish();

            return ham;
        }

        public IDrink OrderDrink()
        {
            Console.WriteLine("来一份你们的饮品！");
            Juice juice = new Juice();

            juice.Do();
            juice.Bottle();

            return juice;
        }
    }
}