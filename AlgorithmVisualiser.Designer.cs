
namespace ShowMeAlgo
{
    partial class AlgorithmVisualiser
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
            this.btSwitchAlgorithm = new System.Windows.Forms.Button();
            this.labelCurrentAlgo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btRestart
            // 
            this.btRestart.Location = new System.Drawing.Point(111, 68);
            this.btRestart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(127, 38);
            this.btRestart.TabIndex = 0;
            this.btRestart.Text = "Restart";
            this.btRestart.UseVisualStyleBackColor = true;
            this.btRestart.Click += new System.EventHandler(this.btRestart_Click);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(363, 68);
            this.btNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(107, 38);
            this.btNext.TabIndex = 1;
            this.btNext.Text = "Next step";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(247, 68);
            this.btClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(107, 38);
            this.btClear.TabIndex = 2;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1006, 728);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Made by viksuper555";
            // 
            // btGenerate
            // 
            this.btGenerate.Location = new System.Drawing.Point(479, 68);
            this.btGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Size = new System.Drawing.Size(141, 38);
            this.btGenerate.TabIndex = 4;
            this.btGenerate.Text = "GenerateGraph";
            this.btGenerate.UseVisualStyleBackColor = true;
            this.btGenerate.Click += new System.EventHandler(this.btGenerate_Click);
            // 
            // btSwitchAlgorithm
            // 
            this.btSwitchAlgorithm.AutoSize = true;
            this.btSwitchAlgorithm.Location = new System.Drawing.Point(628, 68);
            this.btSwitchAlgorithm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSwitchAlgorithm.Name = "btSwitchAlgorithm";
            this.btSwitchAlgorithm.Size = new System.Drawing.Size(164, 38);
            this.btSwitchAlgorithm.TabIndex = 4;
            this.btSwitchAlgorithm.Text = "Change algorithm";
            this.btSwitchAlgorithm.UseVisualStyleBackColor = true;
            this.btSwitchAlgorithm.Click += new System.EventHandler(this.btSwitchAlgorithm_Click);
            // 
            // labelCurrentAlgo
            // 
            this.labelCurrentAlgo.AutoSize = true;
            this.labelCurrentAlgo.Location = new System.Drawing.Point(799, 75);
            this.labelCurrentAlgo.Name = "labelCurrentAlgo";
            this.labelCurrentAlgo.Size = new System.Drawing.Size(71, 25);
            this.labelCurrentAlgo.TabIndex = 5;
            this.labelCurrentAlgo.Text = "Dijkstra";
            // 
            // AlgorithmVisualiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 768);
            this.Controls.Add(this.labelCurrentAlgo);
            this.Controls.Add(this.btSwitchAlgorithm);
            this.Controls.Add(this.btGenerate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btRestart);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AlgorithmVisualiser";
            this.Text = "Algorithm Visualiser";
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
        private System.Windows.Forms.Button btSwitchAlgorithm;
        private System.Windows.Forms.Label labelCurrentAlgo;
    }
}

