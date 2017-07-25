using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Proxy
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

        public void ProcessHeader(byte[] data, int size)
        {
            for (int i = 0; i < size; i++)
            {
                state.Handle(data[i], ChangeState);
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