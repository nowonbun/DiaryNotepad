namespace DiaryNotepad
{
    partial class ImageListForm
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
            this.imageList1 = new DiaryNotepad.ImageList();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageList1.Location = new System.Drawing.Point(0, 0);
            this.imageList1.Name = "imageList1";
            this.imageList1.Size = new System.Drawing.Size(184, 546);
            this.imageList1.TabIndex = 0;
            // 
            // ImageListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 546);
            this.Controls.Add(this.imageList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(980, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ImageList";
            this.ResumeLayout(false);

        }

        #endregion

        private ImageList imageList1;
    }
}