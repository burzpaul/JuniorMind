using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests
{
    public class Body : State
    {
        private Controller controller;

        public Body(Controller controller)
        {
            this.controller = controller;
        }

        internal override void Handle(byte data, Action<State> state)
        {
            throw new NotImplementedException();
        }
    }
}