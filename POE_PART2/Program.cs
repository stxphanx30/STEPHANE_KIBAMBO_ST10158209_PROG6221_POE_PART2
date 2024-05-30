using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART2
{
    /// <summary>
    /// class program that contains the main method that runs the app
    /// </summary>
    /// /// --------------------------------------------------------------------------------------------------------------------------------------------
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the RecipeApp class to handle the main logic
            RecipeApp app = new RecipeApp();

            // Run the main application
            app.Run(); 
        }
    }
}
