function DronInfo(dnum, name, honer, phone, insurance, time) {
    this.dnum = dnum;
    this.name = name;
    this.honer = honer;
    this.phone = phone;
    this.insurance = insurance;

    this.popInfo = null;

    this.time = time;
    var running = 0;
       
    this.startPause = function () {                                
        if (running == 0) {
            running = 1;
            timeIncrement(this);
            moveDron(this);
        }
        else {
            running = 0;
            this.time = 0;            
        }
    };

    
    var timeIncrement = function (dObj) {        
        var _this = dObj;        
        if (running == 1) {
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
                //document.getElementById("output").innerHTML = hours + ":" + mins + ":" + secs;                
                
                if (document.getElementById("popup")) {           
                    for (var i = 0; i < 5; i++){
                        if (vmap.getOverlays().getArray()[0].get('id') == ("MarkerPop-" + _this.dnum)) {
                            document.getElementById("areaInfo").innerHTML = _this.name + '</br>'
                        + '소유주:' + _this.honer + '</br>'
                        + '핸드폰 번호:' + _this.phone + '</br>'
                        + '보험:' + _this.insurance + '</br>'
                        + '비행시간:' + hours + ":" + mins + ":" + secs;                        
                        }
                    }                                        
                }
                timeIncrement(_this);
            }, 100)
        }
        else {
            document.getElementById("output").innerHTML = "0:00:00";
        }
    }  

    //사각형 이동 
    var distance = dir = dx = dy = 0;
    const moveRect = function (dis) {
        //상하좌우 배열로 변경하기 
        if (dir == 1) {//우측                     
            dx = 0.5; dy = 0;
            if (distance == dis) {
                distance = 0;
                dir++;
            }
        }
        else if (dir == 2) {//상측                    
            dx = 0; dy = 0.5;
            if (distance == dis) {
                distance = 0;
                dir++;
            }
        }
        else if (dir == 3) {//좌측                    
            dx = -0.5; dy = 0;
            if (distance == dis) {
                distance = 0;
                dir++;
            }
        }
        else {//하측                    
            dx = 0; dy = -0.5;
            if (distance == dis) {
                distance = 0;
                dir = 1;
            }
        }
        distance++;
    }

    var moveDron = function (dObj) {
        let _this = dObj;
        if (running == 1) {
            setTimeout(function () {
                var dronFeatures = vmap.getLayerByName("마커레이어").getSource().getFeatures(); // 마커레이어를 가져온다.
                var oldcoor = dronFeatures[dObj.dnum].getGeometry().getCoordinates();
                var newcoor;
                moveRect(300);
                if (dObj.dnum == 0)
                    newcoor = [oldcoor[0] + dx, oldcoor[1] + dy];
                else if (dObj.dnum == 1)
                    newcoor = [oldcoor[0] + dx, oldcoor[1] - dy];
                else if (dObj.dnum == 2)
                    newcoor = [oldcoor[0] - dx, oldcoor[1] - dy];
                else// if (dObj.dnum == 3)
                    newcoor = [oldcoor[0] - dx, oldcoor[1] + dy];
                

                dronFeatures[dObj.dnum].getGeometry().setCoordinates(newcoor);
                                                                      
                line_feature[dObj.dnum].getGeometry().appendCoordinate(newcoor);     

                moveDron(_this);
            }, 100)           
        }
    };



}

//var dronA = new DronInfo(0, "Dron A", "홍길동","010 - 7345 - 2345","YES",0)
//var dronB = new DronInfo(1, "Dron B", "이성계", "010 - 2121 - 3131", "YES", 0)
//var dronC = new DronInfo(2, "Dron C", "강감찬", "010 - 2511 - 6101", "YES", 0)
//var dronD = new DronInfo(3, "Dron D", "이순신", "010 - 6232 - 9543", "YES", 0)
//var dronE = new DronInfo(4, "Dron E", "문익점", "010 - 8643 - 1425", "YES", 0)

//var dronInfoArray = new Array();

//dronInfoArray[0]=dronA;
//dronInfoArray[1]=dronB;
//dronInfoArray[2]=dronC;
//dronInfoArray[3]=dronD;
//dronInfoArray[4] = dronE;
