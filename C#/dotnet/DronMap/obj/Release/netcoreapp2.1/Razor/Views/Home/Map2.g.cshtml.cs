#pragma checksum "C:\Users\CEO\Desktop\소형드론\source\DronMap\DronMap\Views\Home\Map2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "874aa7bda5bfbdd999d1e226a9461ca504dc1b95"
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
#line 1 "C:\Users\CEO\Desktop\소형드론\source\DronMap\DronMap\Views\_ViewImports.cshtml"
using DronMap;

#line default
#line hidden
#line 2 "C:\Users\CEO\Desktop\소형드론\source\DronMap\DronMap\Views\_ViewImports.cshtml"
using DronMap.Models;

#line default
#line hidden
#line 3 "C:\Users\CEO\Desktop\소형드론\source\DronMap\DronMap\Views\_ViewImports.cshtml"
using DronMap.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"874aa7bda5bfbdd999d1e226a9461ca504dc1b95", @"/Views/Home/Map2.cshtml")]
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
#line 6 "C:\Users\CEO\Desktop\소형드론\source\DronMap\DronMap\Views\Home\Map2.cshtml"
  
    ViewBag.Title = "MAP2";
    Layout = null;//asp.net core의 레이아웃에 벗어나기 위해 추가

#line default
#line hidden
            BeginContext(218, 27, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(245, 478, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79df578544b346babc30303630fed47a", async() => {
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
            BeginContext(727, 12457, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7835dede39dd4452a5204854659e965c", async() => {
                BeginContext(733, 12444, true);
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
        vw.ol3.MapOptions = {
            basemapType: vw.ol3.BasemapType.GRAPHIC
            , controlDensity: vw.ol3.DensityType.FULL
            , interactionDensity: vw.ol3.DensityType.BASIC
            , controlsAutoArrange: true
            , homePosition: vw.ol3.CameraPosition
            , init");
                WriteLiteral(@"Position: vw.ol3.CameraPosition
        };
        vmap = new vw.ol3.Map(""vmap"", vw.ol3.MapOptions);

        //마커 추가
        var markerLayer = new vw.ol3.layer.Marker(vmap);

        vw.ol3.markerOption = {
            //36.393239, 127.354109
            x: 127.354109,
            y: 36.393239,
            epsg: ""EPSG:4326"",
            title: 'netcustomize',
            contents: 'test marker',
            iconUrl: '../images/dronImg2.png',
            //iconUrl: 'http://map.vworld.kr/images/ol3/marker_blue.png',
        }

        markerLayer.addMarker(vw.ol3.markerOption);
        vmap.addLayer(markerLayer);

        var layList = [""lt_c_aisprhc"", ""lt_c_aisctrc"", ""lt_c_aisresc"", ""lt_c_aisdngc"", ""lt_c_aismoac"", ""lt_c_aiscatc"", ""lt_c_aistmac""];
          
        $('#'+layList[0]).change(function () {            
            if ($('#' +layList[0]).is("":checked"")) {                
                var wmslayer = vmap.addNamedLayer(""비행금지구역"", layList[0]);
                vmap.addLayer");
                WriteLiteral(@"(wmslayer);
            } else {
                vmap.getLayerByName(""비행금지구역"");
                vmap.removeLayer(vmap.getLayerByName(""비행금지구역""));
            }
        });

        $('#' + layList[1]).change(function () {            
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

        $('#' + layList[");
                WriteLiteral(@"3]).change(function () {
            
            if ($('#' + layList[3]).is("":checked"")) {                
                var wmslayer = vmap.addNamedLayer(""위험구역"", layList[3]);
                vmap.addLayer(wmslayer);
            } else {
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
                vmap");
                WriteLiteral(@".addLayer(wmslayer);
            } else {
                vmap.getLayerByName(""훈련구역"");
                vmap.removeLayer(vmap.getLayerByName(""훈련구역""));
            }
        });

        $('#' + layList[6]).change(function () {
            if ($('#' + layList[6]).is("":checked"")) {
                var wmslayer = vmap.addNamedLayer(""접근관제구역"", layList[6]);
                vmap.addLayer(wmslayer);
            } else {
                vmap.getLayerByName(""접근관제구역"");
                vmap.removeLayer(vmap.getLayerByName(""접근관제구역""));
            }
        });
                
        var move = function (x, y) {//127.10153, 37.402566
            vmap.getView().setCenter(ol.proj.transform([x, y], 'EPSG:4326', ""EPSG:900913"")); // 지도 이동
            vmap.getView().setZoom(18);
        }

        $(""#position"").on(""click"", function (e) {
            e.preventDefault();                        
            move(127.354109, 36.393239 ); //넷커스터마이즈 위치 
        });
                       
        ////사각형 이");
                WriteLiteral(@"동 
        //var distance = 0, dir = 0, dx, dy;
        //const moveRect = function (dis) {
        //    //상하좌우 배열로 변경하기 
        //    if (dir == 1) {//우측                     
        //        dx = 1; dy = 0;
        //        if (distance == dis) {
        //            distance = 0;
        //            dir++;
        //        }
        //    }
        //    else if (dir == 2) {//상측                    
        //        dx = 0; dy = 1;
        //        if (distance == dis) {
        //            distance = 0;
        //            dir++;
        //        }
        //    }
        //    else if (dir == 3) {//좌측                    
        //        dx = -1; dy = 0;
        //        if (distance == dis) {
        //            distance = 0;
        //            dir++;
        //        }
        //    }
        //    else {//하측                    
        //        dx = 0; dy = -1;
        //        if (distance == dis) {
        //            distance = 0;
        //   ");
                WriteLiteral(@"         dir = 1;
        //        }
        //    }
        //    distance++;
        //}

        ////드론, 수신기 배열
        //var markers = [],
        //    infoWindows = [];
        //var dronMarker = new Array();

        //var AntennaMarker = new Array();
        //var dronNum = 0;
        //var AntennaNum = 0;
        //function plusTargetNum(target) {
        //    if (target == 5) //갯수 제한
        //        return;
        //    return ++target;
        //}
        //function minusTargetNum(target) {
        //    if (target == 0)
        //        return;
        //    return --target;
        //}

        //function dronMove() {
        //    var mt = setInterval(function () {
        //        if (dronNum) {
        //            //깜빡이는 효과 (x y 사용시 지워지기때문)
        //            //dronMarker[dronNum].setPosition(N.LatLng(dronMarker[dronNum].getPosition().x + 0.0000015, dronMarker[dronNum].getPosition().y + 0.0000015));
        //            //그냥 이동 
        //           ");
                WriteLiteral(@" //dronMarker[dronNum].setPosition(N.LatLng(dronMarker[dronNum].getPosition()._lat + 0.0000015, dronMarker[dronNum].getPosition()._lng + 0.0000015));                        
        //            //랜덤 이동 
        //            //var ranNum = Math.floor(Math.random() * (19)) - 9; //-9~9
        //            //dronMarker[dronNum].setPosition(N.LatLng(dronMarker[dronNum].getPosition()._lat + (ranNum * 0.000005), dronMarker[dronNum].getPosition()._lng + (ranNum * 0.000005)));                        
        //            //사각형 이동 
        //            moveRect(3000);

        //            for (var i in markers) {
        //                if (i == 0)
        //                    markers[i].setPosition(N.LatLng(markers[i].getPosition()._lat + 0.0000015 * dx, markers[i].getPosition()._lng + 0.0000015 * dy));
        //                else if (i == 1)
        //                    markers[i].setPosition(N.LatLng(markers[i].getPosition()._lat + 0.0000015 * (-dx), markers[i].getPosition()._lng + 0.00000");
                WriteLiteral(@"15 * dy));
        //                else if (i == 2)
        //                    markers[i].setPosition(N.LatLng(markers[i].getPosition()._lat + 0.0000015 * dx, markers[i].getPosition()._lng + 0.0000015 * (-dy)));
        //                else
        //                    markers[i].setPosition(N.LatLng(markers[i].getPosition()._lat + 0.0000015 * (-dx), markers[i].getPosition()._lng + 0.0000015 * (-dy)));
        //            }
        //        }
        //        else
        //            return;
        //    }, 50);
        //}

        //function getDronClickHandler(seq) {
        //    return function (e) {
        //        var marker = markers[seq],
        //            infoWindow = infoWindows[seq];

        //        if (infoWindow.getMap()) {
        //            infoWindow.close();
        //        } else {
        //            infoWindow.open(map, marker);
        //        }
        //    }
        //}

        //$(""#addDron"").on(""click"", function (e) {
     ");
                WriteLiteral(@"   //    //e.preventDefault();
        //    if (dronNum == 5) return;

        //    dronNum = plusTargetNum(dronNum);

        //    //드론 마커
        //    var markerOptions = {
        //        position: map.getCenter(),//position.destinationPoint(90, 15),
        //        title: ""Dron "" + dronNum,
        //        draggable: true,
        //        map: map,
        //        icon: {
        //            //url: 'https://postfiles.pstatic.net/MjAxOTA0MDlfMTYy/MDAxNTU0NzgxNDMxODAz.acYMb0Rt6XWRepcNb3Zi67dO0XuErjKTpdgzImVbnwYg.PTuHU3XhQDzPNQJ0X_Dw6eBqcwjxCRl5VjNs_VG9pgYg.PNG.w1nw1n75004/PicsArt_03-23-04.58.23.png?type=w773',
        //            url: ""../images/dronImg.png"",

        //            size: new naver.maps.Size(25, 34),
        //            scaledSize: new naver.maps.Size(25, 34),
        //            origin: new naver.maps.Point(0, 0),
        //            anchor: new naver.maps.Point(12, 34),

        //        },
        //        //animation: naver.maps.Animation.BO");
                WriteLiteral("UNCE\r\n        //    };\r\n\r\n        //    var dronMarker = new naver.maps.Marker(markerOptions);\r\n\r\n        //    markers.push(dronMarker);\r\n    </script>\r\n\r\n");
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
            BeginContext(13184, 9, true);
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
