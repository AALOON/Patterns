﻿namespace Patterns.Singleton
{
    /// <summary>
    /// Одиночка (англ. Singleton) — порождающий шаблон проектирования, гарантирующий, что 
    /// в однопроцессном приложении будет единственный экземпляр некоторого класса, и 
    /// предоставляющий глобальную точку доступа к этому экземпляру.
    /// 
    /// https://ru.wikipedia.org/wiki/%D0%9E%D0%B4%D0%B8%D0%BD%D0%BE%D1%87%D0%BA%D0%B0_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)
    /// 
    /// У класса есть только один экземпляр, и он предоставляет к нему глобальную точку доступа. 
    /// Существенно то, что можно пользоваться именно экземпляром класса, так как при этом во многих 
    /// случаях становится доступной более широкая функциональность. Например, к описанным компонентам 
    /// класса можно обращаться через интерфейс, если такая возможность поддерживается языком.
    /// Глобальный «одинокий» объект — именно объект, а не набор процедур, не привязанных ни к какому 
    /// объекту — бывает нужен:
    /// 
    /// если используется существующая объектно-ориентированная библиотека;
    /// если есть шансы, что один объект когда-нибудь превратится в несколько;
    /// если интерфейс объекта(например, игрового мира) слишком сложен и не стоит засорять основное 
    /// пространство имён большим количеством функций;
    /// если, в зависимости от каких-нибудь условий и настроек, создаётся один из нескольких объектов. 
    /// Например, в зависимости от того, ведётся лог или нет, создаётся или настоящий объект, пишущий в файл, 
    /// или «заглушка», ничего не делающая.
    /// Такие объекты можно создавать и при инициализации программы. Это может приводить к следующим трудностям:
    /// 
    /// 
    /// Если объект нужен уже при инициализации, он может быть затребован раньше, чем будет создан.
    /// Бывает, что объект нужен не всегда.В таком случае его создание можно пропустить.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var v1Instance = V1.Singleton.Instance;
            var v2Instance = V2.Singleton.Instance;
            var v3Instance = V3.Singleton.Instance;
            var v4Instance = V4.TestSingleton.Instance;
            var v5Instance = V5.Singleton.Instance;

        }
    }
}
