// Decompiled with JetBrains decompiler
// Type: gens_lightfield_editor.Program
// Assembly: gens-lightfield-editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A9259400-83B4-4707-B039-63A018DCF32F
// Assembly location: E:\Users\SK\Documents\GitHub\Sonic-Colors-Set-Editor\gens-lightfield-editor\obj\Debug\gens-lightfield-editor.exe

using System;
using System.Windows.Forms;

namespace gens_lightfield_editor
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
