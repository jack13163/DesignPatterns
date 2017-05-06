using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class SHKFC : IFactory
    {
        public IMainFood OrderMainFood()
        {
            Console.WriteLine("来一份主食！");
            FriedChicken fc = new FriedChicken();

            fc.Do();
            fc.Dish();

            return fc;
        }

        public IDrink OrderDrink()
        {
            Console.WriteLine("来一份饮品！");
            Juice juice = new Juice();

            juice.Do();
            juice.Bottle();

            return juice;
        }
    }
}
