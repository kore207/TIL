## C# 기본 문법 2

---

### 상속

* 클래스의 재사용

* ```c#
    namespace ConsoleApplication3
    {
        class A
        {
            int number ;
            protected string name = "hello" ;
            public A(int num)
            {
                number =num ;
            }
            public void PrintA()
            {
                Console.WriteLine(number) ;
            }
        }
        
        class B:A
        {
        	strimg name = "World" ;
        	public B(int num) : base(num)
        	{    	
        	}
        	
        	public void PrintB()
        	{
        		Console.WriteLine("{0} {1} , base.name, name") ;
        	}
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                B Test = new B(3) ;
                Test.PrintA() ;
                Test.PrintB() ;
            }
        }
    }
    ```

* sealed

    * 상속 불가에 대한 명시 (멤버변수, 메서드)

* override

    * C#에서의 의미: 상위 메서드를 무시하고 하위에서 재정의 하는것
    * 클래스 **메서드**,  속성, 인덱서, 이벤트가 대상
    * 상위클래스에 virtual 명시, 하위 클래스에 override 명시

* overload

    * 하나의 메서드에 다양하게 호출

* 추상 클래스 abstract class

    * 구현하려는 메서드의 형태만 존재하는 클래스
    * 추상 클래스는 구현 형태만 제공, 실제 구현은 하위에서 구현
    * 추상 클래스는 상속으로만 사용, new를 통해 생성할 수 없다.

* 다형성 polymorphism

    * 상위에서 하위 호출