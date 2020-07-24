let modeHtmlArray = ["<button onclick='mapModeChange(0)' class='modeChangeIcon' style='bottom:0px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/normal_map.png'></button>",
    "<button onclick='mapModeChange(0)' class='modeChangeIcon' style='bottom:62px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/normal_map.png'></button>",
    "<button onclick='mapModeChange(1)' class='modeChangeIcon' style='bottom:124px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/night_map.png'></button>",
    "<button onclick='mapModeChange(2)' class='modeChangeIcon' style='bottom:186px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/satel_map.png'></button>",
    "<button onclick='mapModeChange(3)' class='modeChangeIcon' style='bottom:248px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/hibrid_map.png'></button>"]

let dronObject = []; //드론 객체가 담길 배열 (배열로 할지는 검토)
let dronLayer; //드론을 담을 레이어
let dronRouteLayer; //드론의 루트 담을 레이어
let selected = null; //선택된 feature 를 담을 변수 

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

function createVworldMap() {
    console.log("i'm ")    

    let container = document.getElementById('popup');
    let content = document.getElementById('popup-content');
    let positionChanger = document.getElementById('popup-positionChange');
    let closer = document.getElementById('popup-closer');

    let popupOverlay = new ol.Overlay({
        element: container,
        autoPan: true,
        autoPanAnimation: {
            duration: 250
        }
    });

    closer.onclick = function () {
        $('#popup-open').attr('id', 'popup')
        popupOverlay.setPosition(undefined);
        popupOverlay.set('id', 'popup-none');
        closer.blur();
        return false;
    };

    positionChanger.onclick = function () {
        var container = document.getElementsByClassName("ol-overlay-container");
        var popupwindow = document.getElementById('popup-open')

        if (container[0].style.position == 'absolute') {
            container[0].style.position = 'static';
            popupwindow.style.left = '5px'
            popupwindow.style.bottom = '57px'
        } else {
            container[0].style.position = 'absolute';
            popupwindow.style.left = '-50px'
            popupwindow.style.bottom = '52px'
        }        
    }

    vw.ol3.CameraPosition.center = [14176994.56431106, 4354866.236842043];//넷커스터마이즈
    vw.ol3.CameraPosition.zoom = 19;

    vw.ol3.MapOptions = {
        basemapType: vw.ol3.BasemapType.GRAPHIC
        , controlDensity: vw.ol3.DensityType.FULL
        , interactionDensity: vw.ol3.DensityType.BASIC
        , controlsAutoArrange: true
        , homePosition: vw.ol3.CameraPosition
        , initPosition: vw.ol3.CameraPosition
    };
    
    vmap = new vw.ol3.Map("vmap", vw.ol3.MapOptions);
    vmap.addOverlay(popupOverlay);

    //툴바-새로고침 버튼 삭제
    vmap.removeControl(vmap.getControls().getArray()[6]);

    //ui 자연스럽게하기위해 + 버튼 아이콘 재정의
    vmap.getControls().getArray()[6].element.src = "../images/btn_zoomin.png";

    //지도에 텍스트 추가 (일반 사용자일때만 보이게 한다.)
    let newDivHtml = "<span><b>※지도의 모든 대상은 5분전의 위치입니다.</b></span>";
    let warningDiv = parent.document.createElement("div");
    warningDiv.style = "position: absolute; z - index: 100; top: 10px; right: 0px; bottom: 0px; width: 300px; height: 25px; color:brown; font-size:13px;"
    warningDiv.innerHTML = newDivHtml;
    parent.document.getElementsByClassName("ol-overlaycontainer-stopevent")[0].appendChild(warningDiv);

    //지도 모드 변환 버튼 추가 
    let newDivHtml2 = modeHtmlArray[0] + modeHtmlArray[1] + modeHtmlArray[2] + modeHtmlArray[3] + modeHtmlArray[4];

    let changeMapDiv = parent.document.createElement("div");
    changeMapDiv.style = "position: absolute; z - index: 100; left: 10px; bottom: 65px; width:62px; height:62px; overflow:hidden;"
    changeMapDiv.innerHTML = newDivHtml2;
    changeMapDiv.setAttribute('id', 'changeMapFnc');
    changeMapDiv.setAttribute('onmouseover', 'sizeChangeEvent(this, 310)');
    changeMapDiv.setAttribute('onmouseout', 'sizeChangeEvent(this, 62)');

    parent.document.getElementsByClassName("ol-overlaycontainer-stopevent")[0].appendChild(changeMapDiv);

    //지도 클릭 이벤트 제어 (객체 클릭시 팝업 생성/제거)
    
    vmap.on('singleclick', function (evt) {
        $('#popup-open').attr('id', 'popup'); //일단 클릭하면 팝업 제거 되도록한다. 
        popupOverlay.set('id', 'popup-none');
        popupOverlay.setPosition(undefined);
        closer.blur();

        if ((selected !== null) && (selected.values_.id)) {
            if (selected.values_.id.indexOf('antenna') > -1) {
                selected.setStyle(antennaStyle(selected, 'normal'));
            } else if (selected.values_.id.indexOf('dron') > -1) {
                selected.setStyle(dronStyle(selected, 'normal'));
            }
            selected = null; // 아무것도 포함되지 않으면 null 값 유지 
        }

        vmap.forEachFeatureAtPixel(evt.pixel,
            function (feature) {
                selected = feature;

                if (feature) {
                    $('#popup').attr('id', 'popup-open')
                    let coordinates = feature.getGeometry().getCoordinates();

                    if (selected.values_.id.indexOf('antenna') > -1) {
                        feature.setStyle(antennaStyle(selected, 'selected'));
                        let thisAntennaNum = feature.get('id').slice(7);
                        popupOverlay.set('id', 'popup-antenna' + thisAntennaNum);
                        popupOverlay.setPosition(coordinates);
                        content.innerHTML = feature.get('contents');

                    } else if (selected.values_.id.indexOf('dron') > -1) {
                        feature.setStyle(dronStyle(selected, 'selected'));
                        let thisDronName = feature.get('id').slice(5); // 'dron42 ' 와 같이 4번째부터 숫자 정보를 가져온다.
                        popupOverlay.set('id', 'popup-dron' + thisDronName);
                        popupOverlay.setPosition(coordinates);
                        content.innerHTML = feature.get('contents');
                    }
                }                                
            });                
    })

    //비행 제한 구역 및 레이어 기능 설정
    let layList = ["lt_c_aisctrc", "lt_c_aisatzc", "lt_c_aisfirc", "lt_c_aisprhc", "lt_c_aisresc",
        "lt_c_aisuac", "lt_c_aiscatc", "lt_c_aismoac", "lt_c_aisdngc", "lt_c_aisaltc"];

    $('#' + layList[0]).change(function () {        
        if ($('#' + layList[0]).is(":checked")) {
            let wmslayer = vmap.addNamedLayer("관제권", layList[0]);
            wmslayer.set('id', 'lt_c_aisctrc');
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("관제권"));
        }
    });

    $('#' + layList[1]).change(function () {
        if ($('#' + layList[1]).is(":checked")) {
            let wmslayer = vmap.addNamedLayer("비행장교통구역", layList[1]);
            wmslayer.set('id', 'lt_c_aisatzc');
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("비행장교통구역"));
        }
    });

    $('#' + layList[2]).change(function () {
        if ($('#' + layList[2]).is(":checked")) {
            let wmslayer = vmap.addNamedLayer("정보구역", layList[2]);
            wmslayer.set('id', layList[2]);
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("정보구역"));
        }
    });

    $('#' + layList[3]).change(function () {
        if ($('#' + layList[3]).is(":checked")) {
            let wmslayer = vmap.addNamedLayer("비행금지구역", layList[3]);
            wmslayer.set('id', layList[3]);
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("비행금지구역"));
        }
    });

    $('#' + layList[4]).change(function () {

        if ($('#' + layList[4]).is(":checked")) {
            let wmslayer = vmap.addNamedLayer("비행제한구역", layList[4]);
            wmslayer.set('id', layList[4]);
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("비행제한구역"));
        }
    });

    $('#' + layList[5]).change(function () {
        if ($('#' + layList[5]).is(":checked")) {
            let wmslayer = vmap.addNamedLayer("초경량비행장치비행제한구역", layList[5]);
            wmslayer.set('id', layList[5]);
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("초경량비행장치비행제한구역"));
        }
    });

    $('#' + layList[6]).change(function () {
        if ($('#' + layList[6]).is(":checked")) {
            let wmslayer = vmap.addNamedLayer("훈련구역", layList[6]);
            wmslayer.set('id', layList[6]);
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("훈련구역"));
        }
    });

    $('#' + layList[7]).change(function () {
        if ($('#' + layList[7]).is(":checked")) {
            let wmslayer = vmap.addNamedLayer("군작전구역", layList[7]);
            wmslayer.set('id', layList[7]);
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("군작전구역"));
        }
    });

    $('#' + layList[8]).change(function () {
        if ($('#' + layList[8]).is(":checked")) {
            let wmslayer = vmap.addNamedLayer("위험구역", layList[8]);
            wmslayer.set('id', layList[8]);
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("위험구역"));
        }
    });

    $('#' + layList[9]).change(function () {
        if ($('#' + layList[9]).is(":checked")) {
            let wmslayer = vmap.addNamedLayer("경계구역", layList[9]);
            wmslayer.set('id', layList[9]);
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("경계구역"));
        }
    });

    $('#adsigg').change(function () {
        if ($('#adsigg').is(":checked")) {
            let wmslayer = vmap.addNamedLayer("시군구경계", "lt_c_adsigg");
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("시군구경계"));
        }
    });

    $('#ademd').change(function () {
        if ($('#ademd').is(":checked")) {
            let wmslayer = vmap.addNamedLayer("읍면동경계", "lt_c_ademd");
            vmap.addLayer(wmslayer);
        } else {
            vmap.removeLayer(vmap.getLayerByName("읍면동경계"));
        }
    });

    //타이머 (백엔드에서 타이머 돌리는걸로 검토)
    //let readDBMainTimer = setInterval(function () {

    //    $.ajax({
    //        type: "POST",
    //        url: "http://localhost:51699/Present/GetDronDB", //"@Url.Action("GetDronDB")",
    //        data: {},
    //        //contentType: "application/json; charset=utf-8",
    //        dataType: "jsonp",
    //        success: function (DBdata) {

    //            if (DBdata.length) {
    //                if (!Dron.totalCnt) {//처음 프로그램 시작 됐을때 DB에 있는 수만큼 추가한다.
    //                    for (let dbIdx in DBdata) {
    //                        addDron(DBdata[dbIdx]);
    //                    }
    //                } else { //이후에는 DB에 데이터가 추가 될때마다 기존 데이터와 비교하여 addDron 한다.
    //                    console.log("data base serching", Dron.totalCnt, DBdata.length);
    //                    if (Dron.totalCnt != DBdata.length) { // DB에 식별된 드론 수와 지도상의 드론수가 다른경우
    //                        if (Dron.totalCnt < DBdata.length) {//DB에 식별된 드론 수 > 지도상의 드론수 (db에만 있는걸 추가)                                
    //                            for (let dbIdx in DBdata) {//중복 검사                                    

    //                                let isDuplicate = false; //중복 체크 플래그                                        
    //                                for (let objIdx in dronObject) {
    //                                    if (dronObject[objIdx].dronID == DBdata[dbIdx].dronE_MID) { // 식별 이름을 비교한다.
    //                                        isDuplicate = true; //이름이 같으면 다음 idx로 넘긴다.
    //                                        continue;
    //                                    }
    //                                }
    //                                if (isDuplicate == false) { //중복 체크플래그가 변하지 않으면 드론을 추가한다.                                        
    //                                    console.log("Find new dron!");
    //                                    addDron(DBdata[dbIdx]);
    //                                }

    //                            }
    //                        } else if (Dron.totalCnt > DBdata.length) { // (지도상에만 있는걸 제거)                                            
    //                            for (let objIdx in dronObject) {//중복 검사                                    

    //                                let isDuplicate = false; //중복 체크 플래그                                        
    //                                for (let dbIdx in DBdata) {
    //                                    if (dronObject[objIdx].dronID == DBdata[dbIdx].dronE_MID) { // 식별 이름을 비교한다.
    //                                        isDuplicate = true; //이름이 같으면 다음 idx로 넘긴다.
    //                                        continue;
    //                                    }
    //                                }
    //                                if (isDuplicate == false) { //중복 체크플래그가 변하지 않으면 드론을 추가한다.                                        
    //                                    console.log("Dron connection finish!");
    //                                    removeDron(objIdx);
    //                                }

    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        },
    //        failure: function (errMsg) {
    //            console.log(errMsg);
    //        }
    //    });
    //}, 5000) //현재는 5초마다 한번씩 DB를 탐색한다. 

    //비행 제한 구역 설정 기능 
    createCustomLayer();


}



//지도 모드(야간, 하이브리드,위성, 일반) 변경 관련 
function mapModeChange(mode) {

    switch (mode) {
        case 0:
            setMode(vw.ol3.BasemapType.GRAPHIC);
            newDivHtml2 = "<button onclick='mapModeChange(0)' class='modeChangeIcon' style='bottom:0px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/normal_map.png'></button>"
                + modeHtmlArray[1] + modeHtmlArray[2] + modeHtmlArray[3] + modeHtmlArray[4];
            document.getElementById('changeMapFnc').innerHTML = newDivHtml2;
            document.getElementById('changeMapFnc').style = "position: absolute; z-index: 14; left: 10px; bottom: 55px; width:62px; height:62px; overflow:hidden;"
            break;
        case 1:
            setMode(vw.ol3.BasemapType.GRAPHIC_NIGHT);
            newDivHtml2 = "<button onclick='mapModeChange(1)' class='modeChangeIcon' style='bottom:0px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/night_map.png'></button>"
                + modeHtmlArray[1] + modeHtmlArray[2] + modeHtmlArray[3] + modeHtmlArray[4];
            document.getElementById('changeMapFnc').innerHTML = newDivHtml2;
            document.getElementById('changeMapFnc').style = "position: absolute; z-index: 14; left: 10px; bottom: 55px; width:62px; height:62px; overflow:hidden;"
            break;
        case 2:
            setMode(vw.ol3.BasemapType.PHOTO);
            newDivHtml2 = "<button onclick='mapModeChange(2)' class='modeChangeIcon' style='bottom:0px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/satel_map.png'></button>"
                + modeHtmlArray[1] + modeHtmlArray[2] + modeHtmlArray[3] + modeHtmlArray[4];
            document.getElementById('changeMapFnc').innerHTML = newDivHtml2;
            document.getElementById('changeMapFnc').style = "position: absolute; z-index: 14; left: 10px; bottom: 55px; width:62px; height:62px; overflow:hidden;"
            break;
        case 3:
            setMode(vw.ol3.BasemapType.PHOTO_HYBRID);
            newDivHtml2 = "<button onclick='mapModeChange(3)' class='modeChangeIcon' style='bottom:0px;'><img style='position:relative; margin: auto; left:-5px;' src='../images/hibrid_map.png'></button>"
                + modeHtmlArray[1] + modeHtmlArray[2] + modeHtmlArray[3] + modeHtmlArray[4];
            document.getElementById('changeMapFnc').innerHTML = newDivHtml2;
            document.getElementById('changeMapFnc').style = "position: absolute; z-index: 14; left: 10px; bottom: 55px; width:62px; height:62px; overflow:hidden;"
            break;
        default:
    }
}

function sizeChangeEvent(obj, size) {
    obj.style.height = size + 'px'
}

function setMode(basemapType) {
    vmap.setBasemapType(basemapType);
}
//지도 모드 변경 관련 끝 


//지도 상 다각형(사용자 비행 제한구역) 그리기
/*실제 구현은 사용자가 지도상에서 범위를 설정하면 DB에 저장이 되고 
 DB에서 로드해야한다.
 따라서 DB에서 읽어온 좌표정보로 polygon을 그리는 기능 추가 필요 */
function createCustomLayer() {
    //사용자 비행 금지 제한구역 설정 관련 변수 
    let sketch;
    let helpTooltipElement;
    let helpTooltip;
    let measureTooltipElement;
    let measureTooltip;
    let continuePolygonMsg = '더블 클릭하여 생성을 완료 합니다.';    
    let moveHandler;
    var draw; // global so we can remove it later

    var wgs84Sphere = new ol.Sphere(6378137);

    var formatArea = function (polygon) {

        var area;// = new ol.Sphere.getArea(polygon); //return geometry

        var sourceProj = vmap.getView().getProjection();
        var geom = (polygon.clone().transform(
            sourceProj, 'EPSG:4326'));
        var coordinates = geom.getLinearRing(0).getCoordinates();
        area = Math.abs(wgs84Sphere.geodesicArea(coordinates));


        var output;
        if (area > 10000) {
            output = (Math.round(area / 1000000 * 100) / 100) +
                ' ' + 'km<sup>2</sup>';
        } else {
            output = (Math.round(area * 100) / 100) +
                ' ' + 'm<sup>2</sup>';
        }
        return output;
    };

    let customLayersource = new ol.source.Vector({
        id: "customLayersourceId"
    });

    customLayersource.set("name", "customLayersourceName");

    let customLayerVector = new ol.layer.Vector({ // 사용자 제한구역  벡터 
        id: "customLayervectorId",
        source: customLayersource,
        style: new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(165, 42, 42, 0.2)'
            }),
            stroke: new ol.style.Stroke({
                color: '#ffcc33',
                width: 2
            }),
            image: new ol.style.Circle({
                radius: 7,
                fill: new ol.style.Fill({
                    color: '#ffcc33'
                })
            })
        })
    });

    customLayerVector.set("name", "customLayervectorName");
    customLayerVector.setZIndex(11);

    let pointerMoveHandler = function (evt) {
        if (evt.dragging) {
            return;
        }

        var helpMsg = '클릭하여 제한 영역을 생성합니다.';

        if (sketch) {
            var geom = (sketch.getGeometry());
            if (geom instanceof ol.geom.Polygon) {
                helpMsg = continuePolygonMsg;
            } else if (geom instanceof ol.geom.LineString) {
                helpMsg = continueLineMsg;
            }
        }

        helpTooltipElement.innerHTML = helpMsg;
        helpTooltip.setPosition(evt.coordinate);

        helpTooltipElement.classList.remove('hidden');
    };

    vmap.addLayer(customLayerVector);

    function addInteraction() {
        var type = 'Polygon';
        draw = new ol.interaction.Draw({
            source: customLayersource,
            type: type,
            style: new ol.style.Style({
                fill: new ol.style.Fill({
                    color: 'rgba(255, 255, 255, 0.2)'
                }),
                stroke: new ol.style.Stroke({
                    color: 'rgba(0, 0, 0, 0.5)',
                    lineDash: [10, 10],
                    width: 2
                }),
                image: new ol.style.Circle({
                    radius: 5,
                    stroke: new ol.style.Stroke({
                        color: 'rgba(0, 0, 0, 0.7)'
                    }),
                    fill: new ol.style.Fill({
                        color: 'rgba(255, 255, 255, 0.2)'
                    })
                })
            })
        });
        vmap.addInteraction(draw);

        var listener;
        draw.on('drawstart',
            function (evt) {
                // set sketch
                sketch = evt.feature;
                sketch.set('id', '사용자설정레이어');

                var tooltipCoord = evt.coordinate;

                listener = sketch.getGeometry().on('change', function (evt) {
                    var geom = evt.target;
                    var output;
                    if (geom instanceof ol.geom.Polygon) {
                        output = formatArea(geom);
                        tooltipCoord = geom.getInteriorPoint().getCoordinates();
                    } else if (geom instanceof ol.geom.LineString) {
                        //output = formatLength(geom);
                        //tooltipCoord = geom.getLastCoordinate();
                    }
                    measureTooltipElement.innerHTML = output;
                    measureTooltip.setPosition(tooltipCoord);
                });
            }, this);

        draw.on('drawend',
            function () {
                measureTooltipElement.className = 'tooltip tooltip-static';
                measureTooltip.setOffset([0, -7]);
                // unset sketch
                sketch = null;
                // unset tooltip so that a new one can be created
                measureTooltipElement = null;
                //createMeasureTooltip();
                ol.Observable.unByKey(listener);

                vmap.removeInteraction(draw);
                vmap.removeOverlay(measureTooltip);
                vmap.removeOverlay(helpTooltip);
                ol.Observable.unByKey(moveHandler);

            }, this);
    }

    function createHelpTooltip() {
        if (helpTooltipElement) {
            helpTooltipElement.parentNode.removeChild(helpTooltipElement);
        }
        helpTooltipElement = document.createElement('div');
        helpTooltipElement.className = 'tooltip hidden';
        helpTooltip = new ol.Overlay({
            element: helpTooltipElement,
            offset: [15, 0],
            positioning: 'center-left'
        });
        vmap.addOverlay(helpTooltip);
    }

    function createMeasureTooltip() {
        if (measureTooltipElement) {
            measureTooltipElement.parentNode.removeChild(measureTooltipElement);
        }
        measureTooltipElement = document.createElement('div');
        measureTooltipElement.className = 'tooltip tooltip-measure';
        measureTooltip = new ol.Overlay({
            element: measureTooltipElement,
            offset: [0, -15],
            positioning: 'bottom-center'
        });
        vmap.addOverlay(measureTooltip);
    }

    $("#createPolygon").on("click", function (e) {
        console.log("create polygon");

        vmap.getViewport().addEventListener('mouseout', function () {
            helpTooltipElement.classList.add('hidden');
        });

        createMeasureTooltip();
        createHelpTooltip();
        //vmap.on('pointermove', pointerMoveHandler);
        moveHandler = vmap.on('pointermove', pointerMoveHandler);;
        addInteraction();

    })
}
//지도 다각형(사용자 비행 제한구역) 그리기 끝

//temp function 
function showDronInfo(DBdata) {            

    if (DBdata) {                
        if (!Dron.totalCnt) {
            for (let dbIdx in DBdata) {
                addDron(DBdata[dbIdx]);                
            }
        }
        //else {
        //    console.log("Dron total count is not change!");
        //}
    }

    //$.ajax({
    //    type: "get",        
    //    url: "http://localhost:56728/api/drones",        
    //    dataType: "json",            
    //    success: function (DBdata) {
    //        if (DBdata != null) {                                                
    //            console.log(DBdata);
    //        }
            
    //        //if (DBdata) {                
    //            //if (!Dron.totalCnt) {
    //            //    for (let dbIdx in DBdata) {
    //            //        addDron(DBdata[dbIdx]);

    //            //    }
    //            //}
    //        //}
    //    },
    //    error: function (erroMsg) {
    //        console.log(erroMsg);
    //    }
    //})       
}

function addDron(receiveData) {
    //if (Dron.totalCnt == dronNumLimit) {//갯수제한 검토
    //    alert("허용 드론 수 초과");
    //    return;
    //}

    //식별 시작시간 (추후엔 DB 서버에서 받을지 검토)
    let time = new Date().toLocaleTimeString('ko-KR', { timeStyle: 'medium', hourCycle: 'h24' });

    //드론 객체 생성(식별기 정보 수집)) , .dronE_MID data.latitude, data.longitude
    dronObject.push(new Dron(receiveData, "익명", "010-xxxx-xxxx", "YES", 0, time));

    //드론 객체 내부 타이머 ON
    dronObject[Dron.totalCnt].switchState('ON');

    //최종으로 드론수 증가
    Dron.totalCnt++;
}