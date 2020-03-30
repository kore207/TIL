#### C# 언어 개요

* C++ 언어 기반 + java 장점
* C#은 포인터를 사용하지 않는다. (가비지 컬렉터)
* C# -> 컴파일 -> MSIL (*.exe 결과물) -> CLR -> 실행

---

* 자동 생성 코드
    * using 부분 -> 프롤로그 , namespace-> 프로그램 몸체
* 프로그램의 진입점 Main (CLR이 제일 먼저 찾는 곳) , 객체 안에서의 static 메서드

---

* 표준 출력
    * Console.Write(), Console.WriteLine() 차이점 -> \n or endl (개행)
    * Console.Write({0} {1}, 3.12f, 3) 다중 출력 ({1:f2} 소수점 자리수)
    * 출력 형식 문자 -> MSDN 참고
        * Console.Write({0:C} {1:P}, 3.12f, 3)
    * 키워드
        * C키워드 (26개) break, case, char, const, continue, default, do , double, else unum, extern, float, for ,goto , if , int, long, return ,short, sizeof , static, struct, switch, typeof, void, while 
        * C++키워드(19개) bool, catch, class, false, finally, namespace, new, private, protected, explicit, operator, public, this, throw, true, try, using, virtual, volatile
        * C#키워드(약32개) abstract, as ,base , byte, checked, decimal,delegate, event, fixed, foreach, in , interface, internal, implicit, is, lock , null, object, out , override, params, readonly, ref, sbyte, sealed, string, uint, ulong, unchecked, unsage, ushort, volatile

---

#### 데이터형

* C#의 데이터형 objuxt로부터 파생된 객체
* 데이터형은 CTS에서 정의된 객체
* Bool 형은 0,1 이 아닌 true , false 로 존재
* String 형의 사용 , 연산자 오버로딩 가능, 문자열의 끝에 0, \0 사용 안함
    * 경로는 "\\ \ "두번 쓰거나 @ 를 앞에 붙여준다.
* 암시적 데이터형 var
    * 대입되는 데이터에 따라 데이터형 결정
    * var를 사용할 수 없는 예
        1. Null 값 초기화, 매개변수로는 사용 못함
        2. var는 지역변수로만 사용 , 클래스 멤버로는 사용 못함
        3. 연속적으로 초기화 하는 경우, var m= 10, n = 20 ; 
* 데이터형 + '?' -> null 값을 갖을수 있게 한다.

#### 데이터 변환

* ToString()  ->문자열
* 기본 데이터형.Parse() -> 문자열을 다시 기본데이터형으로
* Convert.ToInt32() , Convert.Tosingle() , Convert.TOXXXXX()

#### 박싱과 언박싱

* 박싱 -> 데이터 형을 최상위 object 형으로 변환하여 힙에 저장
    * int m =123 ; object obj = m ;
* 언박싱 -> 힙에 저장된 형식을 다시 원래의 형식으로 변환
    * int n = (int)obj ;

#### 표준 입력

* Console.ReadKey() :사용자가 눌린 키 한 문자 정보를 리턴하는 메서드
* 