﻿using System;

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

        public static int DummyStaticMethodWithRetval()
        {
            return 2;
        }

        public void DummyMethodWithParams(int p1, string p2)
        {
            var tmp = dummyField;
            dummyField = tmp;
        }

        public int DummyMethodWithRetval()
        {
            dummyField = "just keeping compiler happy";
            return 2;
        }


        public static void DummyStaticMethodWithParams(long p3, DateTime p4)
        { }

        // warning CS0626: Method, operator, or accessor 'OneClassOverAll.DummyExternMethod()' is marked external and has no attributes on it.
#pragma warning disable CS0626
        public extern void DummyExternMethod();
#pragma warning restore CS0626

        public void DummyMethodWithUglyParams(ref int p5, byte[] p6, OneClassOverAll p7, OneClassOverAll[] p8, DateTime p9, double p10, ref OneClassOverAll p11, out OneClassOverAll p12, out long p13)
        {
            p12 = null;
            p13 = 0;
        }

        public int UglyAdd(int left, int right)
        {
            int ret = 0;
            
            try
            {
                ret = left + right;
            }
            catch (Exception ex)
            {
                var wrapperException = new ApplicationException("blabla", ex);

                // hehe
                ret = wrapperException.GetHashCode();
            }

            return ret;
        }

        public class SubClass
        { }

        public OneClassOverAll()
        {
        }

        public OneClassOverAll(int p1, int p2)
        {
        }

        public OneClassOverAll(int p1, int p2, int p3)
        {
        }
    }

}
