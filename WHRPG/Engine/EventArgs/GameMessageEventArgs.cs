using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.EventArgs
{
    //System is standard event args. We're creating our own custom to add things.
    public class GameMessageEventArgs : System.EventArgs
    {
        public string Message { get; private set; }

        //When create an EventArgs objects we're going to pass in the message we want displayed
        //which will set that parameter value to the property
        public GameMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
