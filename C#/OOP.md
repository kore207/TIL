## C# 객체지향 

> https://hongjinhyeon.tistory.com/25

* 싱글톤
    *  -해당 클래스의 인스턴스가 하나만 생성이 되는것을 보장하며 어디서든지 그 인스턴스에 접근이 가능하도록 만드는 패턴
    *  -시스템에서 전역으로 관리되고 단하나의 클래스에서만 정보가 유지되는 것을 원할때
          -보통 시스템 자원관리나 정보를 관리합니다. 예를 들어서, 프린터가 하나있는데 그것에 대한 접근 인스턴스가 여러개가 생성이 되어서
          사용이 된다면 데드락이나 오류현상이 발생할 요지가 큽니다.(동기화를 해주면 되겠지만 거추장스럽고..) 이럴때 하나의 클래스에서만
          관리해주면 해결이 됩니다.
          -스타크래프트에서 사용이 된다고 생각한다면, 게임 전체적으로 필요한  시간,유닛 킬수, 건물 갯수(엘리를 위해서..) 등등 많이 있겠네요

```c
using System;
 
namespace DoFactory.GangOfFour.Singleton.Structural
{
  
  class MainApp
  {
 
    static void Main()
    {
      
      Singleton s1 = Singleton.Instance();
      Singleton s2 = Singleton.Instance();
 
      if (s1 == s2)
      {
        Console.WriteLine("Objects are the same instance");
      }
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
   //싱글톤 클래스
   class Singleton
  {
    private static Singleton _instance;
 
    //  'protected' 로 생성자를 만듦
    protected Singleton()
    {
    }
 
    // 'static'으로 메서드를 생성
    public static Singleton Instance()
    {
      
      //다중쓰레드에서는 정상적으로 동작안하는 코드입니다.
      //다중 쓰레드 경우에는 동기화가 필요합니다.
      if (_instance == null)
      {
        _instance = new Singleton();
      }

      //다중 쓰레드 환경일 경우 Lock 필요
      //if (_instance == null)
      //{
      //  lock(_instance)<br>
      //  {
      //     _instance = new Singleton();
      //  }
      //}
 
      return _instance;
    }
  }
}
```

