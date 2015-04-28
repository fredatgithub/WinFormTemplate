/*
The MIT License(MIT)
Copyright(c) 2015 Freddy Juhel
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormTemplate.Properties;

namespace WinFormTemplate
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    List<Tuple<string, string, string>> languageTranslations = new List<Tuple<string, string, string>>();
    Dictionary<string, Tuple<string, string>> languageDico = new Dictionary<string, Tuple<string, string>>();

    private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveWindowValue();
      Application.Exit();
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutBoxApplication aboutBoxApplication = new AboutBoxApplication();
      aboutBoxApplication.ShowDialog();
    }

    private void DisplayTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      Text += string.Format(" V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      DisplayTitle();
      GetWindowValue();
      LoadLanguages();
      SetLanguage(Settings.Default.LastLanguageUsed);
    }

    private void LoadLanguages()
    {
      if (!File.Exists(Settings.Default.LanguageFileName))
      {
        CreateLanguageFile();
      }

      // read the translation file and feed the language
      XDocument xDoc = XDocument.Load(Settings.Default.LanguageFileName);
      var result = from node in xDoc.Descendants("term")
                    where node.HasElements
                    select new
                    {
                      name = node.Element("name").Value,
                      englishValue = node.Element("englishValue").Value,
                      frenchValue = node.Element("frenchValue").Value
                    };
      foreach (var i in result)
      {
        languageTranslations.Add(new Tuple<string, string, string>(i.name, i.englishValue, i.frenchValue));
        languageDico.Add(i.name, new Tuple<string, string>(i.englishValue, i.frenchValue));
      }
    }

    private void CreateLanguageFile()
    {
      List<string> minimumVersion = new List<string>();
      minimumVersion.Add("<?xml version=\"1.0\" encoding=\"utf - 8\" ?>");
      minimumVersion.Add("<Document>");
      minimumVersion.Add("<DocumentVersion>");
      minimumVersion.Add("<version> 1.0 </version>");
      minimumVersion.Add("</DocumentVersion>");
      minimumVersion.Add("<terms>");
      minimumVersion.Add(" <term>");
      minimumVersion.Add("<name> WindowHeight </name>");
      minimumVersion.Add("<value> 200 </value>");
      minimumVersion.Add(" </term>");
      minimumVersion.Add(" <term>");
      minimumVersion.Add("<name> WindowWidth </name>");
      minimumVersion.Add("<value> 200 </value>");
      minimumVersion.Add("</term>");
      minimumVersion.Add(" <term>");
      minimumVersion.Add("<name> WindowTop </name>");
      minimumVersion.Add("<value> 0 </value>");
      minimumVersion.Add("</term>");
      minimumVersion.Add("<term>");
      minimumVersion.Add("<name> WindowLeft </name>");
      minimumVersion.Add("<value> 0 </value>");
      minimumVersion.Add("</term>");
      minimumVersion.Add("  </terms>");
      minimumVersion.Add("</Document>");
      StreamWriter sw = new StreamWriter(Settings.Default.LanguageFileName);
      foreach (string item in minimumVersion)
      {
        sw.WriteLine(item);
      }

      sw.Close();
    }

    private void GetWindowValue()
    {
      Width = Settings.Default.WindowWidth;
      Height = Settings.Default.WindowHeight;
      Top = Settings.Default.WindowTop < 0 ? 0 : Settings.Default.WindowTop;
      Left = Settings.Default.WindowLeft < 0 ? 0 : Settings.Default.WindowLeft;
    }

    private void SaveWindowValue()
    {
      Settings.Default.WindowHeight = Height;
      Settings.Default.WindowWidth = Width;
      Settings.Default.WindowLeft = Left;
      Settings.Default.WindowTop = Top;
      Settings.Default.Save();
    }

    private void FormMainFormClosing(object sender, FormClosingEventArgs e)
    {
      SaveWindowValue();
    }

    private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SetLanguage(Language.French.ToString());
    }

    private void englishToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SetLanguage(Language.English.ToString());
    }
        
    private void SetLanguage(string myLanguage)
    {
      switch (myLanguage)
      {
        case "English":
          frenchToolStripMenuItem.Checked = false;
          englishToolStripMenuItem.Checked = true;
          fileToolStripMenuItem.Text = languageDico["MenuFile"].Item1;
          break;
        case "French":
          frenchToolStripMenuItem.Checked = true;
          englishToolStripMenuItem.Checked = false;
          fileToolStripMenuItem.Text = languageDico["MenuFile"].Item2;
          break;
        
      }
    }
  }
}