using System;

class LambdaExpression{

    //람다식 (Lambda Expression) : C# 3.0
    //[1]대리자 선언
    delegate void Lambda(); //delegate :다른 함수를 대신 호출한다.
    static void Main(){
        //[2]대리자 개체에 람다식 정의: goes to 연산자 or arrow 연산자
        Lambda hi =
            () => Console.WriteLine("Hellow");

        //[3]대리자 개체 호출
        hi();

        Main2();

        Main3();

        Main4();
    }

    //반환값 있는 경우
    delegate int Lambda2(int i);
    static void Main2(){
        Lambda2 square = a => a * a ;
        Console.WriteLine(square(3));        
    }

    delegate bool Lambda3(string msg, int len);
    static void Main3(){
        Lambda3 isLong = 
            (msg, len) => msg.Length > len;
        Console.WriteLine(isLong("안녕하세요.",5));    
    }

    delegate void Hi();
    static void Main4(){
        
        Hi hi = () => {
            Console.WriteLine("hellow");
            Console.WriteLine("hi");
        };
        hi();


    }
}

