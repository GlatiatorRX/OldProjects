using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsApp
{
    class Program
    {
        // test id 23280666794759
        static void Main(string[] args)
        {
            bool exit = false;
            Console.WriteLine("Matthew Bolles testing application");
            Console.Write("\nPress any key to continue: ");
            Console.ReadKey();
            Console.WriteLine("\n... ");

            // Singleton test
            /*Singleton singleton = Singleton.GetInstance();
            Console.WriteLine("\n" + singleton.GetValue());*/

            // Factory test
            /*BaseFactory factory1 = new Factory1(100);
            BaseFactory factory2 = new Factory2(200);

            Console.WriteLine("\n" + factory1.GetProduct().Value1);
            Console.WriteLine(factory1.GetProduct().Value2);

            Console.WriteLine("\n" + factory2.GetProduct().Value1);
            Console.WriteLine(factory2.GetProduct().Value2);*/

            // Adapter test
            /*ITarget target = new Adapter();
            AdaptedClass adaptedClass = new AdaptedClass(target);
            target.DoSomething();*/

            // Bridge test
            /*Bridge a = new BridgeA();
            Bridge b = new BridgeB();
            Bridge c = new BridgeC();

            Abstraction aa = new AbstractionA();
            aa._value1 = "Test Message";

            aa.bridge = a;
            aa.CallBridge();

            aa.bridge = b;
            aa.CallBridge();

            aa.bridge = c;
            aa.CallBridge();

            AbstractionB bb = new AbstractionB();
            bb._value1 = "Value 1";
            bb._value2 = "Value 2";

            bb.bridge = a;
            bb.CallBridge();*/

            // Visitor test
            /*ItemGroup g = new ItemGroup();
            g.Attach(new Box());
            g.Attach(new Circle());
            g.Attach(new Triangle());
            
            g.Accept(new NameVisitor());
            g.Accept(new ValueVisitor());
            g.Accept(new NameVisitor());*/

            // Command test
            /*var modifyShape = new ModifySides();
            var shape = new Shape("Polyhedron", 10);
            Execute(shape, modifyShape, new ShapeCommand(shape, Action.Increase, 100));
            Execute(shape, modifyShape, new ShapeCommand(shape, Action.Decrease, 200));
            Execute(shape, modifyShape, new ShapeCommand(shape, Action.Decrease, 50));
            Console.WriteLine(shape);*/

            // Proxy Test
            /*MathProxy proxy = new MathProxy();
            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));*/

            // Observer Test
            /*// Create price watch for Carrots and attach restaurants that buy carrots from suppliers.
            Carrots carrots = new Carrots(0.82);
            carrots.Attach(new Restaurant("Mackay's", 0.77));
            carrots.Attach(new Restaurant("Johnny's Sports Bar", 0.74));
            carrots.Attach(new Restaurant("Salad Kingdom", 0.75));

            // Fluctuating carrot prices will notify subscribing restaurants.
            carrots.PricePerPound = 0.79;
            carrots.PricePerPound = 0.76;
            carrots.PricePerPound = 0.73;
            carrots.PricePerPound = 0.81;*/

            /*int i = 0;
            try
            {
                Console.WriteLine(1/i);
            } catch (Exception e)
            {
                Console.WriteLine("oof " + e.Message);
            }*/

            Console.WriteLine("\n... ");
            Console.Write("\nPress any key to exit: ");
            Console.ReadKey();


            int removeObstacle(int numRows, int numColumns, List<List<Integer>> lot)
            {
                // WRITE YOUR CODE HERE
                int targetX = numRows - 1;
                int targetY = numColumns - 1;
                for (int y = 0; y < numRows; y++)
                {
                    for (int x = 0; x < numColumns; x++)
                    {
                        if (lot.get(y).get(x) == 9)
                        {
                            targetX = x;
                            targetY = y;
                        }
                    }
                }

                int backstepX = targetX;
                int backstepY = targetY;
                int count = 0;
                // get best neighbor
                while (true)
                {
                    if (backstepX > 0)
                    {
                        lot.get(backstepY).get(backstepX - 1);
                        backstepX = backstepX - 1;
                        count++;
                    }
                    else if (backstepY > 0)
                    {
                        lot.get(backstepY).get(backstepX + 1);
                        backstepY = backstepY - 1;
                        count++;
                    }
                    else
                    {
                        lot.get(backstepY - 1).get(backstepX);
                        backstepY = backstepX + 1;
                        count++;
                    }

                    if (backstepY == 0 && backstepX == 0)
                    {
                        return count;
                    }
                }
            }
        }

        private static void Execute(Shape product, ModifySides modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
