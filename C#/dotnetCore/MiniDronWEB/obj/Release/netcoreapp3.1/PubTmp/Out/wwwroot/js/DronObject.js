//'use strict'

class Dron{        

    constructor(dnum, name, honer, phone, insurance, time, StartIdTime) {
        this.dnum = dnum;
        this.name = name;
        this.honer = honer;
        this.phone = phone;
        this.insurance = insurance; 
        this.StartIdTime = StartIdTime;//식별시작시간
        this.running = 0; //타이머 flag
        this.time = 0; // 식별 지속시간 변수
        this.transLatLon = []; // 드론 좌표 (좌표계 변환으로 trans 붙임)
        this.controllerCoorp = []; //조종기 위치        
        this.prevState = 10; //이전상태-> 이전상태가 미식별인 경우 미식별 지점부터 식별 지점까지 점선 연결하기 위한 변수
        this.routeFeatureCnt = 0; //루트 feature 구분하기 위한 변수 
    }

    static totalCnt = 0;
    static reduceCnt() {
        this.totalCnt--;
        if (this.totalCnt < -1)
            this.totalCnt = -1;
    }

    
    switchState(state) {
        if (state == 'ON') {            
            this.running = 1;                  

            //openlayer 마커 생성 과정 : Feature(아이콘) -> vector(레이어에 아이콘 추가) -> add layer(맵에 레이어 등록) 
            let dronFeature = new ol.Feature({                
                geometry: new ol.geom.Point(vmap.getView().getCenter()), //임시로 화면의 중앙에 생성 
                contents:
                    '<b><big>테스트 드론-' + this.dnum + '</big></b>'
                    + '<hr>'
                    + '<table style="width:100%">'
                    + '<tr><th>동작상태</th><td> 정상 </td></tr>'
                    + '<tr><th>식별시작시간</th><td> <span Id="dStartIdTime"></span>' + this.StartIdTime + '</td></tr>'
                    + '<tr><th>식별지속시간</th><td> <span Id="dIdTime"></span> </td></tr>'
                    + '<tr><th>속도</th><td> <span Id="dSpeed"></span> </td></tr>'
                    + '<tr><th>방향</th><td> <span Id="dDirection"></span> </td></tr>'
                    + '<tr><th>해발고도</th><td> <span Id="dAltitude"></span> </td></tr>'
                    + '<tr><th>조종기 거리</th><td> <span Id="dronToConLength"></span> </td></tr>'
                    + '<tr><th>식별기 목록</th><td> <span Id="dIdentyDevice"></span> </td></tr>'
                    + '<tr><th colspan="2" >위도 / 경도</th></tr>'
                    + '<tr><td colspan="2"><span Id="dLatLon"></span> </td></tr>'
                    + '<tr><th colspan="2" style ="text- align: center">주소</th></tr>'
                    + '<tr><td colspan="2"><span Id="dAddress"></span> </td></tr></table>'
                    + '<hr>'
                    + '<button type="button" class="btn btn-primary" id="dronInfoPop" onclick="tempfunc()";>드론정보</button>' + '&nbsp&nbsp'
                    + '<button type="button" class="btn btn-primary" id="dronMasPop" >소유자</button>' + '</br>'
                    + '<button type="button" class="btn btn-primary" id="dronAccPop">허가정보</button>' + '&nbsp&nbsp'
                    + '<button type="button" class="btn btn-primary" id="dronStatusPop">상태로그</button>',
            })

            dronFeature.set("id", "dron" + this.dnum);
            dronFeature.setId("dron" + this.dnum);

            let droniconStyle = new ol.style.Style({
                image: new ol.style.Icon(({
                    anchor: [0.5, 46],
                    anchorXUnits: 'fraction',
                    anchorYUnits: 'pixels',
                    src: '../images/dronImg2.png'
                })),
                text: new ol.style.Text({ //아이콘 하단 텍스트 라벨
                    font: '12px Calibri,sans-serif',
                    text: '테스트 드론' + this.dnum,
                    fill: new ol.style.Fill({ color: '#000' }),
                    stroke: new ol.style.Stroke({ color: '#fff', width: 2 }),
                    offsetX: 0.5,
                    offsetY: 12,
                })
            });

            dronFeature.setStyle(droniconStyle);

            let vectorSource = new ol.source.Vector({
                features: [dronFeature] //배열 형식으로 추가해줘야 한다.
            });
                        
            if (vmap.getLayerByName("드론레이어") == null) { //처음 생성시(레이어가 없는경우 레이어 생성)
                dronLayer = new ol.layer.Vector({
                    source: vectorSource
                });

                dronLayer.set("name", "드론레이어");
                dronLayer.setZIndex(11);
                vmap.addLayer(dronLayer);
            } else {
                dronLayer.getSource().addFeature(dronFeature); //레이어가 있으면 feature만 추가
            }            
            //타이머 시작 
            this.startTimer(this);     
            createRouteLayer(this);
        }
        else {//stop
            console.log(this.dnum + "번 드론 제거");
            this.running = 0;
            this.time = 0;
                        
            let dronRouteFeatures = vmap.getLayerByName('경로레이어').getSource().getFeatureById(this.dnum + 'DronRoute')
            dronRouteLayer.getSource().removeFeature(dronRouteFeatures);

            let dronFeatures = vmap.getLayerByName('드론레이어').getSource().getFeatureById('dron' + this.dnum)
            dronLayer.getSource().removeFeature(dronFeatures);
                        
            
        }
    }

    startTimer(dronObject) {        
        let _this = dronObject;

        _this.time++;                        
        

        if (_this.running == 1) {
            setTimeout(function () {
                
                dronDataAjax(_this);                

                _this.startTimer(_this);

            },100)
        }
    }    
}

function dronDataAjax(dronObject) {
    let _this = dronObject;
    
    let dronFeatures = dronLayer.getSource().getFeatureById('dron' + _this.dnum);
    
    let receiveData;
    $.ajax({
        type: 'GET',
        url: '/Present/AddDronInfo/' + _this.dnum, //추후엔 식별기 아이디를 입력하게 될지 검토 
        success: function (result) {
            receiveData = result;
            let oriCoord = [receiveData[_this.dnum].longitude, receiveData[_this.dnum].latitude];

            //받은 좌표계가 다른경우 변환 한다. 
            _this.transLatLon = new ol.proj.transform(oriCoord, "EPSG:4326", "EPSG:900913")

            //사용자 설정 금지 구역 진입시 아이콘 변경 (정상상태로 진입시 변경할지는 검토)
            if (positionCheck(_this.transLatLon)[0] == true) {
                if (dronFeatures.getStyle().image_.iconImage_.src_.indexOf('warn') == -1) //이미 변경되어있으면 패스
                    dronFeatures.setStyle(dronStyle(dronFeatures, 'warning'));
            }

            //경로 관련 시작//
            if (_this.time > 70) { //경로 표시 시간제한 두기 (7초))
            //    dronRouteLayer.getSource().getFeatureById(_this.dnum + 'DronRoute').getGeometry().flatCoordinates.shift(); // 위도 경도를 빼기 때문에 2번 해줌 
            //    dronRouteLayer.getSource().getFeatureById(_this.dnum + 'DronRoute').getGeometry().flatCoordinates.shift(); //shift 는 오래걸리는 연산이므로 다른 방법도 생각해보기...            
            }

            drawRoute(receiveData, _this)            
            //경로 관련 끝//


            // 선택드론 - 조종기 연결
            if ($('#show-selected-dronController').is(':checked') && (_this.prevState != 8))
                drawControllerDronLine(_this);            
            
            //클릭시 생성되는 팝업내용 업데이트 
            if (document.getElementById("popup-open") && (_this.prevState != 8)) 
                popupContentsUpdate(_this, receiveData);
        }
    })
    if (_this.transLatLon[0] != null && _this.transLatLon[1] != null && _this.prevState != 8) {
        dronFeatures.getGeometry().setCoordinates(_this.transLatLon);
    }
}

function drawRoute(data, obj) {
    let _this = obj;
    if ((_this.prevState) == 8 && (data[_this.dnum].direction != 8)) {//이전상태는 미식별이다가 식별이 된 경우
        console.log("dron identy reConnect")
        //마지막 수신된 위치와 연결
        let lastCoord = dronLayer.getSource().getFeatureById('dron' + _this.dnum).getGeometry().flatCoordinates;
                
        createUnIdentifiedRouteLayer(_this, lastCoord);
        createRouteLayer(_this);
        dronRouteLayer.getSource().getFeatures().filter(a => a.get('id') == _this.dnum + 'DronRoute2-' + (_this.routeFeatureCnt-1)).pop().getGeometry().appendCoordinate(_this.transLatLon)
        
    }
    else if ((_this.prevState != 8) && (data[_this.dnum].direction == 8)) { // 이전상태는 식별이다가 미식별이 된 경우
        //마지막 수신된 위치 저장        
        //console.log("dron connection fail")        
    }
    else if ((_this.prevState != 8) && (data[_this.dnum].direction != 8)) { // 식별 양호한 경우
        //dronRouteLayer.getSource().getFeatureById(_this.dnum + 'DronRoute').getGeometry().appendCoordinate(_this.transLatLon) //정상 경로 (선)
        dronRouteLayer.getSource().getFeatures().filter(a => a.get('id') == _this.dnum + 'DronRoute-' +_this.routeFeatureCnt).pop().getGeometry().appendCoordinate(_this.transLatLon)
    }
    //else if ((_this.prevState == 8) && (data[_this.dnum].direction == 8)) { // 미식별 상태인경우        
        //console.log("dron connection fail ...")
    //}


    _this.prevState = data[_this.dnum].direction

    ////미식별 시 (점선)
    //if (receiveData[_this.dnum].direction == 8) // 8-> 미식별 상태 
    //    drawUnidentifiedRoute()
    //else
    //    dronRouteLayer.getSource().getFeatureById(_this.dnum + 'DronRoute').getGeometry().appendCoordinate(_this.transLatLon) //정상 경로 (선)
}

function popupContentsUpdate(dronObject, receiveData) {
    let _this = dronObject;

    let mins = Math.floor(_this.time / 10 / 60 % 60);
    let secs = Math.floor(_this.time / 10 % 60);
    let hours = Math.floor(_this.time / 10 / 60 / 60);

    if (mins < 10) {
        mins = "0" + mins;
    }
    if (secs < 10) {
        secs = "0" + secs;
    }

    if (vmap.getOverlays().getArray().filter(popup => popup.get('id') == 'popup-dron' + _this.dnum)[0]) { //클릭한 드론의 정보만 보여주기위함
        document.getElementById("dIdTime").innerHTML = hours + ':' + mins + ':' + secs;//누적 식별시간 

        vmap.getOverlays().getArray()[0].values_.position = _this.transLatLon;//팝업창 위치 드론 따라가도록

        document.getElementById("dAltitude").innerHTML = receiveData[_this.dnum].altitude + 'm'
        document.getElementById("dSpeed").innerHTML = receiveData[_this.dnum].speed + 'km/h';
        document.getElementById("dIdentyDevice").innerHTML = receiveData[_this.dnum].identyDevice;
        document.getElementById("dDirection").innerHTML = receiveData[_this.dnum].direction;
        document.getElementById("dLatLon").innerHTML = receiveData[_this.dnum].latitude.toFixed(5) + '/' + receiveData[_this.dnum].longitude.toFixed(5); //위경도 자릿수 제한 

        //드론 - 조종기 거리 계산         
        let pointsLine = new ol.geom.LineString([_this.transLatLon, _this.controllerCoorp]);
        document.getElementById("dronToConLength").innerHTML = formatLength(pointsLine);

        //좌표 -> 주소 변환 하기위한 ajax 통신 
        $.ajax({
            type: "get",
            url: "https://api.vworld.kr/req/address?service=address&version=2.0&request=getaddress&format=json&type=parcel&crs=epsg:900913",//type : both, parcel, road
            //data: { apiKey: $('[name=key]').val(), point: x + "," + y },
            data: { apiKey: "B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF", point: _this.transLatLon[0] + "," + _this.transLatLon[1] },
            dataType: 'jsonp',
            success: function (data) {
                let geoResult = "";
                for (i in data.response.result) {
                    if (i != 0) {
                        geoResult += ", ";
                    }
                    geoResult += data.response.result[i].text;
                }
                document.getElementById("dAddress").innerHTML = geoResult;
            },
            beforeSend: function () {

            },
            error: function (xhr, stat, err) { }
        });
    }
}

function createUnIdentifiedRouteLayer(dronObject, lastposition) {    
    let _this = dronObject;
    _this.routeFeatureCnt++
    
    let line_feature = new ol.Feature({
        geometry: new ol.geom.LineString([_this.transLatLon, lastposition]),
        id: _this.dnum + "DronRoute2-" + _this.routeFeatureCnt /*'DronUnIdentifiedRoute'*/
    });
    //line_feature.setId(_this.dnum + 'DronUnIdentifiedRoute')
    var colorArray = ["rgba(255,0,0,0.5)", "rgba(0,255,0,0.5)", "rgba(0,0,255,0.5)", "rgba(255,0,255,0.5)", "rgba(255,255,255,0.5)"];

    var renStyle = new ol.style.Style({
        stroke: new ol.style.Stroke({
            color: colorArray[_this.dnum % 5], //투명도
            width: 3, //두께                
            lineDash: [.1, 10] // 점선 
        })
    });

    line_feature.setStyle(renStyle);

    if (dronRouteLayer == null) {
        let vectorSource = new ol.source.Vector({
            features: [line_feature],
            id: _this.dnum
        });

        dronRouteLayer = new ol.layer.Vector({
            source: vectorSource,
            id: _this.dnum
        });
        dronRouteLayer.set("name", "경로레이어");
        dronRouteLayer.setZIndex(7);
        vmap.addLayer(dronRouteLayer);
    } else {
        dronRouteLayer.getSource().addFeature(line_feature);
    }
}

function createRouteLayer(dronObject) {//route 레이어 추가     
    let _this = dronObject;

    _this.routeFeatureCnt++
    let line_feature = new ol.Feature({
        geometry: new ol.geom.LineString([]),
        id: _this.dnum + 'DronRoute-' + _this.routeFeatureCnt
    });
    //line_feature.setId(_this.dnum + 'DronRoute')
    //var randomColor = "#66" + Math.round(Math.random() * 0xffffff).toString(16); //색상 랜덤 표시 ->랜덤으로 하기엔 잘 안보이는 색상들이 너무 많음
    var colorArray = ["rgba(255,0,0,0.5)", "rgba(0,255,0,0.5)", "rgba(0,0,255,0.5)", "rgba(255,0,255,0.5)", "rgba(255,255,255,0.5)"];

    var renStyle = new ol.style.Style({
        stroke: new ol.style.Stroke({
            color: colorArray[_this.dnum % 5], //투명도
            width: 3, //두께                
            //lineDash: [.1, 10] // 점선 
        })
    });

    line_feature.setStyle(renStyle);    

   
    if (dronRouteLayer == null) {
        let vectorSource = new ol.source.Vector({
            features: [line_feature],
            id: _this.dnum
        });

        dronRouteLayer = new ol.layer.Vector({
            source: vectorSource,
            id: _this.dnum
        });
        dronRouteLayer.set("name", "경로레이어");
        dronRouteLayer.setZIndex(6);
        vmap.addLayer(dronRouteLayer);
    } else {
        dronRouteLayer.getSource().addFeature(line_feature);
    }

    //if ($('#dispRoute').css('background-color') != 'rgb(0, 230, 0)') //경로표시 선택했을떄 visible 
    //    vmap.getLayerByName("경로레이어" + this.dnum).setVisible(false);

    //점선      
    //this.routePoint.push(ol.proj.transform([vmap.getView().getCenter()[0], vmap.getView().getCenter()[1]], "EPSG:900913", "EPSG:3857"))        
    //this.iconFeature = new ol.Feature({
    //    geometry: new ol.geom.MultiPoint(this.routePoint)
    //});
    //this.iconFeature.setStyle(this.style2);
    //this.features.push(this.iconFeature);
    //this.vectorSource2 = new ol.source.Vector({
    //    features: this.features      //add an array of features
    //    //,style: iconStyle     //to set the style for all your features...
    //});

    //this.vectorLayer2 = new ol.layer.Vector({
    //    source: this.vectorSource2
    //});
    //this.vectorLayer2.set("name", "경로점레이어" + this.dnum);

    //vmap.addLayer(this.vectorLayer2);

    //if ($('#dispDotRoute').css('background-color') != 'rgb(0, 230, 0)') //경로표시 선택했을떄 visible 
    //    vmap.getLayerByName("경로점레이어" + this.dnum).setVisible(false);

}

function drawControllerDronLine(dronObject) {
    let _this = dronObject;
    if ((controllerLayer != null) && (controllerLayer.getSource().getFeatures()[0]) && (controllerLayer.getSource().getFeatures()[0].values_.id == 'controller-' + _this.dnum)) {

        let pointsLine = new ol.geom.LineString([_this.transLatLon, _this.controllerCoorp]);

        if (controllerLayer.getSource().getFeatureById('DronToControllerLine-' + _this.dnum)) //경로가 이미 있는경우
            controllerLayer.getSource().getFeatureById('DronToControllerLine-' + _this.dnum).setGeometry(pointsLine);
        else { // 경로가 없는 경우 생성             
            let featurething = new ol.Feature({
                name: "pointLine",
                geometry: pointsLine,
            });
            let lineStyle = new ol.style.Style({
                stroke: new ol.style.Stroke({
                    color: [0, 255, 0, .7], //투명도
                    width: 2, //두께
                    lineDash: [.1, 10] // 점선 
                })
            }); // 스타일 설정
            featurething.setStyle(lineStyle)
            featurething.setId("DronToControllerLine-" + _this.dnum)
            controllerLayer.getSource().addFeature(featurething);
        }

    }
}

let formatLength = function (line) {
    var length;
   
    //length = Math.round(line.getLength() * 100) / 100; //단순 직선 거리 

    //측지 거리 
    var coordinates = line.getCoordinates();
    length = 0;
    var sourceProj = vmap.getView().getProjection();
    for (var i = 0, ii = coordinates.length - 1; i < ii; ++i) {
        var c1 = ol.proj.transform(coordinates[i], sourceProj, 'EPSG:4326');
        var c2 = ol.proj.transform(coordinates[i + 1], sourceProj, 'EPSG:4326');
        length += wgs84Sphere.haversineDistance(c1, c2);
    }
    var output;

    if (length > 100) {
        output = (Math.round(length / 1000 * 100) / 100) +
            ' ' + 'km';
    } else {
        output = (Math.round(length * 100) / 100) +
            ' ' + 'm';
    }
    return output;
};

let positionCheck = function (coordinate) {

    let checkArray = [false , false] // [사용자 설정 , 공공데이터 ]
    //사용자 설정 제한구역 체크 
    let customLayer = vmap.getLayers().getArray().filter(vectorLayer => vectorLayer.get('id') === 'customLayervectorId')
    
    for (let i = 0; i < customLayer[0].getSource().getFeatures().length; i++) {
        
        if (customLayer[0].getSource().getFeatures()[i].getGeometry().intersectsCoordinate(coordinate) == true)
            checkArray[0] = true; // 폴리곤 범위에 들어가면 true 로 변경
    }    

    //공공데이터 비행 제한 구역 체크 
    dataportalLayerCheck(coordinate)
    // console.log(checkArray);
    
    return checkArray;
}   

let dataportalLayerCheck = function (coordinate) {//AIS(항공 정보 서비스) 데이터 조회 ,리턴이 안됨, 경고창 띄우는정도로 하는거 검토 
    
    vmap.getLayers().forEach(function (layer) {        
        if (String(layer.get("name")).indexOf("wms_theme") > -1) {            
            let wmsLayer = layer.get("id");
            
            let min = [coordinate[0] - 0.1, coordinate[1] - 0.1] //0.1 해준건 확인해봐야함 
            let max = [coordinate[0] + 0.1, coordinate[1] + 0.1]
            let box = min[0] + ',' + min[1] + ',' + max[0] + ',' + max[1];
            
            $('#aisDataForm > [name=bbox]').val(box);
            $('#aisDataForm > [name=typename]').val(wmsLayer);

            $.ajax({
                type: "get",
                url: "https://api.vworld.kr/req/wfs",
                data: $('#aisDataForm').serialize(),
                dataType: 'jsonp',
                async: false,
                jsonpCallback: "parseResponse",
                success: function (data) {

                    let fetureArea = new ol.format.GeoJSON().readFeatures(data)

                    let resultFeature = fetureArea[0]
                    if (typeof resultFeature == "object") {
                        let wfs_html = "";
                        for (let i in resultFeature.getKeys()) {
                            wfs_html += resultFeature.getKeys()[i] + "=" + resultFeature.get(resultFeature.getKeys()[i]) + "\n";
                        }
                        console.log(wfs_html);                        
                    }
                },
                error: function (xhr, stat, err) {
                    console.log("ais ajax error");
                }
            });
        }
    })            
}
