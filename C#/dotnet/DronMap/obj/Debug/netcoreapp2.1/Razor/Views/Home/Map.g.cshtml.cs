#pragma checksum "C:\Users\K\Documents\TIL\C#\dotnet\DronMap\Views\Home\Map.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf2c382b2d7c1a227631c27f0027b8a991c902ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Map), @"mvc.1.0.view", @"/Views/Home/Map.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Map.cshtml", typeof(AspNetCore.Views_Home_Map))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf2c382b2d7c1a227631c27f0027b8a991c902ab", @"/Views/Home/Map.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17c0d9e796847446abb77a811db1a9ab4131c5a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Map : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 4 "C:\Users\K\Documents\TIL\C#\dotnet\DronMap\Views\Home\Map.cshtml"
  
    ViewBag.Title = "MAP";
    Layout = null;//asp.net core의 레이아웃에 벗어나기 위해 추가

#line default
#line hidden
            BeginContext(210, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(490, 64, true);
            WriteLiteral("<h2>Dron map</h2>\r\n\r\n<!doctype html>\r\n    <html lang=\"ko\">\r\n    ");
            EndContext();
            BeginContext(554, 757, false);
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bfbcd038d6a24756882eaa17185b6e42", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ea3e07d314c4ef0a6f6cd40a522400c", async() => {
>>>>>>> ebeb377b7ad28db12337bd22f857160a985eef32
                BeginContext(560, 744, true);
                WriteLiteral(@"
        <meta charset=""utf-8"">
        <title>Dron map</title>
        <script src=""https://code.jquery.com/jquery-3.0.0.min.js""></script>
        <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"" />
        <!--vworld API-->
        <script type=""text/javascript"" src=""https://map.vworld.kr/js/vworldMapInit.js.do?version=2.0&apiKey=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF""></script>
        <!--네이버 API 시작 -->
        <script src=""https://openapi.map.naver.com/openapi/v3/maps.js?ncpClientId=50t2a22815&submodules=drawing""></script>
        <script type=""text/javascript"" src=""https://openapi.map.naver.com/openapi/v3/maps.js?ncpClientId=50t2a22815&submodules=geocoder""></script>
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
            BeginContext(1311, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(1317, 27807, false);
<<<<<<< HEAD
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8bb9135353141189d7f486718e540dc", async() => {
=======
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad4f649bf75c47a4b014f5741bb72287", async() => {
>>>>>>> ebeb377b7ad28db12337bd22f857160a985eef32
                BeginContext(1323, 27794, true);
                WriteLiteral(@"
        <style type=""text/css"">
            .buttons {           
                position:relative;
                top:30px;                
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
              ");
                WriteLiteral(@"  <button id=""simul"" type=""button"" class=""btn btn-default btn-lg btn-block""> 실시간 전시</button>
                <button id=""temp"" type=""button"" class=""btn btn-default btn-lg btn-block""> 임시 버튼 </button>
            </div>
            <div class=""custom-control custom-checkbox checkbox-xl"" "">
                <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aisprhc"">
                <label class=""custom-control-label"" for=""customCheck1"" style=""color:red"">비행금지구역</label><br />
                <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aisctrc"">
                <label class=""custom-control-label"" for=""customCheck1"" style=""color:orange""> 관제권</label><br />
                <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aisresc"">
                <label class=""custom-control-label"" for=""customCheck1"" style=""color:orangered""> 비행제한구역</label><br />
                <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aisdngc"">
                <label class=""custom-c");
                WriteLiteral(@"ontrol-label"" for=""customCheck1"" style=""color:purple""> 위험구역    25kg↑</label><br />
                <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aismoac"">
                <label class=""custom-control-label"" for=""customCheck1"" style=""color:olive""> 군작전구역    25kg↑</label><br />
                <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aiscatc"">
                <label class=""custom-control-label"" for=""customCheck1"" style=""color:blue""> 훈련구역    25kg↑</label><br />
                <input type=""checkbox"" class=""custom-control-input"" id=""lt_c_aistmac"">
                <label class=""custom-control-label"" for=""customCheck1"" style=""color:brown""> 접근관제구역 25kg↑</label>
            </div>
        </div>
        
        <!--지도가 들어갈 영역-->
        <div id=""map"" style=""height:100%; float:right; width:87%""></div>

        <script>
            var map = new naver.maps.Map(""map"", {
                zoom: 18,
                //maxzoom:
                center: new naver.maps.LatLng(3");
                WriteLiteral(@"6.393239, 127.354109),
                mapTypeId: ""normal"",
                mapTypeControl: true,
                mapTypeControlOptions: {
                    style: naver.maps.MapTypeControlStyle.LARGE
                }                
            });
            
            //var degrees2meters = function (lon, lat) { var x = lon * 20037508.34 / 180; var y = Math.log(Math.tan((90 + lat) * Math.PI / 360)) / (Math.PI / 180); y = y * 20037508.34 / 180; return [x, y] }
            //console.log(degrees2meters(132.158513, 38.805633)); //132.158513 , 38.805633
            //console.log(degrees2meters(123.786931, 31.998937)); //123.786931   , 31.998937
            var bounds = new N.LatLngBounds(
                    new N.LatLng(38.805633, 132.158513),
                    new N.LatLng(31.998937, 123.786931)
                )

            //비행 제한구역 뿌리기

            //var a = map.getBounds().minX();//127.3511344
            //console.log(a);
            //var text = map.getBounds().minY() + ',' ");
                WriteLiteral(@"+ map.getBounds().minX() + ',' + map.getBounds().maxY() + ',' + map.getBounds().maxX();
            //console.log(text);
            //var groundOverlay = new naver.maps.GroundOverlay(
            //    //""http://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aisresc&STYLES=lt_c_aisresc&CRS=EPSG:900913&BBOX=13779898.123863915,3763171.0921612238,14711818.369108325,4693868.284896673&WIDTH=600&HEIGHT=600&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
            //    //""http://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aisresc&STYLES=lt_c_aisresc&CRS=EPSG:4326&BBOX=31.998937,123.786931,38.805633,132.158513&WIDTH=600&HEIGHT=600&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
            //    ""http://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=h");
                WriteLiteral(@"ttp://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aisresc&STYLES=lt_c_aisresc&CRS=EPSG:4326&BBOX="" + text + ""&WIDTH=600&HEIGHT=600&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"" ,
            //    bounds, {
            //        opacity: 1,
            //        clickable: false
            //    }
            //);

            var groundOverlays = [];

            $('#FL').on(""click"", function (e) {
                e.preventDefault();
                var text = (map.getBounds().minY() - 0.3) + ',' + (map.getBounds().minX() - 0.3) + ',' + (map.getBounds().maxY() + 0.3) + ',' + (map.getBounds().maxX() + 0.3);                
                //var bounds = new N.LatLngBounds(
                //    new N.LatLng(map.getBounds().maxY() + 0.3, map.getBounds().maxX() + 0.3),
                //    new N.LatLng(map.getBounds().minY() - 0.3, map.getBounds().minX() - 0.3)                    
                //)
         
                var groundOverlay = ne");
                WriteLiteral(@"w naver.maps.GroundOverlay(
                    ""http://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aisresc&STYLES=lt_c_aisresc&CRS=EPSG:900913&BBOX=13779898.123863915,3763171.0921612238,14711818.369108325,4693868.284896673&WIDTH=600&HEIGHT=600&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
                    //""https://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aisresc&STYLES=lt_c_aisresc&CRS=EPSG:4326&BBOX=31.998937,123.786931,38.805633,132.158513&WIDTH=4096&HEIGHT=4096&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",                    
                    //""https://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aisresc&STYLES=lt_c_aisresc&CRS=EPSG:4326&BBOX="" + text + ""&");
                WriteLiteral(@"WIDTH=1024&HEIGHT=1024&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
                    bounds, {
                        opacity: 1,
                        clickable: false
                    }
                );

                groundOverlays.push(groundOverlay);

                if (groundOverlays[0].getMap()) {
                    groundOverlays[0].setMap(null);
                    $('#FL').val('제한구역 보기');
                    //map.setZoom(7, true);
                } else {
                    groundOverlays[0].setMap(map);
                    $('#FL').val('제한구역 없애기');
                    //map.setZoom(7, true);
                }
            });

            new N.LatLng(38.805633, 132.158513),
                new N.LatLng(31.998937, 123.786931)

            var groundOverlays = [];

            var groundOverlay = new naver.maps.GroundOverlay(
                ""http://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0");
                WriteLiteral(@".0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aisprhc&STYLES=lt_c_aisprhc&CRS=EPSG:4326&BBOX=123.786931,31.998937,132.158513,38.805633&WIDTH=1024&HEIGHT=1024&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
                bounds, {
                    opacity: 1,
                    clickable: false
                }
            );

            var groundOverlay2 = new naver.maps.GroundOverlay(
                ""http://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aisctrc&STYLES=lt_c_aisctrc&CRS=EPSG:4326&BBOX=123.786931,31.998937,132.158513,38.805633&WIDTH=1024&HEIGHT=1024&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
                bounds, {
                    opacity: 1,
                    clickable: false
                }
            );

            var groundOverlay3 = new naver.maps.GroundOverlay(
                ""http://api.vwor");
                WriteLiteral(@"ld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aisresc&STYLES=lt_c_aisresc&CRS=EPSG:4326&BBOX=123.786931,31.998937,132.158513,38.805633&WIDTH=1024&HEIGHT=1024&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
                bounds, {
                    opacity: 1,
                    clickable: false
                }
            );

            var groundOverlay4 = new naver.maps.GroundOverlay(
                ""http://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aisdngc&STYLES=lt_c_aisdngc&CRS=EPSG:4326&BBOX=123.786931,31.998937,132.158513,38.805633&WIDTH=1024&HEIGHT=1024&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
                bounds, {
                    opacity: 1,
                    clickable: false
                }
            );

            var ground");
                WriteLiteral(@"Overlay5 = new naver.maps.GroundOverlay(
                ""http://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aismoac&STYLES=lt_c_aismoac&CRS=EPSG:4326&BBOX=123.786931,31.998937,132.158513,38.805633&WIDTH=1024&HEIGHT=1024&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
                bounds, {
                    opacity: 1,
                    clickable: false
                }
            );

            var groundOverlay6 = new naver.maps.GroundOverlay(
                ""http://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aiscatc&STYLES=lt_c_aiscatc&CRS=EPSG:4326&BBOX=123.786931,31.998937,132.158513,38.805633&WIDTH=1024&HEIGHT=1024&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
                bounds, {
                    opacity: 1,
                    cli");
                WriteLiteral(@"ckable: false
                }
            );

            var groundOverlay7 = new naver.maps.GroundOverlay(
                ""http://api.vworld.kr/req/wms?key=B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF&domain=http://127.0.0.1&SERVICE=WMS&REQUEST=GetMap&VERSION=1.3.0&LAYERS=lt_c_aistmac&STYLES=lt_c_aistmac&CRS=EPSG:4326&BBOX=123.786931,31.998937,132.158513,38.805633&WIDTH=1024&HEIGHT=1024&FORMAT=image/png&TRANSPARENT=TRUE&BGCOLOR=#FF2F3F&EXCEPTIONS=text/xml&"",
                bounds, {
                    opacity: 1,
                    clickable: false
                }
            );

            groundOverlays.push(groundOverlay);
            groundOverlays.push(groundOverlay2);
            groundOverlays.push(groundOverlay3);
            groundOverlays.push(groundOverlay4);
            groundOverlays.push(groundOverlay5);
            groundOverlays.push(groundOverlay6);
            groundOverlays.push(groundOverlay7);

            var layList = [""lt_c_aisprhc"", ""lt_c_aisctrc"", ""lt_c_aisresc");
                WriteLiteral(@""", ""lt_c_aisdngc"", ""lt_c_aismoac"", ""lt_c_aiscatc"", ""lt_c_aistmac""];

            $('#' + layList[0]).change(function () {                
                if ($('#' + layList[0]).is("":checked"")) {
                    groundOverlays[0].setMap(map);
                } else {
                    groundOverlays[0].setMap(null);                    
                }
            });

            $('#' + layList[1]).change(function () {
                if ($('#' + layList[1]).is("":checked"")) {
                    groundOverlays[1].setMap(map);
                } else {
                    groundOverlays[1].setMap(null);                    
                }
            });

            $('#' + layList[2]).change(function () {
                if ($('#' + layList[2]).is("":checked"")) {
                    groundOverlays[2].setMap(map);
                } else {
                    groundOverlays[2].setMap(null);
                }
            });

            $('#' + layList[3]).change(function () ");
                WriteLiteral(@"{
                if ($('#' + layList[3]).is("":checked"")) {
                    groundOverlays[3].setMap(map);
                } else {
                    groundOverlays[3].setMap(null);
                }
            });

            $('#' + layList[4]).change(function () {
                if ($('#' + layList[4]).is("":checked"")) {
                    groundOverlays[4].setMap(map);
                } else {
                    groundOverlays[4].setMap(null);
                }
            });

            $('#' + layList[5]).change(function () {
                if ($('#' + layList[5]).is("":checked"")) {
                    groundOverlays[5].setMap(map);
                } else {
                    groundOverlays[5].setMap(null);
                }
            });

            $('#' + layList[6]).change(function () {
                if ($('#' + layList[6]).is("":checked"")) {
                    groundOverlays[6].setMap(map);
                } else {
                    groundOverlays[6].");
                WriteLiteral(@"setMap(null);
                }
            });


            var position = new naver.maps.LatLng(36.393239, 127.354109);  //넷커스터마이즈 위치
            
            $(""#position"").on(""click"", function (e) {
                e.preventDefault();
                map.setCenter(position);
                map.setZoom(18, true);
            });

            //사각형 이동 
            var distance = 0, dir = 0, dx, dy;
            const moveRect = function (dis) {
                //상하좌우 배열로 변경하기 
                if (dir == 1) {//우측                     
                    dx = 1; dy = 0;
                    if (distance == dis) {
                        distance = 0;
                        dir++;
                    }
                }
                else if (dir == 2) {//상측                    
                    dx = 0; dy = 1;
                    if (distance == dis) {
                        distance = 0;
                        dir++;
                    }
                }
              ");
                WriteLiteral(@"  else if (dir == 3) {//좌측                    
                    dx = -1; dy = 0;
                    if (distance == dis) {
                        distance = 0;
                        dir++;
                    }
                }
                else {//하측                    
                    dx = 0; dy = -1;
                    if (distance == dis) {
                        distance = 0;
                        dir = 1;
                    } 
                }
                distance++;
            }
            
            //드론, 수신기 배열
            var markers = [],
                infoWindows = [];
            var dronMarker = new Array();
            
            var AntennaMarker = new Array();            
            var dronNum = 0;
            var AntennaNum = 0;
            function plusTargetNum(target) {
                if (target == 5) //갯수 제한
                    return;
                return ++target;
            }
            function minusTargetNum(targe");
                WriteLiteral(@"t) {
                if (target == 0)
                    return;
                return --target;
            }
            
            function dronMove() {
                var mt = setInterval(function () {
                    if (dronNum) {                        
                        //깜빡이는 효과 (x y 사용시 지워지기때문)
                        //dronMarker[dronNum].setPosition(N.LatLng(dronMarker[dronNum].getPosition().x + 0.0000015, dronMarker[dronNum].getPosition().y + 0.0000015));
                        //그냥 이동 
                        //dronMarker[dronNum].setPosition(N.LatLng(dronMarker[dronNum].getPosition()._lat + 0.0000015, dronMarker[dronNum].getPosition()._lng + 0.0000015));                        
                        //랜덤 이동 
                        //var ranNum = Math.floor(Math.random() * (19)) - 9; //-9~9
                        //dronMarker[dronNum].setPosition(N.LatLng(dronMarker[dronNum].getPosition()._lat + (ranNum * 0.000005), dronMarker[dronNum].getPosition()._lng + (ran");
                WriteLiteral(@"Num * 0.000005)));                        
                        //사각형 이동 
                        moveRect(3000);

                        for (var i in markers) {
                            if(i == 0)
                                markers[i].setPosition(N.LatLng(markers[i].getPosition()._lat + 0.0000015 * dx, markers[i].getPosition()._lng + 0.0000015 * dy));
                            else if (i == 1)
                                markers[i].setPosition(N.LatLng(markers[i].getPosition()._lat + 0.0000015 * (-dx), markers[i].getPosition()._lng + 0.0000015 * dy));
                            else if (i == 2)
                                markers[i].setPosition(N.LatLng(markers[i].getPosition()._lat + 0.0000015 * dx, markers[i].getPosition()._lng + 0.0000015 * (-dy)));
                            else
                                markers[i].setPosition(N.LatLng(markers[i].getPosition()._lat + 0.0000015 * (-dx), markers[i].getPosition()._lng + 0.0000015 * (-dy)));
                      ");
                WriteLiteral(@"  }
                    }
                    else
                        return;                
                }, 50);                
            }            

            function getDronClickHandler(seq) {
                return function (e) {
                    var marker = markers[seq],
                        infoWindow = infoWindows[seq];

                    if (infoWindow.getMap()) {
                        infoWindow.close();
                    } else {
                        infoWindow.open(map, marker);
                    }
                }
            }
            
            $(""#addDron"").on(""click"", function (e) {
                //e.preventDefault();
                if (dronNum == 5) return;

                dronNum = plusTargetNum(dronNum);

                //드론 마커
                var markerOptions = {
                    position: map.getCenter(),//position.destinationPoint(90, 15),
                    title: ""Dron "" + dronNum,
                    dr");
                WriteLiteral(@"aggable: true,
                    map: map,
                    icon: {
                        //url: 'https://postfiles.pstatic.net/MjAxOTA0MDlfMTYy/MDAxNTU0NzgxNDMxODAz.acYMb0Rt6XWRepcNb3Zi67dO0XuErjKTpdgzImVbnwYg.PTuHU3XhQDzPNQJ0X_Dw6eBqcwjxCRl5VjNs_VG9pgYg.PNG.w1nw1n75004/PicsArt_03-23-04.58.23.png?type=w773',
                        url: ""../images/dronImg2.png"",

                        size: new naver.maps.Size(25, 34),
                        scaledSize: new naver.maps.Size(25, 34),
                        origin: new naver.maps.Point(0, 0),
                        anchor: new naver.maps.Point(12, 34),

                    },
                    //animation: naver.maps.Animation.BOUNCE
                };

                var dronMarker = new naver.maps.Marker(markerOptions);

                markers.push(dronMarker);
                
                //드론 정보 팝업창 
                var contentString = [
                    '<div class=""iw_inner"">',
                    '   <h3>드론 정보");
                WriteLiteral(@" ' + dronNum + '</h3>',
                    '   <p>소유자<br />',
                    '       핸드폰 번호<br />',
                    '       등록 여부<br />',
                    '       <img src=""/images/DronIndexImg.jpg"" /><br />',
                    '       ',
                    '   </p>',
                    '</div>'
                ].join('');

                var infowindow = new naver.maps.InfoWindow({
                    content: contentString
                });

                infoWindows.push(infowindow);

                console.log(dronNum);
             
                N.Event.addListener(markers[dronNum - 1], 'click', getDronClickHandler(dronNum - 1));//드론 클릭시 정보창 뜨도록 설정 

                dronMove();               
            });                        
            

            $(""#temp"").on(""click"", function (e) {
                e.preventDefault();
                
                console.log(Math.floor(Math.random() * (19)) - 9);                                
       ");
                WriteLiteral(@"     })
                        
            $(""#addAntenna"").on(""click"", function (e) {
                e.preventDefault();
                if (AntennaNum == 5) return;
                AntennaNum = plusTargetNum(AntennaNum);
                var markerOptions = {
                    position: map.getCenter(),//position.destinationPoint(90, 15),
                    map: map,
                    title: AntennaNum,
                    draggable: true,
                    icon: {
                        url: 'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSD-cYM4abdIAI7V9HiHo8lLTIrpbxo-SItFMM2mi3pviovhU5O&usqp=CAU',
                        size: new naver.maps.Size(25, 34),
                        scaledSize: new naver.maps.Size(25, 34),
                        origin: new naver.maps.Point(0, 0),
                        anchor: new naver.maps.Point(12, 34)
                    },
                };

                AntennaMarker[AntennaNum] = new naver.maps.Marker(markerOptions);
    ");
                WriteLiteral(@"        });         

            var infoWindow2 = new naver.maps.InfoWindow({
                anchorSkew: true
            });

            function searchCoordinateToAddress(latlng) {

                infoWindow2.close();

                naver.maps.Service.reverseGeocode({
                    coords: latlng,
                    orders: [
                        naver.maps.Service.OrderType.ADDR,
                        naver.maps.Service.OrderType.ROAD_ADDR
                    ].join(',')
                }, function (status, response) {
                    if (status === naver.maps.Service.Status.ERROR) {
                        if (!latlng) {
                            return alert('ReverseGeocode Error, Please check latlng');
                        }
                        if (latlng.toString) {
                            return alert('ReverseGeocode Error, latlng:' + latlng.toString());
                        }
                        if (latlng.x && latlng.y) {
          ");
                WriteLiteral(@"                  return alert('ReverseGeocode Error, x:' + latlng.x + ', y:' + latlng.y);
                        }
                        return alert('ReverseGeocode Error, Please check latlng');
                    }

                    var items = response.v2.results,
                        address = '',
                        htmlAddresses = [];

                    for (var i = 0, ii = items.length, item, addrType; i < ii; i++) {
                        item = items[i];
                        address = makeAddress(item) || '';
                        addrType = item.name === 'roadaddr' ? '[도로명 주소]' : '[지번 주소]';

                        htmlAddresses.push((i + 1) + '. ' + addrType + ' ' + address);
                    }

                    infoWindow2.setContent([
                        '<div style=""padding:10px;min-width:200px;line-height:150%;"">',
                        '<h4 style=""margin-top:5px;"">검색 좌표</h4><br />',
                        htmlAddresses.join('<br />'),
  ");
                WriteLiteral(@"                      '</div>'
                    ].join('\n'));

                    infoWindow2.open(map, latlng);
                });
            }
                        
            function initGeocoder() {
                if (!map.isStyleMapReady) {
                    return;
                }

                map.addListener('rightclick', function (e) {
                    
                    searchCoordinateToAddress(e.coord);
                });

                map.addListener('click', function (e) {
                    infoWindow2.close();
                    
                });                               
            }

            function makeAddress(item) {
                if (!item) {
                    return;
                }

                var name = item.name,
                    region = item.region,
                    land = item.land,
                    isRoadAddress = name === 'roadaddr';

                var sido = '', sigugun = '', dong");
                WriteLiteral(@"myun = '', ri = '', rest = '';

                if (hasArea(region.area1)) {
                    sido = region.area1.name;
                }

                if (hasArea(region.area2)) {
                    sigugun = region.area2.name;
                }

                if (hasArea(region.area3)) {
                    dongmyun = region.area3.name;
                }

                if (hasArea(region.area4)) {
                    ri = region.area4.name;
                }

                if (land) {
                    if (hasData(land.number1)) {
                        if (hasData(land.type) && land.type === '2') {
                            rest += '산';
                        }

                        rest += land.number1;

                        if (hasData(land.number2)) {
                            rest += ('-' + land.number2);
                        }
                    }

                    if (isRoadAddress === true) {
                        if (checkLastStrin");
                WriteLiteral(@"g(dongmyun, '면')) {
                            ri = land.name;
                        } else {
                            dongmyun = land.name;
                            ri = '';
                        }

                        if (hasAddition(land.addition0)) {
                            rest += ' ' + land.addition0.value;
                        }
                    }
                }

                return [sido, sigugun, dongmyun, ri, rest].join(' ');
            }

            function hasArea(area) {
                return !!(area && area.name && area.name !== '');
            }

            function hasData(data) {
                return !!(data && data !== '');
            }

            function checkLastString(word, lastString) {
                return new RegExp(lastString + '$').test(word);
            }

            function hasAddition(addition) {
                return !!(addition && addition.value);
            }

            naver.maps.onJSContentLoa");
                WriteLiteral("ded = initGeocoder;\r\n            naver.maps.Event.once(map, \'init_stylemap\', initGeocoder);\r\n\r\n\r\n\r\n            \r\n        </script>        \r\n\r\n    ");
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
            BeginContext(29124, 15, true);
            WriteLiteral("\r\n    </html>\r\n");
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
