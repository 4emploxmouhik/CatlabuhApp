using CatlabuhApp.Data.Access;

namespace CatlabuhApp.UI.UC
{
    interface IDataViewUC
    {
        IDataAccess DataAccess { get; set; }
    }
}
