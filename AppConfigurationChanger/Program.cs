using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AppConfigurationChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            string configPath = args[0];
            string dbPath = args[1];

            if (string.IsNullOrWhiteSpace(configPath) || string.IsNullOrWhiteSpace(dbPath))
            {
                MessageBox.Show("Error", "Incorrect inputs.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(configPath);

                    foreach (XmlNode node in doc.GetElementsByTagName("add"))
                    {
                        if (node.Attributes["name"].Value == "Default")
                        {
                            node.Attributes["connectionString"].Value = $"Data Source={dbPath};Version=3";
                            break;
                        }
                    }

                    doc.Save(configPath);

                    Process.Start(Directory.GetCurrentDirectory() + "\\CatlabuhApp.exe");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error", "Operation failure.\n" + e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
