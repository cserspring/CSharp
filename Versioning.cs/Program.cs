using System;

namespace Versioning.cs
{
    // versioning.cs
    // CS0114 expected
    public class MyBase
    {
        public virtual string Meth1()
        {
            return "MyBase-Meth1";
        }
        public virtual string Meth2()
        {
            return "MyBase-Meth2";
        }
        public virtual string Meth3()
        {
            return "MyBase-Meth3";
        }

        public void F()
        {
            Console.WriteLine("MyBase:F()");
        }
    }

    class MyDerived : MyBase
    {
        // Overrides the virtual method Meth1 using the override keyword:
        public override string Meth1()
        {
            return "MyDerived-Meth1";
        }
        // Explicitly hide the virtual method Meth2 using the new
        // keyword:
        public new string Meth2()
        {
            return "MyDerived-Meth2";
        }
        // Because no keyword is specified in the following declaration
        // a warning will be issued to alert the programmer that 
        // the method hides the inherited member MyBase.Meth3():
        public string Meth3()
        {
            return "MyDerived-Meth3";
        }

        public void F()
        {
            Console.WriteLine("MyDerived:F()");
        }

        public static void Main()
        {
            MyDerived mD = new MyDerived();
            MyBase mB = mD;

            Console.WriteLine(mB.Meth1());
            Console.WriteLine(mB.Meth2());
            Console.WriteLine(mB.Meth3());
            mB.F();
            Console.ReadLine();
        }
    }
}
