using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Web01.Domain
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Messenger
    {

        public string TheMessage { get; set; }

        public Messenger()
        {
            this.TheMessage = "The message from the library";
        }
    }
}