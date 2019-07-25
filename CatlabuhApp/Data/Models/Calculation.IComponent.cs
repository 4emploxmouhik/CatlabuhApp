using CatlabuhApp.Data.Access;

namespace CatlabuhApp.Data.Models
{
    partial class Calculation
    {
        public interface IComponent
        {
            IDataAccess DataAccess { get; } 
            int[] IDs { get; set; }
            string YearOfCalculation { get; set; }

            void Delete();
            int[] Save();
            void Update();
        }
    }
}
