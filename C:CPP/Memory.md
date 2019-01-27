## 클래스와 동적 메모리

* class 내에서 static 선언은 모든 객체가 공유하는 하나의 변수이다.
* 초기화는 어느 객체 내부에서 할 수 없고 별도로 int StringBad::num_strings = 0 ; 과 같이 외부에서 해준다.(정수형, 열거형의 const 경우 제외)
* 