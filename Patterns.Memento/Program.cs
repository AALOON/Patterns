using System;

namespace Patterns.Memento
{
    /// <summary>
    /// Хранитель (англ. Memento) — поведенческий шаблон проектирования, позволяющий, 
    /// не нарушая инкапсуляцию, зафиксировать и сохранить внутреннее состояние объекта 
    /// так, чтобы позднее восстановить его в это состояние.
    /// 
    /// https://ru.wikipedia.org/wiki/%D0%A5%D1%80%D0%B0%D0%BD%D0%B8%D1%82%D0%B5%D0%BB%D1%8C_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Originator o = new Originator();
            o.State = "On";

            // Store internal state
            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMemento(c.Memento);

            // Wait for user
            Console.ReadKey();
        }

        /// <summary>
        /// The 'Originator' - 'Создатель' class
        /// </summary>
        class Originator
        {
            private string _state;
            
            public string State
            {
                get => _state;
                set
                {
                    _state = value;
                    Console.WriteLine("State = " + _state);
                }
            }

            // Creates memento
            public Memento CreateMemento()
            {
                return (new Memento(_state));
            }

            // Restores original state
            public void SetMemento(Memento memento)
            {
                Console.WriteLine("Restoring state...");
                State = memento.State;
            }
        }

        /// <summary>
        /// The 'Memento' - 'Хранитель' class
        /// </summary>
        class Memento
        {
            private string _state;

            // Constructor
            public Memento(string state)
            {
                this._state = state;
            }

            // Gets or sets state
            public string State => _state;
        }

        /// <summary>
        /// The 'Caretaker' - 'Опекун' class
        /// </summary>
        class Caretaker
        {
            private Memento _memento;

            // Gets or sets memento
            public Memento Memento
            {
                get => _memento;
                set => _memento = value;
            }
        }
    }
}
