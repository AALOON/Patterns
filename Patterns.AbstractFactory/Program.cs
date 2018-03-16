using System;

namespace Patterns.AbstractFactory
{
    /// <summary>
    /// Абстрактная фабрика (англ. Abstract factory) — порождающий шаблон проектирования, 
    /// предоставляет интерфейс для создания семейств взаимосвязанных или взаимозависимых 
    /// объектов, не специфицируя их конкретных классов. Шаблон реализуется созданием 
    /// абстрактного класса Factory, который представляет собой интерфейс для создания 
    /// компонентов системы (например, для оконного интерфейса он может создавать окна и 
    /// кнопки). Затем пишутся классы, реализующие этот интерфейс.
    /// https://ru.wikipedia.org/wiki/%D0%90%D0%B1%D1%81%D1%82%D1%80%D0%B0%D0%BA%D1%82%D0%BD%D0%B0%D1%8F_%D1%84%D0%B0%D0%B1%D1%80%D0%B8%D0%BA%D0%B0_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
    /// 
    /// Назначение 
    /// Предоставляет интерфейс для создания семейств взаимосвязанных или взаимозависимых объектов, не специфицируя их конкретных классов.
    /// 
    /// Pros:
    /// изолирует конкретные классы;
    /// упрощает замену семейств продуктов;
    /// гарантирует сочетаемость продуктов.
    /// 
    /// Cons:
    /// сложно добавить поддержку нового вида продуктов.
    ///  </summary>
    class Program
    {
        static void Main()
        {
            var client1 = new Client(new RedFactory());
            var client2 = new Client(new GreenFactory());

            Console.WriteLine("Client 1:");
            client1.DoJob();

            Console.WriteLine();
            Console.WriteLine("Client 2:");
            client2.DoJob();

            Console.ReadKey();
        }

        /// <summary>
        /// Client which may not nothig about implementation of particular color
        /// </summary>
        public class Client
        {
            private readonly IProductA _productA;
            private readonly IProductB _productB;
            public Client(IFactory factory)
            {
                _productA = factory.CreateProductA();
                _productB = factory.CreateProductB();
            }

            public void DoJob()
            {
                _productA.DoSomthingA();
                _productB.DoSomthingB();
            }
        }

        public interface IFactory
        {
            IProductA CreateProductA();
            IProductB CreateProductB();
        }

        public interface IProductA
        {
            void DoSomthingA();
        }

        public interface IProductB
        {
            void DoSomthingB();
        }


        #region Concrete Red

        public class RedFactory : IFactory
        {
            public IProductA CreateProductA()
            {
                return new RedProductA();
            }

            public IProductB CreateProductB()
            {
                return new RedProductB();
            }
        }

        public class RedProductA : IProductA
        {
            public void DoSomthingA()
            {
                var tmp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(nameof(DoSomthingA));
                Console.ForegroundColor = tmp;
            }
        }

        public class RedProductB : IProductB
        {
            public void DoSomthingB()
            {
                var tmp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(nameof(DoSomthingB));
                Console.ForegroundColor = tmp;
            }
        }

        #endregion


        #region Concrete Green

        public class GreenFactory : IFactory
        {
            public IProductA CreateProductA()
            {
                return new GreenProductA();
            }

            public IProductB CreateProductB()
            {
                return new GreenProductB();
            }
        }

        public class GreenProductA : IProductA
        {
            public void DoSomthingA()
            {
                var tmp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(nameof(DoSomthingA));
                Console.ForegroundColor = tmp;
            }
        }

        public class GreenProductB : IProductB
        {
            public void DoSomthingB()
            {
                var tmp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(nameof(DoSomthingB));
                Console.ForegroundColor = tmp;
            }
        }

        #endregion

    }
}
