using System;

namespace Fern
{
    partial class Form1
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
            this.FernPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FernPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FernPictureBox
            // 
            this.FernPictureBox.Location = new System.Drawing.Point(-1, -1);
            this.FernPictureBox.Name = "FernPictureBox";
            this.FernPictureBox.Size = new System.Drawing.Size(800, 640);
            this.FernPictureBox.TabIndex = 0;
            this.FernPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 639);
            this.Controls.Add(this.FernPictureBox);
            this.Name = "Form1";
            this.Text = "Barnsley Fern";
            ((System.ComponentModel.ISupportInitialize)(this.FernPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FernPictureBox;
    }
}

