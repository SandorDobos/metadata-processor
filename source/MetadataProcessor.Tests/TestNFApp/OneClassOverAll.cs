﻿using System;
using System.Text;

namespace TestNFApp
{
    [DummyCustomAttribute1]
    [DummyCustomAttribute2]
    public class OneClassOverAll : IOneClassOverAll
    {
        [DummyCustomAttribute1]
        [DummyCustomAttribute2]
        public int DummyProperty { get; set; }

        [DummyCustomAttribute1]
        [DummyCustomAttribute2]
        private string dummyField = "dummy";

        [DummyCustomAttribute1]
        [DummyCustomAttribute2]
        public void DummyMethod()
        {
            dummyField = "just keeping compiler happy";
        }

        public static void DummyStaticMethod()
        { }

        public void DummyMethodWithParams(int p1, string p2)
        {
            var tmp = dummyField;
            dummyField = tmp;
        }

        public static void DummyStaticMethodWithParams(long p3, DateTime p4)
        { }

        // warning CS0626: Method, operator, or accessor 'OneClassOverAll.DummyExternMethod()' is marked external and has no attributes on it.
#pragma warning disable CS0626
        public extern void DummyExternMethod();
#pragma warning restore CS0626
    }


}