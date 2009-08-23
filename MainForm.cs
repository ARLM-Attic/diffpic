using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Globalization;
using System.Drawing.Drawing2D;

namespace DiffPic {
  public partial class MainForm : Form {
    private static double[] zoomLevels = new double[] {
      2000, 1600, 1200, 1000, 800,
      600, 500, 400, 300, 200,
      150, 125, 100, 83.3, 75,
      66.7, 50, 33.3, 25, 20,
      12.5, 10, 5, 2, 1 };

    /*
    // Support BitBlt
    // http://www.java2s.com/Code/CSharp/Windows/BitBlt.htm
    [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
    private static extern int BitBlt(
      IntPtr hdcDest,     // handle to destination DC (device context)
      int nXDest,         // x-coord of destination upper-left corner
      int nYDest,         // y-coord of destination upper-left corner
      int nWidth,         // width of destination rectangle
      int nHeight,        // height of destination rectangle
      IntPtr hdcSrc,      // handle to source DC
      int nXSrc,          // x-coordinate of source upper-left corner
      int nYSrc,          // y-coordinate of source upper-left corner
      System.Int32 dwRop  // raster operation code
      );
    const int SRCCOPY = 0xCC0020; // dest = source
    const int SRCPAINT = 0xEE0086; // dest = source OR dest
    const int SRCAND = 0x8800C6; // dest = source AND dest
    const int SRCINVERT = 0x660046; // dest = source XOR dest
    const int SRCERASE = 0x440328; // dest = source AND (NOT dest )
    const int NOTSRCCOPY = 0x330008; // dest = (NOT source)
    const int NOTSRCERASE = 0x1100A6; // dest = (NOT src) AND (NOT dest) 
    const int MERGECOPY = 0xC000CA; // dest = (source AND pattern)
    const int MERGEPAINT = 0xBB0226; // dest = (NOT source) OR dest
    const int PATCOPY = 0xF00021; // dest = pattern
    const int PATPAINT = 0xFB0A09; // dest = DPSnoo
    const int PATINVERT = 0x5A0049; // dest = pattern XOR dest
    const int DSTINVERT = 0x550009; // dest = (NOT dest)
    const int BLACKNESS = 0x000042; // dest = BLACK
    const int WHITENESS = 0xFF0062; // dest = WHITE
    */

    public MainForm() {
      InitializeComponent();
      // SetStyle(ControlStyles.Opaque, false);
      // SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      loadCommandLineArgs();
      // http://opinions5.blogspot.com/2008/02/mouse-wheel-event-in-c.html
      MouseWheel += new MouseEventHandler(MainForm_MouseWheel);
      // Load Zoom % box with default values
      this.comboBoxZoom.Items.AddRange(
        zoomLevels.Select(n => n.ToString() + "%").ToArray());
      this.comboBoxZoom.SelectedIndex = 12;
    }

    private void MainForm_Resize(object sender, EventArgs e) {
      pictureBox_doMouseDrag(0, 0);
    }

    // Load images if specified on command line
    // http://www.c-sharpcorner.com/UploadFile/mahesh/CmdLineArgs03212006232449PM/CmdLineArgs.aspx
    private void loadCommandLineArgs() {
      string[] args = Environment.GetCommandLineArgs();
      foreach (string file in args) {
        comboBox1.Items.Add(file);
        comboBox2.Items.Add(file);
      }
      if (args.Length > 1) {
        comboBox1.Text = args[1];
        loadPic1();
        if (args.Length > 2) {
          comboBox2.Text = args[2];
          loadPic2();
        }
      }
    }

    // Handle typing full path into comboboxes
    // http://www.dreamincode.net/forums/showtopic60601.htm

    private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) {
      if (e.KeyChar == (char) Keys.Enter) { loadPic1(); }
    }

    private void comboBox2_KeyPress(object sender, KeyPressEventArgs e) {
      if (e.KeyChar == (char) Keys.Enter) { loadPic2(); }
    }

    // Handle selecting file from combobox drop-down list

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
      loadPic1();
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
      loadPic2();
    }

    // Make combobox dropdown list as wide as widest list item
    // http://www.codeproject.com/KB/combobox/ComboBoxAutoWidth.aspx

    private void AdjustWidthComboBox_DropDown(object sender, System.EventArgs e) {
      ComboBox senderComboBox = (ComboBox) sender;
      int width = senderComboBox.DropDownWidth;
      Graphics g = senderComboBox.CreateGraphics();
      Font font = senderComboBox.Font;
      int vertScrollBarWidth =
          (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
          ? SystemInformation.VerticalScrollBarWidth : 0;

      int newWidth;
      foreach (string s in ((ComboBox) sender).Items) {
        newWidth = (int) g.MeasureString(s, font).Width
            + vertScrollBarWidth;
        if (width < newWidth) {
          width = newWidth;
        }
      }
      senderComboBox.DropDownWidth = width;
    }

    // Open file dialog when pic buttons clicked
    // http://www.java2s.com/Code/CSharp/GUI-Windows-Form/CallShowDialogtodisplayanOpenFileDialog.htm

    private void button_Click(object sender, EventArgs e) {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Title = "Open picture";
      dlg.Filter = "Supported formats|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff|All files|*.*";
      if (dlg.ShowDialog() == DialogResult.OK) {
        // Add file to combobox
        ComboBox cmb = (sender == button1 ? comboBox1 : comboBox2);
        cmb.Items.Add(dlg.FileName);
        cmb.Text = dlg.FileName;
        // Load bitmap
        if (sender == button1) { loadPic1(); } else { loadPic2(); }
      }
    }

    // Handle dragging file(s) into comboboxes
    // http://www.csharphelp.com/archives2/archive365.html

    private void comboBox_DragEnter(object sender, DragEventArgs e) {
      // make sure they're actually dropping files (not text or anything else)
      if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true) {
        // allow them to continue
        // (without this, the cursor stays a "NO" symbol
        e.Effect = DragDropEffects.All;
      }
    }

    private void comboBox_DragDrop(object sender, DragEventArgs e) {
      // transfer the filenames to a string array
      string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
      if (files.Length > 0) {
        if (sender is ComboBox) {
          // loop through the string array, adding each filename to the list
          foreach (string file in files) { ((ComboBox) sender).Items.Add(file); }
          // show first filename in text area
          ((ComboBox) sender).Text = files[0];
        } else { // dragged into picturebox or panel
          foreach (string file in files) {
            comboBox1.Items.Add(file);
            comboBox2.Items.Add(file);
          }
          if (files.Length == 1) { // dragged one file
            if (e.KeyState < 2) { // WHY DOES RMB NOT SET KeyState & 2 TO 1?
              comboBox1.Text = files[0];
            } else {
              comboBox2.Text = files[0];
            }
          } else { // dragged 2 or more files
            comboBox1.Text = files[0];
            comboBox2.Text = files[1];
          }
        }
      }
    }

    private double scaleFactor = 1.0;
    private bool picsAreIdentical;
    private Bitmap bitmap1;
    private Bitmap bitmap2;
    private Bitmap bitmap3;
    private Bitmap bitmap4;

    // Load images into pictureboxes
    //http://www.knightoftheroad.com/post/2008/05/Load-an-image-without-holidng-a-lock.aspx

    private void loadPic1() {
      try {
        using (Stream s = new FileStream(comboBox1.Text, FileMode.Open,
          FileAccess.Read)) { // fails for read-only files without FileAccess.Read
          bitmap1 = (Bitmap) Image.FromStream(s);
          s.Close();
        }
        // The following alternative method locks the file while DiffPic runs:
        // bitmap1 = new Bitmap(comboBox1.Text);
        pictureBox1.Image = bitmap1;
      } catch (Exception e) {
        MessageBox.Show("Could not open \"" + comboBox1.Text + "\":\n" + e.Message);
      }
      loadPic3();
      loadPic4();
      scalePictureBoxes();
      setWindowTitle();
    }

    private void loadPic2() {
      try {
        using (Stream s = new FileStream(comboBox2.Text, FileMode.Open,
          FileAccess.Read)) { // fails for read-only files without FileAccess.Read
          bitmap2 = (Bitmap) Image.FromStream(s);
          s.Close();
        }
        pictureBox2.Image = bitmap2;
      } catch (Exception e) {
        MessageBox.Show("Could not open \"" + comboBox2.Text + "\":\n" + e.Message);
      }
      loadPic3();
      loadPic4();
      scalePictureBoxes();
      setWindowTitle();
    }

    private void loadPic3() {
      if (bitmap1 != null && bitmap2 != null) {
        bitmap3 = new Bitmap(
          Math.Min(bitmap1.Width, bitmap2.Width),
          Math.Min(bitmap1.Height, bitmap2.Height));
        unsafe {
          var d1 = bitmap1.LockBits(
            new Rectangle(0, 0, bitmap1.Width, bitmap1.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
          var d2 = bitmap2.LockBits(
            new Rectangle(0, 0, bitmap2.Width, bitmap2.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
          var d3 = bitmap3.LockBits(
            new Rectangle(0, 0, bitmap3.Width, bitmap3.Height),
            ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
          int ir, ig, ib;
          int lumDiff;
          picsAreIdentical = true;
          for (int y = 0; y < bitmap3.Height; y++) {
            byte* b1 = (byte*) d1.Scan0 + y * d1.Stride;
            byte* b2 = (byte*) d2.Scan0 + y * d2.Stride;
            byte* b3 = (byte*) d3.Scan0 + y * d3.Stride;
            for (int x = 0; x < bitmap3.Width; x++) {
              ib = x * 3; ig = ib + 1; ir = ib + 2;
              lumDiff = (int)
                (0.3 * b2[ir] + 0.59 * b2[ig] + 0.11 * b2[ib] -
                (0.3 * b1[ir] + 0.59 * b1[ig] + 0.11 * b1[ib]) + 0.5);
              if (lumDiff > 0) {
                b3[ir] = 255; // Red channel
                b3[ig] = (byte) lumDiff; // Green channel
                b3[ib] = 0; // Blue channel
                picsAreIdentical = false;
              } else if (lumDiff < 0) {
                b3[ir] = 0; // Red channel
                b3[ig] = (byte) (-lumDiff); // Green channel
                b3[ib] = 255; // Blue channel
                picsAreIdentical = false;
              } else {
                b3[ir] = b3[ig] = b3[ib] = 0;
                if (b1[ir] != b2[ir] || b1[ig] != b2[ig] || b1[ib] != b2[ib]) {
                  picsAreIdentical = false;
                }
              }
            }
          }
          bitmap1.UnlockBits(d1);
          bitmap2.UnlockBits(d2);
          bitmap3.UnlockBits(d3);
        }
        if (picsAreIdentical) {
          Graphics g = Graphics.FromImage(bitmap3);
          g.DrawString("Pics are\nidentical",
            new Font("MS Sans Serif", 12), Brushes.White, new Point(0, 0));
        }
        pictureBoxDiff.Image = bitmap3;
        /*
        // http://www.charlespetzold.com/pwcs/ReadingPixelsFromTheScreen.html
        Graphics g1 = pictureBox1.CreateGraphics(); //Graphics.FromImage(bitmap1);
        Graphics g2 = pictureBox2.CreateGraphics(); //Graphics.FromImage(bitmap2);
        Graphics g3 = Graphics.FromImage(bitmap3);
        IntPtr dc1 = g1.GetHdc();
        IntPtr dc2 = g2.GetHdc();
        IntPtr dc3 = g3.GetHdc();
        BitBlt(dc3, 0, 0, bitmap1.Width, bitmap1.Height, dc1, 0, 0, SRCCOPY);
        BitBlt(dc3, 0, 0, bitmap2.Width, bitmap2.Height, dc2, 0, 0, SRCINVERT);
        g1.ReleaseHdc(dc1);
        g2.ReleaseHdc(dc2);
        g3.ReleaseHdc(dc3);
        g1.Dispose();
        g2.Dispose();
        g3.Dispose();
        */
      }
    }

    private void loadPic4() {
      if (bitmap1 != null && bitmap2 != null) {
        bitmap4 = new Bitmap(
          Math.Min(bitmap1.Width, bitmap2.Width),
          Math.Min(bitmap1.Height, bitmap2.Height), PixelFormat.Format24bppRgb);
        unsafe {
          var d1 = bitmap1.LockBits(
            new Rectangle(0, 0, bitmap1.Width, bitmap1.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
          var d2 = bitmap2.LockBits(
            new Rectangle(0, 0, bitmap2.Width, bitmap2.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
          var d4 = bitmap4.LockBits(
            new Rectangle(0, 0, bitmap4.Width, bitmap4.Height),
            ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
          int i;
          for (int y = 0; y < bitmap4.Height; y++) {
            byte* b1 = (byte*) d1.Scan0 + y * d1.Stride;
            byte* b2 = (byte*) d2.Scan0 + y * d2.Stride;
            byte* b4 = (byte*) d4.Scan0 + y * d4.Stride;
            for (int x = 0; x < bitmap4.Width; x++) {
              i = x * 3; b4[i] = (byte) (b1[i] ^ b2[i]); // Blue channel
              i++; b4[i] = (byte) (b1[i] ^ b2[i]); // Green channel
              i++; b4[i] = (byte) (b1[i] ^ b2[i]); // Red channel
              /*
              for (int rgbChannel = 0; rgbChannel < 3; rgbChannel++) {
                b3[3 * x + rgbChannel] =
                  (byte) (b1[3 * x + rgbChannel] ^ b2[3 * x + rgbChannel]);
              }
              */
            }
          }
          bitmap1.UnlockBits(d1);
          bitmap2.UnlockBits(d2);
          bitmap4.UnlockBits(d4);
        }
        pictureBoxXOR.Image = bitmap4;
      }
    }

    // Panning by left-dragging and showing Pic 2 by right-clicking

    private Point? pointMouseDown; // ? makes it nullable
    private bool isPressedLMB; // left mouse button is pressed
    private bool isPressedRMB; // right mouse button is pressed

    private void pictureBox_doMouseState(MouseEventArgs e) {
      pictureBox2.Visible = pictureBoxDiff.Visible = pictureBoxXOR.Visible = false;
      label1.ForeColor = label2.ForeColor = labelDiff.ForeColor =
        labelXOR.ForeColor = System.Drawing.SystemColors.ControlText;
      label1.BackColor = label2.BackColor = labelDiff.BackColor =
        labelXOR.BackColor = System.Drawing.SystemColors.Control;
      //labelDiff.Text = isPressedLMB + "," + isPressedRMB + pointMouseDown;
      if (isPressedRMB) {
        if (isPressedLMB) { // both LMB and RMB pressed
          labelXOR.ForeColor = System.Drawing.SystemColors.HighlightText;
          labelXOR.BackColor = System.Drawing.SystemColors.Highlight;
          pictureBoxXOR.Visible = true;
        } else { // only RMB pressed
          labelDiff.ForeColor = System.Drawing.SystemColors.HighlightText;
          labelDiff.BackColor = System.Drawing.SystemColors.Highlight;
          pictureBoxDiff.Visible = true;
        }
        //labelIdentical.Visible = picsAreIdentical;
      } else {
        if (isPressedLMB) { // only LMB pressed
          label2.ForeColor = System.Drawing.SystemColors.HighlightText;
          label2.BackColor = System.Drawing.SystemColors.Highlight;
          pictureBox2.Visible = true;
        } else { // neither LMB nor RMB pressed
          label1.ForeColor = System.Drawing.SystemColors.HighlightText;
          label1.BackColor = System.Drawing.SystemColors.Highlight;
        }
        //labelIdentical.Visible = false;
      }
      pointMouseDown = new Point(e.X, e.Y);
    }

    private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) { isPressedLMB = true; } else
        if (e.Button == MouseButtons.Right) { isPressedRMB = true; }
      pictureBox_doMouseState(e);
    }

    private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) { isPressedLMB = false; } else
        if (e.Button == MouseButtons.Right) { isPressedRMB = false; }
      //if (e.Button == MouseButtons.Left) { pointMouseDown = null; }
      pictureBox_doMouseState(e);
    }

    private void pictureBox_doMouseDrag(int x, int y) {
      if (pointMouseDown != null) {
        var p = new Point(
          pictureBox1.Left + x - pointMouseDown.Value.X,
          pictureBox1.Top + y - pointMouseDown.Value.Y);
        p.X = Math.Min(0, Math.Max(p.X, splitContainer1.Panel1.Width - pictureBox1.Width));
        p.Y = Math.Min(0, Math.Max(p.Y, splitContainer1.Panel1.Height - pictureBox1.Height));
        pictureBox1.Location = pictureBox2.Location =
          pictureBoxDiff.Location = pictureBoxXOR.Location = p;
      }
    }

    private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
      if (isPressedLMB || isPressedRMB) { pictureBox_doMouseDrag(e.X, e.Y); }
    }

    private void MainForm_MouseWheel(object sender, MouseEventArgs e) {
      if (e.Delta > 0) { // Scroll up
        if (comboBoxZoom.SelectedIndex > 0) { comboBoxZoom.SelectedIndex--; }
      } else { // Scroll down
        if (comboBoxZoom.SelectedIndex < comboBoxZoom.Items.Count - 1) {
          comboBoxZoom.SelectedIndex++;
        }
      }
    }

    private void setScaleFactor() {
      if (comboBoxZoom.Text != "") {
        try {
          scaleFactor = Double.Parse(comboBoxZoom.Text.Replace("%", "")) * 0.01;
        } catch (Exception e) {
          MessageBox.Show(e.Message);
          scaleFactor = 1.0;
        }
        scalePictureBoxes();
      }
    }

    private void scalePictureBoxes() {
      if (bitmap1 != null) {
        pictureBox1.Width = (int) Math.Round(bitmap1.Width * scaleFactor);
        pictureBox1.Height = (int) Math.Round(bitmap1.Height * scaleFactor);
        /*
        Bitmap rescaled = new Bitmap((int) Math.Round(bitmap1.Width * scaleFactor),
         (int) Math.Round(bitmap1.Height * scaleFactor), PixelFormat.Format24bppRgb);
        Graphics g = Graphics.FromImage(rescaled);
        g.InterpolationMode = InterpolationMode.NearestNeighbor;
        g.DrawImage(bitmap1, 0, 0, rescaled.Width, rescaled.Height);
        pictureBox1.Image = rescaled;
         * */
      }
      if (bitmap2 != null) {
        pictureBox2.Width = (int) Math.Round(bitmap2.Width * scaleFactor);
        pictureBox2.Height = (int) Math.Round(bitmap2.Height * scaleFactor);
      }
      if (bitmap3 != null) {
        pictureBoxDiff.Width = (int) Math.Round(bitmap3.Width * scaleFactor);
        pictureBoxDiff.Height = (int) Math.Round(bitmap3.Height * scaleFactor);
      }
      if (bitmap4 != null) {
        pictureBoxXOR.Width = (int) Math.Round(bitmap4.Width * scaleFactor);
        pictureBoxXOR.Height = (int) Math.Round(bitmap4.Height * scaleFactor);
      }
    }

    private void comboBoxZoom_SelectedIndexChanged(object sender, EventArgs e) {
      setScaleFactor();
    }

    private void comboBoxZoom_KeyPress(object sender, KeyPressEventArgs e) {
      if (e.KeyChar == (char) Keys.Enter) {
        setScaleFactor();
        comboBoxZoom.Text = (scaleFactor * 100).ToString() + "%";
        comboBoxZoom.SelectAll();
      }
    }

    private void setWindowTitle() {
      string path1 = comboBox1.Text;
      string path2 = comboBox2.Text;
      string subpath1, subpath2;
      int indexLastSeparator1 = path1.Length;
      int indexLastSeparator2 = path2.Length;
      do {
        indexLastSeparator1 = path1.Substring(0, indexLastSeparator1).LastIndexOf('\\');
        indexLastSeparator2 = path2.Substring(0, indexLastSeparator2).LastIndexOf('\\');
        subpath1 = path1.Substring(indexLastSeparator1 + 1);
        subpath2 = path2.Substring(indexLastSeparator2 + 1);
        if (path1.Equals(path2)) { break; } // use filename if paths are the same
      } while (subpath1.Equals(subpath2));
      this.Text = subpath1 + " " + subpath2 + " - DiffPic";
      //this.Text = comboBox1.Text.Substring(comboBox1.Text.LastIndexOf('\\') + 1) +
      //  " " + comboBox2.Text.Substring(comboBox2.Text.LastIndexOf('\\') + 1) + " - DiffPic";
    }

    /*
    // Handle triple-clicking of path comboboxes
    private int[] nMouseClick = {0, 0}; // 0th=comboBox1,1st=comboBox2
    private int? indexLastClicked = null;
    private DateTime timeLastClicked = DateTime.Now;
    private int countClicks(int index) {
      nMouseClick[index] = (index == indexLastClicked &&
        DateTime.Now - timeLastClicked <
        TimeSpan.FromMilliseconds(SystemInformation.DoubleClickTime) ?
        nMouseClick[index] + 1 : 1);
      indexLastClicked = index;
      timeLastClicked = DateTime.Now;
      return nMouseClick[index];
    }

    private void comboBox1_MouseDown(object sender, MouseEventArgs e) {
      if (countClicks(0) > 2) { comboBox1.SelectAll(); }
    }
    private void comboBox2_MouseDown(object sender, MouseEventArgs e) {
      if (countClicks(1) > 2) { comboBox1.SelectAll(); }
    }
    */
  }
}
