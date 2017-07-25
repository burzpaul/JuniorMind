using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Proxy.UnitTests
{
    public class Header : State
    {
        private State state;
        private Controller controller;
        private HeaderFields header;

        public Header(Controller controller)
        {
            this.controller = controller;
            header = new HeaderFields();
            state = new HeaderFieldState(this);
        }

        internal override void Handle(byte data, Action<State> state)
        {
            this.state.Handle(data, ChangeState);
        }

        public void ChangeState(State state)
        {
            this.state = state;
        }

        public void OnHeaderChar(byte data)
        {
            header.AddChar((char)data);
        }

        public void OnHeaderComplete()
        {
            header.ProcessRawData();
            controller.OnHeaderComplete(true, header);
        }
    }
}