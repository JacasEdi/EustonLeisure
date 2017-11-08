using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EustonLeisure
{
    partial class TrendingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.tbHashtags = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbHashtags
            // 
            this.tbHashtags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHashtags.BackColor = System.Drawing.SystemColors.Control;
            this.tbHashtags.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHashtags.ForeColor = System.Drawing.Color.Black;
            this.tbHashtags.Location = new System.Drawing.Point(13, 13);
            this.tbHashtags.Multiline = true;
            this.tbHashtags.Name = "tbHashtags";
            this.tbHashtags.ReadOnly = true;
            this.tbHashtags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHashtags.Size = new System.Drawing.Size(357, 295);
            this.tbHashtags.TabIndex = 0;
            // 
            // TrendingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 320);
            this.Controls.Add(this.tbHashtags);
            this.Name = "TrendingForm";
            this.Text = "TrendingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbHashtags;
    }
}