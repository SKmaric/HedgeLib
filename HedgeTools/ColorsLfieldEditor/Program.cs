// Decompiled with JetBrains decompiler
// Type: colors_lightfield_editor.Program
// Assembly: colors-lightfield-editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 674CC61A-1A6C-479E-86D6-17A8B7B17B8C
// Assembly location: E:\Users\SK\Documents\GitHub\Sonic-Colors-Set-Editor\colors-lightfield-editor\colors-lightfield-editor\obj\Debug\colors-lightfield-editor.exe

using System;
using System.Windows.Forms;

namespace colors_lightfield_editor
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new MainForm());
    }
  }
}
