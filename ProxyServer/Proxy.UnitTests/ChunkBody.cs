using System;

namespace Proxy.UnitTests
{
    internal interface State
    {
        void Feed(byte data, Action<State> changeState);
    }

    internal class NumberOrCrState : State
    {
        private ChunkBody body;

        public NumberOrCrState(ChunkBody body)
        {
            this.body = body;
        }

        public void Feed(byte data, Action<State> changeState)
        {
            if ('0' <= data && data <= '9')
            {
                body.OnLenght(data);
            }
            else if (data == '\r')
            {
                changeState(new NewLineState(body));
            }
            else
            {
                throw new Exception("Protocol violation");
            }
        }
    }

    internal class NewLineState : State
    {
        private ChunkBody body;

        public NewLineState(ChunkBody body)
        {
            this.body = body;
        }

        public void Feed(byte data, Action<State> changeState)
        {
            if (data == '\n')
            {
                changeState(new ContentState(body));
            }
            else
            {
                throw new Exception("Protocol violation");
            }
        }
    }

    internal class ContentState : State
    {
        private ChunkBody body;
        private int size;

        public ContentState(ChunkBody body)
        {
            this.body = body;
        }

        public void Feed(byte data, Action<State> changeState)
        {
            if (body.ExpectedLength == 0)
            {
                FeedComplete(data, changeState);
                return;
            }
            size += 1;
            if (size == body.ExpectedLength)
            {
            }
        }

        private void FeedComplete(byte data, Action<State> changeState)
        {
            changeState(new CompleteState(body));
        }
    }

    internal class CompleteState : State
    {
        private ChunkBody body;

        public CompleteState(ChunkBody body)
        {
            this.body = body;
            this.body.TriggerComplete();
        }

        public void Feed(byte data, Action<State> changeState)
        {
            // throw new Exception("Protocol violation");
        }
    }

    internal class ChunkBody
    {
        private string length;
        private State currentState;

        public ChunkBody()
        {
            currentState = new NumberOrCrState(this);
        }

        public int ExpectedLength
        {
            get
            {
                return int.Parse(length);
            }
        }

        public event Action OnComplete;

        public void Feed(byte[] data)
        {
            foreach (var item in data)
                currentState.Feed(item, ChangeState);
        }

        private void ChangeState(State nextState)
        {
            currentState = nextState;
        }

        internal void OnLenght(byte data)
        {
            length += (char)data;
        }

        internal void TriggerComplete()
        {
            OnComplete?.Invoke();
        }
    }
}