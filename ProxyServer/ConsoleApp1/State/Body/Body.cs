﻿using System;

namespace Proxy
{
    public class Body : State
    {
        private ProxyState controller;
        private int length;
        private int counter;

        public Body(ProxyState controller, string contentLength)
        {
            this.controller = controller;
            length = int.Parse(contentLength);
        }

        internal override void Handle(byte data, Action<State> state)
        {
            if (data != '\0')
            {
                counter++;
                if (counter == length)
                {
                    controller.OnBodyComplete();
                }
            }
            else
            {
                throw new Exception("Invalid Content-Length.");
            }
        }
    }
}