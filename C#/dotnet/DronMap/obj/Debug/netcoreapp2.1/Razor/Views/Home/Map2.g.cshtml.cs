#pragma checksum "C:\Users\K\Documents\TIL\C#\dotnet\DronMap\Views\Home\Map2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26efe666e18be40df7969756130055dc81b7c7e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Map2), @"mvc.1.0.view", @"/Views/Home/Map2.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Map2.cshtml", typeof(AspNetCore.Views_Home_Map2))]
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
#line 1 "C:\Users\K\Documents\TIL\C#\dotnet\DronMap\Views\_ViewImports.cshtml"
using DronMap;

#line default
#line hidden
#line 2 "C:\Users\K\Documents\TIL\C#\dotnet\DronMap\Views\_ViewImports.cshtml"
using DronMap.Models;

#line default
#line hidden
#line 3 "C:\Users\K\Documents\TIL\C#\dotnet\DronMap\Views\_ViewImports.cshtml"
using DronMap.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26efe666e18be40df7969756130055dc81b7c7e3", @"/Views/Home/Map2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17c0d9e796847446abb77a811db1a9ab4131c5a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Map2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Users\K\Documents\TIL\C#\dotnet\DronMap\Views\Home\Map2.cshtml"
  
    ViewBag.Title = "MAP2";
    Layout = null;//asp.net core의 레이아웃에 벗어나기 위해 추가

#line default
#line hidden
            BeginContext(218, 27, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(245, 478, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a1e87fa7895e442c90d4cde5aca150a2", async() => {
                BeginContext(251, 465, true);
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
    <title>Dron map 2</title>
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"" />
    <script src=""https://code.jquery.com/jquery-latest.min.js""></script>
    <script type=""text/javascript"" src=""https://map.vworld.kr/js/vworldMapInit.js.do?version=2.0&apiKey=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=localhost:8080""></script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(723, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(727, 10840, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "998e2bfdd3b141618f9238d13b84becb", async() => {
                BeginContext(733, 10827, true);
                WriteLiteral(@"
    <style type=""text/css"">
        .buttons {
            position: relative;
            top: 30px;
        }

        .checkbox-xl {
            position: relative;
            top: 120px;
            left: 90px;
            transform: scale(1.5);
            -webkit-transform: scale(1.5);
        }
    </style>
    <!--네비게이션 영역-->
    <div id=""navi"" style=""height:100%; float:left; width:13% "">
        <div class=""buttons"">
            <!-- 부트스트랩 사용-->
            <button id=""FL"" type=""button"" class=""btn btn-default btn-lg btn-block"">제한구역 보기</button>
            <button id=""position"" type=""button"" class=""btn btn-default btn-lg btn-block"">  내 위치 </button>
            <button id=""addAntenna"" type=""button"" class=""btn btn-default btn-lg btn-block""> 수신기 추가</button>
            <button id=""addDron"" type=""button"" class=""btn btn-default btn-lg btn-block""> 드론 추가 </button>
            <button id=""simul"" type=""button"" class=""btn btn-default btn-lg btn-block""> 실시간 전시</button>
            <butt");
                WriteLiteral(@"on id=""temp"" type=""button"" class=""btn btn-default btn-lg btn-block""> 임시 버튼 </button>
        </div>
        <div class=""custom-control custom-checkbox checkbox-xl"" "">
            <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aisprhc"">
            <label class=""custom-control-label"" for=""customCheck1"" style=""color:red"">비행금지구역</label><br />
            <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aisctrc"">
            <label class=""custom-control-label"" for=""customCheck1"" style=""color:orange""> 관제권</label><br />
            <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aisresc"">
            <label class=""custom-control-label"" for=""customCheck1"" style=""color:orangered""> 비행제한구역</label><br />
            <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aisdngc"">
            <label class=""custom-control-label"" for=""customCheck1"" style=""color:purple""> 위험구역    25kg↑</label><br />
            <input type=""checkbox"" class=""custom-control-input"" id=""lt_");
                WriteLiteral(@"c_aismoac"">
            <label class=""custom-control-label"" for=""customCheck1"" style=""color:olive""> 군작전구역    25kg↑</label><br />
            <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aiscatc"">
            <label class=""custom-control-label"" for=""customCheck1"" style=""color:blue""> 훈련구역    25kg↑</label><br />
            <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aistmac"">
            <label class=""custom-control-label"" for=""customCheck1"" style=""color:brown""> 접근관제구역 25kg↑</label>
        </div>
    </div>

    <!--지도가 들어갈 영역-->
    <div id=""vmap"" style=""height:100%; float:right; width:87%""></div>        

    <script type=""text/javascript"">

        //지도 생성                
        vw.ol3.CameraPosition.center = [14176994.56431106, 4354866.236842043];
        vw.ol3.CameraPosition.zoom = 19;

        vw.ol3.MapOptions = {
            basemapType: vw.ol3.BasemapType.GRAPHIC
            , controlDensity: vw.ol3.DensityType.FULL
            , interactionDensi");
                WriteLiteral(@"ty: vw.ol3.DensityType.BASIC
            , controlsAutoArrange: true
            , homePosition: vw.ol3.CameraPosition
            , initPosition: vw.ol3.CameraPosition
        };
        vmap = new vw.ol3.Map(""vmap"", vw.ol3.MapOptions);

        //마커 추가
        var markerLayer = new vw.ol3.layer.Marker(vmap);
        $(""#addDron"").on(""click"", function (e) {
            

            //vw.ol3.markerOption = {
            //    //36.393239, 127.354109
            //    x: 127.354109,
            //    y: 36.393239,
            //    epsg: ""EPSG:4326"",
            //    title: 'netcustomize',
            //    contents: 'test marker',
            //    iconUrl: '../images/dronImg2.png',
            //    //iconUrl: 'http://map.vworld.kr/images/ol3/marker_blue.png',
            //}            
          
            //markerLayer.addMarker(vw.ol3.markerOption);            
            //vmap.addLayer(markerLayer);            
                        
            
            moveM();
");
                WriteLiteral(@"                
        })

        //사각형 이동 
        var distance = 0, dir = 0, dx, dy;
        const moveRect = function (dis) {
            //상하좌우 배열로 변경하기 
            if (dir == 1) {//우측                     
                dx = 0.0001; dy = 0;
                if (distance == dis) {
                    distance = 0;
                    dir++;
                }
            }
            else if (dir == 2) {//상측                    
                dx = 0; dy = 0.0001;
                if (distance == dis) {
                    distance = 0;
                    dir++;
                }
            }
            else if (dir == 3) {//좌측                    
                dx = -0.0001; dy = 0;
                if (distance == dis) {
                    distance = 0;
                    dir++;
                }
            }
            else {//하측                    
                dx = 0; dy = -0.0001;
                if (distance == dis) {
                    distance = 0;
  ");
                WriteLiteral(@"                  dir = 1;
                }
            }
            distance++;
        }
        
        var moveM = function () {
            var addPoint = [];
            addPoint.push(ol.proj.transform([vmap.getView().getCenter()[0], vmap.getView().getCenter()[1]], ""EPSG:900913"", ""EPSG:4326""));
            
            var t = setInterval(function () {
                var markerLayer;
                if (markerLayer == null) {
                    markerLayer = new vw.ol3.layer.Marker(vmap);
                }
                markerLayer.set(""name"", ""마커레이어"");
                moveRect(10);
                console.log(addPoint[0][0], addPoint[0][1]);
                vw.ol3.markerOption = {
                    x: addPoint[0][0],
                    y: addPoint[0][1],
                    epsg: ""EPSG:4326"",
                    title: 'netcustomize',
                    contents: 'test marker',
                    iconUrl: '../images/dronImg2.png',
                }; //마커 옵션 설정

  ");
                WriteLiteral(@"              markerLayer.addMarker(vw.ol3.markerOption);// 마커를 레이어에 등록
                //markerLayer.getSource().getFeatures()[o].set(""식별자"", ""ID_"" + o);

                //vmap.removeLayer(vmap.getLayerByName(""마커레이어"")) //vmap.getLayerByName(레이어명)
                vmap.addLayer(markerLayer) //마커를 vmap에 등록
            }, 1000);            
        }

        
        

       

       

        var layList = [""lt_c_aisprhc"", ""lt_c_aisctrc"", ""lt_c_aisresc"", ""lt_c_aisdngc"", ""lt_c_aismoac"", ""lt_c_aiscatc"", ""lt_c_aistmac""];
          
        $('#'+layList[0]).change(function () {            
            if ($('#' +layList[0]).is("":checked"")) {                
                var wmslayer = vmap.addNamedLayer(""비행금지구역"", layList[0]);
                vmap.addLayer(wmslayer);
            } else {
                vmap.getLayerByName(""비행금지구역"");
                vmap.removeLayer(vmap.getLayerByName(""비행금지구역""));
            }
        });

        $('#' + layList[1]).change(function () {            ");
                WriteLiteral(@"
            if ($('#' + layList[1]).is("":checked"")) {                
                var wmslayer = vmap.addNamedLayer(""관제권"", layList[1]);
                vmap.addLayer(wmslayer);
            } else {
                vmap.getLayerByName(""관제권"");
                vmap.removeLayer(vmap.getLayerByName(""관제권""));
            }
        });

        $('#' + layList[2]).change(function () {            
            if ($('#' + layList[2]).is("":checked"")) {                
                var wmslayer = vmap.addNamedLayer(""비행제한구역"", layList[2]);
                vmap.addLayer(wmslayer);
            } else {
                vmap.getLayerByName(""비행제한구역"");
                vmap.removeLayer(vmap.getLayerByName(""비행제한구역""));
            }
        });

        $('#' + layList[3]).change(function () {
            
            if ($('#' + layList[3]).is("":checked"")) {                
                var wmslayer = vmap.addNamedLayer(""위험구역"", layList[3]);
                vmap.addLayer(wmslayer);
            } ");
                WriteLiteral(@"else {
                vmap.getLayerByName(""위험구역"");
                vmap.removeLayer(vmap.getLayerByName(""위험구역""));
            }
        });

        $('#' + layList[4]).change(function () {            
            if ($('#' + layList[4]).is("":checked"")) {                
                var wmslayer = vmap.addNamedLayer(""군작전구역"", layList[4]);
                vmap.addLayer(wmslayer);
            } else {
                vmap.getLayerByName(""군작전구역"");
                vmap.removeLayer(vmap.getLayerByName(""군작전구역""));
            }
        });

        $('#' + layList[5]).change(function () {            
            if ($('#' + layList[5]).is("":checked"")) {                
                var wmslayer = vmap.addNamedLayer(""훈련구역"", layList[5]);
                vmap.addLayer(wmslayer);
            } else {
                vmap.getLayerByName(""훈련구역"");
                vmap.removeLayer(vmap.getLayerByName(""훈련구역""));
            }
        });

        $('#' + layList[6]).change(function () {
     ");
                WriteLiteral(@"       if ($('#' + layList[6]).is("":checked"")) {
                var wmslayer = vmap.addNamedLayer(""접근관제구역"", layList[6]);
                vmap.addLayer(wmslayer);
            } else {
                vmap.getLayerByName(""접근관제구역"");
                vmap.removeLayer(vmap.getLayerByName(""접근관제구역""));
            }
        });
                        
        $(""#position"").on(""click"", function (e) {
            e.preventDefault();                        
            //move(127.354109, 36.393239 ); //넷커스터마이즈 위치 
            //move(127.354109, 36.393239, 9);
            move(14176994.56431106, 4354866.236842043, 18);
        });     

        //var move = function (x, y) {//127.10153, 37.402566
        //    vmap.getView().setCenter(ol.proj.transform([x, y], 'EPSG:4326', ""EPSG:900913"")); // 지도 이동
        //    vmap.getView().setZoom(18);
        //}

        //지정 위치로 지도 이동 부드럽게 
        function move(x, y, z) {
            var _center = [x, y];

            var z = z;
            var pan = o");
                WriteLiteral(@"l.animation.pan({
                duration: 1000,
                source: (vmap.getView().getCenter())
            });
            vmap.beforeRender(pan);
            //vmap.getView().setCenter(ol.proj.transform(_center, 'EPSG:4326', ""EPSG:900913""));
            vmap.getView().setCenter(_center);
            setTimeout(""fnMoveZoom()"", 2000);            
        }
        function fnMoveZoom() {
            zoom = vmap.getView().getZoom();
            if (16 > zoom) {
                vmap.getView().setZoom(18);
            }
        };

          
    </script>

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(11567, 9, true);
            WriteLiteral("\r\n</html>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
