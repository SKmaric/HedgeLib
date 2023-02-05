// Decompiled with JetBrains decompiler
// Type: colors_lightfield_editor.LightfieldData
// Assembly: colors-lightfield-editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 674CC61A-1A6C-479E-86D6-17A8B7B17B8C
// Assembly location: E:\Users\SK\Documents\GitHub\Sonic-Colors-Set-Editor\colors-lightfield-editor\colors-lightfield-editor\obj\Debug\colors-lightfield-editor.exe

using HedgeLib;
using HedgeLib.Exceptions;
using HedgeLib.Headers;
using HedgeLib.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace colors_lightfield_editor
{
  public class LightfieldData
  {
    public BINAHeader Header = new BINAHeader();
    public const string Signature = "RLFS";
    public const string Extension = ".orc";
    public List<LightfieldNode> objs = new List<LightfieldNode>();
    public List<TransformNode> transforms = new List<TransformNode>();

    public void Load(Stream fileStream)
    {
      BINAReader binaReader = new BINAReader(fileStream);
      this.Header = binaReader.ReadHeader();
      //this.Header = binaReader.ReadHeader(false);
      char[] chArray = ((BinaryReader) binaReader).ReadChars(4);
      if (!((ExtendedBinaryReader) binaReader).IsBigEndian)
        Array.Reverse((Array) chArray);
      string str = new string(chArray);
      if (str != "RLFS")
        throw new InvalidSignatureException("RLFS", str);
      ((BinaryReader) binaReader).ReadUInt32();
      ((BinaryReader) binaReader).ReadUInt32();
      uint num1 = ((BinaryReader) binaReader).ReadUInt32();
      uint num2 = ((BinaryReader) binaReader).ReadUInt32();
      uint num3 = ((BinaryReader) binaReader).ReadUInt32();
      uint num4 = ((BinaryReader) binaReader).ReadUInt32();
      ((ExtendedBinaryReader) binaReader).JumpTo((long) num2, false);
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        ((ExtendedBinaryReader) binaReader).JumpTo((long) num2 + (long) (index * 60), false);
        this.objs.Add(new LightfieldNode());
        this.objs[index].ObjectName = ((ExtendedBinaryReader) binaReader).GetString(false, true);
        this.objs[index].ColorID = ((BinaryReader) binaReader).ReadUInt32();
        this.objs[index].ShapeType = ((BinaryReader) binaReader).ReadByte();
        ((ExtendedBinaryReader) binaReader).JumpAhead(1L);
        this.objs[index].unknown2 = ((BinaryReader) binaReader).ReadUInt16();
        this.objs[index].unknown3 = ((BinaryReader) binaReader).ReadSingle();
        this.objs[index].unknown4 = ((BinaryReader) binaReader).ReadSingle();
        this.objs[index].unknown5 = ((BinaryReader) binaReader).ReadSingle();
        this.objs[index].unknown6 = ((BinaryReader) binaReader).ReadSingle();
        this.objs[index].unknown7 = ((BinaryReader) binaReader).ReadSingle();
        this.objs[index].unknown8 = ((BinaryReader) binaReader).ReadSingle();
        this.objs[index].unknown9 = ((BinaryReader) binaReader).ReadSingle();
        this.objs[index].unknown10 = ((BinaryReader) binaReader).ReadSingle();
        ((Vector4) this.objs[index].Rotation).X = ((BinaryReader) binaReader).ReadSingle();
        ((Vector4) this.objs[index].Rotation).Y = ((BinaryReader) binaReader).ReadSingle();
        ((Vector4) this.objs[index].Rotation).Z = ((BinaryReader) binaReader).ReadSingle();
        ((Vector4) this.objs[index].Rotation).W = ((BinaryReader) binaReader).ReadSingle();
        this.objs[index].Rotation3 = this.objs[index].Rotation.ToEulerAngles(false);
      }
      ((ExtendedBinaryReader) binaReader).JumpTo((long) num4, false);
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        ((ExtendedBinaryReader) binaReader).JumpTo((long) num4 + (long) (index * 32), false);
        this.transforms.Add(new TransformNode());
        this.transforms[index].unknown1 = ((BinaryReader) binaReader).ReadUInt32();
        this.transforms[index].unknown2 = ((BinaryReader) binaReader).ReadUInt32();
        this.transforms[index].unknown3 = ((BinaryReader) binaReader).ReadSingle();
        this.transforms[index].unknown4 = ((BinaryReader) binaReader).ReadSingle();
        this.transforms[index].unknown5 = ((BinaryReader) binaReader).ReadSingle();
        this.transforms[index].unknown6 = ((BinaryReader) binaReader).ReadSingle();
        this.transforms[index].unknown7 = ((BinaryReader) binaReader).ReadSingle();
        this.transforms[index].unknown8 = ((BinaryReader) binaReader).ReadSingle();
      }
    }
  }
}
