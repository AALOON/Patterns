using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    /// <summary>
    /// Декоратор (англ. Decorator) — структурный шаблон проектирования, предназначенный
    /// для динамического подключения дополнительного поведения к объекту. Шаблон 
    /// Декоратор предоставляет гибкую альтернативу практике создания подклассов с целью 
    /// расширения функциональности.
    /// 
    /// https://ru.wikipedia.org/wiki/%D0%94%D0%B5%D0%BA%D0%BE%D1%80%D0%B0%D1%82%D0%BE%D1%80_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
    /// 
    /// Драйверы-фильтры в ядре Windows (архитектура WDM (Windows Driver Model)) 
    /// представляют собой декораторы. Несмотря на то, что WDM реализована на 
    /// не-объектном языке Си, в ней четко прослеживаются паттерны проектирования — 
    /// декоратор, цепочка обязанностей, и команда (объект IRP).
    /// 
    /// Архитектура COM (Component Object Model) не поддерживает наследование реализаций, вместо него предлагается использовать декораторы (в данной архитектуре это называется «агрегация»). При этом архитектура решает (с помощью механизма pUnkOuter) проблему object identity, возникающую при использовании декораторов — identity агрегата есть identity его самого внешнего декоратора.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create ConcreteComponent and two Decorators
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA dA = new ConcreteDecoratorA();
            ConcreteDecoratorB dB = new ConcreteDecoratorB();

            // Link decorators
            dA.SetComponent(c);
            dB.SetComponent(dA);

            dA.Operation();

            Console.WriteLine();

            dB.Operation();

            // Wait for user
            Console.Read();
        }

        /// <summary>
        /// Component - компонент
        /// </summary>
        /// <remarks>
        /// <li>
        /// <lu>определяем интерфейс для объектов, на которые могут быть динамически 
        /// возложены дополнительные обязанности;</lu>
        /// </li>
        /// </remarks>
        abstract class Component
        {
            public abstract void Operation();
        }

        /// <summary>
        /// ConcreteComponent - конкретный компонент
        /// </summary>
        /// <remarks>
        /// <li>
        /// <lu>определяет объект, на который возлагается дополнительные обязанности</lu>
        /// </li>
        /// </remarks>
        class ConcreteComponent : Component
        {
            public override void Operation()
            {
                Console.Write("Привет");
            }
        }

        /// <summary>
        /// Decorator - декоратор
        /// </summary>
        /// <remarks>
        /// <li>
        /// <lu>хранит ссылку на объект <see cref="Component"/> и определяет интерфейс,
        /// соответствующий интерфейсу <see cref="Component"/></lu>
        /// </li>
        /// </remarks>
        abstract class Decorator : Component
        {
            protected Component Component;

            public void SetComponent(Component component)
            {
                this.Component = component;
            }

            public override void Operation()
            {
                Component?.Operation();
            }
        }

        /// <summary>
        /// ConcreteDecoratorA - конкретный декоратор
        /// </summary>
        /// <remarks>
        /// <li>
        /// <lu>Выполняет основную задачу</lu>
        /// </li>
        /// </remarks>
        class ConcreteDecoratorA : Decorator
        {
            public override void Operation()
            {
                base.Operation();
            }
        }

        /// <summary>
        /// ConcreteDecorator - конкретный декоратор
        /// </summary>
        /// <remarks>
        /// <li>
        /// <lu>Выполняет основную задачу + дополнительную</lu>
        /// </li>
        /// </remarks>
        class ConcreteDecoratorB : Decorator
        {
            public override void Operation()
            {
                base.Operation();

                Console.Write(" Мир!");
            }
        }
    }
}
