#pragma checksum "F:\Project\RockProject\Rocky\Rocky\Views\Cart\InquiryConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed5a9217ed72f65cee0e4765a0dd7ef841545289"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_InquiryConfirmation), @"mvc.1.0.view", @"/Views/Cart/InquiryConfirmation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed5a9217ed72f65cee0e4765a0dd7ef841545289", @"/Views/Cart/InquiryConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d879588a5d757b9e10ffe8da55da96f951f008eb", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cart_InquiryConfirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Rocky_Models.OrderHeader>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center\"> \r\n");
#nullable restore
#line 4 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\InquiryConfirmation.cshtml"
     if(Model != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1 class=\"text-info\">Order Created</h1>\r\n        <p>Order ");
#nullable restore
#line 7 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\InquiryConfirmation.cshtml"
            Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" has been created seccessfully!</p>\r\n");
#nullable restore
#line 8 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\InquiryConfirmation.cshtml"

    }
    else
    {     

#line default
#line hidden
#nullable disable
            WriteLiteral("      <h1 class=\"text-info\">Inquiry Confirmation</h1>\r\n");
            WriteLiteral("      <p>We have received  your inquiry and someone from our team will contact you shortly!</p>\r\n");
#nullable restore
#line 15 "F:\Project\RockProject\Rocky\Rocky\Views\Cart\InquiryConfirmation.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <img src=\"/images/patio.jpg\" width=\"80%\"/>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Rocky_Models.OrderHeader> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
