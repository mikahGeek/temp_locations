using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

namespace TestLocationsWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Class1 dao = new Class1();

            List<int> iterations = new List<int>();
            iterations.AddRange(Enumerable.Range(1, 100));
            System.Threading.Tasks.Parallel.ForEach(iterations, iter =>
            {
                Console.WriteLine(iter);
                var list = dao.GetList_2();
                if (list == null)
                {
                    throw new NullReferenceException("things broke");
                }
                if (list.Count == 0)
                {
                    throw new ArgumentException("things were empty");
                }
            });



        }
    }
}