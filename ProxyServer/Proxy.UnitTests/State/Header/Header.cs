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
            if (header.Get("Transfer-Encoding") == "chunked")
            {
                controller.ChangeState(new Chunk(controller));
            }
            else
            {
                controller.ChangeState(new Body(controller, header.Get("Content-Length")));
            }
            controller.OnHeaderComplete(true, header);
        }
    }
}