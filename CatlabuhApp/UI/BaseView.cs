using System.Globalization;
using System.Threading;

namespace CatlabuhApp.UI
{
    public class BaseView : IBaseView
    {
        public void GetCultureInfo()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }
        }
    }
}
