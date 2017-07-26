﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.UnitTests
{
    public class Body : State
    {
        private Controller controller;
        private int length;
        private int counter;

        public Body(Controller controller, string contentLength)
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
                throw new Exception("Invalid Content-Length or Body");
            }
        }
    }
}