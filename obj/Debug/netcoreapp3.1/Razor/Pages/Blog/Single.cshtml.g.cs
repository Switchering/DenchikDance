#pragma checksum "C:\Users\Sowich\Projects\DenchikDance\DenchikDance\Pages\Blog\Single.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4349358bd06a7112f204883229104d370f8e8f0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DenchikDance.Pages.Blog.Pages_Blog_Single), @"mvc.1.0.razor-page", @"/Pages/Blog/Single.cshtml")]
namespace DenchikDance.Pages.Blog
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
#line 1 "C:\Users\Sowich\Projects\DenchikDance\DenchikDance\Pages\_ViewImports.cshtml"
using DenchikDance;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4349358bd06a7112f204883229104d370f8e8f0a", @"/Pages/Blog/Single.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8f6aa5f067ed9192c0e5628ee1c5d99ea0be5fb", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Blog_Single : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Sowich\Projects\DenchikDance\DenchikDance\Pages\Blog\Single.cshtml"
  
    ViewData["Title"] = "Single";

#line default
#line hidden
#nullable disable
            WriteLiteral(@" <section class=""blog-details-area ptb-100"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-8"">
                <div class=""blog-details-left"">
                    <div class=""blog-part"">
                        <div class=""blog-img"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 394, "\"", 453, 1);
#nullable restore
#line 14 "C:\Users\Sowich\Projects\DenchikDance\DenchikDance\Pages\Blog\Single.cshtml"
WriteAttributeValue("", 400, Html.DisplayFor(model => model.Article.ArticleImage), 400, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 454, "\"", 460, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </div>\r\n                        <div class=\"blog-info\">\r\n                            <h3>");
#nullable restore
#line 17 "C:\Users\Sowich\Projects\DenchikDance\DenchikDance\Pages\Blog\Single.cshtml"
                           Write(Html.DisplayFor(model => model.Article.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <div class=\"blog-meta\">\r\n                                <p class=\"blog-icon2\">Автор : ");
#nullable restore
#line 19 "C:\Users\Sowich\Projects\DenchikDance\DenchikDance\Pages\Blog\Single.cshtml"
                                                         Write(Html.DisplayFor(model => model.Article.User.Login));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n");
            WriteLiteral("                            </div>\r\n                            <p>");
#nullable restore
#line 22 "C:\Users\Sowich\Projects\DenchikDance\DenchikDance\Pages\Blog\Single.cshtml"
                          Write(Html.DisplayFor(model => model.Article.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                        <div class=""blog-social text-center"">
                            <ul>
                                <li><a href=""#"">Facebook</a></li>
                                <li><a href=""#"">Twitter</a></li>
                                <li><a href=""#"">Pinterest</a></li>
                                <li><a href=""#"">Dribble</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            ");
#nullable restore
#line 35 "C:\Users\Sowich\Projects\DenchikDance\DenchikDance\Pages\Blog\Single.cshtml"
       Write(await Html.PartialAsync("_BlogPartial.cshtml", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_Blog.SingleModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Blog.SingleModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Blog.SingleModel>)PageContext?.ViewData;
        public Pages_Blog.SingleModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
