#pragma checksum "D:\creativa project\Creativa_api\Views\Graduates\PartialViewGraduate.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "03ecb5a28a91e484396b8c418c4b75f351d85081b56208c1c62b2bfedb02d7a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Graduates_PartialViewGraduate), @"mvc.1.0.view", @"/Views/Graduates/PartialViewGraduate.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"03ecb5a28a91e484396b8c418c4b75f351d85081b56208c1c62b2bfedb02d7a8", @"/Views/Graduates/PartialViewGraduate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"1b2877783bbdb0066a6b07ed5b48224e9e8d854f2299aba83f88c3a548dbfc77", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Graduates_PartialViewGraduate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Assets/HomeContent/img/team2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<br />\r\n<section id=\"team\" class=\"section\">\r\n    <div class=\"container\">\r\n");
#nullable restore
#line 11 "D:\creativa project\Creativa_api\Views\Graduates\PartialViewGraduate.cshtml"
         if (ViewBag.graduateUser != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\creativa project\Creativa_api\Views\Graduates\PartialViewGraduate.cshtml"
             foreach (var item in ViewBag.graduateUser)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-md-3 col-sm-6 col-xs-12 wow fadeInRight"" data-wow-duration=""0.8s"" data-wow-delay=""0.6s"">
                    Single Team
                    <div class=""single-team"">
                        <div class=""team-head"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "03ecb5a28a91e484396b8c418c4b75f351d85081b56208c1c62b2bfedb02d7a84550", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            <div class=""team-hover"">
                                <ul class=""social"">
                                    <li><a href=""#""><i class=""fa fa-linkedin""></i></a></li>
                                    <li><a href=""#""><i class=""fa fa-vimeo""></i></a></li>
                                    <li><a href=""#""><i class=""fa fa-github""></i></a></li>
                                    <li><a href=""#""><i class=""fa fa-code""></i></a></li>
                                </ul>
                            </div>
                        </div>
                        <div class=""t-name"">
                            <h4>");
#nullable restore
#line 30 "D:\creativa project\Creativa_api\Views\Graduates\PartialViewGraduate.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>Designer</span></h4>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 34 "D:\creativa project\Creativa_api\Views\Graduates\PartialViewGraduate.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\creativa project\Creativa_api\Views\Graduates\PartialViewGraduate.cshtml"
             

        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1>No Graduates</h1>\r\n");
#nullable restore
#line 40 "D:\creativa project\Creativa_api\Views\Graduates\PartialViewGraduate.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</section>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
