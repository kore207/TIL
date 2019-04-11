## C/CPP  

---

* 변수의 선언(declaration) 과 정의(definition)의 구분
  * 선언: 컴파일러에게 변수의 존재를 알려 줌
  * 정의: 실제로 메모리를 할당

- But 변수를 서로 공유하지 않도록 하는것이 가장 나이스하다.

#### 헤더파일의 중복 방지

* 중복된 헤더 파일 문제를 해결하기 위해 **#ifndef - #endif** 지시어를 이용한다.

* 혹은 #pragma once

  * 경고 무시 ( #pragma warning (disable:코드번호))

  