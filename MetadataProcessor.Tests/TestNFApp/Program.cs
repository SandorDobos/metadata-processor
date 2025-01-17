﻿using System.Diagnostics;
using TestNFClassLibrary;

namespace TestNFApp
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Starting TestNFApp");

            // instantiating a class on another assembly
            ClassOnAnotherAssembly anotherClass = new ClassOnAnotherAssembly();

            // accessing property on class
            var dummyMirror1 = anotherClass.DummyProperty;

            // instantiating a class on another assembly with a constructor parameter
            anotherClass = new ClassOnAnotherAssembly(99);

            // accessing property on class
            dummyMirror1 = anotherClass.DummyProperty;

            Debug.WriteLine("Exiting TestNFApp");
        }
    }
}
