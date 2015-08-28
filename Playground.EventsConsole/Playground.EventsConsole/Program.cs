using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.EventsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container("Container to be killed");
            var containerService = new ContainerListener();
            containerService.Register(container);
            Console.Write(container.Name);
            container.Kill("pillow");
            Console.ReadLine();
        }
    }

    public class CustomEvenArgs : EventArgs
    {
        public string Description { get; private set; }

        public CustomEvenArgs(string description)
        {
            this.Description = description;
        }
    }

    public class ContainerListener
    {
        public void Register(Container container)
        {
            container.ChangedName += Container_ChangedName;
        }

        private void Container_ChangedName(object sender, CustomEvenArgs e)
        {
            Console.Write("The event was raised");
            Console.Write(e.Description);
        }
    }

    public class Container
    {
        public string Name { get; private set; }

        public Guid Id { get; private set; }

        public event EventHandler<CustomEvenArgs> ChangedName;

        private bool _isDead;

        public Container(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public void Kill(string weapon)
        {
            this._isDead = true;
            ChangedName.Invoke(this, new CustomEvenArgs($"The container has been killed with a {weapon}"));
        }
    }
}
