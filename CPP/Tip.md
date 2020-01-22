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



### 구조체(Struct) 메모리 할당 규칙

---

```c
struct StructA{
    char a;
    int b;
    char c;
    int d;
};
```

* 일반적으로 생각할떄 위의 구조체가 메모리에 할당되는 그림은 아래와 같다

  * [1 byte] [4 byte] [1 byte] [4 byte] 

* 하지만 모두 4byte로 할당된다 

* 데이터를 읽고 쓸 떄 보다 효율적으로 사용하기 위해서

  >padding을 없애기위한 방법
  >
  >#pragma pack(n)  // n = 1, 2, 4, 8, 16 ...

  

