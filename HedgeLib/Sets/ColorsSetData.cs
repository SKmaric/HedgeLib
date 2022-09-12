using System.Collections.Generic;
using System.IO;
using System;
using HedgeLib.Headers;
using HedgeLib.IO;

namespace HedgeLib.Sets
{
    public class ColorsSetData : SetData
    {
        // Variables/Constants
        public BINAHeader Header = new BINAv1Header()
        {
            IsFooterMagicPresent = true
        };

        // Methods
        public override void Load(Stream fileStream,
            Dictionary<string, SetObjectType> objectTemplates)
        {
            if (objectTemplates == null)
                throw new ArgumentNullException("objectTemplates",
                    "Cannot load Colors set data without object templates.");

            // Header
            var reader = new BINAReader(fileStream);
            var Header = (BINAv1Header)reader.ReadHeader();

            // SOBJ Data
            Objects = SOBJ.Read(reader,
                objectTemplates, SOBJ.SOBJType.Colors);

            reader.JumpTo(Header.FinalTableOffset, false);
            var footer = reader.ReadFooter(Header.FinalTableLength);
        }

        public override void Save(Stream fileStream)
        {
            // Header
            var writer = new BINAWriter(fileStream, Header);

            // SOBJ Data
            SOBJ.Write(writer, Objects, SOBJ.SOBJType.Colors);
            writer.FinishWrite(Header);
        }
    }
}