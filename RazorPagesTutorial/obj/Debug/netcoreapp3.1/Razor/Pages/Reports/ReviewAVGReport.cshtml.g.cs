#pragma checksum "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "330f184c049a51c71e9d5bcaba6601700c1ec6dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorPagesTutorial.Pages.Reports.Pages_Reports_ReviewAVGReport), @"mvc.1.0.razor-page", @"/Pages/Reports/ReviewAVGReport.cshtml")]
namespace RazorPagesTutorial.Pages.Reports
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\_ViewImports.cshtml"
using RazorPagesTutorial;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"330f184c049a51c71e9d5bcaba6601700c1ec6dc", @"/Pages/Reports/ReviewAVGReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0528aad3caa1f40183726f0fca2507560c5d2536", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Reports_ReviewAVGReport : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
  
    ViewData["Title"] = "ReviewAVGReport";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Review AVG Report</h1>\r\n\r\n<style>\r\n    table, th, td {\r\n        border: 1px solid black;\r\n    }\r\n</style>\r\n\r\n");
#nullable restore
#line 15 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
 foreach (System.Data.DataTable table in Model.dataSet.Tables)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
     if (table == Model.dataSet.Tables[0])
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>AVG Report Rating Per Product</h2>\r\n");
#nullable restore
#line 20 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
    }
    else if (table == Model.dataSet.Tables[1])
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>All Reviews</h2>\r\n");
#nullable restore
#line 24 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table>\r\n        <thead>\r\n            <tr>\r\n");
#nullable restore
#line 28 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
                 foreach (System.Data.DataColumn col in table.Columns)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th>");
#nullable restore
#line 30 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
                   Write(col.ColumnName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 31 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 35 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
             foreach (System.Data.DataRow row in table.Rows)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n");
#nullable restore
#line 38 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
                     foreach (System.Data.DataColumn col2 in table.Columns)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 40 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
                       Write(row[col2.ColumnName]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 41 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 44 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 48 "C:\Users\gamer\Source\Repos\Team-13-COSC3320\CougarCar2.0\RazorPagesTutorial\Pages\Reports\ReviewAVGReport.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorPagesTutorial.ReviewAVGReportModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorPagesTutorial.ReviewAVGReportModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorPagesTutorial.ReviewAVGReportModel>)PageContext?.ViewData;
        public RazorPagesTutorial.ReviewAVGReportModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
