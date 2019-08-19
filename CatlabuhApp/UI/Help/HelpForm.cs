using System.ComponentModel;
using System.Windows.Forms;

namespace CatlabuhAppSupportHelp.UI.Help
{
    public partial class HelpForm : Form
    {
        private static ComponentResourceManager res = new ComponentResourceManager(typeof(CatlabuhApp.UI.Help.HelpText));
        private string language = "";

        public HelpForm()
        {
            CatlabuhApp.UI.Main.Forms.MainForm.GetCultureInfo();
            InitializeComponent();

            switch (CatlabuhApp.Properties.Settings.Default.Language)
            {
                case "en-US":
                    language = "EN";
                    break;
                case "uk-UA":
                    language = "UA";
                    break;
                case "ru-RU":
                    language = "RU";
                    break;
            }

            richTextBox.Text = res.GetString($"startWorkText_{language}");
        }

        public HelpForm(params string[] namesOfHelpStrings) : this()
        {
            richTextBox.Clear();

            foreach (var entry in namesOfHelpStrings)
            {
                richTextBox.Text += res.GetString($"{entry}_{language}") + "\n\n";
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "calculation" || e.Node.Name == "chart")
            {
                return;
            }

            richTextBox.Text = res.GetString($"{e.Node.Name}Text_{language}");
        }

    }
}
