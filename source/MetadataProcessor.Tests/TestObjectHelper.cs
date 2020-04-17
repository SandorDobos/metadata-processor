﻿using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace nanoFramework.Tools.MetadataProcessor.Tests
{
    public static class TestObjectHelper
    {
        public static nanoTablesContext GetInitializedNanoTablesContext()
        {
            nanoTablesContext ret = null;

            var assemblyDefinition = GetInitializedTestAssemblyDefinition();

            ret = new nanoTablesContext(
                assemblyDefinition, 
                null,
                new List<string>(),
                null,
                false,
                false,
                false);

            return ret;
        }

        public static AssemblyDefinition GetInitializedTestAssemblyDefinition()
        {
            AssemblyDefinition ret = AssemblyDefinition.ReadAssembly(Assembly.GetExecutingAssembly().Location);
            return ret;
        }

        public static MockNanoBinaryWriter GetMockNanoBinaryWriter()
        {
            MockNanoBinaryWriter ret = new MockNanoBinaryWriter(new BinaryWriter(Stream.Null));
            return ret;
        }
    }
}