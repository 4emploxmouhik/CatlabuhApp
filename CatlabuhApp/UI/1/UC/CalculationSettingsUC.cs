using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CatlabuhApp.Data.Access;

namespace CatlabuhApp.UI.UC
{
    public partial class CalculationSettingsUC : UserControl, IDataViewUC
    {
        public IDataAccess DataAccess { get; set; }
        private List<TextBox> table_3_1Boxes = new List<TextBox>();
        private List<TextBox> table_3_2Boxes = new List<TextBox>();
        private double[,] table_3_1 = new double[3, 12];
        private double[,] table_3_2 = new double[3, 12];

        private List<TextBox> coefficientsBoxes = new List<TextBox>();
        private double[] coefficients = new double[34];
                
        public CalculationSettingsUC()
        {
            InitializeComponent();

            table_3_1Boxes.AddRange(new TextBox[] {
                table_3_1ItemBox0, table_3_1ItemBox1, table_3_1ItemBox2, table_3_1ItemBox3, table_3_1ItemBox4, table_3_1ItemBox5, table_3_1ItemBox6, table_3_1ItemBox7,
                table_3_1ItemBox8, table_3_1ItemBox9, table_3_1ItemBox10, table_3_1ItemBox11, table_3_1ItemBox12, table_3_1ItemBox13, table_3_1ItemBox14, table_3_1ItemBox15,
                table_3_1ItemBox16, table_3_1ItemBox17, table_3_1ItemBox18, table_3_1ItemBox19, table_3_1ItemBox20, table_3_1ItemBox21, table_3_1ItemBox22, table_3_1ItemBox23,
                table_3_1ItemBox24, table_3_1ItemBox25, table_3_1ItemBox26, table_3_1ItemBox27, table_3_1ItemBox28, table_3_1ItemBox29, table_3_1ItemBox30, table_3_1ItemBox31,
                table_3_1ItemBox32, table_3_1ItemBox33, table_3_1ItemBox34, table_3_1ItemBox35
            });
            table_3_2Boxes.AddRange(new TextBox[] {
                table_3_2ItemBox0, table_3_2ItemBox1, table_3_2ItemBox2, table_3_2ItemBox3, table_3_2ItemBox4, table_3_2ItemBox5, table_3_2ItemBox6, table_3_2ItemBox7,
                table_3_2ItemBox8, table_3_2ItemBox9, table_3_2ItemBox10, table_3_2ItemBox11, table_3_2ItemBox12, table_3_2ItemBox13, table_3_2ItemBox14, table_3_2ItemBox15,
                table_3_2ItemBox16, table_3_2ItemBox17, table_3_2ItemBox18, table_3_2ItemBox19, table_3_2ItemBox20, table_3_2ItemBox21, table_3_2ItemBox22, table_3_2ItemBox23,
                table_3_2ItemBox24, table_3_2ItemBox25, table_3_2ItemBox26, table_3_2ItemBox27, table_3_2ItemBox28, table_3_2ItemBox29, table_3_2ItemBox30, table_3_2ItemBox31,
                table_3_2ItemBox32, table_3_2ItemBox33, table_3_2ItemBox34, table_3_2ItemBox35
            });
            coefficientsBoxes.AddRange(new TextBox[] {
                coefficientBox0, coefficientBox1, coefficientBox2, coefficientBox3, coefficientBox4, coefficientBox5, coefficientBox6, coefficientBox7, coefficientBox8,
                coefficientBox9, coefficientBox10, coefficientBox11, coefficientBox12, coefficientBox13, coefficientBox14, coefficientBox15, coefficientBox16, coefficientBox17,
                coefficientBox18, coefficientBox19, coefficientBox20, coefficientBox21, coefficientBox22, coefficientBox23, coefficientBox24, coefficientBox25, coefficientBox26,
                coefficientBox27, coefficientBox28, coefficientBox29, coefficientBox30, coefficientBox31, coefficientBox32, coefficientBox33, coefficientBox34
            });
        }

        public CalculationSettingsUC(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;

            table_3_1 = DataAccess.GetTableData<double>("Table_3_1", 12, new string[] { "HighWaterLevel", "AverageWaterLevel", "LowWaterLevel" });
            table_3_2 = DataAccess.GetTableData<double>("Table_3_2", 12, new string[] { "HighWaterLevel", "AverageWaterLevel", "LowWaterLevel" });
            coefficients = DataAccess.GetColumnData<double>("SELECT Value FROM Coefficients").ToArray();
            FHGrid.DataSource = DataAccess.GetTableView("SELECT F, avr_H AS[H cp.] FROM Dependence_avrH_to_F");
        }

        private void CalculationSettingsUC_Load(object sender, EventArgs e)
        {
            for (int i = 0, k = 0; i < 3; i++)
            { 
                for (int j = 0; j < 12; j++, k++)
                {
                    table_3_1Boxes[k].Text = table_3_1[i, j].ToString();
                    table_3_2Boxes[k].Text = table_3_2[i, j].ToString();
                }
            }

            for (int i = 0; i < coefficientsBoxes.Count; i++)
            {
                coefficientsBoxes[i].Text = coefficients[i].ToString();
            }

            for (int i = 0; i < 71; i++)
            {
                FHChart.Series[0].Points.AddXY(FHGrid.Rows[i].Cells[0].Value, FHGrid.Rows[i].Cells[1].Value);
            }
        }
    }
}
