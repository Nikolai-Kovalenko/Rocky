#pragma checksum "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5047b9c09a9495b2af2c3c7b1a242efe04a6e8a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#nullable restore
#line 1 "F:\Project\RockProject\Rocky\Rocky\Views\_ViewImports.cshtml"
using Rocky;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Project\RockProject\Rocky\Rocky\Views\_ViewImports.cshtml"
using Rocky_Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
using Rocky_Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5047b9c09a9495b2af2c3c7b1a242efe04a6e8a8", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d879588a5d757b9e10ffe8da55da96f951f008eb", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Remove", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
 if(Model.Count() > 0){

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5047b9c09a9495b2af2c3c7b1a242efe04a6e8a85627", async() => {
                WriteLiteral(@"
    <br />
    <div class=""backgroundWhiteBorder"">
        <div class=""container row"">
            <div class=""col -8"">
                <div class=""card mt-4"">
                    <div class=""card-header bg-dark text-light ml-0 row container"">
                        <div class=""col-6"">
                            <i class=""fa fa-shopping-cart""></i> &nbsp;
                            Shopping Cart
                        </div>
                        <div class=""col-6 text-right"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5047b9c09a9495b2af2c3c7b1a242efe04a6e8a86426", async() => {
                    WriteLiteral("Continue Shopping");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class="" d-none d-lg-block"">
                            <div class=""row"" style=""color:#821f3d"">
                                <div class=""col-lg-2"">
                                </div>
                                <div class=""col-12 col-lg-7"">
                                    Product Details
                                </div>
                                <div class=""col-12 col-lg-2"">
                                    Price per sqft
                                </div>
                                <div class=""col-6 col-sm-4 col-lg-1"">
                                </div>
                            </div>
                        </div>

                        <hr />
");
#nullable restore
#line 38 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
                         foreach (var obj in Model)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"row h-100\">\r\n                                <div class=\"col-4 col-md-2 text-center py-2\">\r\n                                    <img");
                BeginWriteAttribute("src", " src=\"", 1839, "\"", 1868, 2);
#nullable restore
#line 42 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1845, WC.ImagePath, 1845, 13, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1858, obj.Image, 1858, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"rounded\" width=\"100%\" />\r\n                                </div>\r\n                                <div class=\"col-8 col-lg-7\">\r\n                                    <h5>");
#nullable restore
#line 45 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
                                   Write(obj.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                                    <div style=\"font-size:11px;\">");
#nullable restore
#line 46 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
                                                            Write(obj.ShortDesc);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                                </div>\r\n                                <div class=\"col-3 col-lg-2 pt-lg-4\" style=\"font-size:11px;\">\r\n                                    <span style=\"font-size:17px;\"> $");
#nullable restore
#line 49 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
                                                               Write(obj.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>/ sqft\r\n\r\n                                </div>\r\n                                <div class=\"col-2 col-lg-1 p-0 pt-lg-4 text-center\">\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5047b9c09a9495b2af2c3c7b1a242efe04a6e8a811230", async() => {
                    WriteLiteral("\r\n                                        <i class=\"fas fa-trash\"></i>\r\n                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
                                                            WriteLiteral(obj.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                            <hr />\r\n");
#nullable restore
#line 59 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </div>
                    <div class=""card-footer"">
                        <div class=""row"">
                            <div class=""col-6 col-md-3 offset-md-9"">
                                <button type=""submit"" class=""btn btn-success form-control "">
                                    <span>Continue</span>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 75 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Please add items  to cart.</p>\r\n");
#nullable restore
#line 79 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
