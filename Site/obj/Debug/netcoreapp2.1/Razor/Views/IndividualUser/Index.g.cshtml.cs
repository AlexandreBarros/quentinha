#pragma checksum "E:\Projetos\Quentinha-Carioca\Site\Views\IndividualUser\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "044b607dc98f0a11f11a171a69ba624a3b3878bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IndividualUser_Index), @"mvc.1.0.view", @"/Views/IndividualUser/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/IndividualUser/Index.cshtml", typeof(AspNetCore.Views_IndividualUser_Index))]
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
#line 1 "E:\Projetos\Quentinha-Carioca\Site\Views\_ViewImports.cshtml"
using Site;

#line default
#line hidden
#line 2 "E:\Projetos\Quentinha-Carioca\Site\Views\_ViewImports.cshtml"
using Site.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"044b607dc98f0a11f11a171a69ba624a3b3878bd", @"/Views/IndividualUser/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7a49299ddd9177753a8c5e91637ab1b0ceff98e", @"/Views/_ViewImports.cshtml")]
    public class Views_IndividualUser_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuentinhaCarioca.Root.Customer>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "IndividualUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\Projetos\Quentinha-Carioca\Site\Views\IndividualUser\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutUser.cshtml";

#line default
#line hidden
            BeginContext(146, 353, true);
            WriteLiteral(@"
<table class=""table table-striped"">
    <thead>
        <tr>
            <th>
                Nome
            </th>
            <th>
                E-mail
            </th>
            <th>
                Telefone
            </th>
            <th>
                Celular
            </th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 26 "E:\Projetos\Quentinha-Carioca\Site\Views\IndividualUser\Index.cshtml"
         if (Model != null && Model.Count() > 0)
        {
            foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(616, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(688, 230, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93c4bbcf1d7141bdbcc22041f9b944dd", async() => {
                BeginContext(792, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
                BeginContext(823, 65, false);
#line 33 "E:\Projetos\Quentinha-Carioca\Site\Views\IndividualUser\Index.cshtml"
                       Write(String.Format("{0} {1}", item.User.FirstName, item.User.LastName));

#line default
#line hidden
                EndContext();
                BeginContext(888, 26, true);
                WriteLiteral("\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-identifier", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 32 "E:\Projetos\Quentinha-Carioca\Site\Views\IndividualUser\Index.cshtml"
                                                                                       WriteLiteral(item.User.IndividualUserId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["identifier"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-identifier", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["identifier"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(918, 83, true);
            WriteLiteral("\r\n                        </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1002, 41, false);
#line 37 "E:\Projetos\Quentinha-Carioca\Site\Views\IndividualUser\Index.cshtml"
                   Write(item.User.Contacts.FirstOrDefault().Email);

#line default
#line hidden
            EndContext();
            BeginContext(1043, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1123, 41, false);
#line 40 "E:\Projetos\Quentinha-Carioca\Site\Views\IndividualUser\Index.cshtml"
                   Write(item.User.Contacts.FirstOrDefault().Phone);

#line default
#line hidden
            EndContext();
            BeginContext(1164, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1244, 45, false);
#line 43 "E:\Projetos\Quentinha-Carioca\Site\Views\IndividualUser\Index.cshtml"
                   Write(item.User.Contacts.FirstOrDefault().CellPhone);

#line default
#line hidden
            EndContext();
            BeginContext(1289, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 46 "E:\Projetos\Quentinha-Carioca\Site\Views\IndividualUser\Index.cshtml"
            }

        }

#line default
#line hidden
            BeginContext(1369, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuentinhaCarioca.Root.Customer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
