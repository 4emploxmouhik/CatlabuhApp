using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Forms
{
    public partial class GatewayScheduleForm : Form
    {
        private bool isShown;
        public bool IsShown { get => isShown; }

        public Form MainForm { get; set; }

        

        public GatewayScheduleForm()
        {
            isShown = false;

            InitializeComponent();
        }



        private void GatewayScheduleForm_Load(object sender, EventArgs e)
        {

        }

        private void GatewayScheduleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isShown = false;
        }

        public new void Show()
        {
            Location = new Point(MainForm.Location.X + MainForm.Width - (MainForm.Width / 3), MainForm.Location.Y + 50);
            isShown = true;

            base.Show();
        }

    }
}
