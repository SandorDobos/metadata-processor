﻿using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.Cecil;

namespace nanoFramework.Tools.MetadataProcessor.Tests.Tables
{
    [TestClass]
    public class nanoReferenceTableBaseTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var items = new List<object>() { 1, 2, 3 };

            var comparer = new ObjectComparer();
            var context = TestObjectHelper.GetInitializedNanoTablesContext();

            // test
            var iut = new TestNanoReferenceTable(items, comparer, context);

            Assert.IsTrue(comparer.EqualsCallParameters.Any() || comparer.GetHashCodeCallParameters.Any());
        }

        [TestMethod]
        public void ForEachItemsTest()
        {
            var items = new List<object>() { 1, 2, 3 };

            var comparer = new ObjectComparer();
            var context = TestObjectHelper.GetInitializedNanoTablesContext();
            var iut = new TestNanoReferenceTable(items, comparer, context);

            // test
            var forEachCalledOnItems = new List<object>();
            iut.ForEachItems((idx, item) =>
            {
                forEachCalledOnItems.Add(item);
                Assert.AreEqual(items.IndexOf(item), (int)idx);
            });

            CollectionAssert.AreEqual(items.ToArray(), forEachCalledOnItems.ToArray());
        }

        private class TestNanoReferenceTable : nanoReferenceTableBase<object>
        {
            public List<HashSet<MetadataToken>> RemoveUnusedItemsCallParameters = new List<HashSet<MetadataToken>>();
            public List<object> AllocateSingleItemStringsCallParameters = new List<object>();
            public List<object> WriteSingleItemCallParameters = new List<object>();

            public TestNanoReferenceTable(IEnumerable<object> nanoTableItems, IEqualityComparer<object> comparer, nanoTablesContext context) : base(nanoTableItems, comparer, context)
            {
            }

            protected override void WriteSingleItem(nanoBinaryWriter writer, object item)
            {
                this.WriteSingleItemCallParameters.Add(item);
                writer.WriteString(item.ToString());
            }

            public override void RemoveUnusedItems(HashSet<MetadataToken> set)
            {
                this.RemoveUnusedItemsCallParameters.Add(set);
                base.RemoveUnusedItems(set);
            }

            protected override void AllocateSingleItemStrings(object item)
            {
                this.AllocateSingleItemStringsCallParameters.Add(item);
                base.AllocateSingleItemStrings(item);
            }
        }

        private class ObjectComparer : IEqualityComparer<object>
        {
            public List<KeyValuePair<object, object>> EqualsCallParameters = new List<KeyValuePair<object, object>>();
            public List<object> GetHashCodeCallParameters = new List<object>();

            public new bool Equals(object x, object y)
            {
                this.EqualsCallParameters.Add(new KeyValuePair<object, object>(x, y));
                return Object.Equals(x, y);
            }

            public int GetHashCode(object obj)
            {
                this.GetHashCodeCallParameters.Add(obj);
                return obj.GetHashCode();
            }
        }

    }
}
