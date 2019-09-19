using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsApp
{
    public class Shape
    {
        public string Name { get; set; }
        public int Sides { get; set; }

        public Shape(string name, int sides)
        {
            Name = name;
            Sides = sides;
        }

        public void IncrementSidesBy(int amount)
        {
            Sides += amount;
            Console.WriteLine($"Shape: {Name} now has {amount} more sides!");
        }

        public void DerementSidesBy(int amount)
        {
            if (amount < Sides)
            {
                Sides -= amount;
                Console.WriteLine($"Shape: {Name} now has {amount} less siades!");
            } else
            {
                Console.WriteLine("You cant have negative sides...");
            }
        }

        public override string ToString() => $"{Name} has {Sides} sides.";
    }

    public interface ICommand
    {
        void ExecuteAction();
    }

    public enum Action
    {
        Increase,
        Decrease
    }

    public class ShapeCommand : ICommand
    {
        private readonly Shape _shape;
        private readonly Action _action;
        private readonly int _amount;

        public ShapeCommand(Shape shape, Action action, int amount)
        {
            _shape = shape;
            _action = action;
            _amount = amount;
        }

        public void ExecuteAction()
        {
            if (_action == Action.Increase)
            {
                _shape.IncrementSidesBy(_amount);
            }
            else
            {
                _shape.DerementSidesBy(_amount);
            }
        }
    }

    public class ModifySides
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;

        public ModifySides()
        {
            _commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => _command = command;

        public void Invoke()
        {
            _commands.Add(_command);
            _command.ExecuteAction();
        }
    }
}
