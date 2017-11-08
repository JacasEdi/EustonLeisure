using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace EustonLeisure
{
    partial class MentionsForm
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
            this.tbMentions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbMentions
            // 
            this.tbMentions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMentions.BackColor = System.Drawing.SystemColors.Control;
            this.tbMentions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMentions.ForeColor = System.Drawing.Color.Black;
            this.tbMentions.Location = new System.Drawing.Point(13, 13);
            this.tbMentions.Multiline = true;
            this.tbMentions.Name = "tbMentions";
            this.tbMentions.ReadOnly = true;
            this.tbMentions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMentions.Size = new System.Drawing.Size(357, 295);
            this.tbMentions.TabIndex = 1;
            // 
            // MentionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 320);
            this.Controls.Add(this.tbMentions);
            this.Name = "MentionsForm";
            this.Text = "MentionsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbMentions;
    }
}