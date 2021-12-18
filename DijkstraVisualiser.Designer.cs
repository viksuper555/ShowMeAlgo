﻿
namespace ShowMeAlgo
{
    partial class DijkstraVisualiser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btRestart = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btRestart
            // 
            this.btRestart.Location = new System.Drawing.Point(78, 41);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(89, 23);
            this.btRestart.TabIndex = 0;
            this.btRestart.Text = "Restart";
            this.btRestart.UseVisualStyleBackColor = true;
            this.btRestart.Click += new System.EventHandler(this.btRestart_Click);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(254, 41);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 1;
            this.btNext.Text = "Next step";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(173, 41);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 2;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(704, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Made by viksuper555";
            // 
            // btGenerate
            // 
            this.btGenerate.Location = new System.Drawing.Point(335, 41);
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Size = new System.Drawing.Size(94, 23);
            this.btGenerate.TabIndex = 4;
            this.btGenerate.Text = "GenerateGraph";
            this.btGenerate.UseVisualStyleBackColor = true;
            this.btGenerate.Click += new System.EventHandler(this.btGenerate_Click);
            // 
            // DijkstraVisualiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.btGenerate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btRestart);
            this.KeyPreview = true;
            this.Name = "DijkstraVisualiser";
            this.Text = "Dijkstra Visualiser";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRestart;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGenerate;
    }
}
