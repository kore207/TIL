function DronInfo(name, honer,phone,insurance){
    this.name = name;
    this.honer = honer;
    this.phone = phone;
    this.insurance = insurance;
    
}

var dronA = new DronInfo("Dron A", "홍길동","010 - 7345 - 2345","YES")
var dronB = new DronInfo("Dron B", "이성계","010 - 2121 - 3131","YES")
var dronC = new DronInfo("Dron C", "강감찬","010 - 2511 - 6101","YES")
var dronD = new DronInfo("Dron D", "이순신","010 - 6232 - 9543","YES")
var dronE = new DronInfo("Dron E", "문익점","010 - 8643 - 1425","YES")

var dronInfoArray = new Array();

dronInfoArray[0]=dronA;
dronInfoArray[1]=dronB;
dronInfoArray[2]=dronC;
dronInfoArray[3]=dronD;
dronInfoArray[4]=dronE;