using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS155Homework14
{
    public partial class Person : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<person> myList = new List<person>();
            person p1 = new person("Mark", 12, 5.9);
            person p2 = new person("Mary", 11, 5.4);
            person p3 = new person("John", 10, 5.2);
            person p4 = new person("David", 16, 6.2);

            myList.Add(p1);
            myList.Add(p2);
            myList.Add(p3);
            myList.Add(p4);


            GridView1.Caption = "All persons";
            GridView1.DataSource = from a in myList select a;
            GridView1.DataBind();

            GridView2.Caption = "\nAll persons <= 12";
            GridView2.DataSource = from a in myList  where a.Age <=12 select a;
            GridView2.DataBind();

            int personcount = (from a in myList select a).Count();
            double averageHt = 0.0;
            double sum = 0.0;
            foreach (var p in myList)
            {
                sum += p.Height;
            }
            averageHt = sum / personcount;

            GridView3.Caption = "\nAll persons above the average height";
            GridView3.DataSource = from a in myList where a.Height > averageHt select a;
            GridView3.DataBind();

        }

        public class person
        {
            private String name;
            private int age;
            private double height;

            public person(String n, int a, double h)
            {
                Name = n;
                Age = a;
                Height = h;
            }

            public string Name { get => name; set => name = value; }
            public int Age { get => age; set => age = value; }
            public double Height { get => height; set => height = value; }
        }
    }
}