#pragma checksum "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/Shared/NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a72adf1dc57ee3e27e85dc952694f25dac690d4e"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorWebAssembly.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/_Imports.razor"
using BlazorWebAssembly;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/_Imports.razor"
using BlazorWebAssembly.Shared;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddMarkupContent(2, "\n    ");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href>BlazorWebAssembly</a>\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/Shared/NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(7, "\n        <span class=\"navbar-toggler-icon\"></span>\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\n\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", 
#nullable restore
#line 8 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/Shared/NavMenu.razor"
             NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/Shared/NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(13, "\n    ");
            __builder.OpenElement(14, "ul");
            __builder.AddAttribute(15, "class", "nav flex-column");
            __builder.AddMarkupContent(16, "\n        ");
            __builder.OpenElement(17, "li");
            __builder.AddAttribute(18, "class", "nav-item px-3");
            __builder.AddMarkupContent(19, "\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(20);
            __builder.AddAttribute(21, "class", "nav-link");
            __builder.AddAttribute(22, "href", "");
            __builder.AddAttribute(23, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 11 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/Shared/NavMenu.razor"
                                                     NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(25, "\n                <span class=\"oi oi-home\" aria-hidden=\"true\"></span> Home\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(26, "\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\n        ");
            __builder.OpenElement(28, "li");
            __builder.AddAttribute(29, "class", "nav-item px-3");
            __builder.AddMarkupContent(30, "\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(31);
            __builder.AddAttribute(32, "class", "nav-link");
            __builder.AddAttribute(33, "href", "counter");
            __builder.AddAttribute(34, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(35, "\n                <span class=\"oi oi-plus\" aria-hidden=\"true\"></span> Counter\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(36, "\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\n        ");
            __builder.OpenElement(38, "li");
            __builder.AddAttribute(39, "class", "nav-item px-3");
            __builder.AddMarkupContent(40, "\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(41);
            __builder.AddAttribute(42, "class", "nav-link");
            __builder.AddAttribute(43, "href", "fetchdata");
            __builder.AddAttribute(44, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(45, "\n                <span class=\"oi oi-list-rich\" aria-hidden=\"true\"></span> Fetch data\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(46, "\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 28 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorWebAssembly/Shared/NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591