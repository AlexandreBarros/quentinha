#pragma checksum "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1de186031ef841ffb29dd4635b505cad1a8d3a24"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_viaadmin_Views_LegalUser_Index), @"mvc.1.0.view", @"/Areas/viaadmin/Views/LegalUser/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/viaadmin/Views/LegalUser/Index.cshtml", typeof(AspNetCore.Areas_viaadmin_Views_LegalUser_Index))]
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
#line 1 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\_ViewImports.cshtml"
using Site.Areas;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1de186031ef841ffb29dd4635b505cad1a8d3a24", @"/Areas/viaadmin/Views/LegalUser/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d7ecaf6f50836d86280b3890c64390d5c83ac57", @"/Areas/viaadmin/Views/_ViewImports.cshtml")]
    public class Areas_viaadmin_Views_LegalUser_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuentinhaCarioca.Root.ViewModel.LegalUserResponse>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
  
    ViewData["Title"] = "Empresas registradas no sistema";
    Layout = "~/Areas/viaadmin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(202, 497, true);
            WriteLiteral(@"<a href=""LegalUser/Create"">Criar</a>
<hr />
<table class=""table table-striped"">
    <thead>
        <tr>
            <th>
                Razão Social
            </th>
            <th>
                Nome Fantasia
            </th>
            <th>
                CNPJ
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
#line 33 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
         if (Model != null && Model.Count() > 0)
        {
            

#line default
#line hidden
#line 35 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(817, 74, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 891, "\"", 943, 2);
            WriteAttributeValue("", 898, "./legaluser/edit?identifier=", 898, 28, true);
#line 39 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
WriteAttributeValue("", 926, item.LegalUserId, 926, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(944, 31, true);
            WriteLiteral(">\r\n                            ");
            EndContext();
            BeginContext(976, 14, false);
#line 40 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
                       Write(item.LegalName);

#line default
#line hidden
            EndContext();
            BeginContext(990, 109, true);
            WriteLiteral("\r\n                        </a>\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1100, 49, false);
#line 44 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ExhibitionName));

#line default
#line hidden
            EndContext();
            BeginContext(1149, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1229, 39, false);
#line 47 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CNPJ));

#line default
#line hidden
            EndContext();
            BeginContext(1268, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1348, 37, false);
#line 50 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
                   Write(item.CreationDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1385, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 53 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
                         if (item.DetachmentDate.HasValue)
                        {
                            item.DetachmentDate.Value.ToShortDateString();
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1687, 50, true);
            WriteLiteral("                            <label>ATIVO</label>\r\n");
            EndContext();
#line 60 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"

                        }

#line default
#line hidden
            BeginContext(1766, 83, true);
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1849, "\"", 1871, 1);
#line 64 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
WriteAttributeValue("", 1854, item.LegalUserId, 1854, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1872, 159, true);
            WriteLiteral(" type=\"button\" class=\"btn btn-default\" style=\"font-size:small;\" value=\"Desativar\" onclick=\"Remove(this)\" />\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 67 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
            }

#line default
#line hidden
#line 67 "E:\Projetos\Quentinha-Carioca\Site\Areas\viaadmin\Views\LegalUser\Index.cshtml"
             
        }

#line default
#line hidden
            BeginContext(2057, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuentinhaCarioca.Root.ViewModel.LegalUserResponse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
