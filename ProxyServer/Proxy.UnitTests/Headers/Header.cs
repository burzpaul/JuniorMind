using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Proxy.UnitTests.Headers
{
    public class Header
    {
        private HeaderState state;
        private HeaderFields header = new HeaderFields();

        public event EventHandler<HeaderCompleteEventArgs> HeaderCompleted;

        public Header()
        {
            state = new FieldState(this);
        }

        public void ProcessHeader(byte[] data)
        {
            foreach (var item in data)
            {
                state.Handle(item, ChangeState);
            }
        }

        public void ChangeState(HeaderState state)
        {
            this.state = state;
        }

        public void HeaderChar(byte data)
        {
            header.AddField((char)data);
        }

        public void OnHeaderComplete()
        {
            header.ProcessRawData();
            HeaderCompleted?.Invoke(this, new HeaderCompleteEventArgs() { IsComplete = true, HeaderFields = header });
        }
    }
}