#pragma checksum "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d476618d88ec41059d92b3b0cf96358a7238bc15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Present__ContactModalPartial), @"mvc.1.0.view", @"/Views/Present/_ContactModalPartial.cshtml")]
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
#line 1 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\_ViewImports.cshtml"
using MiniDron;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\_ViewImports.cshtml"
using MiniDron.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d476618d88ec41059d92b3b0cf96358a7238bc15", @"/Views/Present/_ContactModalPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e585bc668d4a6ab898a30f4c2aae8a14413abf6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Present__ContactModalPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Contact>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Contact", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Modal -->
<div class=""modal fade"" id=""add-contact"" tabindex=""-1"" role=""dialog"" aria-labelledby=""addContactLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""addContactLabel"">등록 기체 정보</h5>
                <button type=""button"" data-dismiss=""modal"">X</button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d476618d88ec41059d92b3b0cf96358a7238bc154094", async() => {
                WriteLiteral("\n                    <input name=\"IsValid\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 575, "\"", 622, 1);
#nullable restore
#line 12 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 583, ViewData.ModelState.IsValid.ToString(), 583, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                    <div class=""row"">
                        <div class=""col"">
                            <label class=""control-label"">드론식별ID</label>
                        </div>
                        <div class=""col-4"">
                            <input class=""form-control input-sm"" disabled=""disabled""");
                BeginWriteAttribute("value", " value=\"", 938, "\"", 959, 1);
#nullable restore
#line 18 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 946, Model.dronID, 946, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                        </div>
                        <div class=""col"">
                            <label class=""control-label"">드론 종류</label>
                        </div>
                        <div class=""col-4"">
                            <input class=""form-control input-sm"" disabled=""disabled""");
                BeginWriteAttribute("value", " value=\"", 1277, "\"", 1298, 1);
#nullable restore
#line 24 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 1285, Model.dronID, 1285, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col"">
                            <label class=""control-label"">용도</label>
                        </div>
                        <div class=""col-4"">
                            <input class=""form-control input-sm"" disabled=""disabled""");
                BeginWriteAttribute("value", " value=\"", 1678, "\"", 1699, 1);
#nullable restore
#line 32 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 1686, Model.dronID, 1686, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                        </div>
                        <div class=""col"">
                            <label class=""control-label"">제작자</label>
                        </div>
                        <div class=""col-4"">
                            <input class=""form-control input-sm"" disabled=""disabled""");
                BeginWriteAttribute("value", " value=\"", 2015, "\"", 2036, 1);
#nullable restore
#line 38 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 2023, Model.dronID, 2023, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col"">
                            <label class=""control-label"">모델명</label>
                        </div>
                        <div class=""col-4"">
                            <input class=""form-control input-sm"" disabled=""disabled""");
                BeginWriteAttribute("value", " value=\"", 2417, "\"", 2438, 1);
#nullable restore
#line 46 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 2425, Model.dronID, 2425, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                        </div>
                        <div class=""col"">
                            <label class=""control-label"">보관처 주소</label>
                        </div>
                        <div class=""col-4"">
                            <input class=""form-control input-sm"" disabled=""disabled""");
                BeginWriteAttribute("value", " value=\"", 2757, "\"", 2778, 1);
#nullable restore
#line 52 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 2765, Model.dronID, 2765, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col"">
                            <label class=""control-label"">제작 연월일</label>
                        </div>
                        <div class=""col-4"">
                            <input class=""form-control input-sm"" disabled=""disabled""");
                BeginWriteAttribute("value", " value=\"", 3162, "\"", 3183, 1);
#nullable restore
#line 60 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 3170, Model.dronID, 3170, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                        </div>
                        <div class=""col"">
                            <label class=""control-label"">최대이륙중량</label>
                        </div>
                        <div class=""col-4"">
                            <input class=""form-control input-sm"" disabled=""disabled""");
                BeginWriteAttribute("value", " value=\"", 3502, "\"", 3523, 1);
#nullable restore
#line 66 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 3510, Model.dronID, 3510, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col"">
                            <label class=""control-label"">카메라</label>
                        </div>
                        <div class=""col-4"">
                            <input class=""form-control input-sm"" disabled=""disabled""");
                BeginWriteAttribute("value", " value=\"", 3904, "\"", 3925, 1);
#nullable restore
#line 74 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 3912, Model.dronID, 3912, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""text"">
                        </div>
                        <div class=""col"">
                            <label class=""control-label"">안전성 인증서 번호</label>
                        </div>
                        <div class=""col-4"">
                            <input class=""form-control input-sm"" disabled=""disabled""");
                BeginWriteAttribute("value", " value=\"", 4248, "\"", 4269, 1);
#nullable restore
#line 80 "C:\Users\CEO\Desktop\소형드론\source\MiniDron\MiniDron\Views\Present\_ContactModalPartial.cshtml"
WriteAttributeValue("", 4256, Model.dronID, 4256, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"text\">\n                        </div>\n                    </div>\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </div>\n\n          \n\n            <div class=\"modal-footer\">\n                <button type=\"button\" class=\"btn btn-secondary text-center\" data-dismiss=\"modal\">확인</button>                \n            </div>\n        </div>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Contact> Html { get; private set; }
    }
}
#pragma warning restore 1591
