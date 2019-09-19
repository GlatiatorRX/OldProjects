using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsApp
{
    // Singleton pattern
    public class Singleton
    {
        private string _value = "Test";

        private Singleton()
        {
            // Do not instantiate externally
        }

        private static readonly Singleton _instance = new Singleton();

        public static Singleton GetInstance()
        {
            return _instance;
        }

        public string GetValue()
        {
            return _value;
        }
    }
}
