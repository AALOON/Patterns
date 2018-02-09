using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Composite
{
    /// <summary>
    /// Компоновщик (англ. Composite pattern) — структурный шаблон проектирования, 
    /// объединяющий объекты в древовидную структуру для представления иерархии от 
    /// частного к целому. Компоновщик позволяет клиентам обращаться к отдельным 
    /// объектам и к группам объектов одинаково.
    /// 
    /// https://ru.wikipedia.org/wiki/%D0%9A%D0%BE%D0%BC%D0%BF%D0%BE%D0%BD%D0%BE%D0%B2%D1%89%D0%B8%D0%BA_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
    /// 
    /// Паттерн определяет иерархию классов, которые одновременно могут состоять 
    /// из примитивных и сложных объектов, упрощает архитектуру клиента, делает 
    /// процесс добавления новых видов объекта более простым.
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create a tree structure
            IComposite root = new Composite("Root");

            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            #region < Sub Composite X >
            IComposite comp = new Composite("Composite X");

            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            //Adding SubComposite to Root
            root.Add(comp);
            #endregion

            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf
            IComponent leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(1);

            // Wait for user
            Console.Read();
        }
    }

    #region < Interfaces >

    interface IComponent
    {
        void Display(int depth);
    }

    interface IComposite : IComponent
    {
        void Add(IComponent component);
        void Remove(IComponent component);
    }

    #endregion

    /// <summary>
    /// Component - компонент
    /// </summary>
    /// <li>
    /// <lu>объявляет интерфейс для компонуемых объектов;</lu>
    /// <lu>предоставляет подходящую реализацию операций по умолчанию,
    /// общую для всех классов;</lu>
    /// <lu>объявляет интерфейс для доступа к потомкам и управлению ими;</lu>
    /// <lu>определяет интерфейс доступа к родителю компонента в рекурсивной структуре
    /// и при необходимости реализует его. Описанная возможность необязательна;</lu>
    /// </li>
    abstract class Component : IComponent
    {
        protected string Name;

        // Constructor
        protected Component(string name)
        {
            Name = name;
        }

        public abstract void Display(int depth);
    }

    /// <summary>
    /// Composite - составной объект
    /// </summary>
    /// <li>
    /// <lu>определяет поведеление компонентов, у которых есть потомки;</lu>
    /// <lu>хранит компоненты-потомоки;</lu>
    /// <lu>реализует относящиеся к управлению потомками операции и интерфейсе
    /// класса <see cref="Component"/></lu>
    /// </li>
    class Composite : Component, IComposite
    {
        private readonly List<IComponent> _children = new List<IComponent>();

        // Constructor
        public Composite(string name) : base(name)
        {
        }

        public void Add(IComponent component)
        {
            _children.Add(component);
        }

        public void Remove(IComponent component)
        {
            _children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + Name);

            // Recursively display child nodes
            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }

    /// <summary>
    /// Leaf - лист
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>представляет листовой узел композиции и не имеет потомков;</lu>
    /// <lu>определяет поведение примитивных объектов в композиции;</lu>
    /// </li>
    /// </remarks>
    class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + Name);
        }
    }
}
