using System;
using System.Reflection;

namespace Patterns.Singleton.V4
{
    /// <summary>
    /// Generic singleton потокобезопасный с отложенной инициализацией
    /// <typeparam name="T">Singleton class</typeparam>
    /// </summary>
    public class Singleton<T> where T : class//, new()
    {
        // Конструктор защищен
        protected Singleton() { }

        /// Фабрика используется для отложенной инициализации экземпляра класса
        private static class SingletonCreator<TS> where TS : class//, new()
        {
            static SingletonCreator()
            {
                //Используется Reflection для создания экземпляра класса без публичного конструктора
                InstanceCreator = (TS)typeof(TS).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], new ParameterModifier[0])?.Invoke(null);

                //Or if there public contructor just uncomment , new() and line bellow
                //InstanceCreator = new TS();
            }



            public static TS InstanceCreator { get; }
        }

        public static T Instance => SingletonCreator<T>.InstanceCreator;
    }

    /// Использование Singleton
    public sealed class TestSingleton : Singleton<TestSingleton>
    {
        /// Вызовет защищённый конструктор класса Singleton
        private TestSingleton() { }

        public string TestProc()
        {
            return "Hello World";
        }
    }
}
