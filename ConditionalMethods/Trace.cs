namespace ConditionalMethods
{
    using System;
    using System.Diagnostics;

    class Trace
    {
        [Conditional("DEBUG")]
        public static void Message(string traceMessage)
        {
            Console.WriteLine("[TRACE] - " + traceMessage);
        }
    }
}
