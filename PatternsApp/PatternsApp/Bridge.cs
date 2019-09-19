using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsApp
{
    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public abstract class Abstraction
    {
        public Bridge bridge { get; set; }
        public string _value1 { get; set; }
        public abstract void CallBridge();
    }

    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class AbstractionA : Abstraction
    {
        public override void CallBridge()
        {
            bridge.DoSomething(_value1);
        }
    }

    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class AbstractionB : Abstraction
    {
        public string _value2 { get; set; }

        public override void CallBridge()
        {
            string compound = string.Format("{0}\n - {1}", _value1, _value2);
            bridge.DoSomething(compound);
        }
    }

    /// <summary>
    /// The 'Bridge/Implementor' interface
    /// </summary>
    public interface Bridge
    {
        void DoSomething(string val);
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class BridgeA : Bridge
    {
        public void DoSomething(string val)
        {
            Console.WriteLine("Bridge A \n{0}\n", val);
        }
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class BridgeB : Bridge
    {
        public void DoSomething(string val)
        {
            Console.WriteLine("Bridge B \n{0}\n", val);
        }
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class BridgeC : Bridge
    {
        public void DoSomething(string val)
        {
            Console.WriteLine("Bridge C \n{0}\n", val);
        }
    }
}
