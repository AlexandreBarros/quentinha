#pragma checksum "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d93e756da07af1e7c020999638325dd4375d1da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_shopadmin_Views_Employee_Index), @"mvc.1.0.view", @"/Areas/shopadmin/Views/Employee/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/shopadmin/Views/Employee/Index.cshtml", typeof(AspNetCore.Areas_shopadmin_Views_Employee_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\_ViewImports.cshtml"
using Site.Areas;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d93e756da07af1e7c020999638325dd4375d1da", @"/Areas/shopadmin/Views/Employee/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7ecaf6f50836d86280b3890c64390d5c83ac57", @"/Areas/shopadmin/Views/_ViewImports.cshtml")]
    public class Areas_shopadmin_Views_Employee_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuentinhaCarioca.Root.ViewModel.EmployeeRequest>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/appjs/employee.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(69, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
  
    ViewData["Title"] = "Funcionários registrados";
    Layout = "~/Areas/shopadmin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(194, 432, true);
            WriteLiteral(@"
<a href=""LegalUser/Create"">Criar</a>
<hr />
<table class=""table table-striped"">
    <thead>
        <tr>
            <th>
                Nome
            </th>
            <th>
                Nome de Usuário
            </th>

            <th>
                Criado em
            </th>
            <th>
                Ativo
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 30 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
         if (Model != null && Model.Count() > 0)
        {
            string userName = String.Empty;
            

#line default
#line hidden
#line 33 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
             foreach (var item in Model)
            {
                userName = $"{item.FirstName} {item.LastName}";

#line default
#line hidden
            BeginContext(854, 74, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 928, "\"", 969, 2);
            WriteAttributeValue("", 935, "./edit?identifier=", 935, 18, true);
#line 38 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
WriteAttributeValue("", 953, item.EmployeeId, 953, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(970, 31, true);
            WriteLiteral(">\r\n                            ");
            EndContext();
            BeginContext(1002, 8, false);
#line 39 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
                       Write(userName);

#line default
#line hidden
            EndContext();
            BeginContext(1010, 109, true);
            WriteLiteral("\r\n                        </a>\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1120, 13, false);
#line 43 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
                   Write(item.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1133, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1213, 37, false);
#line 46 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
                   Write(item.CreationDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1250, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 49 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
                         if (item.DetachmentDate.HasValue)
                        {

#line default
#line hidden
            BeginContext(1392, 69, true);
            WriteLiteral("                            <label>\r\n                                ");
            EndContext();
            BeginContext(1462, 45, false);
#line 52 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
                           Write(item.DetachmentDate.Value.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1507, 40, true);
            WriteLiteral("\r\n                            </label>\r\n");
            EndContext();
#line 54 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1631, 50, true);
            WriteLiteral("                            <label>ATIVO</label>\r\n");
            EndContext();
#line 58 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"

                        }

#line default
#line hidden
            BeginContext(1710, 53, true);
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 62 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
                         if (!item.DetachmentDate.HasValue)
                        {

#line default
#line hidden
            BeginContext(1851, 34, true);
            WriteLiteral("                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1885, "\"", 1906, 1);
#line 64 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
WriteAttributeValue("", 1890, item.EmployeeId, 1890, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1907, 109, true);
            WriteLiteral(" type=\"button\" class=\"btn btn-default\" style=\"font-size:small;\" value=\"Desativar\" onclick=\"Remove(this)\" />\r\n");
            EndContext();
#line 65 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(2100, 34, true);
            WriteLiteral("                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2134, "\"", 2155, 1);
#line 68 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
WriteAttributeValue("", 2139, item.EmployeeId, 2139, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2156, 112, true);
            WriteLiteral(" type=\"button\" class=\"btn btn-default\" style=\"font-size:small;\" value=\"Reativar\" onclick=\"Reactivate(this)\" />\r\n");
            EndContext();
#line 69 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(2295, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 73 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
            }

#line default
#line hidden
#line 73 "E:\Projetos\Quentinha-Carioca\Site\Areas\shopadmin\Views\Employee\Index.cshtml"
             
        }

#line default
#line hidden
            BeginContext(2373, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
            BeginContext(2397, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb75bf9cf6e749b990ca7d6d6b181fa0", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuentinhaCarioca.Root.ViewModel.EmployeeRequest>> Html { get; private set; }
    }
}
#pragma warning restore 1591
