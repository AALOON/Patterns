using System;
using System.Collections.Generic;

namespace Patterns.Command.CalculatorExample
{

    public static class CalculatorExample
    {
        public static void Run()
        {
            // Создаем пользователя.
            var user = new UserInvoker();

            // Пользователь он что-нибудь сделает.
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Отменяем 4 команды
            user.Undo(4);

            // Вернём 3 отменённые команды.
            user.Redo(3);
        }
    }

    /// <summary>
    /// "Command" : абстрактная Команда
    /// </summary>
    abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }


    /// <summary>
    /// "ConcreteCommand" : конкретная команда
    /// </summary>
    class CalculatorCommand : Command
    {
        char _operator;
        int _operand;
        readonly CalculatorReceiver _calculatorReceiver;

        public CalculatorCommand(CalculatorReceiver calculatorReceiver, char operatorChar, int operand)
        {
            _calculatorReceiver = calculatorReceiver;
            _operator = operatorChar;
            _operand = operand;
        }

        public char Operator
        {
            set => _operator = value;
        }

        public int Operand
        {
            set => _operand = value;
        }

        public override void Execute()
        {
            _calculatorReceiver.Operation(_operator, _operand);
        }

        public override void UnExecute()
        {
            _calculatorReceiver.Operation(Undo(_operator), _operand);
        }

        private char Undo(char operatorChar)
        {
            char undo;
            switch (operatorChar)
            {
                case '+': undo = '-'; break;
                case '-': undo = '+'; break;
                case '*': undo = '/'; break;
                case '/': undo = '*'; break;
                default: undo = ' '; break;
            }
            return undo;
        }
    }

    /// <summary>
    /// "Receiver" : получатель
    /// </summary>
    class CalculatorReceiver
    {
        private int _curr;

        public void Operation(char operatorChar, int operand)
        {
            switch (operatorChar)
            {
                case '+': _curr += operand; break;
                case '-': _curr -= operand; break;
                case '*': _curr *= operand; break;
                case '/': _curr /= operand; break;
            }
            Console.WriteLine("Current value = {0,3} (following {1} {2})", _curr, operatorChar, operand);
        }
    }


    /// <summary>
    /// "Invoker" : вызывающий
    /// </summary>
    class UserInvoker
    {
        private readonly CalculatorReceiver _calculatorReceiver = new CalculatorReceiver();
        private readonly List<Command> _commandsHistory = new List<Command>();

        private int _current;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);

            // Делаем возврат операций
            for (var i = 0; i < levels; i++)
                if (_current < _commandsHistory.Count)
                    _commandsHistory[_current++].Execute();
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);

            // Делаем отмену операций
            for (var i = 0; i < levels; i++)
                if (_current > 0)
                    _commandsHistory[--_current].UnExecute();
        }

        public void Compute(char operatorChar, int operand)
        {
            // Создаем команду операции и выполняем её
            Command command = new CalculatorCommand(_calculatorReceiver, operatorChar, operand);
            command.Execute();

            if (_current < _commandsHistory.Count)
            {
                // если "внутри undo" мы запускаем новую операцию, 
                // надо обрубать список команд, следующих после текущей, 
                // иначе undo/redo будут некорректны
                _commandsHistory.RemoveRange(_current, _commandsHistory.Count - _current);
            }

            // Добавляем операцию к списку отмены
            _commandsHistory.Add(command);
            _current++;
        }
    }
}
