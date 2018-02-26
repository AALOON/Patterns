namespace Patterns.Singleton.V3
{
    /// <summary>
    /// Стандартный потокобезопасный вариант c отложенной инициализацией
    /// </summary>
    public class Singleton
    {
        // Конструктор защищен
        protected Singleton() { }

        private sealed class SingletonCreator
        {
            private static readonly Singleton _instance = new Singleton();
            public static Singleton Instance => _instance;
        }

        public static Singleton Instance => SingletonCreator.Instance;
    }
}
