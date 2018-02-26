namespace Patterns.Singleton.V1
{
    /// <summary>
    /// Реализация шаблона с лениновй инициализацей
    /// </summary>
    public class Singleton
    {
        // Конструктор защищен
        protected Singleton() { }

        private static Singleton _instance;

        public static Singleton Instance => _instance ?? (_instance = new Singleton());
    }
}
