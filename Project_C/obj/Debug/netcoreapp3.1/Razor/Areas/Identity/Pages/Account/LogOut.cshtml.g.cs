#pragma checksum "F:\Projects\Project_C\Project_C\Areas\Identity\Pages\Account\LogOut.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "580e87faa4f26b07c32280b4a4a19c3f61b16786"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_LogOut), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/LogOut.cshtml")]
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
#line 2 "F:\Projects\Project_C\Project_C\Areas\Identity\Pages\_ViewImports.cshtml"
using Project_C.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Projects\Project_C\Project_C\Areas\Identity\Pages\_ViewImports.cshtml"
using Project_C.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\Projects\Project_C\Project_C\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Project_C.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\Project_C\Project_C\Areas\Identity\Pages\Account\LogOut.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Projects\Project_C\Project_C\Areas\Identity\Pages\Account\LogOut.cshtml"
           [IgnoreAntiforgeryToken]

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"580e87faa4f26b07c32280b4a4a19c3f61b16786", @"/Areas/Identity/Pages/Account/LogOut.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af02272a7b881b71ebc8e0de0a0e11e824f869ff", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14b2259474a93b99ee002273de8ec01aaa36557c", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_LogOut : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "F:\Projects\Project_C\Project_C\Areas\Identity\Pages\Account\LogOut.cshtml"
            
    public async Task<IActionResult> OnPost()
    {
        if (SignInManager.IsSignedIn(User))
        {
            await SignInManager.SignOutAsync();
        }

        return Redirect("~/");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Areas_Identity_Pages_Account_LogOut> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Areas_Identity_Pages_Account_LogOut> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Areas_Identity_Pages_Account_LogOut>)PageContext?.ViewData;
        public Areas_Identity_Pages_Account_LogOut Model => ViewData.Model;
    }
}
#pragma warning restore 1591
