#pragma checksum "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3536c762c861d75ae4e232155aaa25d81decf176"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorPagesTutorial.Pages.Reports.Pages_Reports_RevenueReport), @"mvc.1.0.razor-page", @"/Pages/Reports/RevenueReport.cshtml")]
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
#line 1 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\_ViewImports.cshtml"
using RazorPagesTutorial;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3536c762c861d75ae4e232155aaa25d81decf176", @"/Pages/Reports/RevenueReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0528aad3caa1f40183726f0fca2507560c5d2536", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Reports_RevenueReport : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
  
    ViewData["Title"] = "RevenueReport";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Revenue Report</h1>\r\n\r\n<style>\r\n    table, th, td {\r\n        border: 1px solid black;\r\n    }\r\n</style>\r\n\r\n");
#nullable restore
#line 15 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
 foreach (System.Data.DataTable table in Model.dataSet.Tables)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table>\r\n        <thead>\r\n            <tr>\r\n");
#nullable restore
#line 20 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
                 foreach (System.Data.DataColumn col in table.Columns)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th>");
#nullable restore
#line 22 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
                   Write(col.ColumnName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 23 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 27 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
             foreach (System.Data.DataRow row in table.Rows)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n");
#nullable restore
#line 30 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
                     foreach (System.Data.DataColumn col2 in table.Columns)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 32 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
                       Write(row[col2.ColumnName]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 33 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 36 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 40 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorPagesTutorial.RevenueReportModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorPagesTutorial.RevenueReportModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorPagesTutorial.RevenueReportModel>)PageContext?.ViewData;
        public RazorPagesTutorial.RevenueReportModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
