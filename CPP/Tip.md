### EEPROM 관련

---

* Fist, Second 주소 (2byte) 표현 일때 와 1byte 표현 일때 프로토콜 다르므로 주의하기
* buffer 전달시에는 strcpy 함수는 null 값을 인식하기때문에 memcpy 사용을 우선으로 한다 .

