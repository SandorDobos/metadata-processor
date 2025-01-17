﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nanoFramework.Tools.MetadataProcessor.Core.Extensions;

namespace nanoFramework.Tools.MetadataProcessor.Tests.Core.Extensions
{
    [TestClass]
    public class ParameterDefintionExtensionsTests
    {
        [TestMethod]
        public void TypeToStringTest()
        {
            var assemblyDefinition = TestObjectHelper.GetTestNFAppAssemblyDefinition();
            var typeDefinition = TestObjectHelper.GetTestNFAppOneClassOverAllTypeDefinition(assemblyDefinition);
            var methodDefinition = TestObjectHelper.GetTestNFAppOneClassOverAllDummyMethodWithUglyParamsMethodDefinition(typeDefinition);

            var refIntParameterDefinition = methodDefinition.Parameters.First(i => i.Name == "p5");
            Assert.IsInstanceOfType(refIntParameterDefinition.ParameterType, typeof(Mono.Cecil.ByReferenceType));

            // test
            var r = refIntParameterDefinition.TypeToString();

            // TODO need to investigate if this is the correct pointer
            Assert.AreEqual(" *BYREF I4", r);

            var arrayParameterDefinition = methodDefinition.Parameters.First(i => i.Name == "p6");
            Assert.IsInstanceOfType(arrayParameterDefinition.ParameterType, typeof(Mono.Cecil.ArrayType));
            var arrayElementType = ((Mono.Cecil.ArrayType)arrayParameterDefinition.ParameterType).ElementType;
            Assert.AreEqual("Byte", arrayElementType.Name);

            // test
            r = arrayParameterDefinition.TypeToString();

            Assert.AreEqual($"CLR_RT_TypedArray_{arrayElementType.TypeSignatureAsString()}", r);


            var valueTypeParameterDefinition = methodDefinition.Parameters.First(i => i.Name == "p10");
            Assert.IsTrue(valueTypeParameterDefinition.ParameterType.IsValueType);
            Assert.AreEqual("Double", valueTypeParameterDefinition.ParameterType.Name);

            // test
            r = valueTypeParameterDefinition.TypeToString();

            Assert.AreEqual(valueTypeParameterDefinition.ParameterType.TypeSignatureAsString(), r);


            var dateTimeParameterDefinition = methodDefinition.Parameters.First(i => i.Name == "p9");
            Assert.IsTrue(dateTimeParameterDefinition.ParameterType.IsValueType);
            Assert.AreEqual("DateTime", dateTimeParameterDefinition.ParameterType.Name);

            // test
            r = dateTimeParameterDefinition.TypeToString();

            Assert.AreEqual(dateTimeParameterDefinition.ParameterType.Resolve().TypeSignatureAsString(), r);


            var classParameterDefinition = methodDefinition.Parameters.First(i => i.Name == "p7");
            Assert.AreEqual("OneClassOverAll", classParameterDefinition.ParameterType.Name);

            // test
            r = classParameterDefinition.TypeToString();

            Assert.AreEqual(classParameterDefinition.ParameterType.TypeSignatureAsString(), r);


        }
    }
}
