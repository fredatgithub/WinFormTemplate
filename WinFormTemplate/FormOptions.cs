<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> d0204a2512691e3d2653d8c8d5824943e045393d
using System.Windows.Forms;

namespace WinFormTemplate
{
  internal partial class FormOptions : Form
  {
    private readonly ConfigurationOptions _configurationOptions2;

    internal FormOptions(ConfigurationOptions configurationOptions)
    {
      if (configurationOptions == null)
      {
        //throw new ArgumentNullException(nameof(configurationOptions));
        _configurationOptions2 = new ConfigurationOptions();
      }
      else
      {
        _configurationOptions2 = configurationOptions;
      }

      InitializeComponent();
      checkBoxOption1.Checked = ConfigurationOptions2.Option1Name;
      checkBoxOption2.Checked = ConfigurationOptions2.Option2Name;
    }

    internal ConfigurationOptions ConfigurationOptions2
    {
      get { return _configurationOptions2; }
    }

    private void buttonOptionsOK_Click(object sender, EventArgs e)
    {
      ConfigurationOptions2.Option1Name = checkBoxOption1.Checked;
      ConfigurationOptions2.Option2Name = checkBoxOption2.Checked;
      Close();
    }

    private void buttonOptionsCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void FormOptions_Load(object sender, EventArgs e)
    {
      // take care of language
      //buttonOptionsCancel.Text = _languageDicoEn["Cancel"];
    }
  }
}
