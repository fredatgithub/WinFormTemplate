namespace WinFormTemplate
{
  partial class FormOptions
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.checkBoxOption1 = new System.Windows.Forms.CheckBox();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.buttonOptionsOK = new System.Windows.Forms.Button();
      this.buttonOptionsCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // checkBoxOption1
      // 
      this.checkBoxOption1.AutoSize = true;
      this.checkBoxOption1.Location = new System.Drawing.Point(31, 45);
      this.checkBoxOption1.Name = "checkBoxOption1";
      this.checkBoxOption1.Size = new System.Drawing.Size(63, 17);
      this.checkBoxOption1.TabIndex = 0;
      this.checkBoxOption1.Text = "Option1";
      this.checkBoxOption1.UseVisualStyleBackColor = true;
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new System.Drawing.Point(31, 90);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(63, 17);
      this.checkBox2.TabIndex = 1;
      this.checkBox2.Text = "Option2";
      this.checkBox2.UseVisualStyleBackColor = true;
      // 
      // buttonOptionsOK
      // 
      this.buttonOptionsOK.Location = new System.Drawing.Point(116, 227);
      this.buttonOptionsOK.Name = "buttonOptionsOK";
      this.buttonOptionsOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOptionsOK.TabIndex = 2;
      this.buttonOptionsOK.Text = "OK";
      this.buttonOptionsOK.UseVisualStyleBackColor = true;
      this.buttonOptionsOK.Click += new System.EventHandler(this.buttonOptionsOK_Click);
      // 
      // buttonOptionsCancel
      // 
      this.buttonOptionsCancel.Location = new System.Drawing.Point(197, 227);
      this.buttonOptionsCancel.Name = "buttonOptionsCancel";
      this.buttonOptionsCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonOptionsCancel.TabIndex = 3;
      this.buttonOptionsCancel.Text = "Cancel";
      this.buttonOptionsCancel.UseVisualStyleBackColor = true;
      this.buttonOptionsCancel.Click += new System.EventHandler(this.buttonOptionsCancel_Click);
      // 
      // FormOptions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.buttonOptionsCancel);
      this.Controls.Add(this.buttonOptionsOK);
      this.Controls.Add(this.checkBox2);
      this.Controls.Add(this.checkBoxOption1);
      this.Name = "FormOptions";
      this.Text = "FormOptions";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox checkBoxOption1;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.Button buttonOptionsOK;
    private System.Windows.Forms.Button buttonOptionsCancel;
  }
}