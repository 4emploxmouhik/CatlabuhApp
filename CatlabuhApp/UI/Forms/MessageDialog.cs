using System.Windows.Forms;

namespace CatlabuhApp.UI.Forms
{
    public partial class MessageDialog : Form, IBaseView
    {
        private Button OK = new Button() { Name = "OK", Dock = DockStyle.Fill, Text = "Ok"};
        private Button Cancel = new Button();
        private Button Yes = new Button();
        private Button No = new Button();
        public enum MessageIcon { Alert, Cross, OK, Question }

        private string Message {
            set
            {
                messageBox.Text = value;
            }
        }
        private string Title {
            set
            {
                Text = value;
            }
        }
        private MessageIcon Icon {
            set
            {
                switch (value)
                {
                    case MessageIcon.Alert:
                        iconBox.Image = imageList.Images[0];
                        buttonTable.Controls.AddRange(new Control[] {
                            new Control(), new Control(), OK
                        });
                        break;
                    case MessageIcon.Cross:
                        iconBox.Image = imageList.Images[1];
                        break;
                    case MessageIcon.OK:
                        iconBox.Image = imageList.Images[2];
                        break;
                    case MessageIcon.Question:
                        iconBox.Image = imageList.Images[3];
                        break;
                }
            }
        }

        public MessageDialog()
        {
            GetCultureInfo();
            InitializeComponent();
        }

        public MessageDialog(string title, string message, MessageIcon icon) : this()
        {
            Title = title;
            Message = message;
            Icon = icon;
            DialogResult = DialogResult.None;

            OK.Click += DialogButton_Click;
            Cancel.Click += DialogButton_Click;
            Yes.Click += DialogButton_Click;
            No.Click += DialogButton_Click;
            
            ShowDialog();
        }

        private void DialogButton_Click(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "Ok": DialogResult = DialogResult.OK; break;
                case "Cancel": DialogResult = DialogResult.Cancel; break;
                case "Yes": DialogResult = DialogResult.Yes; break;
                case "No": DialogResult = DialogResult.No; break;
            }

            Close();
        }

        public void GetCultureInfo()
        {
            new BaseView().GetCultureInfo();
        }
    }
}
