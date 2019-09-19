using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsApp
{
    // Factory pattern
    abstract class BaseFactoryProduct
    {
        public abstract string Value1 { get; }
        public abstract int Value2 { get; set; }
    }

    class FactoryProd1 : BaseFactoryProduct
    {
        private string _value1;
        private int _value2;

        public FactoryProd1(int newVal)
        {
            _value1 = "Test1";
            _value2 = newVal;
        }

        public override string Value1
        {
            get { return _value1; }
        }

        public override int Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
    }

    class FactoryProd2 : BaseFactoryProduct
    {
        private string _value1;
        private int _value2;

        public FactoryProd2(int newVal)
        {
            _value1 = "Test2";
            _value2 = newVal;
        }

        public override string Value1
        {
            get { return _value1; }
        }

        public override int Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
    }

    abstract class BaseFactory
    {
        public abstract BaseFactoryProduct GetProduct();
    }

    class Factory1 : BaseFactory
    {
        private int _value;

        public Factory1(int newVal)
        {
            _value = newVal;
        }

        public override BaseFactoryProduct GetProduct()
        {
            return new FactoryProd1(_value);
        }
    }

    class Factory2 : BaseFactory
    {
        private int _value;

        public Factory2(int newVal)
        {
            _value = newVal;
        }

        public override BaseFactoryProduct GetProduct()
        {
            return new FactoryProd2(_value);
        }
    }
}
