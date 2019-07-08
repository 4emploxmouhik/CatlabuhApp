using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CatlabuhApp.Data.Access;

namespace CatlabuhApp.UI.UC
{
    public partial class GatewaySheduleUC : UserControl, IDataViewUC
    {
        public IDataAccess DataAccess { get; set; }
        public string YearOfCalculation { get; set; }

        // GODP, GCDM - gateway open(close) date plus(minus)
        private List<TextBox> VDGDPlusBoxes = new List<TextBox>();
        private List<TextBox> VDGDMinusBoxes = new List<TextBox>();
        private List<TextBox> VozGDPlusBoxes = new List<TextBox>();
        private List<TextBox> VozGDMinusBoxes = new List<TextBox>();
        private List<TextBox> VD_plusBoxes = new List<TextBox>();
        private List<TextBox> VD_minusBoxes = new List<TextBox>();
        private List<TextBox> Voz_plusBoxes = new List<TextBox>();
        private List<TextBox> Voz_minusBoxes = new List<TextBox>();

        public byte[] VD_months
        {
            get
            {
                return GetScheduleOfWorkGateway(GetMonthsOfTimeOfWorkAGateway(VDGDPlusBoxes), GetMonthsOfTimeOfWorkAGateway(VDGDMinusBoxes));   
            }
        }
        public byte[] Voz_months
        {
            get
            {
                return GetScheduleOfWorkGateway(GetMonthsOfTimeOfWorkAGateway(VDGDPlusBoxes), GetMonthsOfTimeOfWorkAGateway(VDGDMinusBoxes));
            }
        }
 
        public double[] VD_plus
        {
            get
            {
                return GetConvertArray(VD_plusBoxes);
            }
        }
        public double[] VD_minus
        {
            get
            {
                return GetConvertArray(VD_minusBoxes);
            }
        }

        public double[] Voz_plus
        {
            get
            {
                return GetConvertArray(Voz_plusBoxes);
            }
        }
        public double[] Voz_minus
        {
            get
            {
                return GetConvertArray(Voz_minusBoxes);
            }
        }

        public GatewaySheduleUC()
        {
            InitializeComponent();

            VDGDPlusBoxes.AddRange(new TextBox[] {
                VDGODP_Box0, VDGCDP_Box0, VDGODP_Box1, VDGCDP_Box1, VDGODP_Box2, VDGCDP_Box2, VDGODP_Box3, VDGCDP_Box3, VDGODP_Box4, VDGCDP_Box4,
                VDGODP_Box5, VDGCDP_Box5, VDGODP_Box6, VDGCDP_Box6, VDGODP_Box7, VDGCDP_Box7, VDGODP_Box8, VDGCDP_Box8, VDGODP_Box9, VDGCDP_Box9,
                VDGODP_Box10, VDGCDP_Box10, VDGODP_Box11, VDGCDP_Box11
            });
            VDGDMinusBoxes.AddRange(new TextBox[] {
                VDGODM_Box0, VDGCDM_Box0, VDGODM_Box1, VDGCDM_Box1, VDGODM_Box2, VDGCDM_Box2, VDGODM_Box3, VDGCDM_Box3, VDGODM_Box4, VDGCDM_Box4,
                VDGODM_Box5, VDGCDM_Box5, VDGODM_Box6, VDGCDM_Box6, VDGODM_Box7, VDGCDM_Box7, VDGODM_Box8, VDGCDM_Box8, VDGODM_Box9, VDGCDM_Box9,
                VDGODM_Box10, VDGCDM_Box10, VDGODM_Box11, VDGCDM_Box11
            });
            VozGDPlusBoxes.AddRange(new TextBox[] {
                VozGODP_Box0, VozGCDP_Box0, VozGODP_Box1, VozGCDP_Box1, VozGODP_Box2, VozGCDP_Box2, VozGODP_Box3, VozGCDP_Box3, VozGODP_Box4, VozGCDP_Box4,
                VozGODP_Box5, VozGCDP_Box5, VozGODP_Box6, VozGCDP_Box6, VozGODP_Box7, VozGCDP_Box7, VozGODP_Box8, VozGCDP_Box8, VozGODP_Box9, VozGCDP_Box9,
                VozGODP_Box10, VozGCDP_Box10, VozGODP_Box11, VozGCDP_Box11
            });
            VozGDMinusBoxes.AddRange(new TextBox[] {
                VozGODM_Box0, VozGCDM_Box0, VozGODM_Box1, VozGCDM_Box1, VozGODM_Box2, VozGCDM_Box2, VozGODM_Box3, VozGCDM_Box3, VozGODM_Box4, VozGCDM_Box4,
                VozGODM_Box5, VozGCDM_Box5, VozGODM_Box6, VozGCDM_Box6, VozGODM_Box7, VozGCDM_Box7, VozGODM_Box8, VozGCDM_Box8, VozGODM_Box9, VozGCDM_Box9,
                VozGODM_Box10, VozGCDM_Box10, VozGODM_Box11, VozGCDM_Box11
            });
            VD_plusBoxes.AddRange(new TextBox[] {
                VDP_Box0, VDP_Box1, VDP_Box2, VDP_Box3, VDP_Box4, VDP_Box5, VDP_Box6, VDP_Box7, VDP_Box8, VDP_Box9, VDP_Box10, VDP_Box11
            });
            VD_minusBoxes.AddRange(new TextBox[] {
                VDM_Box0, VDM_Box1, VDM_Box2, VDM_Box3, VDM_Box4, VDM_Box5, VDM_Box6, VDM_Box7, VDM_Box8, VDM_Box9, VDM_Box10, VDM_Box11
            });
            Voz_plusBoxes.AddRange(new TextBox[] {
                VozP_Box0, VozP_Box1, VozP_Box2, VozP_Box3, VozP_Box4, VozP_Box5, VozP_Box6, VozP_Box7, VozP_Box8, VozP_Box9, VozP_Box10, VozP_Box11
            });
            Voz_minusBoxes.AddRange(new TextBox[] {
                VozM_Box0, VozM_Box1, VozM_Box2, VozM_Box3, VozM_Box4, VozM_Box5, VozM_Box6, VozM_Box7, VozM_Box8, VozM_Box9, VozM_Box10, VozM_Box11
            });
        }

        public void LoadSheduleData()
        {

        }

        private double[] GetConvertArray(List<TextBox> someTextBoxes)
        {
            double[] output = new double[12];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = Convert.ToDouble(someTextBoxes[i].Text);
            }

            return output;
        }

        private byte[] GetMonthsOfTimeOfWorkAGateway(List<TextBox> datesWorkingBoxes)
        {
            byte[] monthsOfWork = new byte[12];
            bool isGatewayOpen = false;

            for (int i = 0, pointer = 0; i < datesWorkingBoxes.Count; i++)
            {
                if (datesWorkingBoxes[i].Text.Length > 0)
                {
                    if (datesWorkingBoxes[i].Tag.Equals("open"))
                    {
                        isGatewayOpen = true;
                    }
                    else if (datesWorkingBoxes[i].Tag.Equals("close"))
                    {
                        isGatewayOpen = false;
                    }
                }

                if (isGatewayOpen)
                {
                    monthsOfWork[pointer] = 1;
                }

                if (i % 2 != 0)
                {
                    pointer++;
                }
            }

            return monthsOfWork;
        }

        private byte[] GetScheduleOfWorkGateway(byte[] workToFilling, byte[] workToDisharge)
        {
            byte[] shedule = new byte[12];

            for (int i = 0; i < shedule.Length; i++)
            {
                if (workToFilling[i] == 1)
                {
                    shedule[i] = 1;
                }
                else if (workToDisharge[i] == 1)
                {
                    shedule[i] = 2;
                }
                else
                {
                    shedule[i] = 0;
                }
            }

            return shedule;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if ((e.KeyChar == '-') || (e.KeyChar == ','))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }
    }
}
