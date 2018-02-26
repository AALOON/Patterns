using System;

namespace Patterns.Singleton.V5
{
    public sealed class Singleton
    {
        // Конструктор защищен
        private Singleton() { }

        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());
        
        public static Singleton Instance => _instance.Value;
    }
}
