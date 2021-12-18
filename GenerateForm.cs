using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowMeAlgo
{
    public partial class GenerateForm : Form
    {
        public int NodeCount { get; set; }
        public int MaxEdgeWeight { get; set; }
        public int EdgeDepth { get; set; }
        public GenerateForm()
        {
            InitializeComponent();
        }

        private void GenerateForm_Load(object sender, EventArgs e)
        {

        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            NodeCount = (int)inputNodes.Value;
            MaxEdgeWeight = (int)inputMaxEdgeWeight.Value;
            EdgeDepth = (int)inputEdgeDepth.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
