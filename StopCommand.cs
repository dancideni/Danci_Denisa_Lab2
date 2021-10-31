using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Danci_Denisa_Lab2.CustomCommands
{
    class StopCommand
    {
        static StopCommand()
        {
            InputGestureCollection myInputGestures = new InputGestureCollection();
            myInputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            Launch = new RoutedUICommand("Launch", "Launch", typeof(StopCommand), myInputGestures);
        }
        public static RoutedUICommand Launch { get; private set; }
    }
}
