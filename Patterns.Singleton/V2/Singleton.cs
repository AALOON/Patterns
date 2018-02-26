namespace Patterns.Singleton.V2
{
    /// <summary>
    /// Реализация шаблона простая
    /// </summary>
    public class Singleton
    {
        // Конструктор защищен
        protected Singleton() { }

        private static Singleton _instance = new Singleton();

        public static Singleton Instance => _instance;
    }
    
    /// <summary>
    /// Реализация шаблона простая с инициализацией в контрукторе типа
    /// </summary>
    public class Singleton2
    {
        // Конструктор защищен
        protected Singleton2() { }

        static Singleton2()
        {
            _instance = new Singleton2();
        }

        private static Singleton2 _instance;

        public static Singleton2 Instance => _instance;
    }
}
