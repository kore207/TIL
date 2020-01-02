### EEPROM 관련

---

* Fist, Second 주소 (2byte) 표현 일때 와 1byte 표현 일때 프로토콜 다르므로 주의하기

  * 페이지의 크기가 넘어가는 버퍼를 저장시에는 페이지 넘어갈때 delay를 고려한뒤 각 공간에 비트 마스킹을 하여 주소를 입력한다. ( data sheet 를 반드시 참조해야한다.)

    ```c
    //first address
    at24c256.msgs[0].buf[0] = (unsigned char)((address + (BYTE_PER_PAGE * i)) >> 8) 
    //second address
    at24c256.msgs[0].buf[1] = (unsigned char)((address + (BYTE_PER_PAGE * i)) & 0xFF) 
    ```

    

* buffer 전달시에는 strcpy 함수는 null 값을 인식하기때문에 memcpy 사용을 우선으로 한다 .

