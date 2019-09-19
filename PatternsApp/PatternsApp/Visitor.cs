using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsApp
{
    /// <summary>
    /// The Element abstract class.  All this does is define an Accept operation, which needs to be implemented by any class that can be visited.
    /// </summary>
    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    /// <summary>
    /// The Visitor interface, which declares a Visit operation for each ConcreteVisitor to implement.
    /// </summary>
    interface IVisitor
    {
        void Visit(Element element);
    }

    /// <summary>
    /// A Concrete Visitor class.
    /// </summary>
    class NameVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Item item = element as Item;
            
            item.Name = "VERY " + item.Name;
            Console.WriteLine("Name of " + item.GetType().Name + " changed to: " + item.Name);
        }
    }

    /// <summary>
    /// A Concrete Visitor class
    /// </summary>
    class ValueVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Item item = element as Item;
            
            item.Value *= 2;
            Console.WriteLine("Value of " + item.GetType().Name + " changed to: " + item.Value);
        }
    }

    /// <summary>
    /// The ConcreteElement class, which implements all operations defined by the Element.
    /// </summary>
    class Item : Element
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public Item(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// The Object Structure class, which is a collection of Concrete Elements.  This could be implemented using another pattern such as Composite.
    /// </summary>
    class ItemGroup
    {
        private List<Item> _items = new List<Item>();

        public void Attach(Item item)
        {
            _items.Add(item);
        }

        public void Detach(Item item)
        {
            _items.Remove(item);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Item i in _items)
            {
                i.Accept(visitor);
            }
            Console.WriteLine();
        }
    }

    class Box : Item
    {
        public Box() : base("cool Box", 4)
        {
        }
    }

    class Circle : Item
    {
        public Circle() : base("cool Circle", 24)
        {
        }
    }

    class Triangle : Item
    {
        public Triangle() : base("cool Triangle", 3)
        {
        }
    }
}
