using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.Facade.BigComplicatedLibrary1;
using Patterns.Facade.BigComplicatedLibrary2;

namespace Patterns.Facade
{
    /// <summary>
    /// Шаблон фасад (англ. Facade) — структурный шаблон проектирования, позволяющий
    /// скрыть сложность системы путём сведения всех возможных внешних вызовов к одному 
    /// объекту, делегирующему их соответствующим объектам системы.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            Facade facade = new Facade();

            //Простое использование сложных систем
            facade.Operation1();
            facade.Operation2();

            Console.Read();
        }
    }

    /// <summary>
    /// Facade - фасад
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu> "знает", каким классами подсистемы адресовать запрос;</lu>
    /// <lu> делегирует запросы клиентов объектам внутри подсистемы;</lu>
    /// </li>
    /// </remarks>
    public class Facade
    {
        private readonly SubsystemA _subsystemA = new SubsystemA();
        private readonly SubsystemB _subsystemB = new SubsystemB();
        private readonly SubsystemC _subsystemC = new SubsystemC();

        public void Operation1()
        {
            Console.WriteLine($@"Operation: {nameof(Operation1)}
                                 Result: {_subsystemA.A1() + " | " +
                                          _subsystemB.B1() + " | " +
                                          _subsystemC.C1()}");
            Console.WriteLine();
        }

        public void Operation2()
        {
            Console.WriteLine($@"Operation: {nameof(Operation1)}
                                 Result: {_subsystemA.A2() + " | " +
                                          _subsystemB.B1() + " | " +
                                          _subsystemC.C1()}");
            Console.WriteLine();
        }
    }

    namespace BigComplicatedLibrary1
    {
        /// <summary>
        /// <b>Подсистема</b> которая ничего не "знает" о существовании фасада <see cref="Facade"/>;
        /// </summary>
        internal class SubsystemA
        {
            internal string A1() => nameof(SubsystemA) + "." + nameof(A1);
            internal string A2() => nameof(SubsystemA) + "." + nameof(A2);
        }

        internal class SubsystemB
        {
            internal string B1() => nameof(SubsystemB) + "." + nameof(B1);
        }
    }

    namespace BigComplicatedLibrary2
    {
        internal class SubsystemC
        {
            internal string C1() => nameof(SubsystemC) + "." + nameof(C1);
        }
    }
}
