using System;
using System.Collections.Generic;

namespace Patterns.FactoryMethod
{
    /// <summary>
    /// Фабричный метод (англ. Factory Method также известен как Виртуальный конструктор 
    /// (англ. Virtual Constructor)) — порождающий шаблон проектирования, предоставляющий 
    /// подклассам интерфейс для создания экземпляров некоторого класса. В момент создания 
    /// наследники могут определить, какой класс создавать. Иными словами, данный шаблон 
    /// делегирует создание объектов наследникам родительского класса. Это позволяет 
    /// использовать в коде программы не специфические классы, а манипулировать абстрактными 
    /// объектами на более высоком уровне.
    /// 
    /// https://ru.wikipedia.org/wiki/%D0%A4%D0%B0%D0%B1%D1%80%D0%B8%D1%87%D0%BD%D1%8B%D0%B9_%D0%BC%D0%B5%D1%82%D0%BE%D0%B4_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
    /// 
    /// Определяет интерфейс для создания объекта, но оставляет подклассам решение о том, 
    /// какой класс инстанцировать. Фабричный метод позволяет классу делегировать создание 
    /// подклассов. Используется, когда:
    /// - классу заранее неизвестно, объекты каких подклассов ему нужно создавать.
    /// - класс спроектирован так, чтобы объекты, которые он создаёт, специфицировались 
    /// подклассами.
    /// - класс делегирует свои обязанности одному из нескольких вспомогательных подклассов, 
    /// и планируется локализовать знание о том, какой класс принимает эти обязанности на себя
    /// 
    /// Pros: 
    /// - позволяет сделать код создания объектов более универсальным, не привязываясь к 
    /// конкретным классам (ConcreteProduct), а оперируя лишь общим интерфейсом (Product);
    /// - позволяет установить связь между параллельными иерархиями классов.
    /// 
    /// Cons:
    /// необходимость создавать наследника Creator для каждого нового типа продукта (ConcreteProduct).
    /// </summary>
    class Program
    {
        static void Main()
        {
            var creators = new List<ICreator>
            {
                new KeyboardCreator(),
                new MouseCreator()
            };

            foreach (var creator in creators)
            {
                creator.SetColor("Black");
                var product = creator.FactoryMethod();
                product.PrintInfo();
                Console.WriteLine();
                
                creator.SetColor("Blue");
                product = creator.FactoryMethod();
                product.PrintInfo();
                Console.WriteLine();
                
                creator.SetColor("Gray");
                product = creator.FactoryMethod();
                product.PrintInfo();
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Product 
        /// определяет интерфейс объектов, создаваемых абстрактным методом;
        /// </summary>
        interface IProduct
        {
            void PrintInfo();
        }

        abstract class Product : IProduct
        {
            protected Product()
            {
                Id = Guid.NewGuid();
            }

            protected Guid Id { get; }

            public abstract void PrintInfo();
        }

        /// <summary>
        /// ConcreteProduct 
        /// </summary>
        class MouseProduct : Product
        {
            private readonly string _color;
            public MouseProduct(string color = "Black")
            {
                _color = color;
            }
            public override void PrintInfo()
            {
                Console.WriteLine($"{nameof(MouseProduct)}:{Id}, {_color}");
            }
        }

        /// <summary>
        /// ConcreteProduct 
        /// </summary>
        class KeyboardProduct : Product
        {
            public override void PrintInfo()
            {
                Console.WriteLine($"{nameof(MouseProduct)}:{Id}, Gray");
            }
        }

        /// <summary>
        /// Creator 
        /// </summary>
        interface ICreator
        {
            IProduct FactoryMethod();

            void SetColor(string color);
        }

        abstract class Creator : ICreator
        {
            protected string Color { get; private set; }

            public abstract IProduct FactoryMethod();

            public void SetColor(string color)
            {
                Color = color;
            }
        }

        class MouseCreator : Creator
        {
            public override IProduct FactoryMethod()
            {
                return new MouseProduct(Color);
            }
        }

        class KeyboardCreator : Creator
        {
            public override IProduct FactoryMethod()
            {
                return new KeyboardProduct();
            }
        }
    }
}
