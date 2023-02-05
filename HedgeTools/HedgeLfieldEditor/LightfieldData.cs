// Decompiled with JetBrains decompiler
// Type: gens_lightfield_editor.LightfieldData
// Assembly: gens-lightfield-editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A9259400-83B4-4707-B039-63A018DCF32F
// Assembly location: E:\Users\SK\Documents\GitHub\Sonic-Colors-Set-Editor\gens-lightfield-editor\obj\Debug\gens-lightfield-editor.exe

using HedgeLib.Headers;
using HedgeLib.IO;
using System.Collections.Generic;
using System.IO;

namespace gens_lightfield_editor
{
  public class LightfieldData
  {
    public GensHeader Header = new GensHeader();
    public float[] WorldAABB = new float[6];
    public List<Cube> Cubes = new List<Cube>();
    public List<ColorBlock> Colors = new List<ColorBlock>();
    public List<Index> Indexes = new List<Index>();

    public void Load(Stream fileStream)
    {
      GensReader gensReader = new GensReader(fileStream, true);
      this.Header = new GensHeader(gensReader);
            this.WorldAABB[0] = ((BinaryReader) gensReader).ReadSingle();
      this.WorldAABB[1] = ((BinaryReader) gensReader).ReadSingle();
      this.WorldAABB[2] = ((BinaryReader) gensReader).ReadSingle();
      this.WorldAABB[3] = ((BinaryReader) gensReader).ReadSingle();
      this.WorldAABB[4] = ((BinaryReader) gensReader).ReadSingle();
      this.WorldAABB[5] = ((BinaryReader) gensReader).ReadSingle();
      uint num1 = ((BinaryReader) gensReader).ReadUInt32();
      uint num2 = ((BinaryReader) gensReader).ReadUInt32();
      uint num3 = ((BinaryReader) gensReader).ReadUInt32();
      uint num4 = ((BinaryReader) gensReader).ReadUInt32();
      uint num5 = ((BinaryReader) gensReader).ReadUInt32();
      uint num6 = ((BinaryReader) gensReader).ReadUInt32();
      ((ExtendedBinaryReader) gensReader).JumpTo((long) num2, false);
      for (uint index = 0; index < num1; ++index)
        this.Cubes.Add(new Cube()
        {
          Type = ((BinaryReader) gensReader).ReadUInt32(),
          Value = ((BinaryReader) gensReader).ReadUInt32()
        });
      ((ExtendedBinaryReader) gensReader).JumpTo((long) num4, false);
      for (uint index1 = 0; index1 < num3; ++index1)
      {
        ColorBlock colorBlock = new ColorBlock();
        for (uint index2 = 0; index2 < 8U; ++index2)
          colorBlock.Color.Add(new Color()
          {
            Red = (uint) ((BinaryReader) gensReader).ReadByte(),
            Green = (uint) ((BinaryReader) gensReader).ReadByte(),
            Blue = (uint) ((BinaryReader) gensReader).ReadByte()
          });
        colorBlock.Flag = ((BinaryReader) gensReader).ReadByte();
        this.Colors.Add(colorBlock);
      }
      ((ExtendedBinaryReader) gensReader).JumpTo((long) num6, false);
      for (uint index = 0; index < num5; ++index)
        this.Indexes.Add(new Index()
        {
          Value = ((BinaryReader) gensReader).ReadUInt32()
        });
    }
  }
}
