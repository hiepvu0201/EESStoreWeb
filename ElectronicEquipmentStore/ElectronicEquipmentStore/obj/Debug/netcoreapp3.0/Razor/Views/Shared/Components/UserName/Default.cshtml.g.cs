#pragma checksum "E:\Web\ElectronicEquipmentStore\ElectronicEquipmentStore\Views\Shared\Components\UserName\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32a7ce96067aa55055cb3c0da5548e58fcbca2b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserName_Default), @"mvc.1.0.view", @"/Views/Shared/Components/UserName/Default.cshtml")]
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
#line 1 "E:\Web\ElectronicEquipmentStore\ElectronicEquipmentStore\Views\_ViewImports.cshtml"
using ElectronicEquipmentStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Web\ElectronicEquipmentStore\ElectronicEquipmentStore\Views\_ViewImports.cshtml"
using ElectronicEquipmentStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32a7ce96067aa55055cb3c0da5548e58fcbca2b9", @"/Views/Shared/Components/UserName/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a335555f433d9c00e0247e70894060fa41867e0d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_UserName_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ElectronicEquipmentStore.Models.ApplicationUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\nHi! ");
#nullable restore
#line 3 "E:\Web\ElectronicEquipmentStore\ElectronicEquipmentStore\Views\Shared\Components\UserName\Default.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"far fa-user\"></i>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ElectronicEquipmentStore.Models.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
