
namespace ShowMeAlgo
{
    partial class GenerateForm
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
            this.inputNodes = new System.Windows.Forms.NumericUpDown();
            this.inputMaxEdgeWeight = new System.Windows.Forms.NumericUpDown();
            this.btConfirm = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputEdgeDepth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputNodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMaxEdgeWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputEdgeDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // inputNodes
            // 
            this.inputNodes.Location = new System.Drawing.Point(116, 45);
            this.inputNodes.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.inputNodes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputNodes.Name = "inputNodes";
            this.inputNodes.Size = new System.Drawing.Size(50, 23);
            this.inputNodes.TabIndex = 0;
            this.inputNodes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // inputMaxEdgeWeight
            // 
            this.inputMaxEdgeWeight.Location = new System.Drawing.Point(116, 95);
            this.inputMaxEdgeWeight.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.inputMaxEdgeWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputMaxEdgeWeight.Name = "inputMaxEdgeWeight";
            this.inputMaxEdgeWeight.Size = new System.Drawing.Size(50, 23);
            this.inputMaxEdgeWeight.TabIndex = 1;
            this.inputMaxEdgeWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btConfirm
            // 
            this.btConfirm.Location = new System.Drawing.Point(130, 218);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(75, 23);
            this.btConfirm.TabIndex = 2;
            this.btConfirm.Text = "Confirm";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(25, 218);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nodes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max weight";
            // 
            // inputEdgeDepth
            // 
            this.inputEdgeDepth.Location = new System.Drawing.Point(116, 147);
            this.inputEdgeDepth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.inputEdgeDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputEdgeDepth.Name = "inputEdgeDepth";
            this.inputEdgeDepth.Size = new System.Drawing.Size(50, 23);
            this.inputEdgeDepth.TabIndex = 1;
            this.inputEdgeDepth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Edge depth";
            // 
            // GenerateForm
            // 
            this.AcceptButton = this.btConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(217, 253);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.inputEdgeDepth);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.inputMaxEdgeWeight);
            this.Controls.Add(this.inputNodes);
            this.Name = "GenerateForm";
            this.Text = "Generate Graph";
            this.Load += new System.EventHandler(this.GenerateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputNodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMaxEdgeWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputEdgeDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown inputNodes;
        private System.Windows.Forms.NumericUpDown inputMaxEdgeWeight;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown inputEdgeDepth;
        private System.Windows.Forms.Label label3;
    }
}