using System;

namespace Patterns.Command.SwitchExample
{
    public static class SwitchExample
    {
        public static void Run()
        {
            var ligth = new Light();
            var turnOn = new TurnOnLightCommand(ligth);
            var turnOff = new TurnOffLigthCommand(ligth);
            var sw = new Switch(turnOn, turnOff);

            sw.FlipUp();
            sw.FlipDown();
            sw.FlipDown();
            sw.FlipUp();
            sw.FlipDown();
        }
    }

    /// <summary>
    /// Command
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }

    /// <summary>
    /// Invoker
    /// </summary>
    public class Switch
    {
        private readonly ICommand _flipUpCommand;
        private readonly ICommand _flipDownCommand;
        private bool _isUp = false;

        public Switch(ICommand flipUpCommand, ICommand flipDownCommand)
        {
            _flipUpCommand = flipUpCommand;
            _flipDownCommand = flipDownCommand;
        }

        public void FlipUp()
        {
            if (_isUp) return;

            _flipUpCommand.Execute();
            _isUp = !_isUp;
        }

        public void FlipDown()
        {
            if (!_isUp) return;

            _flipDownCommand.Execute();
            _isUp = !_isUp;
        }

        public bool IsUp => _isUp;
    }

    /// <summary>
    /// Receiver
    /// </summary>
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("The light is on!");
        }

        public void TurnOff()
        {
            Console.WriteLine("The light is off!");
        }
    }

    public abstract class LightCommand : ICommand
    {
        protected Light LightInstance { get; }

        protected LightCommand(Light light)
        {
            LightInstance = light;
        }

        public abstract void Execute();
    }

    public class TurnOnLightCommand : LightCommand
    {
        public TurnOnLightCommand(Light light) : base(light)
        {
        }

        public override void Execute()
        {
            LightInstance.TurnOn();
        }
    }

    public class TurnOffLigthCommand : LightCommand
    {
        public TurnOffLigthCommand(Light light) : base(light)
        {
        }

        public override void Execute()
        {
            LightInstance.TurnOff();
        }
    }

}
