using System;
using System.Diagnostics;
using MvvmCross.Platform.Platform;

namespace ShapeTest.Wpf
{
    public class DebugTrace : IMvxTrace
    {
        public void Trace(MvxTraceLevel level, string tag, Func<string> message)
        {
            Debug.WriteLine($"{tag}:{level}:{message()}");
        }

        public void Trace(MvxTraceLevel level, string tag, string message)
        {
            Debug.WriteLine($"{tag}:{level}:{message}");
        }

        public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
        {
            Debug.WriteLine(tag + ":" + level + ":" + message, args);
        }
    }
}
