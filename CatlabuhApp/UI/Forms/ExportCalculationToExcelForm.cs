﻿using System;
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
    public partial class ExportCalculationToExcelForm : Form, IBaseView
    {
        public ExportCalculationToExcelForm()
        {
            InitializeComponent();
        }

        public void GetCultureInfo()
        {
            new BaseView().GetCultureInfo();
        }
    }
}
