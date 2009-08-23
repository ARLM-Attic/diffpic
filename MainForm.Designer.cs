namespace DiffPic
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.labelDiff = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.comboBox2 = new System.Windows.Forms.ComboBox();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.labelIdentical = new System.Windows.Forms.Label();
      this.pictureBoxXOR = new System.Windows.Forms.PictureBox();
      this.pictureBoxDiff = new System.Windows.Forms.PictureBox();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.labelHelp = new System.Windows.Forms.Label();
      this.labelXOR = new System.Windows.Forms.Label();
      this.comboBoxZoom = new System.Windows.Forms.ComboBox();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) (this.pictureBoxXOR)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.pictureBoxDiff)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.SuspendLayout();
      // 
      // labelDiff
      // 
      this.labelDiff.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.labelDiff.AutoSize = true;
      this.labelDiff.Location = new System.Drawing.Point(707, 3);
      this.labelDiff.Margin = new System.Windows.Forms.Padding(0);
      this.labelDiff.Name = "labelDiff";
      this.labelDiff.Size = new System.Drawing.Size(23, 13);
      this.labelDiff.TabIndex = 7;
      this.labelDiff.Text = "Diff";
      this.labelDiff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.SystemColors.Highlight;
      this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.label1.Location = new System.Drawing.Point(0, 2);
      this.label1.Margin = new System.Windows.Forms.Padding(0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Pic 1:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(0, 2);
      this.label2.Margin = new System.Windows.Forms.Padding(0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(34, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Pic 2:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // comboBox1
      // 
      this.comboBox1.AllowDrop = true;
      this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(32, -1);
      this.comboBox1.Margin = new System.Windows.Forms.Padding(0);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(264, 21);
      this.comboBox1.TabIndex = 2;
      this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
      this.comboBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBox_DragDrop);
      this.comboBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.comboBox_DragEnter);
      this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
      this.comboBox1.DropDown += new System.EventHandler(this.AdjustWidthComboBox_DropDown);
      // 
      // comboBox2
      // 
      this.comboBox2.AllowDrop = true;
      this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Location = new System.Drawing.Point(32, -1);
      this.comboBox2.Margin = new System.Windows.Forms.Padding(0);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new System.Drawing.Size(275, 21);
      this.comboBox2.TabIndex = 5;
      this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
      this.comboBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBox_DragDrop);
      this.comboBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.comboBox_DragEnter);
      this.comboBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox2_KeyPress);
      this.comboBox2.DropDown += new System.EventHandler(this.AdjustWidthComboBox_DropDown);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer1.IsSplitterFixed = true;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.AllowDrop = true;
      this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
      this.splitContainer1.Panel1.Controls.Add(this.labelIdentical);
      this.splitContainer1.Panel1.Controls.Add(this.pictureBoxXOR);
      this.splitContainer1.Panel1.Controls.Add(this.pictureBoxDiff);
      this.splitContainer1.Panel1.Controls.Add(this.pictureBox2);
      this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
      this.splitContainer1.Panel1.Controls.Add(this.labelHelp);
      this.splitContainer1.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBox_DragDrop);
      this.splitContainer1.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.comboBox_DragEnter);
      this.splitContainer1.Panel1MinSize = 0;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.labelXOR);
      this.splitContainer1.Panel2.Controls.Add(this.comboBoxZoom);
      this.splitContainer1.Panel2.Controls.Add(this.labelDiff);
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
      this.splitContainer1.Panel2MinSize = 0;
      this.splitContainer1.Size = new System.Drawing.Size(760, 485);
      this.splitContainer1.SplitterDistance = 465;
      this.splitContainer1.SplitterWidth = 1;
      this.splitContainer1.TabIndex = 0;
      // 
      // labelIdentical
      // 
      this.labelIdentical.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.labelIdentical.BackColor = System.Drawing.Color.Transparent;
      this.labelIdentical.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.labelIdentical.ForeColor = System.Drawing.Color.White;
      this.labelIdentical.Location = new System.Drawing.Point(0, 428);
      this.labelIdentical.Margin = new System.Windows.Forms.Padding(0);
      this.labelIdentical.Name = "labelIdentical";
      this.labelIdentical.Size = new System.Drawing.Size(760, 37);
      this.labelIdentical.TabIndex = 9;
      this.labelIdentical.Text = "Pic 1 and Pic 2 are identical.";
      this.labelIdentical.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.labelIdentical.Visible = false;
      // 
      // pictureBoxXOR
      // 
      this.pictureBoxXOR.AllowDrop = true;
      this.pictureBoxXOR.BackColor = System.Drawing.Color.Transparent;
      this.pictureBoxXOR.Image = global::DiffPic.Properties.Resources.help64x32;
      this.pictureBoxXOR.InitialImage = null;
      this.pictureBoxXOR.Location = new System.Drawing.Point(192, 0);
      this.pictureBoxXOR.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBoxXOR.Name = "pictureBoxXOR";
      this.pictureBoxXOR.Size = new System.Drawing.Size(64, 32);
      this.pictureBoxXOR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxXOR.TabIndex = 7;
      this.pictureBoxXOR.TabStop = false;
      this.pictureBoxXOR.Visible = false;
      // 
      // pictureBoxDiff
      // 
      this.pictureBoxDiff.AllowDrop = true;
      this.pictureBoxDiff.BackColor = System.Drawing.Color.Transparent;
      this.pictureBoxDiff.Image = global::DiffPic.Properties.Resources.help64x32;
      this.pictureBoxDiff.InitialImage = null;
      this.pictureBoxDiff.Location = new System.Drawing.Point(128, 0);
      this.pictureBoxDiff.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBoxDiff.Name = "pictureBoxDiff";
      this.pictureBoxDiff.Size = new System.Drawing.Size(64, 32);
      this.pictureBoxDiff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBoxDiff.TabIndex = 5;
      this.pictureBoxDiff.TabStop = false;
      this.pictureBoxDiff.Visible = false;
      this.pictureBoxDiff.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
      this.pictureBoxDiff.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBox_DragDrop);
      this.pictureBoxDiff.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
      this.pictureBoxDiff.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
      this.pictureBoxDiff.DragEnter += new System.Windows.Forms.DragEventHandler(this.comboBox_DragEnter);
      // 
      // pictureBox2
      // 
      this.pictureBox2.AllowDrop = true;
      this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox2.Image = global::DiffPic.Properties.Resources.help64x32;
      this.pictureBox2.InitialImage = null;
      this.pictureBox2.Location = new System.Drawing.Point(64, 0);
      this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(64, 32);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 4;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Visible = false;
      this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
      this.pictureBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBox_DragDrop);
      this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
      this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
      this.pictureBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.comboBox_DragEnter);
      // 
      // pictureBox1
      // 
      this.pictureBox1.AllowDrop = true;
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.InitialImage = null;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(64, 32);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
      this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBox_DragDrop);
      this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
      this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
      this.pictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.comboBox_DragEnter);
      // 
      // labelHelp
      // 
      this.labelHelp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.labelHelp.ForeColor = System.Drawing.Color.White;
      this.labelHelp.Location = new System.Drawing.Point(0, 0);
      this.labelHelp.Name = "labelHelp";
      this.labelHelp.Size = new System.Drawing.Size(760, 465);
      this.labelHelp.TabIndex = 6;
      this.labelHelp.Text = resources.GetString("labelHelp.Text");
      this.labelHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.labelHelp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
      this.labelHelp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
      this.labelHelp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
      // 
      // labelXOR
      // 
      this.labelXOR.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.labelXOR.AutoSize = true;
      this.labelXOR.Location = new System.Drawing.Point(730, 3);
      this.labelXOR.Margin = new System.Windows.Forms.Padding(0);
      this.labelXOR.Name = "labelXOR";
      this.labelXOR.Size = new System.Drawing.Size(30, 13);
      this.labelXOR.TabIndex = 8;
      this.labelXOR.Text = "XOR";
      this.labelXOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // comboBoxZoom
      // 
      this.comboBoxZoom.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.comboBoxZoom.DropDownWidth = 56;
      this.comboBoxZoom.Location = new System.Drawing.Point(0, -1);
      this.comboBoxZoom.MaxDropDownItems = 99;
      this.comboBoxZoom.MaxLength = 4;
      this.comboBoxZoom.Name = "comboBoxZoom";
      this.comboBoxZoom.Size = new System.Drawing.Size(56, 21);
      this.comboBoxZoom.TabIndex = 0;
      this.comboBoxZoom.Text = "100%";
      this.comboBoxZoom.SelectedIndexChanged += new System.EventHandler(this.comboBoxZoom_SelectedIndexChanged);
      this.comboBoxZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxZoom_KeyPress);
      // 
      // splitContainer2
      // 
      this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer2.IsSplitterFixed = true;
      this.splitContainer2.Location = new System.Drawing.Point(58, 1);
      this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.label1);
      this.splitContainer2.Panel1.Controls.Add(this.button1);
      this.splitContainer2.Panel1.Controls.Add(this.comboBox1);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.label2);
      this.splitContainer2.Panel2.Controls.Add(this.comboBox2);
      this.splitContainer2.Panel2.Controls.Add(this.button2);
      this.splitContainer2.Size = new System.Drawing.Size(654, 19);
      this.splitContainer2.SplitterDistance = 319;
      this.splitContainer2.SplitterWidth = 1;
      this.splitContainer2.TabIndex = 8;
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.button1.Image = ((System.Drawing.Image) (resources.GetObject("button1.Image")));
      this.button1.Location = new System.Drawing.Point(295, -2);
      this.button1.Margin = new System.Windows.Forms.Padding(0);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(24, 20);
      this.button1.TabIndex = 3;
      this.button1.Text = "&1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button_Click);
      // 
      // button2
      // 
      this.button2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.button2.Image = ((System.Drawing.Image) (resources.GetObject("button2.Image")));
      this.button2.Location = new System.Drawing.Point(306, -1);
      this.button2.Margin = new System.Windows.Forms.Padding(0);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(24, 20);
      this.button2.TabIndex = 6;
      this.button2.Text = "&2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(760, 485);
      this.Controls.Add(this.splitContainer1);
      this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "DiffPic";
      this.Resize += new System.EventHandler(this.MainForm_Resize);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize) (this.pictureBoxXOR)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.pictureBoxDiff)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.Panel2.PerformLayout();
      this.splitContainer2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.Label labelDiff;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.PictureBox pictureBoxDiff;
    private System.Windows.Forms.Label labelHelp;
    private System.Windows.Forms.ComboBox comboBoxZoom;
    private System.Windows.Forms.PictureBox pictureBoxXOR;
    private System.Windows.Forms.Label labelXOR;
    private System.Windows.Forms.Label labelIdentical;
  }
}

