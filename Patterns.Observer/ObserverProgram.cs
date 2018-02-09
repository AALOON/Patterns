using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.Observer
{
    /// <summary>
    /// Наблюдатель (англ. Observer) — поведенческий шаблон проектирования. 
    /// Также известен как «подчинённые» (Dependents). Создает механизм у класса, 
    /// который позволяет получать экземпляру объекта этого класса оповещения от 
    /// других объектов об изменении их состояния, тем самым наблюдая за ними.
    /// https://ru.wikipedia.org/wiki/%D0%9D%D0%B0%D0%B1%D0%BB%D1%8E%D0%B4%D0%B0%D1%82%D0%B5%D0%BB%D1%8C_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
    /// 
    /// The Subject runs in a thread and changes its state
    /// independently. At each change, it notifies its Observers.
    /// </summary>
    class ObserverProgram
    {
        static void Main(string[] args)
        {
            ObservableSubject observableSubject = new ObservableSubject();
            Observer observer = new Observer(observableSubject, "Left", "");
            Observer observer2 = new Observer(observableSubject, "Center", "\t\t");
            Observer observer3 = new Observer(observableSubject, "Right", "\t\t\t\t");
            observableSubject.Go();

            // Wait for user
            Console.Read();
        }

    }

    class Simulator : IEnumerable
    {
        private readonly string[] _moves;

        public Simulator()
        {
            var random = new Random();
            _moves = new string[random.Next(4, 10)];
            for (var i = 0; i < _moves.Length; i++)
            {
                _moves[i] = random.Next(1, 10).ToString();
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var element in _moves)
                yield return element;
        }
    }

    interface IObservableSubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(string s);
    }

    class ObservableSubject : IObservableSubject
    {
        public string SubjectState { get; set; }
        public List<IObserver> Observers { get; private set; }

        private readonly Simulator _simulator;

        private const int Speed = 200;

        public ObservableSubject()
        {
            Observers = new List<IObserver>();
            _simulator = new Simulator();
        }

        public void AddObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void NotifyObservers(string s)
        {
            Console.WriteLine("****************************************");
            foreach (var observer in Observers)
            {
                observer.Update(s);
            }
            Console.WriteLine("****************************************");
        }

        public void Go()
        {
            new Thread(Run).Start();
        }

        void Run()
        {
            foreach (string s in _simulator)
            {
                Console.WriteLine("******* \tSubject: " + s + " \t********");
                SubjectState = s;
                NotifyObservers(s);
                Thread.Sleep(Speed); // milliseconds
            }
        }
    }

    interface IObserver
    {
        void Update(string state);
    }

    class Observer : IObserver, IDisposable
    {
        private bool _disposed = false;

        readonly string _name;

        readonly IObservableSubject _observableSubject;

        string _state;

        readonly string _gap;

        public Observer(IObservableSubject observableSubject, string name, string gap)
        {
            _observableSubject = observableSubject;
            _name = name;
            _gap = gap;
            observableSubject.AddObserver(this);
        }

        public void Update(string subjectState)
        {
            _state = subjectState;
            Console.WriteLine(_gap + _name + ": " + _state);
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">true in case of calling IDisposable.Dispose(),false in case of destructor</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                _observableSubject.RemoveObserver(this);

                _disposed = true;
            }
        }

        ~Observer()
        {
            Dispose(false);
        }

        #endregion

    }
}
