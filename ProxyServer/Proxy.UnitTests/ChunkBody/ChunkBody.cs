using System;

namespace Proxy.UnitTests
{
    internal class ChunkBody
    {
        private string length;
        private IState currentState;

        public event Action OnComplete;

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

        public void Feed(byte[] data)
        {
            foreach (var item in data)
            {
                currentState.Feed(item, ChangeState);
            }
        }

        private void ChangeState(IState nextState)
        {
            currentState = nextState;
        }

        internal void OnLength(byte data)
        {
            length += (char)data;
        }

        internal void TriggerComplete()
        {
            currentState = null;
            OnComplete?.Invoke();
        }
    }
}