#pragma checksum "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09b38e395e11659d2d82b5b122ef6a173cbb48d4"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09b38e395e11659d2d82b5b122ef6a173cbb48d4", @"/Pages/Reports/RevenueReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0528aad3caa1f40183726f0fca2507560c5d2536", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Reports_RevenueReport : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
  
    ViewData["Title"] = "RevenueReport";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Revenue Report</h1>\r\n\r\n<style>\r\n    table, th, td {\r\n        border: 1px solid black;\r\n    }\r\n</style>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-lg-auto\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09b38e395e11659d2d82b5b122ef6a173cbb48d43852", async() => {
                WriteLiteral(@"
            <div class=""form-group"">
                <input type=""date"" id=""Date"" name=""dateSelected""
                       value=""04-01-2020""
                       min=""04-01-2020"" max=""12-31-2020"">


                <input type=""submit"" value=""Generate Report"" class=""btn btn-primary"" />
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 32 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
 foreach (System.Data.DataTable table in Model.dataSet.Tables)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
     if (table == Model.dataSet.Tables[0])
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>Total Company Revenue</h2>\r\n");
#nullable restore
#line 37 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
    }
    else if (table == Model.dataSet.Tables[1])
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>Revenue by Car</h2>\r\n");
#nullable restore
#line 41 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>Most Popular Cars</h2>\r\n");
#nullable restore
#line 45 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table>\r\n        <thead>\r\n            <tr>\r\n");
#nullable restore
#line 49 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
                 foreach (System.Data.DataColumn col in table.Columns)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th>");
#nullable restore
#line 51 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
                   Write(col.ColumnName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 52 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 56 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
             foreach (System.Data.DataRow row in table.Rows)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n");
#nullable restore
#line 59 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
                     foreach (System.Data.DataColumn col2 in table.Columns)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 61 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
                       Write(row[col2.ColumnName]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 62 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 65 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 69 "C:\Users\qs\Documents\GitHub\CougarCar2.0\RazorPagesTutorial\Pages\Reports\RevenueReport.cshtml"
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
