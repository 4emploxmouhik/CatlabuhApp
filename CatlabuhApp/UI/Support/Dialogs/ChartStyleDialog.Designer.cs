namespace CatlabuhApp.UI.Support.Dialogs
{
    partial class ChartStyleDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartStyleDialog));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.genralPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.regularChoice1 = new System.Windows.Forms.RadioButton();
            this.underlineChoice1 = new System.Windows.Forms.RadioButton();
            this.italicChoice1 = new System.Windows.Forms.RadioButton();
            this.boldChoice1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chartTitleBox = new System.Windows.Forms.TextBox();
            this.textSize1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.regularChoice3 = new System.Windows.Forms.RadioButton();
            this.yAxisTitleBox = new System.Windows.Forms.TextBox();
            this.textSize3 = new System.Windows.Forms.NumericUpDown();
            this.underlineChoice3 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.boldChoice3 = new System.Windows.Forms.RadioButton();
            this.italicChoice3 = new System.Windows.Forms.RadioButton();
            this.regularChoice2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.underlineChoice2 = new System.Windows.Forms.RadioButton();
            this.xAxisTitleBox = new System.Windows.Forms.TextBox();
            this.italicChoice2 = new System.Windows.Forms.RadioButton();
            this.boldChoice2 = new System.Windows.Forms.RadioButton();
            this.textSize2 = new System.Windows.Forms.NumericUpDown();
            this.gridPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.yAxisMinorGridStyle = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.yAxisMajorGridStyle = new System.Windows.Forms.ComboBox();
            this.showYAxisMinorGrid = new System.Windows.Forms.CheckBox();
            this.showYAxisMajorGrid = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.xAxisMinorGridStyle = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.showXAxisMinorGrid = new System.Windows.Forms.CheckBox();
            this.xAxisMajorGridStyle = new System.Windows.Forms.ComboBox();
            this.showXAxisMajorGrid = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.showGrid = new System.Windows.Forms.CheckBox();
            this.seriesPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.seriesGridView = new Main.UC.SeriesGridView();
            this.tabControl.SuspendLayout();
            this.genralPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSize1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSize3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSize2)).BeginInit();
            this.gridPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.genralPage);
            this.tabControl.Controls.Add(this.gridPage);
            this.tabControl.Controls.Add(this.seriesPage);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // genralPage
            // 
            resources.ApplyResources(this.genralPage, "genralPage");
            this.genralPage.BackColor = System.Drawing.SystemColors.Control;
            this.genralPage.Controls.Add(this.groupBox2);
            this.genralPage.Controls.Add(this.groupBox1);
            this.genralPage.Name = "genralPage";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.regularChoice1);
            this.groupBox2.Controls.Add(this.underlineChoice1);
            this.groupBox2.Controls.Add(this.italicChoice1);
            this.groupBox2.Controls.Add(this.boldChoice1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chartTitleBox);
            this.groupBox2.Controls.Add(this.textSize1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // regularChoice1
            // 
            resources.ApplyResources(this.regularChoice1, "regularChoice1");
            this.regularChoice1.Checked = true;
            this.regularChoice1.Name = "regularChoice1";
            this.regularChoice1.TabStop = true;
            this.regularChoice1.UseVisualStyleBackColor = true;
            // 
            // underlineChoice1
            // 
            resources.ApplyResources(this.underlineChoice1, "underlineChoice1");
            this.underlineChoice1.Name = "underlineChoice1";
            this.underlineChoice1.UseVisualStyleBackColor = true;
            // 
            // italicChoice1
            // 
            resources.ApplyResources(this.italicChoice1, "italicChoice1");
            this.italicChoice1.Name = "italicChoice1";
            this.italicChoice1.UseVisualStyleBackColor = true;
            // 
            // boldChoice1
            // 
            resources.ApplyResources(this.boldChoice1, "boldChoice1");
            this.boldChoice1.Name = "boldChoice1";
            this.boldChoice1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chartTitleBox
            // 
            resources.ApplyResources(this.chartTitleBox, "chartTitleBox");
            this.chartTitleBox.Name = "chartTitleBox";
            this.chartTitleBox.Tag = "chart";
            // 
            // textSize1
            // 
            resources.ApplyResources(this.textSize1, "textSize1");
            this.textSize1.Name = "textSize1";
            this.textSize1.Tag = "chart";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.regularChoice2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.underlineChoice2);
            this.groupBox1.Controls.Add(this.xAxisTitleBox);
            this.groupBox1.Controls.Add(this.italicChoice2);
            this.groupBox1.Controls.Add(this.boldChoice2);
            this.groupBox1.Controls.Add(this.textSize2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.regularChoice3);
            this.panel2.Controls.Add(this.yAxisTitleBox);
            this.panel2.Controls.Add(this.textSize3);
            this.panel2.Controls.Add(this.underlineChoice3);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.boldChoice3);
            this.panel2.Controls.Add(this.italicChoice3);
            this.panel2.Name = "panel2";
            // 
            // regularChoice3
            // 
            resources.ApplyResources(this.regularChoice3, "regularChoice3");
            this.regularChoice3.Checked = true;
            this.regularChoice3.Name = "regularChoice3";
            this.regularChoice3.TabStop = true;
            this.regularChoice3.UseVisualStyleBackColor = true;
            // 
            // yAxisTitleBox
            // 
            resources.ApplyResources(this.yAxisTitleBox, "yAxisTitleBox");
            this.yAxisTitleBox.Name = "yAxisTitleBox";
            this.yAxisTitleBox.Tag = "yAxis";
            // 
            // textSize3
            // 
            resources.ApplyResources(this.textSize3, "textSize3");
            this.textSize3.Name = "textSize3";
            this.textSize3.Tag = "chart";
            // 
            // underlineChoice3
            // 
            resources.ApplyResources(this.underlineChoice3, "underlineChoice3");
            this.underlineChoice3.Name = "underlineChoice3";
            this.underlineChoice3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // boldChoice3
            // 
            resources.ApplyResources(this.boldChoice3, "boldChoice3");
            this.boldChoice3.Name = "boldChoice3";
            this.boldChoice3.UseVisualStyleBackColor = true;
            // 
            // italicChoice3
            // 
            resources.ApplyResources(this.italicChoice3, "italicChoice3");
            this.italicChoice3.Name = "italicChoice3";
            this.italicChoice3.UseVisualStyleBackColor = true;
            // 
            // regularChoice2
            // 
            resources.ApplyResources(this.regularChoice2, "regularChoice2");
            this.regularChoice2.Checked = true;
            this.regularChoice2.Name = "regularChoice2";
            this.regularChoice2.TabStop = true;
            this.regularChoice2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // underlineChoice2
            // 
            resources.ApplyResources(this.underlineChoice2, "underlineChoice2");
            this.underlineChoice2.Name = "underlineChoice2";
            this.underlineChoice2.UseVisualStyleBackColor = true;
            // 
            // xAxisTitleBox
            // 
            resources.ApplyResources(this.xAxisTitleBox, "xAxisTitleBox");
            this.xAxisTitleBox.Name = "xAxisTitleBox";
            this.xAxisTitleBox.Tag = "xAxis";
            // 
            // italicChoice2
            // 
            resources.ApplyResources(this.italicChoice2, "italicChoice2");
            this.italicChoice2.Name = "italicChoice2";
            this.italicChoice2.UseVisualStyleBackColor = true;
            // 
            // boldChoice2
            // 
            resources.ApplyResources(this.boldChoice2, "boldChoice2");
            this.boldChoice2.Name = "boldChoice2";
            this.boldChoice2.UseVisualStyleBackColor = true;
            // 
            // textSize2
            // 
            resources.ApplyResources(this.textSize2, "textSize2");
            this.textSize2.Name = "textSize2";
            this.textSize2.Tag = "chart";
            // 
            // gridPage
            // 
            resources.ApplyResources(this.gridPage, "gridPage");
            this.gridPage.BackColor = System.Drawing.SystemColors.Control;
            this.gridPage.Controls.Add(this.groupBox4);
            this.gridPage.Controls.Add(this.groupBox3);
            this.gridPage.Controls.Add(this.showGrid);
            this.gridPage.Name = "gridPage";
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.yAxisMinorGridStyle);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.yAxisMajorGridStyle);
            this.groupBox4.Controls.Add(this.showYAxisMinorGrid);
            this.groupBox4.Controls.Add(this.showYAxisMajorGrid);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // yAxisMinorGridStyle
            // 
            resources.ApplyResources(this.yAxisMinorGridStyle, "yAxisMinorGridStyle");
            this.yAxisMinorGridStyle.FormattingEnabled = true;
            this.yAxisMinorGridStyle.Items.AddRange(new object[] {
            resources.GetString("yAxisMinorGridStyle.Items"),
            resources.GetString("yAxisMinorGridStyle.Items1"),
            resources.GetString("yAxisMinorGridStyle.Items2")});
            this.yAxisMinorGridStyle.Name = "yAxisMinorGridStyle";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // yAxisMajorGridStyle
            // 
            resources.ApplyResources(this.yAxisMajorGridStyle, "yAxisMajorGridStyle");
            this.yAxisMajorGridStyle.FormattingEnabled = true;
            this.yAxisMajorGridStyle.Items.AddRange(new object[] {
            resources.GetString("yAxisMajorGridStyle.Items"),
            resources.GetString("yAxisMajorGridStyle.Items1"),
            resources.GetString("yAxisMajorGridStyle.Items2")});
            this.yAxisMajorGridStyle.Name = "yAxisMajorGridStyle";
            // 
            // showYAxisMinorGrid
            // 
            resources.ApplyResources(this.showYAxisMinorGrid, "showYAxisMinorGrid");
            this.showYAxisMinorGrid.Name = "showYAxisMinorGrid";
            this.showYAxisMinorGrid.UseVisualStyleBackColor = true;
            this.showYAxisMinorGrid.CheckedChanged += new System.EventHandler(this.ShowAxisGrid_CheckedChanged);
            // 
            // showYAxisMajorGrid
            // 
            resources.ApplyResources(this.showYAxisMajorGrid, "showYAxisMajorGrid");
            this.showYAxisMajorGrid.Checked = true;
            this.showYAxisMajorGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showYAxisMajorGrid.Name = "showYAxisMajorGrid";
            this.showYAxisMajorGrid.UseVisualStyleBackColor = true;
            this.showYAxisMajorGrid.CheckedChanged += new System.EventHandler(this.ShowAxisGrid_CheckedChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.xAxisMinorGridStyle);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.showXAxisMinorGrid);
            this.groupBox3.Controls.Add(this.xAxisMajorGridStyle);
            this.groupBox3.Controls.Add(this.showXAxisMajorGrid);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // xAxisMinorGridStyle
            // 
            resources.ApplyResources(this.xAxisMinorGridStyle, "xAxisMinorGridStyle");
            this.xAxisMinorGridStyle.FormattingEnabled = true;
            this.xAxisMinorGridStyle.Items.AddRange(new object[] {
            resources.GetString("xAxisMinorGridStyle.Items"),
            resources.GetString("xAxisMinorGridStyle.Items1"),
            resources.GetString("xAxisMinorGridStyle.Items2")});
            this.xAxisMinorGridStyle.Name = "xAxisMinorGridStyle";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // showXAxisMinorGrid
            // 
            resources.ApplyResources(this.showXAxisMinorGrid, "showXAxisMinorGrid");
            this.showXAxisMinorGrid.Name = "showXAxisMinorGrid";
            this.showXAxisMinorGrid.UseVisualStyleBackColor = true;
            this.showXAxisMinorGrid.CheckedChanged += new System.EventHandler(this.ShowAxisGrid_CheckedChanged);
            // 
            // xAxisMajorGridStyle
            // 
            resources.ApplyResources(this.xAxisMajorGridStyle, "xAxisMajorGridStyle");
            this.xAxisMajorGridStyle.FormattingEnabled = true;
            this.xAxisMajorGridStyle.Items.AddRange(new object[] {
            resources.GetString("xAxisMajorGridStyle.Items"),
            resources.GetString("xAxisMajorGridStyle.Items1"),
            resources.GetString("xAxisMajorGridStyle.Items2")});
            this.xAxisMajorGridStyle.Name = "xAxisMajorGridStyle";
            // 
            // showXAxisMajorGrid
            // 
            resources.ApplyResources(this.showXAxisMajorGrid, "showXAxisMajorGrid");
            this.showXAxisMajorGrid.Checked = true;
            this.showXAxisMajorGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showXAxisMajorGrid.Name = "showXAxisMajorGrid";
            this.showXAxisMajorGrid.UseVisualStyleBackColor = true;
            this.showXAxisMajorGrid.CheckedChanged += new System.EventHandler(this.ShowAxisGrid_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // showGrid
            // 
            resources.ApplyResources(this.showGrid, "showGrid");
            this.showGrid.Checked = true;
            this.showGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGrid.Name = "showGrid";
            this.showGrid.UseVisualStyleBackColor = true;
            this.showGrid.CheckedChanged += new System.EventHandler(this.ShowGrid_CheckedChanged);
            // 
            // seriesPage
            // 
            resources.ApplyResources(this.seriesPage, "seriesPage");
            this.seriesPage.Controls.Add(this.seriesGridView);
            this.seriesPage.BackColor = System.Drawing.SystemColors.Control;
            this.seriesPage.Name = "seriesPage";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.apply);
            this.panel1.Name = "panel1";
            // 
            // cancel
            // 
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // apply
            // 
            resources.ApplyResources(this.apply, "apply");
            this.apply.Name = "apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.Apply_Click);
            //
            // seriesGridView
            //
            resources.ApplyResources(this.seriesGridView, "seriesGridView");
            this.seriesGridView.Name = "seriesGridView";
            this.seriesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // ChartStyleDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartStyleDialog";
            this.ShowInTaskbar = false;
            this.tabControl.ResumeLayout(false);
            this.genralPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSize1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSize3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSize2)).EndInit();
            this.gridPage.ResumeLayout(false);
            this.gridPage.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage genralPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox chartTitleBox;
        private System.Windows.Forms.NumericUpDown textSize1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox xAxisTitleBox;
        private System.Windows.Forms.TextBox yAxisTitleBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage gridPage;
        private System.Windows.Forms.RadioButton regularChoice1;
        private System.Windows.Forms.RadioButton underlineChoice1;
        private System.Windows.Forms.RadioButton italicChoice1;
        private System.Windows.Forms.RadioButton boldChoice1;
        private System.Windows.Forms.RadioButton regularChoice3;
        private System.Windows.Forms.RadioButton underlineChoice3;
        private System.Windows.Forms.RadioButton italicChoice3;
        private System.Windows.Forms.RadioButton boldChoice3;
        private System.Windows.Forms.NumericUpDown textSize3;
        private System.Windows.Forms.RadioButton regularChoice2;
        private System.Windows.Forms.RadioButton underlineChoice2;
        private System.Windows.Forms.RadioButton italicChoice2;
        private System.Windows.Forms.RadioButton boldChoice2;
        private System.Windows.Forms.NumericUpDown textSize2;
        private System.Windows.Forms.ComboBox xAxisMajorGridStyle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox showGrid;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox yAxisMinorGridStyle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox yAxisMajorGridStyle;
        private System.Windows.Forms.CheckBox showYAxisMinorGrid;
        private System.Windows.Forms.CheckBox showYAxisMajorGrid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox xAxisMinorGridStyle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox showXAxisMinorGrid;
        private System.Windows.Forms.CheckBox showXAxisMajorGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TabPage seriesPage;
        private Main.UC.SeriesGridView seriesGridView;
    }
}