function DronInfo(dnum, name, honer, phone, insurance, time) {//객체 생성자 함수     
    this.dnum = dnum;
    this.name = name;
    this.honer = honer;
    this.phone = phone;
    this.insurance = insurance;

    this.popInfo = null;

    this.time = time;
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
        }
    };  

    this.style = new ol.style.Style({
        stroke: new ol.style.Stroke({
            color: [0, 255, 0, .7], //투명도
            width: 1 //두께
        })
    }); // 스타일 설정

    this.createRoute = function () {        
        //route 레이어 추가 
        this.line_feature = new ol.Feature({
            geometry: new ol.geom.LineString([]),
            id: this.dnum
        });
        
        this.line_feature.setStyle(this.style);
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
        
        vmap.addLayer(this.vectorLayer);
        
        if ($('#dispRoute').css('background-color') != 'rgb(0, 230, 0)') //경로표시 선택했을떄 visible 
            vmap.getLayerByName("경로레이어" + this.dnum).setVisible(false);
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

                if (document.getElementById("popup")) { //팝업창에서만 실시간 주행 시간을 표시
                    for (var i = 0; i < 5; i++) {
                        if (vmap.getOverlays().getArray()[0].get('id') == ("MarkerPop-" + _this.dnum)) {
                            document.getElementById("areaInfo").innerHTML = _this.name + '</br>'
                                + '소유주:' + _this.honer + '</br>'
                                + '핸드폰 번호:' + _this.phone + '</br>'
                                + '보험:' + _this.insurance + '</br>'
                                + '비행시간:' + hours + ":" + mins + ":" + secs;
                        }
                    }
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
                        oldcoor = dronFeatures[i].getGeometry().getCoordinates();

                        _this.moveRect(300, _this);

                        if (_this.dnum == 0)  //시작방향을 달리주기위한 조건문                            
                            newcoor = [oldcoor[0] + _this.dx, oldcoor[1] + _this.dy];                                                    
                        else if (_this.dnum == 1) 
                            newcoor = [oldcoor[0] + _this.dx, oldcoor[1] - _this.dy];                                                    
                        else if (_this.dnum == 2)
                            newcoor = [oldcoor[0] - _this.dx, oldcoor[1] - _this.dy];
                        else// if (dObj.dnum == 3)
                            newcoor = [oldcoor[0] - _this.dx, oldcoor[1] + _this.dy];

                        dronFeatures[i].getGeometry().setCoordinates(newcoor);
                    }
                }
                //Cannot read property 'length' of undefined 에러 나는 부분 
                _this.line_feature.getGeometry().appendCoordinate(newcoor);                
                
                _this.moveDron(_this);
                
                ajaxTest(newcoor[0], newcoor[1]);
            }, 100)           
        }
    };    
}
