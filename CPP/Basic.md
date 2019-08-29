## C/CPP  

---

* 변수의 선언(declaration) 과 정의(definition)의 구분
  * 선언: 컴파일러에게 변수의 존재를 알려 줌
  * 정의: 실제로 메모리를 할당

- But 변수를 서로 공유하지 않도록 하는것이 가장 나이스하다.

* foreach 문  : foreach(데이터 타입: 배열이나 컬랙션 객체 참조 변수) 자동으로 0번째 인덱스에서 해당 배열/컬랙션 객체의 length까지 1씩 인덱스를 증가시켜 준다.



#### 헤더파일의 중복 방지

* 중복된 헤더 파일 문제를 해결하기 위해 **#ifndef - #endif** 지시어를 이용한다.

* 혹은 #pragma once

  * 경고 무시 ( #pragma warning (disable:코드번호))
  
### 힙과 스택
```C
   AStruct temp ;
    memset(&temp, 0, sizeof(AStruct)) ;
    memcpy(&temp,data, sizeof(AStruct)) ;
    
    return temp ; //스택에 메모리를 저장하여 다른곳에서 스택공간을 덮어버리면 다운되는 문제가 있다 .
```


