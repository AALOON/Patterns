using System;

namespace Patterns.Adapter
{
    /// <summary>
    /// Адаптер (англ. Adapter) — структурный шаблон проектирования, предназначенный
    /// для организации использования функций объекта, недоступного для модификации, 
    /// через специально созданный интерфейс.
    /// 
    /// https://ru.wikipedia.org/wiki/%D0%90%D0%B4%D0%B0%D0%BF%D1%82%D0%B5%D1%80_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
    /// 
    /// 
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Create adapter and place a request
            ITartget target = new Adapter();
            target.Request();

            // Wait for user
            Console.Read();
        }
    }

    // Target - targeted interface or abstract class
    interface ITartget
    {
        void Request();
    }
    
    abstract class Target : ITartget
    {
        public virtual void Request()
        {
            Console.WriteLine(nameof(Target) + "." + nameof(Request));
        }
    }

    // Adapter for class Adaptee
    class Adapter : Target
    {
        private readonly Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            base.Request();
            // Possibly do some other work
            // and then call SpecificRequest
            _adaptee.SpecificRequest();
        }
    }

    // Adaptee - it's what to need to adapt
    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine(nameof(Adaptee) + "." + nameof(SpecificRequest));
        }
    }
}
