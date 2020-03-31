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

#### 사용자 지정형

* struct , 구조체에 선언된 const, static 변수만 초기화가능, 구조체 안에 선언할 수 있는 생성자는 매개변수가 반드시 있어야 함.
    * 구조체를 같은 구조체에 대입하게 되면 값이 복사
    * 구조체는 값 형식이고 클래스는 참조 형식임 (call by value, ref)

```c#
public struct 구조체 명
{
    //멤버, 속성, 메서드
    public const float PI = 3.14f ;
    public static int Age = 12 ;
    //public int var ; //이렇게 하면 생성해서 사용해야한다.
    //new를 통해 생성하면 0으로 setting이 된다.
    public 구조체 명(int InAge) // 생성자
    {
        Age = InAge 
    }
}
////////////////////////////////////////////////////
//값과 참조
namespace ConsoloeApplication1
{
    public struct MyStruct
    {
        public int Age ;
    }
    
    class MyClass
    {
        public int Age ;
    }
    
    class Program
    {
        static void Main(stringp[] args)
        {
            MyStruct test1 = new MyStruct() ;
            test1.Age =12 ;
            MyStrcut test2 = test1 ; 
            test2.Age = 24 ; //이렇게 되면 값(value) 이 복사되기 때문에 각각 12, 24가 출력된다.
            
            MyClass test3 = new MyClass() ;
            test3.Age =12 ;
            MyClass test4 = test3 ;
            test4.Age =24 ; //같은 객체에대한 참조형식이기 때문에 둘다 24가 출력이된다.
            
        }
    }
}

```

* 구조체는 구조체 또는 클래스에 상속할 수 없음 (C++에서는 가능)
* enum : 상수를 문자열로 대치하여 선언, 상수에 의미 부여 
    * enum 열거형 명칭{문자열1, 문자열2} ;
    * enum 열거형 명칭{문자열1= 상수, 문자열2= 상수};
    * enum열거형 명칭{문자열1=상수, 문자열2};
    * 기본은 Int형이지만 char형을 제외한 형식 지정할수있음
        * enum Days:byte{sum=0, Mon, Tue, Wed, Thu} ; //0 ,1 ,2 ...

