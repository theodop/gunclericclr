using guncleric.winforms.Rendering;
using GunCleric.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guncleric.winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var outputter = new WinFormsOutputter(richTextBox1);
            var gameController = new GameFactory().GetGameController(outputter);
            Task.Run(() => gameController.Start());
        }
    }
}
