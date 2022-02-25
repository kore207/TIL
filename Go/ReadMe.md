### Go lang study

> Go는 전통적인 컴파일, 링크 모델을 따르는 범용 프로그래밍 언어이다.
> 
> C++, Java, Python의 장점들을 뽑아 만들어 졌다. 
> 
> C++와 같이 Go는 컴파일러를 통해 컴파일되며, 정적 타입의 언어이다. 
> 
> Garbage Collection 기능을 제공한다.



#### 환경 세팅

* 참고 사이트
  
  * [[Go] Go 언어 시작하기 (VS Code 사용 및 설치)](https://soyoung-new-challenge.tistory.com/84)
  
  * http://golang.site/go/

* Go는 Go Path 에서만 프로젝트가 수행된다.



##### 문법 정리

* Go 키워드
  
  * | break    | default     | func   | interface | select |
    |:--------:|:-----------:| ------ | --------- | ------ |
    | case     | defer       | go     | map       | struct |
    | chan     | else        | goto   | package   | switch |
    | const    | fallthrough | if     | range     | type   |
    | continue | for         | import | return    | var    |

##### Go

* Main.go 는 컴파일러의 진입점이 된다.

* 대문자로 된 function은 다른 패키지로부터 export 된것

* 상수  const, 변수 var ,

* func 안에서는 변수 := value 로 축양형 선언이 가능하다.

* ```go
  //기본 함수 반환
  func multyply(a, b int) int{
      return a*b
  }
  
  //여러개의 반환도 가능, _ 변수로 무시하는 값을 반환받을수 있음 
  func leAndUpper(name string) (int, string){
      return len(name), strings.ToUpper(name)
  }
  
  //naked 리턴과 defer
  func lenAndUpper(name string) (length int, uppercase string){
      defer fmt.Println("I'm done") //function이 끝났을때 실행된
      length = len(name)
      uppercase = strings.Toupper(name)
      return
  }
  
  //가변 파라미터 
  func repeatMe(words ...string){
      fmt.Println(words)
  }
  ```

* 변수를 생성하고 사용하지 않으면 애러가 생긴다.
