namespace CatlabuhApp.UI.Main.UC
{
    partial class SeriesGridView
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeriesGridView));
            this.contentTLP = new System.Windows.Forms.TableLayoutPanel();
            this.headerTLP = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.headerTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentTLP
            // 
            resources.ApplyResources(this.contentTLP, "contentTLP");
            this.contentTLP.Name = "contentTLP";
            // 
            // headerTLP
            // 
            this.headerTLP.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.headerTLP, "headerTLP");
            this.headerTLP.Controls.Add(this.label8, 5, 0);
            this.headerTLP.Controls.Add(this.label6, 7, 0);
            this.headerTLP.Controls.Add(this.label5, 3, 0);
            this.headerTLP.Controls.Add(this.label9, 4, 0);
            this.headerTLP.Controls.Add(this.label3, 1, 0);
            this.headerTLP.Controls.Add(this.label4, 2, 0);
            this.headerTLP.Controls.Add(this.label7, 6, 0);
            this.headerTLP.Controls.Add(this.label2, 0, 0);
            this.headerTLP.Name = "headerTLP";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // SeriesGridView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerTLP);
            this.Controls.Add(this.contentTLP);
            this.DoubleBuffered = true;
            this.Name = "SeriesGridView";
            this.headerTLP.ResumeLayout(false);
            this.headerTLP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel contentTLP;
        private System.Windows.Forms.TableLayoutPanel headerTLP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
    }
}
