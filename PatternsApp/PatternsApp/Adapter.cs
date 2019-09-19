using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsApp
{
    // For use when two classes are incompatible, or must use existing code without changing
    public interface ITarget
    {
        void DoSomething();
    }

    public class Adaptee
    {
        public void DoSomethingElse()
        {
            Console.WriteLine("DoSomethingElse() is called");
        }
    }

    public class AdaptedClass
    {
        private ITarget _target;

        public AdaptedClass(ITarget target)
        {
            _target = target;
        }

        public void CallTarget()
        {
            _target.DoSomething();
        }
    }

    public class Adapter : Adaptee, ITarget
    {
        public void DoSomething()
        {
            DoSomethingElse();
        }
    }
}
