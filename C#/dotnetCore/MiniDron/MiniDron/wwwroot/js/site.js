// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function plusTargetNum(target) {
    if (target == 5) //갯수 제한
        return;
    return ++target;
}
function minusTargetNum(target) {
    if (target == 0)
        return;
    return --target;
}

const dronNumLimit = 5;
let dronNum = 0;//드론 객체 수
let dronObject = []; //드론 객체가 담길 배열
let markerLayer; //마커를 담을 레이어

////마커(드론) 추가
//$("#addDron").on("click", function (e) {    

//    if (dronNum == dronNumLimit) {//임의로 5개로 제한
//        alert("허용 드론 수 초과");
//        return;
//    }
    
//    var time = new Date().toLocaleTimeString('ko-KR', { timeStyle: 'medium', hourCycle: 'h24' });
//    dronObject.push(new DronInfo(dronNum, "Dron" + dronNum, "익명", "010-xxxx-xxxx", "YES", 0, time));

//    if (markerLayer == null) {//레이어가 없으면 생성함 (init)
//        markerLayer = new vw.ol3.layer.Marker(vmap);
//        markerLayer.set("name", "마커레이어");
//    }

//    var addPoint = [];
//    addPoint.push(ol.proj.transform([vmap.getView().getCenter()[0], vmap.getView().getCenter()[1]], "EPSG:900913", "EPSG:4326"));//현재 지도의 중앙 좌표 콜

//    vw.ol3.markerOption = {
//        x: addPoint[0][0], 
//        y: addPoint[0][1],
//        epsg: "EPSG:4326",
//        title: dronObject[dronNum].name + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ID',
//        contents: '동 작 상 태:' + '-' + '</br>'  //여기서 콘텐츠는 구현 안해줘도 될듯
//            + '식별시작시간:' + '<span Id="dStartIdTime"></span>' + '</br>'
//            + '식 별 시 간:' + '<span Id="dIdTime"></span>' + '</br>'
//            + '속       도:' + '-' + '</br>'
//            + '방       향:' + '-' + '</br>'
//            + '주       소:' + '-' + '</br>'
//            + '위 도/경 도:' + '-' + '</br>'
//            + '해 발 고 도:' + '-' + '</br>'
//            + '식별기 목록:' + '-' + '</br>'
//            + '<hr>'
//            + '<button id="dronInfoPop" onclick="button1_click();">드론</button>' + '&nbsp&nbsp'
//            + '<button id="dronMasPop" >소유자</button>' + '&nbsp&nbsp'
//            + '<button id="dronStatusPop">로그</button>',
//        iconUrl: '../images/dronImg2.png',
//    }; //마커 옵션 설정

//    dronObject.popInfo = markerLayer.addMarker(vw.ol3.markerOption);// 마커를 레이어에 등록
//    dronObject.popInfo.set("id", "Marker-" + dronNum); // 마커 팝업레이어 ID 등록

//    if (vmap.getLayerByName("마커레이어") == null)//하나의 레이어에 추가
//    {
//        markerLayer.setZIndex(10); // 이동 경로보다 마커가 위에오도록함
//        vmap.addLayer(markerLayer) //마커를 vmap에 등록
//    }

//    dronObject[dronNum].createRoute();
//    dronObject[dronNum].startPause();//가상 전시 타이머 + 주행시간 타이머

//    dronNum = plusTargetNum(dronNum);
//})

////드론 삭제
//$("#delDron").on("click", function (e) {
//    e.preventDefault();

//    if (dronNum == 0) {
//        alert("드론이 없습니다.");
//        return;
//    }
//    dronNum = minusTargetNum(dronNum);

//    var DronFeatures = markerLayer.getSource().getFeatures();

//    for (var i = 0; i < dronNum + 1; i++) {
//        if (DronFeatures[i].get('id') == ("Marker-" + dronNum))
//            markerLayer.removeMarker(DronFeatures[i]);
//    }



//    //vmap.getLayers().getArray().filter(vectorLayer => vectorLayer.get('name') === '경로레이어' + dronNum).forEach(vectorLayer => vmap.removeLayer(vectorLayer));
//    dronObject[dronNum].startPause(); //드론 비행시간 종료

//    dronObject.pop(); //드론객체를 스택형식으로 사용하지만 추후에 선택된 드론으로 변경할지 검토
//});

$("#mapmode1").on("click", function (e) {
    e.preventDefault();
    setMode(vw.ol3.BasemapType.GRAPHIC);
    $("#mapmode1").addClass('active')
    $("#mapmode2").removeClass('active')
    $("#mapmode3").removeClass('active')
    $("#mapmode4").removeClass('active')
})

$("#mapmode2").on("click", function (e) {
    e.preventDefault();
    setMode(vw.ol3.BasemapType.GRAPHIC_NIGHT);
    $("#mapmode1").removeClass('active')
    $("#mapmode2").addClass('active')
    $("#mapmode3").removeClass('active')
    $("#mapmode4").removeClass('active')
})

$("#mapmode3").on("click", function (e) {
    e.preventDefault();
    setMode(vw.ol3.BasemapType.PHOTO);
    $("#mapmode1").removeClass('active')
    $("#mapmode2").removeClass('active')
    $("#mapmode3").addClass('active')
    $("#mapmode4").removeClass('active')
})

$("#mapmode4").on("click", function (e) {
    e.preventDefault();
    setMode(vw.ol3.BasemapType.PHOTO_HYBRID);
    $("#mapmode1").removeClass('active')
    $("#mapmode2").removeClass('active')
    $("#mapmode3").removeClass('active')
    $("#mapmode4").addClass('active')
})

$(".vw-span").click(function () {
    $("#mapmode1").toggle(
        function () { $('#mapmode1').addClass('d.none') },
        function () { $('#mapmode1').addClass('d.print') }
    )
})

function setMode(basemapType) {
    vmap.setBasemapType(basemapType);
}

//지정 위치로 지도 이동 부드럽게

var move = function (x, y, zoom) {//127.10153, 37.402566
    vmap.getView().setCenter(ol.proj.transform([x, y], 'EPSG:4326', "EPSG:900913")); // 지도 이동
    vmap.getView().setZoom(zoom);
}

//function move(x, y, z) {
//    var _center = [x, y];

//    var z = z;
//    var pan = ol.animation.pan({
//        duration: 1000,
//        source: (vmap.getView().getCenter())
//    });
//    vmap.beforeRender(pan);
//    //vmap.getView().setCenter(ol.proj.transform(_center, 'EPSG:4326', "EPSG:900913"));
//    vmap.getView().setCenter(_center);
//    setTimeout("fnMoveZoom()", 2000);
//}

function fnMoveZoom() {
    zoom = vmap.getView().getZoom();
    if (16 > zoom) {
        vmap.getView().setZoom(18);
    }
};

var layList = ["lt_c_aisprhc", "lt_c_aisctrc", "lt_c_aisresc", "lt_c_aisdngc", "lt_c_aismoac", "lt_c_aiscatc", "lt_c_aistmac"];

$('#' + layList[0]).change(function () {
    if ($('#' + layList[0]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("비행금지구역", layList[0]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.getLayerByName("비행금지구역");
        vmap.removeLayer(vmap.getLayerByName("비행금지구역"));
    }
});

$('#' + layList[1]).change(function () {
    if ($('#' + layList[1]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("관제권", layList[1]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.getLayerByName("관제권");
        vmap.removeLayer(vmap.getLayerByName("관제권"));
    }
});

$('#' + layList[2]).change(function () {
    if ($('#' + layList[2]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("비행제한구역", layList[2]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.getLayerByName("비행제한구역");
        vmap.removeLayer(vmap.getLayerByName("비행제한구역"));
    }
});

$('#' + layList[3]).change(function () {

    if ($('#' + layList[3]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("위험구역", layList[3]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.getLayerByName("위험구역");
        vmap.removeLayer(vmap.getLayerByName("위험구역"));
    }
});

$('#' + layList[4]).change(function () {
    if ($('#' + layList[4]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("군작전구역", layList[4]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.getLayerByName("군작전구역");
        vmap.removeLayer(vmap.getLayerByName("군작전구역"));
    }
});

$('#' + layList[5]).change(function () {
    if ($('#' + layList[5]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("훈련구역", layList[5]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.getLayerByName("훈련구역");
        vmap.removeLayer(vmap.getLayerByName("훈련구역"));
    }
});

$('#' + layList[6]).change(function () {
    if ($('#' + layList[6]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("접근관제구역", layList[6]);
        vmap.addLayer(wmslayer);
    } else {
        //vmap.getLayerByName("접근관제구역"); //?
        vmap.removeLayer(vmap.getLayerByName("접근관제구역"));
    }
});

$('#adsigg').change(function () {
    if ($('#adsigg').is(":checked")) {
        var wmslayer = vmap.addNamedLayer("시군구경계", "lt_c_adsigg");
        vmap.addLayer(wmslayer);
    } else {        
        vmap.removeLayer(vmap.getLayerByName("시군구경계"));
    }
});

$('#ademd').change(function () {
    if ($('#ademd').is(":checked")) {
        var wmslayer = vmap.addNamedLayer("읍면동경계", "lt_c_ademd");
        vmap.addLayer(wmslayer);
    } else {        
        vmap.removeLayer(vmap.getLayerByName("읍면동경계"));
    }
});




$("#position").on("click", function (e) {
    e.preventDefault();
    move(14176994.56431106, 4354866.236842043, 18);
});

$("#dispRoute").on("click", function (e) {
    e.preventDefault();

    if ($(this).css('background-color') == 'rgb(0, 230, 0)') {
        $(this).css('background-color', 'rgb(230, 230, 230)');
        for (var i = 0; i < dronNum; i++)
            vmap.getLayerByName("경로레이어" + i).setVisible(false);
    }
    else {
        $(this).css('background-color', 'rgb(0, 230, 0)');
        for (var i = 0; i < dronNum; i++)
            vmap.getLayerByName("경로레이어" + i).setVisible(true);
    }
});

$("#dispDotRoute").on("click", function (e) {
    e.preventDefault();

    if ($(this).css('background-color') == 'rgb(0, 230, 0)') {
        $(this).css('background-color', 'rgb(230, 230, 230)');
        for (var i = 0; i < dronNum; i++)
            vmap.getLayerByName("경로점레이어" + i).setVisible(false);
    }
    else {
        $(this).css('background-color', 'rgb(0, 230, 0)');
        for (var i = 0; i < dronNum; i++)
            vmap.getLayerByName("경로점레이어" + i).setVisible(true);
    }
});

function toggleNav() {
    if (document.getElementById("mySidebar").style.width == "13%") {
        document.getElementById("mySidebar").style.width = "0%";
        document.getElementById("vmap").style.width = "100%";        
    }
    else {
        document.getElementById("mySidebar").style.width = "13%";
        //document.getElementById("main").style.marginLeft = "250px";
        document.getElementById("vmap").style.width = "87%";        
    }    
}

//시도군 콤보박스 선택 
$(function () {

    $.ajax({
        type: "get",
        url: "http://openapi.nsdi.go.kr/nsdi/eios/service/rest/AdmService/admCodeList.json",
        data: { authkey: $('#sido_key').val() },
        async: false,
        dataType: 'json',
        success: function (data) {
            var html = "<option>선택</option>";

            for (var i = 0; i < data.admVOList.admVOList.length; i++) {
                html += "<option value='" + data.admVOList.admVOList[i].admCode + "'>" + data.admVOList.admVOList[i].lowestAdmCodeNm + "</option>"
            }

            $('#sido_code').html(html);

        },
        error: function (xhr, stat, err) { }
    });


    $(document).on("change", "#sido_code", function () {
        var thisVal = $(this).val();

        $.ajax({
            type: "get",
            url: "http://openapi.nsdi.go.kr/nsdi/eios/service/rest/AdmService/admSiList.json",
            data: { admCode: thisVal, authkey: $('#sigoon_key').val() },
            async: false,
            dataType: 'json',
            success: function (data) {
                var html = "<option>선택</option>";

                for (var i = 0; i < data.admVOList.admVOList.length; i++) {
                    html += "<option value='" + data.admVOList.admVOList[i].admCode + "'>" + data.admVOList.admVOList[i].lowestAdmCodeNm + "</option>"
                }

                $('#sigoon_code').html(html);

            },
            error: function (xhr, stat, err) { }
        });
    });

    $(document).on("change", "#sigoon_code", function () {
        var thisVal = $(this).val();

        $.ajax({
            type: "get",
            url: "http://openapi.nsdi.go.kr/nsdi/eios/service/rest/AdmService/admDongList.json",
            data: { admCode: thisVal, authkey: $('#dong_key').val() },
            async: false,
            dataType: 'json',
            success: function (data) {
                var html = "<option>선택</option>";

                for (var i = 0; i < data.admVOList.admVOList.length; i++) {
                    html += "<option value='" + data.admVOList.admVOList[i].admCode + "'>" + data.admVOList.admVOList[i].lowestAdmCodeNm + "</option>"
                }

                $('#dong_code').html(html);

            },
            error: function (xhr, stat, err) { }
        });
    });
    $(document).on("change", "#dong_code", function () {
        var thisVal = $(this).val();
        var addressText = $("#sido_code option:selected").text() + " " + $("#sigoon_code option:selected").text() + " " + $("#dong_code option:selected").text()
        //address

        geocoder(addressText);

    });

})

var dataAjax = function (x, y) {
    $.ajax({
        type: "get",
        url: "https://api.vworld.kr/req/data?geomFilter=POINT(" + x + " " + y + ")",
        data: $('#dataForm').serialize(),
        dataType: 'jsonp',
        async: false,
        success: function (data) {
            var vectorSource = new ol.source.Vector({ features: (new ol.format.GeoJSON()).readFeatures(data.response.result.featureCollection) })

            var vector_layer = new ol.layer.Vector({
                source: vectorSource
            })

            vector_layer.set("vectorLayer", "search_vector")

            vmap.getLayers().forEach(function (layer) { //기존검색결과 제거 
                if (layer.get("vectorLayer") == "search_vector") {
                    vmap.removeLayer(layer);
                }
            });

            vmap.addLayer(vector_layer);
        },
        complete: function () {
            $('#loading').text("");
        },

        error: function (xhr, stat, err) { }
    });
}

/**
 *  지오코더 호출 
 */
var geocoder = function (name) {
    $.ajax({
        type: "get",
        url: "https://api.vworld.kr/req/address?service=address&version=2.0&request=getcoord&format=json&type=parcel",
        data: { apiKey: $('[name=apiKey]').val(), address: name },
        dataType: 'jsonp',
        success: function (data) {
            result = data;
            move(data.response.result.point.x * 1, data.response.result.point.y * 1, 14);
            var point = ol.proj.transform([data.response.result.point.x * 1, data.response.result.point.y * 1], 'EPSG:4326', "EPSG:900913");
            //dataAjax(point[0], point[1]); //검색된 행정 구역에 레이어 칠하는거 일단 막아둠 
        },
        beforeSend: function () {
            $('#loading').text("로딩중....");
        },

        error: function (xhr, stat, err) { }
    });
}

$(function () {
    
    var placeholderElement = $('#modal-placeholder');

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        
        var url = $(this).data('url');        
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();

        $.post(actionUrl, dataToSend).done(function (data) {
            var newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);

            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            if (isValid) {
                placeholderElement.find('.modal').modal('hide');
            }
        });
    });
});

function tempfunc() {

    var placeholderElement = $('#modal-placeholder');

    var url = '/Present/Contact';

    $.get(url).done(function (data) {
        placeholderElement.html(data);
        placeholderElement.find('.modal').modal('show');
    });

    //placeholderElement.on('click', '[data-save="modal"]', function (event) {
    //    event.preventDefault();

    //    var form = $(this).parents('.modal').find('form');
    //    var actionUrl = form.attr('action');
    //    var dataToSend = form.serialize();

    //    $.post(actionUrl, dataToSend).done(function (data) {
    //        var newBody = $('.modal-body', data);
    //        placeholderElement.find('.modal-body').replaceWith(newBody);

    //        var isValid = newBody.find('[name="IsValid"]').val() == 'True';
    //        if (isValid) {
    //            placeholderElement.find('.modal').modal('hide');
    //        }
    //    });
    //});
}

$("#tempbtn").on("click", function (e) {
    e.preventDefault();
    console.log("hellow")

    $.ajax({
        type: 'GET',
        url: '/Present/AddDronInfo',
        success: function (result) {
            console.log(result.longitude);
            
        }
    })

    

});

 //geocoder
var geocoder_reverse = function (x, y) {
    $.ajax({
        type: "get",
        url: "https://api.vworld.kr/req/address?service=address&version=2.0&request=getaddress&format=json&type=both&crs=epsg:900913",
        //data: { apiKey: $('[name=key]').val(), point: x + "," + y },
        data: { apiKey: "B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF", point: x + "," + y },
        dataType: 'jsonp',
        success: function (data) {
            var geoResult = "";
            for (i in data.response.result) {
                if (i != 0) {
                    geoResult += ", ";
                }
                geoResult += data.response.result[i].text;
            }
            //$('#geoAddress').text(geoResult);
            var a = "3";
            return a;
        },
        beforeSend: function () {
            //var g4326 = ol.proj.transform([x * 1, y * 1], 'EPSG:900913', "EPSG:4326");
            //$('#geo4326').text(g4326[0] + "," + g4326[1]);
            //$('#geo3857').text(x + "," + y);

        },

        error: function (xhr, stat, err) { }
    });
}
