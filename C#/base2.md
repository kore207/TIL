### C# 기본 문법

* 산술 연산자

    * 정수/부동 + 문자열 = 문자열 ex) 5.01f + "5" - > 5.015 

* 관계연산자의 결과는 truem, false 로 나타난다 ( 1,0 과는 또 다름)

* is 연산자

    * 형식 호환을 조사하는 연산자
    * 형식 '변수' is '클래형 or 데이터 형'
    * 박싱/언박싱 변환, 참조 변환에서 사용

* as 연산자

    * 형변환과 변환 조사
    * 캐스트 연산자의 역할과 불변환은 null리턴
    * 참조 박싱 언박싱 null형에 사용
    * 형식 : 결과형 = 참조형, 언박싱, 박싱 as 변환형

* Null 병합 연산자 

    * ??  : C =A ?? B ,A가 null이 아니면 A를 C에 대입 null이면 B를 C에 대입

* if 문에서 true, false 를 구분한다는것을 유의 

* switch, case: 모든 case 와 default에는 break 가 반드시 있어야함, 문자열도 사용이 가능

* for(;;) : 무한 반복

* **foreach** 

    * 처음부터 끝까지 순차적으로 값을 반복하여 읽는 역할 -> 읽기 전용

    * ```c
        foreach(데이터형 변수 in 배열명(컬렉션명))
        {
             //데이터형 변수는 읽기전용이라 변경이 안된다.
        }
        ```

* 예외 처리문 try ~ catch

* ```c#
    int[] array = {1,2,3} ;
    try
    {
        //예외가 발생할 수 있는 코드
        array[3] = {1,2,3} ;
    }catch(IndexOutOfRangeException e)//(예외처리 객체 e)
    {
        //예외처리
        Console.WriteLine("배열 인덱스 에러 발생") ;
        Console.WriteLine(e.ToString()) ; // 어디서 문제가 발생한지 출력해준다.
        array[2] = 10 ;
        //System.Exception 파생객체 사용
        /*overflowException, FormatException,DivideByZeroException,FileNotFoundException*/
        //IndexOutOfRangeException
    }
    //다중 예외 처리도 가능하다.
    
    ```

* try~finally 

    * Finally : 예외 발생과 상관없이 항상 실행되는 구문 

* throw :예외 상황을 임의로 발생시키는 역할 , System,Exception 파생된 객체만 사용, try문과 그 외에서 사용가능

* ```c#
    static int GetNumber(int index)
    {
        int[] nums = {300, 600, 900} ;
        if(index >= nums.Length)
        {
            throw new IndexOutOfRangeException() ;
        }
        return nums[index] ;
    }
    ```

---

### 배열

* 같은 데이터형 + 변수명 + 순차적인 메모리 나열

* 참조형 , new 를 통해 생성

* Foreach 사용 가능

* 데이터형[] 배열명 ; , 몇개를 할지는 new를 통해서 한다.

* 행과 열, 면은 콤마(,) 로 구분

* **가변 배열**

    * 데이터형[ ] [ ]  배열명 ; 

* 배열을 리턴하는 함수

    ```c#
    static void Main(string[] args)
    {
        int[] nArray1;
        int[,] nArray2; //참조 배열 변수
        
    	nArray1 = CreateArray1(5) ;
        nArray2 = CreateArray2(2,3) ;
    }
    
    static int[] CreateArray1(int nSize)
    {
        int[] Array1 = new int[nSize] ;
        for(int i=0 ; i <Array1.Length; i++)
            Array1[i] = 1 ;
        return Array1 ;
    }
    
    static int[,] CreateArray2(int nRow, int nCol)
    {
        int index =0 ;
        int[,] Array2 = new int[nRow, nCol] ;
        for(int i = 0; i<nRow; i++)
            for(int j = 0; l < nCol; j++)
    			Array2[i,j] = index++ ;
        return Array2 ;
    }
    ```

    

* Array 클래스로부터 파생된 객체 , 다양한 매소드 사용가능
* Clear, Clone , ex)Array.Clear(Array,2,3) ;

---

### 파일 입출력

> 스트림 (stream) , 직렬화(Serialize),

* 스트림 : 파일, 네트워크 등에서 데이터를 바이트 단위로 읽고 쓰는 클래스
* Stream class 는 상위 기본 클래스 , 상속 클래스들 (FileStream, MemoryStream, NetworkStream, SqlFileStream 등)
* using System.IO 선언



* 파일 스트림
    * Byte[] 
    * StreamWriter/ StreamReader + BinaryWriter/BinaryReader 와 사용 

---

### 클래스

* 변수와 메서드를 그룹화한 것
* 주요개념
    * 그룹화를 위해 class키워드와 형식 사용
    * New 연산자로 생성하여 사용
    * new를 사용하지 않으면 같은 클래스 참조할수있는 변수가됨( 클래스 참조 변수)
    * 클래스를 new를 통해 생성하면 객체가 됨
    * 객체 해제는 가비지 컬렉터에게한다. ( c++에서 delete같은걸 안해도 된다.)
* 인스턴스는 본질, 객체는 실물인 형상
* 접근한정자(access modifier)
    * private, protected, public,internal, protected internal

> 언어에 따른 static 역할 비교
>
> C:변수 값 유지, C++ :객체 안에서 변수 공유 ,C# :객체를 생성하지 않고 멤버 사용
>
> Ex) Console.Writeline() 에서 Console의 객체를 생성하지 않았지만 static으로 선언되어있기 때문에 사용할 수 있다.

### 속성과 인덱서

* 속성
    * 클래스 안의 멤버변수에 값 읽기 또는 저장 
    * private로 선언된 멤버 변수 
    * keyword : get, set , value, return 
* 인덱스: 색인
    * 어떤 것을 뒤져서 찾아내거나 필요한 정보를 밝힘
    * 클래스 내의 배열 또는 컬렉션을 외부에서 접근할 수 있도록 하는 역할
    * 속성 형식(get, setm return, value ) + 배열 형식(this[int index])
    * 배열과 같이 사용 , 객체명[인덱스] = 값 또는 변수; 변수= 객체명[인덱스 ;]

---

### 델리게이트와 이벤트

* Delegate(위임하다) , 대리자

* 델리게이트의 본질은 메서드 참조형이다. 

* 속성과 인덱서는 멤버변수를 다루고, 델리게이트는 메서드를 다룬다.

* 복수 또는 단일 메서드를 대신하여 호출하는 역할

* ```c#
    namespace ConsoleApplication1
    {
        delegate void DelegateType(string str) ;
        
        clss A
        {
            public void Print(string str)
            {
                Console.WriteLine(str) ;
            }
        }
        
        class program
        {
            static void Main(string[] args)
            {
                A Test = new A() ;
                DelegateType DelMethod1 = new DelegateType(Test.Print) ; //c# 1.0이상
                DelMethod1("Hello World") ; //대신 호출해서 사용하고있다.
                
                DelegateType DelMethoe2 = Test.Print ; //C#2.0 이상에서 사용가능
                DelMethod2("Hello World") ;
                
            }
        }
    }
    ```

* **멀티캐스트 델리게이트(multicast delegate)**

    * 데이터를 여러 사용자에게 동시에 보낸다.

    * += ,-= 연산자로 추가

    * ```c#
        DelegateType DelFunc = Test.PrintA ;
        DelFunc += Test.printB ;
        DelFunc() ;
        ```

* **이벤트**

    * 특정 상황이 발생했을 때 알리고자 하는 용도 (호출을 의미 + 데이터)

    * 델리게이트를 기반으로 한다.

    * 이벤트는 메서드 안에서만 사용가능

    * ```c#
        [Class A]
        puvlic event DelegateType EventHandler ;
        public void Func(string Message)
        {
            EventHandler(Message) ;
        }
        [Program]
        static void Main(string[] args)
        {
            A Test1 = new A() ;
            B Test1 = new B() ;
            
            Test1.EventHandler += new DelegateType(Test2.PrintA) ;
            Test1.EventHandler += new DelegateType(Test2.PrintB) ;
            Test1.Func("good") ;
            
        }
        ```

        