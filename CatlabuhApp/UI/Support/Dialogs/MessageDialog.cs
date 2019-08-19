using System.Windows.Forms;

namespace CatlabuhApp.UI.Support.Dialogs
{
    public partial class MessageDialog : Form
    {
        private Button OK = new Button() { Name = "ok", Dock = DockStyle.Fill, Text = "OK" };
        private Button Cancel = new Button() { Name = "cancel", Dock = DockStyle.Fill };
        private Button Yes = new Button() { Name = "yes", Dock = DockStyle.Fill };
        private Button No = new Button() { Name = "no", Dock = DockStyle.Fill };

        public enum Icon { Alert, Cross, OK, Question }

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
        private Icon MessageIcon {
            set
            {
                switch (value)
                {
                    case Icon.Alert:
                        iconBox.Image = imageList.Images[0];
                        buttonTable.Controls.AddRange(new Control[] {
                            new Control(), OK, Cancel
                        });
                        break;
                    case Icon.Cross:
                        iconBox.Image = imageList.Images[3];
                        buttonTable.Controls.AddRange(new Control[] {
                            new Control(), new Control(), OK
                        });
                        break;
                    case Icon.OK:
                        iconBox.Image = imageList.Images[1];
                        buttonTable.Controls.AddRange(new Control[] {
                            new Control(), new Control(), OK
                        });
                        break;
                    case Icon.Question:
                        iconBox.Image = imageList.Images[2];
                        buttonTable.Controls.AddRange(new Control[] {
                            Yes, No, Cancel
                        });
                        break;
                }
            }
        }

        public MessageDialog()
        {
            Main.Forms.MainForm.GetCultureInfo();
            InitializeComponent(); 

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    Cancel.Text = "Cancel";
                    Yes.Text = "Yes";
                    No.Text = "No";
                    break;
                case "uk-UA":
                    Cancel.Text = "Відміна";
                    Yes.Text = "Так";
                    No.Text = "Ні";
                    break;
                case "ru-RU":
                    Cancel.Text = "Отмена";
                    Yes.Text = "Да";
                    No.Text = "Нет";
                    break;
            }
        }

        public MessageDialog(string title, string message, Icon icon) : this()
        {
            Title = title;
            Message = message;
            MessageIcon = icon;
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
                case "ok": DialogResult = DialogResult.OK; break;
                case "cancel": DialogResult = DialogResult.Cancel; break;
                case "yes": DialogResult = DialogResult.Yes; break;
                case "no": DialogResult = DialogResult.No; break;
            }

            Close();
        }

        public static void Show(string title, string message, Icon icon) => new MessageDialog(title, message, icon);
    }
}
