using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nanoFramework.Tools.MetadataProcessor.Tests
{
    public class MockNanoBinaryWriter : nanoBinaryWriter
    {
        private List<object> thingsWritten = new List<object>();
        public IReadOnlyList<object> ThingsWritten
        {
            get
            {
                return thingsWritten.AsReadOnly();
            }
        }

        public MockNanoBinaryWriter(BinaryWriter baseWriter) : base(baseWriter)
        {
        }

        public override nanoBinaryWriter GetMemoryBasedClone(MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        public override void WriteDouble(double value)
        {
            thingsWritten.Add(value);
        }

        public override void WriteSingle(float value)
        {
            thingsWritten.Add(value);
        }

        public override void WriteUInt16(ushort value)
        {
            thingsWritten.Add(value);
        }

        public override void WriteUInt32(uint value)
        {
            thingsWritten.Add(value);
        }

        public override void WriteUInt64(ulong value)
        {
            thingsWritten.Add(value);
        }
    }
}
