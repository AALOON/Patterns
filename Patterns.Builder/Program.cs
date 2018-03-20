using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Builder
{
    /// <summary>
    /// Строитель (англ. Builder) — порождающий шаблон проектирования предоставляет 
    /// способ создания составного объекта.
    /// 
    /// https://ru.wikipedia.org/wiki/%D0%A1%D1%82%D1%80%D0%BE%D0%B8%D1%82%D0%B5%D0%BB%D1%8C_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
    /// 
    /// Отделяет конструирование сложного объекта от его представления так, что в 
    /// результате одного и того же процесса конструирования могут получаться разные представления.
    /// 
    /// Pros:
    /// позволяет изменять внутреннее представление продукта;
    /// изолирует код, реализующий конструирование и представление;
    /// дает более тонкий контроль над процессом конструирования.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var director = new Director();
            var pcBuilder = new PcBuilder();
            var notebookBuilder = new NotebookBuilder();

            director.Construct(pcBuilder);
            var pc = pcBuilder.GetProduct();

            director.Construct(notebookBuilder);
            var notebook = notebookBuilder.GetProduct();


            pc.Show();
            notebook.Show();

            Console.ReadKey();
        }

        /// <summary>
        /// Director - is class wich is setups basic steps of any builder
        /// </summary>
        class Director
        {
            public void Construct(IBuilder builder)
            {
                builder.SetupName(Guid.NewGuid().ToString());
                builder.BuildStage1();
                builder.BuildStage2();
                builder.BuildStage3();
            }
        }

        /// <summary>
        /// Builder interface
        /// </summary>
        interface IBuilder
        {
            void SetupName(string name);
            void BuildStage1();
            void BuildStage2();
            void BuildStage3();

            IProduct GetProduct();
        }

        /// <summary>
        /// Abstract builder of Product
        /// </summary>
        abstract class Builder : IBuilder
        {
            protected readonly Product Product = new Product();
            public abstract void SetupName(string name);
            public abstract void BuildStage1();
            public abstract void BuildStage2();
            public abstract void BuildStage3();

            public virtual IProduct GetProduct()
            {
                return Product;
            }
        }

        /// <summary>
        /// Builder which is builds PC product
        /// </summary>
        class PcBuilder : Builder
        {
            public override void SetupName(string name)
            {
                Product.Name = "PC-" + name;
            }

            public override void BuildStage1()
            {
                Product.Add("MotherBoard");
                Product.Add("CPU");
                Product.Add("Cooler");
                Product.Add("RAM");
                Product.Add("Power supply");
            }

            public override void BuildStage2()
            {
                Product.Add("\tSystem Unit");
            }

            public override void BuildStage3()
            {
                Product.Add("\t\tMonitor");
                Product.Add("\t\tCabels");
            }
        }

        /// <summary>
        /// Builder which is builds Notebook product
        /// </summary>
        class NotebookBuilder : Builder
        {
            public override void SetupName(string name)
            {
                Product.Name = "Notebook-" + name;
            }

            public override void BuildStage1()
            {
                Product.Add("MotherBoardSlim");
                Product.Add("CPULow");
                Product.Add("Cooler");
                Product.Add("RAM");
            }

            public override void BuildStage2()
            {
                Product.Add("\tLaptop case");
            }

            public override void BuildStage3()
            {
                Product.Add("\t\tPortable Power supply");
            }
        }

        /// <summary>
        /// Abstaction of product
        /// </summary>
        interface IProduct
        {
            void Show();
            void Add(string part);
        }

        /// <summary>
        /// Product
        /// </summary>
        class Product : IProduct
        {
            private readonly List<string> _parts = new List<string>();

            public void Add(string part)
            {
                _parts.Add(part);
            }

            public string Name { get; set; }

            public void Show()
            {
                Console.WriteLine(ToString());
                Console.WriteLine();
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Product Parts of ");
                sb.Append(Name);
                sb.Append(":\n");
                foreach (var part in _parts)
                    sb.AppendLine(part);

                return sb.ToString();
            }
        }
    }
}
