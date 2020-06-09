using System;
using System.Collections.Generic;
using System.Text;

namespace Demoqa_Suite_Project.Assertion
{
    class SelectionAssertValues
    {
        public readonly string selectedItemClass = "ui-widget-content ui-selectee ui-selected";


        public readonly Dictionary<string, string> expectedValueDictionary = new Dictionary<string, string>()
        {
            {"firstItem","ui-widget-content ui-selectee ui-selected"},
            {"secondItem","ui-widget-content ui-selectee ui-selected"}
        };

    }
}
