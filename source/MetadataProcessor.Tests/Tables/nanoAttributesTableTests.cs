using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.Cecil;
using System.Reflection;

namespace nanoFramework.Tools.MetadataProcessor.Tests.Tables
{
    [DummyCustomAttribute1]
    [DummyCustomAttribute2]
    [TestClass]
    public class nanoAttributesTableTests
    {
        [TestMethod]
        public void constructorTest()
        {
            var typesAttributes = new Tuple<CustomAttribute, ushort>[0];
            var fieldsAttributes = new Tuple<CustomAttribute, ushort>[0];
            var methodsAttributes = new Tuple<CustomAttribute, ushort>[0];
            var context = TestObjectHelper.GetInitializedNanoTablesContext();

            // test
            var iut = new nanoAttributesTable(typesAttributes, fieldsAttributes, methodsAttributes, context);

            // no op
        }

        [TestMethod]
        public void RemoveUnusedItems_TypesAttributesTest()
        {
            var assemblyDefinition = TestObjectHelper.GetInitializedTestAssemblyDefinition();
            var module = assemblyDefinition.Modules[0];
            var thisTypeDefinition = module.Types.First(i => i.FullName == this.GetType().FullName);
            Assert.IsTrue(thisTypeDefinition.CustomAttributes.Count > 1);
            var customAttribute0 = thisTypeDefinition.CustomAttributes[0];
            var customAttribute1 = thisTypeDefinition.CustomAttributes[1];

            var referencedMetadataTokens = new HashSet<MetadataToken>();
            referencedMetadataTokens.Add(customAttribute1.Constructor.MetadataToken);

            var tuple0 = new Tuple<CustomAttribute, ushort>(customAttribute0, 1);
            var tuple1 = new Tuple<CustomAttribute, ushort>(customAttribute1, 2);

            var typesAttributes = new Tuple<CustomAttribute, ushort>[] { tuple0, tuple1 };
            var fieldsAttributes = new Tuple<CustomAttribute, ushort>[0];
            var methodsAttributes = new Tuple<CustomAttribute, ushort>[0];
            var context = TestObjectHelper.GetInitializedNanoTablesContext();

            var iut = new nanoAttributesTable(typesAttributes, fieldsAttributes, methodsAttributes, context);

            // test
            iut.RemoveUnusedItems(referencedMetadataTokens);

            var writer = TestObjectHelper.GetMockNanoBinaryWriter();
            iut.Write(writer);

            var expectedThingsWritten = new List<object>()
            {
                (ushort)0x0004,
                (ushort)tuple1.Item2,
                (ushort)context.GetMethodReferenceId(customAttribute1.Constructor),
                (ushort)context.SignaturesTable.GetOrCreateSignatureId(customAttribute1)
            };


            CollectionAssert.AreEqual(
                expectedThingsWritten.ToArray(), 
                writer.ThingsWritten.ToArray(),
                String.Join(", ", writer.ThingsWritten.Select((i, idx) => $"[{idx}]: {i.ToString()} ({i.GetType().ToString()})")));
        }


        [DummyCustomAttribute1]
        [DummyCustomAttribute2]
        private readonly string dummyField = "dummy";

        [TestMethod]
        public void RemoveUnusedItems_FieldAttributesTest()
        {
            var assemblyDefinition = TestObjectHelper.GetInitializedTestAssemblyDefinition();
            var module = assemblyDefinition.Modules[0];
            var dummyFieldDefinition = module.Types.First(i => i.FullName == this.GetType().FullName).Fields.First(i=>i.Name == nameof(dummyField));
            Assert.IsTrue(dummyFieldDefinition.CustomAttributes.Count > 1);
            var customAttribute0 = dummyFieldDefinition.CustomAttributes[0];
            var customAttribute1 = dummyFieldDefinition.CustomAttributes[1];

            var referencedMetadataTokens = new HashSet<MetadataToken>();
            referencedMetadataTokens.Add(customAttribute1.Constructor.MetadataToken);

            var tuple0 = new Tuple<CustomAttribute, ushort>(customAttribute0, 1);
            var tuple1 = new Tuple<CustomAttribute, ushort>(customAttribute1, 2);

            var typesAttributes = new Tuple<CustomAttribute, ushort>[0];
            var fieldsAttributes = new Tuple<CustomAttribute, ushort>[] { tuple0, tuple1 };
            var methodsAttributes = new Tuple<CustomAttribute, ushort>[0];
            var context = TestObjectHelper.GetInitializedNanoTablesContext();

            var iut = new nanoAttributesTable(typesAttributes, fieldsAttributes, methodsAttributes, context);

            // test
            iut.RemoveUnusedItems(referencedMetadataTokens);

            var writer = TestObjectHelper.GetMockNanoBinaryWriter();
            iut.Write(writer);

            var expectedThingsWritten = new List<object>()
            {
                (ushort)0x0005,
                (ushort)tuple1.Item2,
                (ushort)context.GetMethodReferenceId(customAttribute1.Constructor),
                (ushort)context.SignaturesTable.GetOrCreateSignatureId(customAttribute1)
            };


            CollectionAssert.AreEqual(
                expectedThingsWritten.ToArray(),
                writer.ThingsWritten.ToArray(),
                String.Join(", ", writer.ThingsWritten.Select((i, idx) => $"[{idx}]: {i.ToString()} ({i.GetType().ToString()})")));
        }


        [DummyCustomAttribute1]
        [DummyCustomAttribute2]
        [TestMethod]
        public void RemoveUnusedItems_MethodAttributesTest()
        {
            var assemblyDefinition = TestObjectHelper.GetInitializedTestAssemblyDefinition();
            var module = assemblyDefinition.Modules[0];
            var methodDefinition = module.Types.First(i => i.FullName == this.GetType().FullName).Methods.First(i => i.Name == nameof(RemoveUnusedItems_MethodAttributesTest));
            Assert.IsTrue(methodDefinition.CustomAttributes.Count > 1);
            var customAttribute0 = methodDefinition.CustomAttributes[0];
            var customAttribute1 = methodDefinition.CustomAttributes[1];

            var referencedMetadataTokens = new HashSet<MetadataToken>();
            referencedMetadataTokens.Add(customAttribute1.Constructor.MetadataToken);

            var tuple0 = new Tuple<CustomAttribute, ushort>(customAttribute0, 1);
            var tuple1 = new Tuple<CustomAttribute, ushort>(customAttribute1, 2);

            var typesAttributes = new Tuple<CustomAttribute, ushort>[0];
            var fieldsAttributes = new Tuple<CustomAttribute, ushort>[0];
            var methodsAttributes = new Tuple<CustomAttribute, ushort>[] { tuple0, tuple1 };
            var context = TestObjectHelper.GetInitializedNanoTablesContext();

            var iut = new nanoAttributesTable(typesAttributes, fieldsAttributes, methodsAttributes, context);

            // test
            iut.RemoveUnusedItems(referencedMetadataTokens);

            var writer = TestObjectHelper.GetMockNanoBinaryWriter();
            iut.Write(writer);

            var expectedThingsWritten = new List<object>()
            {
                (ushort)0x0006,
                (ushort)tuple1.Item2,
                (ushort)context.GetMethodReferenceId(customAttribute1.Constructor),
                (ushort)context.SignaturesTable.GetOrCreateSignatureId(customAttribute1)
            };


            CollectionAssert.AreEqual(
                expectedThingsWritten.ToArray(),
                writer.ThingsWritten.ToArray(),
                String.Join(", ", writer.ThingsWritten.Select((i, idx) => $"[{idx}]: {i.ToString()} ({i.GetType().ToString()})")));
        }
    }


}
