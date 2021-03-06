﻿using System;

namespace Patterns.Command
{
    /// <summary>
    /// Команда (англ. Command) — поведенческий шаблон проектирования, используемый 
    /// при объектно-ориентированном программировании, представляющий действие. 
    /// Объект команды заключает в себе само действие и его параметры.
    /// 
    /// <see href="https://ru.wikipedia.org/wiki/%D0%9A%D0%BE%D0%BC%D0%B0%D0%BD%D0%B4%D0%B0_(%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD_%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F)">Link</see>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorExample.CalculatorExample.Run();

            Console.WriteLine();

            SwitchExample.SwitchExample.Run();

            Console.Read();
        }
    }

}
