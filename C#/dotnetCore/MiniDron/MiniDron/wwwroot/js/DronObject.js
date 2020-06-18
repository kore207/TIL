function DronInfo(dnum, name, honer, phone, insurance, time, StartIdTime) {//객체 생성자 함수     
    //기본 정보
    this.dnum = dnum;
    this.name = name;
    this.honer = honer;
    this.phone = phone;
    this.insurance = insurance;
    this.transLatLon = [];
    
    
    this.StartIdTime = StartIdTime;//식별시작시간
    this.time = time; //식별지속시간

    this.popInfo = null;
    
    
    this.running = 0;

    this.routeFeatures = new Array();    
    this.line_feature;
    this.vectorSource;    
    this.vectorLayer;
       
    this.startPause = function () {//타이머 시작 중지 함수                 
        if (this.running == 0) {
            this.running = 1;
            this.timeIncrement(this);
            this.moveDron(this);
        }
        else {
            this.running = 0;
            this.time = 0;

            //vmap.getLayers().getArray().filter(vectorLayer => vectorLayer.get('name') === '경로레이어' + dronNum).forEach(vectorLayer => vmap.removeLayer(vectorLayer));            
            vmap.removeLayer(this.vectorLayer);
            vmap.removeLayer(this.vectorLayer2);
        }
    };

    //this.style = new ol.style.Style({
    //    stroke: new ol.style.Stroke({
    //        color: [0, 255, 0, .7], //투명도
    //        width: 2, //두께
    //        //lineDash: [.1, 10] // 점선 
    //    })
    //}); // 스타일 설정
    //미식별 시 점으로  표시    
    this.features = new Array();
    this.iconFeature;
    this.style2 = new ol.style.Style({
        image: new ol.style.Circle({
            radius: 0.1,
            fill: new ol.style.Fill({ color: '#FF0000' }), //내부 원 
            stroke: new ol.style.Stroke({ color: '#0000FF', width: 0.1 }) // 외부 테두리
        })
    });
    this.vectorSource2;
    this.vectorLayer2;
    this.routePoint = [];
    //
    this.createRoute = function () {
        //route 레이어 추가 

        //선 ( 대쉬 선 으로 대체 가능)
        this.line_feature = new ol.Feature({
            geometry: new ol.geom.LineString([]),
            id: this.dnum
        });

        var randonColor = "#66" + Math.round(Math.random() * 0xffffff).toString(16);
        console.log(randonColor);
        var renStyle = new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: randonColor, //투명도
                width: 3, //두께
                
                //lineDash: [.1, 10] // 점선 
            })
        });

        this.line_feature.setStyle(renStyle);
        this.routeFeatures.push(this.line_feature);
        this.vectorSource = new ol.source.Vector({
            features: this.routeFeatures,
            id: this.dnum
        });

        this.vectorLayer = new ol.layer.Vector({
            source: this.vectorSource,
            id: this.dnum
        });
        this.vectorLayer.set("name", "경로레이어" + this.dnum);
        this.vectorLayer.setZIndex(6);
        vmap.addLayer(this.vectorLayer);

        if ($('#dispRoute').css('background-color') != 'rgb(0, 230, 0)') //경로표시 선택했을떄 visible 
            vmap.getLayerByName("경로레이어" + this.dnum).setVisible(false);
        
        //점선      
        //this.routePoint.push(ol.proj.transform([vmap.getView().getCenter()[0], vmap.getView().getCenter()[1]], "EPSG:900913", "EPSG:3857"))        
        this.iconFeature = new ol.Feature({
            geometry: new ol.geom.MultiPoint(this.routePoint)
        });
        this.iconFeature.setStyle(this.style2);
        this.features.push(this.iconFeature);
        this.vectorSource2 = new ol.source.Vector({
            features: this.features      //add an array of features
            //,style: iconStyle     //to set the style for all your features...
        });

        this.vectorLayer2 = new ol.layer.Vector({
            source: this.vectorSource2
        });
        this.vectorLayer2.set("name", "경로점레이어" + this.dnum);

        vmap.addLayer(this.vectorLayer2);

        if ($('#dispDotRoute').css('background-color') != 'rgb(0, 230, 0)') //경로표시 선택했을떄 visible 
            vmap.getLayerByName("경로점레이어" + this.dnum).setVisible(false);
                        
    }


    this.timeIncrement = function (dObj) {
        var _this = dObj;
        if (_this.running == 1) {
            setTimeout(function () {
                _this.time++;
                var mins = Math.floor(_this.time / 10 / 60);
                var secs = Math.floor(_this.time / 10 % 60);
                var hours = Math.floor(_this.time / 10 / 60 / 60);

                if (mins < 10) {
                    mins = "0" + mins;
                }
                if (secs < 10) {
                    secs = "0" + secs;
                }
                //ajax 로 드론 DB 수신 하는 부분 추가 
                //속도, 방향, 위치 

                if (document.getElementById("popup")) { //팝업창에서만 실시간 주행 시간을 표시
                    for (var i = 0; i < 5; i++) {
                        if (vmap.getOverlays().getArray()[0].get('id') == ("MarkerPop-" + _this.dnum)) {                           
                            //document.getElementById("dStartIdTime").innerHTML = _this.StartIdTime; //시작시간은 처음 추갈 될떄 입력된다.
                            document.getElementById("dIdTime").innerHTML = hours + ':' + mins + ':' + secs;

                        } 
                    }
                }
                
                if (secs > 7 ) { //경로 표시 시간제한 두기 
                    _this.line_feature.getGeometry().flatCoordinates.shift(); // 위도 경도를 빼기 때문에 2번 해줌 
                    _this.line_feature.getGeometry().flatCoordinates.shift();
                }

                _this.timeIncrement(_this);
            }, 100)
        }
    }

    
    //사각형 이동 
    //var dir = dx = dy = 0;
    this.dir = this.dx = this.dy = this.distance = 0;

    this.moveRect = function (dis, _this) {
        //상하좌우 배열로 변경하기 
        if (_this.dir == 1) {//우측                     
            _this.dx = 0.5; _this.dy = 0;
            if (_this.distance == dis) {
                _this.distance = 0;
                _this.dir++;
            }
        }
        else if (_this.dir == 2) {//상측                    
            _this.dx = 0; _this.dy = 0.5;
            if (_this.distance == dis) {
                _this.distance = 0;
                _this.dir++;
            }
        }
        else if (_this.dir == 3) {//좌측                    
            _this.dx = -0.5; _this.dy = 0;
            if (_this.distance == dis) {
                _this.distance = 0;
                _this.dir++;
            }
        }
        else {//하측                    
            _this.dx = 0; _this.dy = -0.5;
            if (_this.distance == dis) {
                _this.distance = 0;
                _this.dir = 1;
            }
        }
        _this.distance++;
    }

    this.moveDron = function (dObj) {
        
        let _this = dObj;
        let oldcoor;
        let newcoor;        
        if (_this.running == 1) {
            setTimeout(function () {
                var dronFeatures = vmap.getLayerByName("마커레이어").getSource().getFeatures(); // 마커레이어를 가져온다. (생성된 순서대로 가져오는게 아닌듯)
                for (var i = 0; i < dronNum; i++) {

                    if (dronFeatures[i].get('id') == ("Marker-" + _this.dnum)) {
                        //수신된 좌표 정보로 드론의 위치를 변경할 구간 
                        //oldcoor = dronFeatures[i].getGeometry().getCoordinates();

                        //_this.moveRect(300, _this);

                        //if (_this.dnum == 0)  //시작방향을 달리주기위한 조건문                            
                        //    newcoor = [oldcoor[0] + _this.dx, oldcoor[1] + _this.dy];
                        //else if (_this.dnum == 1)
                        //    newcoor = [oldcoor[0] + _this.dx, oldcoor[1] - _this.dy];
                        //else if (_this.dnum == 2)
                        //    newcoor = [oldcoor[0] - _this.dx, oldcoor[1] - _this.dy];
                        //else// if (dObj.dnum == 3)
                        //    newcoor = [oldcoor[0] - _this.dx, oldcoor[1] + _this.dy];
                        var tempCor = dronFeatures[i].getGeometry().getCoordinates();
                        //var temptransLatLon = new ol.proj.transform(tempCor, "EPSG:900913", "EPSG:4326")                        
                        $.ajax({
                            type: 'GET',
                            url: '/Present/AddDronInfo/'+ _this.dnum,
                            success: function (result) {                                
                                var temp = [result[_this.dnum].longitude, result[_this.dnum].latitude];
                                _this.transLatLon = new ol.proj.transform(temp, "EPSG:4326", "EPSG:900913")
                                //console.log(result[_this.dronNum].dronID)
                            }
                        })                              
                        if (_this.transLatLon[0] != null && _this.transLatLon[1] !=null)
                            dronFeatures[i].getGeometry().setCoordinates(_this.transLatLon);
                        //dronFeatures[i].getGeometry().setCoordinates(newcoor);
                    }
                }
                //Cannot read property 'length' of undefined 에러 나는 부분 
                _this.line_feature.getGeometry().appendCoordinate(_this.transLatLon); //드론 경로 라인 추가                                                 
                
                _this.iconFeature.getGeometry().appendPoint(new ol.geom.Point(_this.transLatLon)) //점선

                //var LatLon = new ol.proj.transform(oldcoor, "EPSG:900913", "EPSG:4326")

                var LatLon = new ol.proj.transform(_this.transLatLon, "EPSG:900913", "EPSG:4326")
                //팝업창 드론 따라가도록
                if (document.getElementById("popup")) {
                    for (var i = 0; i < 5; i++) {
                        if (vmap.getOverlays().getArray()[0].get('id') == ("MarkerPop-" + _this.dnum)) {
                            vmap.getOverlays().getArray()[0].values_.position = _this.transLatLon;
                            document.getElementById("dLatLon").innerHTML = LatLon[1].toFixed(5) + '/' + LatLon[0].toFixed(5);

                            $.ajax({
                                type: "get",
                                url: "https://api.vworld.kr/req/address?service=address&version=2.0&request=getaddress&format=json&type=parcel&crs=epsg:900913",//type : both, parcel, road
                                //data: { apiKey: $('[name=key]').val(), point: x + "," + y },
                                data: { apiKey: "B4DB6C25-ADD1-3B61-AED5-934A7F0E07BF", point: _this.transLatLon[0] + "," + _this.transLatLon[1] },
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
                                    document.getElementById("dAddress").innerHTML = geoResult;
                                },
                                beforeSend: function () {
                                    //var g4326 = ol.proj.transform([x * 1, y * 1], 'EPSG:900913', "EPSG:4326");
                                    //$('#geo4326').text(g4326[0] + "," + g4326[1]);
                                    //$('#geo3857').text(x + "," + y);

                                },

                                error: function (xhr, stat, err) { }
                            });
                        }
                    }
                }                

            


                _this.moveDron(_this);
                //ajaxTest(newcoor[0], newcoor[1]);
            }, 100)
        }
    };
}

14176994.56431106