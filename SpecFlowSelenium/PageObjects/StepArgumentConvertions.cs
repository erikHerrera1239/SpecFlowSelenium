using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.PageObjects
{
    [Binding]
    public class StepArgumentConvertions
    {
        /* Transform a Table instance into a simple List of strings */
        [StepArgumentTransformation]
        public List<string> TableToListOfStrings(Table table)
        {
            var list = new List<string>();
            foreach (var row in table.Rows)
            {
                list.Add(row["ListItem"].ToString());
            }
            return list;
        }

        [StepArgumentTransformation]
        public string TableToSingleString(Table table)
        {
            if (table.Rows.Count != 1)
            {
                throw new ArgumentOutOfRangeException("There should be 1 single item in the list");
            }
            return table.Rows.Single().Values.Single().ToString();
        }
    }
}
