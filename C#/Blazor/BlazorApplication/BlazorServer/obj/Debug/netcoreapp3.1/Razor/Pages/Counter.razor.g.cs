#pragma checksum "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/Pages/Counter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c81112c94646600aa26cb95fcc8bfa701903315"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorServer.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/_Imports.razor"
using BlazorServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/_Imports.razor"
using BlazorServer.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public partial class Counter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Counter</h1>\n\n");
            __builder.OpenElement(1, "p");
            __builder.AddAttribute(2, "style", "font-family:" + (
#nullable restore
#line 5 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/Pages/Counter.razor"
                       fontFamily

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(3, "Current count: ");
            __builder.AddContent(4, 
#nullable restore
#line 5 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/Pages/Counter.razor"
                                                   currentCount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\n\n");
            __builder.OpenElement(6, "button");
            __builder.AddAttribute(7, "class", "btn btn-primary");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/Pages/Counter.razor"
                                          IncrementCount

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(9, "Click me");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "/Users/gt/TIL/C#/Blazor/BlazorApplication/BlazorServer/Pages/Counter.razor"
       
    private int currentCount = 0;

    private string fontFamily = "Verdana";

    private void IncrementCount()
    {
        currentCount++;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591