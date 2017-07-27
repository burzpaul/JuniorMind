using System;
using System.Text;

namespace Proxy
{
    public class Header : State
    {
        private State state;
        private ProxyState controller;
        private HeaderFields header;

        public Header(ProxyState controller)
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
            var a = Encoding.UTF8.GetString(new byte[] { data });
            header.AddChar((char)data);
        }

        public void OnHeaderComplete()
        {
            header.ProcessRawData();

            controller.OnHeaderComplete(true, header);

            if (header.ContainsKey("Transfer-Encoding"))
            {
                controller.ChangeState(new Chunk(controller));
            }
            else if (header.ContainsKey("Content-Length"))
            {
                controller.ChangeState(new Body(controller, header.Get("Content-Length")));
            }
            else
            {
                controller.ChangeState(null);
            }
        }
    }
}