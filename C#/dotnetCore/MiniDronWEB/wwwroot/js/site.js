﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const dronNumLimit = 999;
let dronObject = []; //드론 객체가 담길 배열 (배열로 할지는 검토)
let dronLayer; //드론을 담을 레이어
let dronRouteLayer; //드론의 루트 담을 레이어
let antennaLayer; //식별기담길 레이어
let controllerLayer; //컨트롤러를 담을 레이어 

let antennaStyle = function (select, mode) { //이미지 src만 다르므로 함수화 하기 (normal , highlight, status 구분해서)
    let imgSrc = null;
    if (mode == 'selected')
        imgSrc = '../images/selected_antennaImg.png'
    else if (mode == 'normal')
        imgSrc = '../images/antennaImg.png'

    let style = new ol.style.Style({
        image: new ol.style.Icon(({
            crossOrigin: 'anonymous',
            anchor: [0.5, 66],
            anchorXUnits: 'fraction',
            anchorYUnits: 'pixels',
            src: imgSrc
        })),
        text: new ol.style.Text({ //아이콘 하단 텍스트 라벨             
            font: '12px Calibri,sans-serif',
            text: '테스트 식별기' + select.values_.id[7],
            fill: new ol.style.Fill({ color: '#000' }),
            stroke: new ol.style.Stroke({ color: '#fff', width: 2 }),
            offsetX: 0.5,
            offsetY: 12,
        })
    })
    return style;
}

let dronStyle = function (select, mode) {
    let imgSrc = null;
    if (mode == 'selected')
        imgSrc = '../images/selected_dronImg2.png'
    else if (mode == 'normal')
        imgSrc = '../images/dronImg2.png'
    else if (mode == 'warning')
        imgSrc = '../images/dronImg2warn.png'

    let style = new ol.style.Style({
        image: new ol.style.Icon(({
            anchor: [0.5, 46],
            anchorXUnits: 'fraction',
            anchorYUnits: 'pixels',
            src: imgSrc
        })),
        text: new ol.style.Text({ //아이콘 하단 텍스트 라벨                     
            font: '12px Calibri,sans-serif',
            //text: '테스트 드론' + select.values_.id[4],
            text: select.style_.text_.text_,
            fill: new ol.style.Fill({ color: '#000' }),
            stroke: new ol.style.Stroke({ color: '#fff', width: 2 }),
            offsetX: 0.5,
            offsetY: 12,
        })
    })
    return style;
}

let FilteringDronStyle = function (dronID, mode) {
    let imgSrc = null;
    if (mode == 'selected')
        imgSrc = '../images/selected_dronImg2.png'
    else if (mode == 'normal')
        imgSrc = '../images/dronImg2.png'
    else if (mode == 'warning')
        imgSrc = '../images/dronImg2warn.png'

    let style = new ol.style.Style({
        image: new ol.style.Icon(({
            anchor: [0.5, 46],
            anchorXUnits: 'fraction',
            anchorYUnits: 'pixels',
            src: imgSrc
        })),
        text: new ol.style.Text({ //아이콘 하단 텍스트 라벨                     
            font: '12px Calibri,sans-serif',
            text: '테스트 드론' + dronID,
            fill: new ol.style.Fill({ color: '#000' }),
            stroke: new ol.style.Stroke({ color: '#fff', width: 2 }),
            offsetX: 0.5,
            offsetY: 12,
        })
    })
    return style;
}

$(".vw-span").click(function () {
    $("#mapmode1").toggle(
        function () { $('#mapmode1').addClass('d.none') },
        function () { $('#mapmode1').addClass('d.print') }
    )
})

function setMode(basemapType) {
    vmap.setBasemapType(basemapType);
}

var move = function (x, y, zoom) {
    vmap.getView().setCenter([x, y])
    //vmap.getView().setCenter(ol.proj.transform([x, y], 'EPSG:4326', "EPSG:900913")); // 좌표 변환시..
    vmap.getView().setZoom(zoom);
}

let layList = ["lt_c_aisctrc", "lt_c_aisatzc", "lt_c_aisfirc", "lt_c_aisprhc", "lt_c_aisresc",
    "lt_c_aisuac", "lt_c_aiscatc", "lt_c_aismoac", "lt_c_aisdngc", "lt_c_aisaltc"];

$('#' + layList[0]).change(function () {
    if ($('#' + layList[0]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("관제권", layList[0]);
        wmslayer.set('id', 'lt_c_aisctrc');
        vmap.addLayer(wmslayer);
    } else {
        vmap.removeLayer(vmap.getLayerByName("관제권"));
    }
});

$('#' + layList[1]).change(function () {
    if ($('#' + layList[1]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("비행장교통구역", layList[1]);
        wmslayer.set('id', 'lt_c_aisatzc');
        vmap.addLayer(wmslayer);
    } else {
        vmap.removeLayer(vmap.getLayerByName("비행장교통구역"));
    }
});

$('#' + layList[2]).change(function () {
    if ($('#' + layList[2]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("정보구역", layList[2]);
        wmslayer.set('id', layList[2]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.removeLayer(vmap.getLayerByName("정보구역"));
    }
});

$('#' + layList[3]).change(function () {
    if ($('#' + layList[3]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("비행금지구역", layList[3]);
        wmslayer.set('id', layList[3]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.removeLayer(vmap.getLayerByName("비행금지구역"));
    }
});

$('#' + layList[4]).change(function () {

    if ($('#' + layList[4]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("비행제한구역", layList[4]);
        wmslayer.set('id', layList[4]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.removeLayer(vmap.getLayerByName("비행제한구역"));
    }
});

$('#' + layList[5]).change(function () {
    if ($('#' + layList[5]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("초경량비행장치비행제한구역", layList[5]);
        wmslayer.set('id', layList[5]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.removeLayer(vmap.getLayerByName("초경량비행장치비행제한구역"));
    }
});

$('#' + layList[6]).change(function () {
    if ($('#' + layList[6]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("훈련구역", layList[6]);
        wmslayer.set('id', layList[6]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.removeLayer(vmap.getLayerByName("훈련구역"));
    }
});

$('#' + layList[7]).change(function () {
    if ($('#' + layList[7]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("군작전구역", layList[7]);
        wmslayer.set('id', layList[7]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.removeLayer(vmap.getLayerByName("군작전구역"));
    }
});

$('#' + layList[8]).change(function () {
    if ($('#' + layList[8]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("위험구역", layList[8]);
        wmslayer.set('id', layList[8]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.removeLayer(vmap.getLayerByName("위험구역"));
    }
});

$('#' + layList[9]).change(function () {
    if ($('#' + layList[9]).is(":checked")) {
        var wmslayer = vmap.addNamedLayer("경계구역", layList[9]);
        wmslayer.set('id', layList[9]);
        vmap.addLayer(wmslayer);
    } else {
        vmap.removeLayer(vmap.getLayerByName("경계구역"));
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

$('#customLayerCheck').change(function () {
    if ($('#customLayerCheck').is(":checked")) {
        customLayerVector.setVisible(true);
    } else {
        customLayerVector.setVisible(false);
    }
})

$('#hide-all-dron').change(function () {
    if ($('#hide-all-dron').is(":checked")) {
        dronLayer.setVisible(false);
        dronRouteLayer.setVisible(false);
    } else {
        dronLayer.setVisible(true);
        dronRouteLayer.setVisible(true);
    }
})

$('#showFlyViolation').change(function () { //비행금지 위반 드론만 보기
    if ($('#showFlyViolation').is(":checked")) {
        //dronLayer.setVisible(false);
        //dronRouteLayer.setVisible(false);
        console.log("check")
        for (sub in dronObject) {
            console.log(dronObject[sub].violation);
            if (dronObject[sub].violation == false) {
                let violationDronId = dronObject[sub].dnum;
                dronLayer.getSource().getFeatures().filter(a => a.get('id') == 'dron' + violationDronId)[0].getStyle().image_ = null
                dronLayer.getSource().getFeatures().filter(a => a.get('id') == 'dron' + violationDronId)[0].getStyle().text_.scale_ = 0

                let temp = dronRouteLayer.getSource().getFeatures().filter(a => a.get('id').indexOf(violationDronId+"Dron") > -1);
                for (all in temp) {
                    temp[all].setStyle(new ol.style.Style({}));
                }
            }
        }
        
    } else {
        for (sub in dronObject) {
            console.log(dronObject[sub].violation);
            if (dronObject[sub].violation == false) {
                let violationDronId = dronObject[sub].dnum;
                dronLayer.getSource().getFeatures().filter(a => a.get('id') == 'dron' + violationDronId)[0].setStyle(FilteringDronStyle(sub, 'normal'));

                let temp = dronRouteLayer.getSource().getFeatures().filter(a => a.get('id').indexOf(violationDronId + "Dron") > -1);
                for (all in temp) {
                    temp[all].setStyle(null);
                }
            }
        }
    }
})

$('#hide-all-antenna').change(function () {
    if ($('#hide-all-antenna').is(":checked")) {
        antennaLayer.setVisible(false);
    } else {
        antennaLayer.setVisible(true);
    }
})

$('#show-selected-dronController').change(function () {
    if ($('#show-selected-dronController').is(':checked')) {
        controllerLayer.setVisible(true);
    } else {
        controllerLayer.setVisible(false);
    }

})


$("#position").on("click", function (e) {
    e.preventDefault();
    move(14176994.56431106, 4354866.236842043, 18);
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
        var addressText = $("#sido_code option:selected").text() + " " + $("#sigoon_code option:selected").text() + " " + $("#dong_code option:selected").text()
        //address

        geocoder(addressText);

    });

})

var dataLayerAjax = function (x, y) { //검색된 행정구역 정보 
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
            var point = ol.proj.transform([data.response.result.point.x * 1, data.response.result.point.y * 1], 'EPSG:4326', "EPSG:900913"); //좌표 변환
            move(point[0] * 1, point[1] * 1, 14);
            //dataLayerAjax(point[0], point[1]); //검색된 행정 구역에 레이어 칠하는거 일단 막아둠
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

    var url = '/Present/DronData';

    $.get(url).done(function (data) {
        placeholderElement.html(data);
        placeholderElement.find('.modal').modal('show');
    });
    
}

//$("#tempbtn").on("click", function (e) {
//    e.preventDefault();

//    var x = document.getElementsByClassName("ol-overlay-container");
//    var x2 = document.getElementById('popup-open')

//    x[0].style.position = 'static';
//    x2.style.left = '50px'
//    x2.style.bottom = '70px'
//});

$("#tempbtn2").on("click", function (e) {
    e.preventDefault();

    var x = document.getElementsByClassName("ol-overlay-container");
    var x2 = document.getElementById('popup-open')

    x[0].style.position = 'absolute';
    x2.style.left = '-50px'
    x2.style.bottom = '52px'
});
function tempfunc2() {

    console.log("hellow")
    //$("#popup").css('width','300px');
    //$("#popup").css("border", "10px solid #ffffff");

    $("#popup").css("background-color", "rgba(255, 255, 255, 0.2)"); //팝업창 뒤에 가려지는 경우 대비해서 투명도 조절 

}

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

var wgs84Sphere = new ol.Sphere(6378137);

//지도 모드 변경 관련 

function mapModeChange(mode) {
    switch (mode) {
        case 0:
            setMode(vw.ol3.BasemapType.GRAPHIC);
            newDivHtml2 = "<button onclick='mapModeChange(0)' class='modeChangeIcon' style='bottom:0px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/normal_map.png'></button>"
                + modeHtmlArray[1] + modeHtmlArray[2] + modeHtmlArray[3] + modeHtmlArray[4];
            div2.innerHTML = newDivHtml2;
            div2.style = "position: absolute; z-index: 14; left: 10px; bottom: 55px; width:62px; height:62px; overflow:hidden;"
            break;
        case 1:
            setMode(vw.ol3.BasemapType.GRAPHIC_NIGHT);
            newDivHtml2 = "<button onclick='mapModeChange(1)' class='modeChangeIcon' style='bottom:0px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/night_map.png'></button>"
                + modeHtmlArray[1] + modeHtmlArray[2] + modeHtmlArray[3] + modeHtmlArray[4];
            div2.innerHTML = newDivHtml2;
            div2.style = "position: absolute; z-index: 14; left: 10px; bottom: 55px; width:62px; height:62px; overflow:hidden;"
            break;
        case 2:
            setMode(vw.ol3.BasemapType.PHOTO);
            newDivHtml2 = "<button onclick='mapModeChange(2)' class='modeChangeIcon' style='bottom:0px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/satel_map.png'></button>"
                + modeHtmlArray[1] + modeHtmlArray[2] + modeHtmlArray[3] + modeHtmlArray[4];
            div2.innerHTML = newDivHtml2;
            div2.style = "position: absolute; z-index: 14; left: 10px; bottom: 55px; width:62px; height:62px; overflow:hidden;"
            break;
        case 3:
            setMode(vw.ol3.BasemapType.PHOTO_HYBRID);
            newDivHtml2 = "<button onclick='mapModeChange(3)' class='modeChangeIcon' style='bottom:0px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/hibrid_map.png'></button>"
                + modeHtmlArray[1] + modeHtmlArray[2] + modeHtmlArray[3] + modeHtmlArray[4];
            div2.innerHTML = newDivHtml2;
            div2.style = "position: absolute; z-index: 14; left: 10px; bottom: 55px; width:62px; height:62px; overflow:hidden;"
            break;
        default:
    }
}

function sizeChangeEvent(obj, size) {
    obj.style.height = size + 'px'
}

//지도 모드 변경 관련 함수들 끝