// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Project_C.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\Projects\Project_C\Project_C\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Project_C;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Project_C.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\Project_C\Project_C\Pages\Notificaties.razor"
using Project_C.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Projects\Project_C\Project_C\Pages\Notificaties.razor"
using Project_C.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\Projects\Project_C\Project_C\Pages\Notificaties.razor"
using Project_C.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\Projects\Project_C\Project_C\Pages\Notificaties.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\Projects\Project_C\Project_C\Pages\Notificaties.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Notificaties")]
    public partial class Notificaties : OwningComponentBase<SessionService>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 43 "F:\Projects\Project_C\Project_C\Pages\Notificaties.razor"
       
    public System.Collections.Generic.IList<SessionInfo> sessies;

    protected override void OnInitialized()
    {
        sessies = Service.DisplaySession();
    }

    public async Task ClickHandler()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        ClaimsPrincipal ding = authState.User;
        var currentUser = await UserManager.GetUserAsync(ding);
        // int currentUserID = int.Parse(currentUser.FindFirst("Id").Value);

        User currentUserId = (from U in database.Users where U.Id == currentUser.Id select U).FirstOrDefault();

        currentUser.accept_invitation++;
        database.Update(currentUser);
        await database.SaveChangesAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<User> UserManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ApplicationDbContext database { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
