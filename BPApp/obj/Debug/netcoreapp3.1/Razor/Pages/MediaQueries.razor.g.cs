#pragma checksum "C:\Rebosoft\BlazorPoker\BPApp\Pages\MediaQueries.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a34f8d7c9b0f7b12515677bb94bde203b5183f7"
// <auto-generated/>
#pragma warning disable 1591
namespace BPApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Rebosoft\BlazorPoker\BPApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Rebosoft\BlazorPoker\BPApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Rebosoft\BlazorPoker\BPApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Rebosoft\BlazorPoker\BPApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Rebosoft\BlazorPoker\BPApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Rebosoft\BlazorPoker\BPApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Rebosoft\BlazorPoker\BPApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Rebosoft\BlazorPoker\BPApp\_Imports.razor"
using BPApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Rebosoft\BlazorPoker\BPApp\_Imports.razor"
using BPApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Rebosoft\BlazorPoker\BPApp\Pages\MediaQueries.razor"
using BPData;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Rebosoft\BlazorPoker\BPApp\Pages\MediaQueries.razor"
using BPData.Lists;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Rebosoft\BlazorPoker\BPApp\Pages\MediaQueries.razor"
using BPData.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Rebosoft\BlazorPoker\BPApp\Pages\MediaQueries.razor"
using BPData.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/mediaqueries")]
    public partial class MediaQueries : IndexBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style>\r\n/* Smartphones (portrait and landscape) ----------- */\r\n@media only screen and (min-device-width : 320px) and (max-device-width : 480px) {\r\n\r\n}\r\n\r\n/* Smartphones (landscape) ----------- */\r\n@media only screen and (min-width : 321px) {\r\n\r\n}\r\n\r\n/* Smartphones (portrait) ----------- */\r\n@media only screen and (max-width : 320px) {\r\n\r\n}\r\n\r\n/* iPads (portrait and landscape) ----------- */\r\n@media only screen and (min-device-width : 768px) and (max-device-width : 1024px) {\r\n\r\n}\r\n\r\n/* iPads (landscape) ----------- */\r\n@media only screen and (min-device-width : 768px) and (max-device-width : 1024px) and (orientation : landscape) {\r\n\r\n}\r\n\r\n/* iPads (portrait) ----------- */\r\n@media only screen and (min-device-width : 768px) and (max-device-width : 1024px) and (orientation : portrait) {\r\n\r\n}\r\n/**********\r\niPad 3\r\n**********/\r\n@media only screen and (min-device-width : 768px) and (max-device-width : 1024px) and (orientation : landscape) and (-webkit-min-device-pixel-ratio : 2) {\r\n\r\n}\r\n\r\n@media only screen and (min-device-width : 768px) and (max-device-width : 1024px) and (orientation : portrait) and (-webkit-min-device-pixel-ratio : 2) {\r\n\r\n}\r\n/* Desktops and laptops ----------- */\r\n@media only screen  and (min-width : 1224px) {\r\n\r\n    .cardtable {\r\n        max-width: 1224px;\r\n        height: 701px;\r\n        background-image: url(table1224_701.png)\r\n    }\r\n}\r\n\r\n/* Large screens ----------- */\r\n@media only screen  and (min-width : 1824px) {\r\n    .cardtable {\r\n        max-width: 1824px;\r\n        height: 1045px;\r\n        background-image: url(table1824_1045.png)\r\n    }\r\n}\r\n\r\n/* iPhone 4 ----------- */\r\n    @media only screen and (min-device-width : 320px) and (max-device-width : 480px) and (orientation : landscape) and (-webkit-min-device-pixel-ratio : 2) {\r\n    }\r\n\r\n    @media only screen and (min-device-width : 320px) and (max-device-width : 480px) and (orientation : portrait) and (-webkit-min-device-pixel-ratio : 2) {\r\n    }\r\n\r\n/* iPhone 5 ----------- */\r\n@media only screen and (min-device-width: 320px) and (max-device-height: 568px) and (orientation : landscape) and (-webkit-device-pixel-ratio: 2){\r\n\r\n}\r\n\r\n@media only screen and (min-device-width: 320px) and (max-device-height: 568px) and (orientation : portrait) and (-webkit-device-pixel-ratio: 2){\r\n\r\n}\r\n\r\n/* iPhone 6, 7, 8 ----------- */\r\n@media only screen and (min-device-width: 375px) and (max-device-height: 667px) and (orientation : landscape) and (-webkit-device-pixel-ratio: 2){\r\n\r\n}\r\n\r\n@media only screen and (min-device-width: 375px) and (max-device-height: 667px) and (orientation : portrait) and (-webkit-device-pixel-ratio: 2){\r\n\r\n}\r\n\r\n/* iPhone 6+, 7+, 8+ ----------- */\r\n@media only screen and (min-device-width: 414px) and (max-device-height: 736px) and (orientation : landscape) and (-webkit-device-pixel-ratio: 2){\r\n\r\n}\r\n\r\n@media only screen and (min-device-width: 414px) and (max-device-height: 736px) and (orientation : portrait) and (-webkit-device-pixel-ratio: 2){\r\n\r\n}\r\n\r\n/* iPhone X ----------- */\r\n@media only screen and (min-device-width: 375px) and (max-device-height: 812px) and (orientation : landscape) and (-webkit-device-pixel-ratio: 3){\r\n\r\n}\r\n\r\n@media only screen and (min-device-width: 375px) and (max-device-height: 812px) and (orientation : portrait) and (-webkit-device-pixel-ratio: 3){\r\n\r\n}\r\n\r\n/* iPhone XS Max, XR ----------- */\r\n@media only screen and (min-device-width: 414px) and (max-device-height: 896px) and (orientation : landscape) and (-webkit-device-pixel-ratio: 3){\r\n\r\n}\r\n\r\n@media only screen and (min-device-width: 414px) and (max-device-height: 896px) and (orientation : portrait) and (-webkit-device-pixel-ratio: 3){\r\n\r\n}\r\n\r\n/* Samsung Galaxy S3 ----------- */\r\n@media only screen and (min-device-width: 320px) and (max-device-height: 640px) and (orientation : landscape) and (-webkit-device-pixel-ratio: 2){\r\n\r\n}\r\n\r\n@media only screen and (min-device-width: 320px) and (max-device-height: 640px) and (orientation : portrait) and (-webkit-device-pixel-ratio: 2){\r\n\r\n}\r\n\r\n/* Samsung Galaxy S4 ----------- */\r\n@media only screen and (min-device-width: 320px) and (max-device-height: 640px) and (orientation : landscape) and (-webkit-device-pixel-ratio: 3){\r\n\r\n}\r\n\r\n@media only screen and (min-device-width: 320px) and (max-device-height: 640px) and (orientation : portrait) and (-webkit-device-pixel-ratio: 3){\r\n\r\n}\r\n\r\n/* Samsung Galaxy S5 ----------- */\r\n@media only screen and (min-device-width: 360px) and (max-device-height: 640px) and (orientation : landscape) and (-webkit-device-pixel-ratio: 3){\r\n\r\n}\r\n\r\n@media only screen and (min-device-width: 360px) and (max-device-height: 640px) and (orientation : portrait) and (-webkit-device-pixel-ratio: 3){\r\n\r\n}\r\n\r\n\r\n    </style>\r\n\r\n");
#nullable restore
#line 156 "C:\Rebosoft\BlazorPoker\BPApp\Pages\MediaQueries.razor"
 if (Deck == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(1, "    ");
            __builder.AddMarkupContent(2, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 159 "C:\Rebosoft\BlazorPoker\BPApp\Pages\MediaQueries.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "   ");
            __builder.AddMarkupContent(4, "<div align=\"center\" id=\"table\" class=\"cardtable\">\r\n     \r\n   </div>\r\n");
#nullable restore
#line 165 "C:\Rebosoft\BlazorPoker\BPApp\Pages\MediaQueries.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 167 "C:\Rebosoft\BlazorPoker\BPApp\Pages\MediaQueries.razor"
       

    private List<Card> Deck = null;
    protected override void OnInitialized()
    {
        Deck = DeckSvc.GetDeck();



    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private GameService GameSvc { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private EvalService EvalService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private DeckService DeckSvc { get; set; }
    }
}
#pragma warning restore 1591