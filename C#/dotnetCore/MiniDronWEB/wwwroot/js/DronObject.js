//'use strict'

class Dron{        
    //.dronE_MID data.latitude, data.longitude
    constructor(receiveData, honer, phone, insurance, time, StartIdTime) {
        //this.dnum = dnum;
        this.dronID = receiveData.dronE_MID
        //this.name = receiveData.dronE_MID;
        this.latitude = receiveData.latitude;
        this.longitude = receiveData.longitude;
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
        this.violation = false; // 위반 (현재는 비행금지구역에 한번이라도 진입하면 true가 된다. 추후에 위반 내용들을 세분화 할 필요 있을듯.)
    }

    static totalCnt = 0;//드론의 총갯수 멤버변수
    static reduceCnt() {
        this.totalCnt--;
        if (this.totalCnt < -1)
            this.totalCnt = -1;
    }
    
    switchState(state) {
        if (state == 'ON') {            
            this.running = 1;
                        
            //드론 마커를 지도에 추가 
            addDronMarker(this);                        
                        
            //타이머 시작             
            this.startTimer(this);     
            
            createRouteLayer(this);                        
            
        }
        else {//stop
            console.log(this.dronID + "- 드론 제거");
            this.running = 0;
            this.time = 0;
                                    
            //let dronRouteFeatures = vmap.getLayerByName('경로레이어').getSource().getFeatures().filter(a => a.get('id').indexOf(this.dronID + "DronRoute") > -1);

            //경로 식별(선)/미식별(점선) 구분하는 경우 
            //for (let featuresAry in dronRouteFeatures) {                
            //    dronRouteLayer.getSource().removeFeature(dronRouteFeatures[featuresAry]);
            //}
            //경로 단일                         
            //드론 루트 제거
            let dronRoute = dronRouteLayer.getSource().getFeatures().filter(a => a.get('id') == this.dronID + 'DronRoute-' + this.routeFeatureCnt).pop()
            dronRouteLayer.getSource().removeFeature(dronRoute);
            //드론 마커 제거 
            let dronFeature = dronLayer.getSource().getFeatures().filter(a => a.get('id') == 'dron-' + this.dronID).pop()
            
            dronLayer.getSource().removeFeature(dronFeature);
            
            
            
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

function addDronMarker(obj) {
    let _this = obj
    
    let initPosition = [_this.longitude, _this.latitude]; //[경도, 위도] *순서중요 바뀌어도 실행 될수있지만 표시오류
    
    //openlayer 마커 생성 과정 : Feature(아이콘) -> vector(레이어에 아이콘 추가) -> add layer(맵에 레이어 등록) 
    let dronFeature = new ol.Feature({
        id: "dron-" + _this.dronID, //이 Feature의 value 내부 ID , featureID는 setID 로 설정해야한다.
        geometry: new ol.geom.Point(new ol.proj.transform(initPosition, "EPSG:4326", "EPSG:900913")),
        contents: //팝업 내부에 표시되는 부분
            '<b><big>' + _this.dronID + '</big>' + '&nbsp' + '드론 명' + '</b>'
            + '<hr>'
            + '<table style="width:100%">'
            + '<tr><th>동작상태</th><td> 정상 </td></tr>'
            + '<tr><th>식별시작시간</th><td> <span Id="dStartIdTime"></span>' + _this.StartIdTime + '</td></tr>'
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

    dronFeature.setId("dronFeatrue-" + _this.dronID);//굳이 또 id를 설정할 필요는 없을듯            

    let droniconStyle = new ol.style.Style({
        image: new ol.style.Icon(({
            anchor: [0.5, 46],
            anchorXUnits: 'fraction',
            anchorYUnits: 'pixels',
            //rotation: Math.PI / 2.0, //아이콘 회전에 관한 속성
            src: '../images/dronImg2.png'
        })),
        text: new ol.style.Text({ //아이콘 하단 텍스트 라벨
            font: '12px Calibri,sans-serif',
            text: _this.dronID ,
            fill: new ol.style.Fill({ color: '#000' }),
            stroke: new ol.style.Stroke({ color: '#fff', width: 2 }),
            offsetX: 0.5,
            offsetY: 12,
        })
    });

    dronFeature.setStyle(droniconStyle);

    if (vmap.getLayerByName("드론레이어") == null) { //처음 생성시(레이어가 없는경우 레이어 생성)
        let vectorSource = new ol.source.Vector({
            features: [dronFeature] //배열 형식으로 추가해줘야 한다.
        });

        dronLayer = new ol.layer.Vector({
            source: vectorSource
        });

        dronLayer.set("name", "드론레이어");
        dronLayer.setZIndex(11);
        vmap.addLayer(dronLayer);
    } else {
        dronLayer.getSource().addFeature(dronFeature); //레이어가 있으면 feature만 추가                                
    } 
}

function dronDataAjax(dronObject) {
    let _this = dronObject;
            
    let receiveData;
    let tempDronID = _this.dronID.length; //드론명만 들어가야하지만 임시로 표현하기위함..

    $.ajax({
        type: 'GET',
        url: '/Present/AddDronInfo/' + (tempDronID)%3, //추후엔 식별기 아이디를 입력하게 될지 검토 
        success: function (result) {
            receiveData = result;
            let oriCoord = [_this.longitude + receiveData[tempDronID % 3].longitude, _this.latitude + receiveData[tempDronID % 3].latitude];
            
            //받은 좌표계가 다른경우 변환 한다. 
            _this.transLatLon = ol.proj.transform(oriCoord, "EPSG:4326", "EPSG:900913")
            let dronFeatures = dronLayer.getSource().getFeatureById("dronFeatrue-" + _this.dronID)
            //사용자 설정 금지 구역 진입시 아이콘 변경 (정상상태로 진입시 변경할지는 검토)
            if (positionCheck(_this.transLatLon)[0] == true) {
                if ((dronFeatures.getStyle().image_ == null) || (dronFeatures.getStyle().image_.iconImage_.src_.indexOf('warn') == -1)) //이미 변경되어있으면 패스, 필터링되어서 가려진경우null
                {
                    _this.violation = true; 
                    dronFeatures.setStyle(dronStyle(dronFeatures, 'warning'));
                }
            }            

            //경로 관련 시작//
            //식별/미식별 구분하지 않는 경우 
            if (_this.time > 70) { //경로 표시 시간제한 두기 (7초))
                dronRouteLayer.getSource().getFeatures().filter(a => a.get('id') == _this.dronID + 'DronRoute-' + _this.routeFeatureCnt).pop().getGeometry().flatCoordinates.shift(); // 위도 경도를 빼기 때문에 2번 해줌 
                dronRouteLayer.getSource().getFeatures().filter(a => a.get('id') == _this.dronID + 'DronRoute-' + _this.routeFeatureCnt).pop().getGeometry().flatCoordinates.shift(); //shift 는 오래걸리는 연산이므로 다른 방법도 생각해보기...            
            }
            drawRouteOnlyLine(_this)

            //식별(선) / 미식별(미식별) 구분하는 경우: feature가 구분되기때문에 경로 표시 시간제한이 까다롭다.
            //drawRouteLineNDash(receiveData, _this)            
            //경로 관련 끝//
            
            // 선택드론 - 조종기 연결
            if ($('#show-selected-dronController').is(':checked') && (_this.prevState != 8))
                drawControllerDronLine(_this);            
            
            //클릭시 생성되는 팝업내용 업데이트 
            if (document.getElementById("popup-open") && (_this.prevState != 8)) 
                popupContentsUpdate(_this, receiveData);

            if (_this.transLatLon[0] != null && _this.transLatLon[1] != null && _this.prevState != 8) {
                dronFeatures.getGeometry().setCoordinates(_this.transLatLon);                                    
            }
        }
    })
    
}

function drawRouteOnlyLine(obj) {
    let _this = obj;
    //단일 feature 이기때문에 createroute 해줄 필요 없다.    
    dronRouteLayer.getSource().getFeatures().filter(a => a.get('id') == _this.dronID + 'DronRoute-' + _this.routeFeatureCnt).pop().getGeometry().appendCoordinate(_this.transLatLon);
}

function drawRouteLineNDash(data, obj) {
    let _this = obj;
    let tempDronID = _this.dronID.length
    if ((_this.prevState) == 8 && (data[tempDronID % 3].direction != 8)) {//이전상태는 미식별이다가 식별이 된 경우    
        console.log("dron identy reConnect")
        //마지막 수신된 위치와 연결
        let lastCoord = dronLayer.getSource().getFeatureById("dronFeatrue-" + _this.dronID).getGeometry().flatCoordinates;
                
        createUnIdentifiedRouteLayer(_this, lastCoord);
        createRouteLayer(_this);
        dronRouteLayer.getSource().getFeatures().filter(a => a.get('id') == _this.dronID + 'DronRoute2-' + (_this.routeFeatureCnt-1)).pop().getGeometry().appendCoordinate(_this.transLatLon)
        
    }
    else if ((_this.prevState != 8) && (data[tempDronID % 3].direction == 8)) { // 이전상태는 식별이다가 미식별이 된 경우
        //마지막 수신된 위치 저장        
        //console.log("dron connection fail")        
    }
    else if ((_this.prevState != 8) && (data[tempDronID % 3].direction != 8)) { // 식별 양호한 경우
    
        //dronRouteLayer.getSource().getFeatureById(_this.dnum + 'DronRoute').getGeometry().appendCoordinate(_this.transLatLon) //정상 경로 (선)  
        //console.log(_this.dnum + 'DronRoute-' + _this.routeFeatureCnt);
        dronRouteLayer.getSource().getFeatures().filter(a => a.get('id') == _this.dronID + 'DronRoute-' +_this.routeFeatureCnt).pop().getGeometry().appendCoordinate(_this.transLatLon)
    }
    else if ((_this.prevState == 8) && (data[tempDronID % 3].direction == 8)) { // 미식별 상태인경우        
        //console.log("dron connection fail ...")
    }

    _this.prevState = data[tempDronID % 3].direction    //다음 상태와 비교하기위해 글로벌 변수에 저장한다. 
}

function popupContentsUpdate(dronObject, receiveData) {
    let _this = dronObject;
    let tempDronID = _this.dronID.length;
    //식별 지속 시간 표시를 위한 부분 ( 추후 식별기에서 받을지 검토)
    let mins = Math.floor(_this.time / 10 / 60 % 60);
    let secs = Math.floor(_this.time / 10 % 60);
    let hours = Math.floor(_this.time / 10 / 60 / 60);
    if (mins < 10) {
        mins = "0" + mins;
    }
    if (secs < 10) {
        secs = "0" + secs;
    }
    
    if (vmap.getOverlays().getArray().filter(popup => popup.get('id') == 'popup-dron' + _this.dronID)[0]) { //클릭한 드론의 정보만 보여주기위함
        document.getElementById("dIdTime").innerHTML = hours + ':' + mins + ':' + secs;//누적 식별시간 
        
        vmap.getOverlays().getArray()[0].values_.position = _this.transLatLon;//팝업창 위치 드론 따라가도록

        document.getElementById("dAltitude").innerHTML = receiveData[tempDronID % 3].altitude + 'm'
        document.getElementById("dSpeed").innerHTML = receiveData[tempDronID % 3].speed + 'km/h';
        document.getElementById("dIdentyDevice").innerHTML = receiveData[tempDronID % 3].identyDevice;
        document.getElementById("dDirection").innerHTML = receiveData[tempDronID % 3].direction;
        let lat = _this.latitude + receiveData[tempDronID % 3].latitude;
        let lng = _this.longitude + receiveData[tempDronID % 3].longitude;
        document.getElementById("dLatLon").innerHTML = lat.toFixed(5) + '/' + lng.toFixed(5); //위경도 자릿수 제한 
        
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
    let tempDronId = _this.dronID.length;
    _this.routeFeatureCnt++
    
    let line_feature = new ol.Feature({
        geometry: new ol.geom.LineString([_this.transLatLon, lastposition]),
        id: _this.dronID + "DronRoute2-" + _this.routeFeatureCnt /*'DronUnIdentifiedRoute'*/
    });
    //line_feature.setId(_this.dnum + 'DronUnIdentifiedRoute')
    var colorArray = ["rgba(255,0,0,0.5)", "rgba(0,255,0,0.5)", "rgba(0,0,255,0.5)", "rgba(255,0,255,0.5)", "rgba(255,255,255,0.5)"];

    var renStyle = new ol.style.Style({
        stroke: new ol.style.Stroke({
            color: colorArray[tempDronID % 5], //투명도
            width: 3, //두께                
            lineDash: [.1, 10] // 점선 
        })
    });

    line_feature.setStyle(renStyle);

    if (dronRouteLayer == null) {
        let vectorSource = new ol.source.Vector({
            features: [line_feature],
            id: _this.dronID
        });

        dronRouteLayer = new ol.layer.Vector({
            source: vectorSource,
            id: _this.dronID
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
    
    _this.routeFeatureCnt++ //식별 미식별에 따라 선/ 점선으로 나뉘고, 나뉠때마다 새로운 feature에 표시해주기때문에 cnt 한다.
    let line_feature = new ol.Feature({
        geometry: new ol.geom.LineString([]),
        id: _this.dronID + 'DronRoute-' + _this.routeFeatureCnt
    });
    
    var colorArray = ["rgba(255,0,0,0.5)", "rgba(0,255,0,0.5)", "rgba(0,0,255,0.5)", "rgba(255,0,255,0.5)", "rgba(0,255,255,0.5)"];

    var renStyle = new ol.style.Style({
        stroke: new ol.style.Stroke({
            color: colorArray[_this.dronID.length % 5], //투명도
            width: 3, //두께                
            //lineDash: [.1, 10] // 점선 
        })
    });

    line_feature.setStyle(renStyle);    
   
    if (dronRouteLayer == null) {
        let vectorSource = new ol.source.Vector({
            features: [line_feature],
            id: _this.dronID
        });

        dronRouteLayer = new ol.layer.Vector({
            source: vectorSource,
            id: _this.dronID
        });
        dronRouteLayer.set("name", "경로레이어");
        dronRouteLayer.setZIndex(6);
        vmap.addLayer(dronRouteLayer);
    } else {
        dronRouteLayer.getSource().addFeature(line_feature);
    }    
}

function drawControllerDronLine(dronObject) {
    let _this = dronObject;
    if ((controllerLayer != null) && (controllerLayer.getSource().getFeatures()[0]) && (controllerLayer.getSource().getFeatures()[0].values_.id == 'controller-' + _this.dnum)) {

        let pointsLine = new ol.geom.LineString([_this.transLatLon, _this.controllerCoorp]);

        if (controllerLayer.getSource().getFeatureById('DronToControllerLine-' + _this.dronID)) //경로가 이미 있는경우
            controllerLayer.getSource().getFeatureById('DronToControllerLine-' + _this.dronID).setGeometry(pointsLine);
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
            featurething.setId("DronToControllerLine-" + _this.dronID)
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
