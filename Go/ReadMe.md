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

* Go의 Loop는 for만이 존재한다.

* ```go
  func superAdd(numbers ...int) int{
      //index를 쓰지않는경우 _, 를 사용하여 ignore 할 수 있다.
      for index, number := range numbers{
      fmt.Println(index, number)
      }
  
      for i := 0; i<len(numbers); i++{
          fmt.Println(numbers[i])
       }
      return 1    
  }
  
  func main(){
      total := superAdd(1,2,3,4,5,6)
  }
  ```

* ```go
  //if , else
  func canIDrint(age int) bool{
      if age < 18 { //if 문의 조건식은 반드시 Boolean 식이여야 한
          return false
      } else {
          return true
      }  
  
      //Optional Statement (Switch, for 문 등 여러 문법에서 사용 가능)
      //if문 안에서 변수 생성 (variable expression)
      if koreanAge:=age +2; koreanAge<18{
          return false
      }
  }
  ```

* ```go
  func canIDrint(age int) bool{
      //Go에서는 별도의 break 가 없어도 다음 case로 넘어가지 않는다.
      //fallthrough 명령문을 쓰면 넘어간
      switch age{
      case age < 10:
          return false
      case 18:
          return true
      }
      return false
  }
  ```

* Pointers
  
  * & 연산자로 메모리 주소에 접근 할 수 있다.
  
  * *연산자로 값을 훑어 볼 수 있다.
  
  * ```go
    func main(){
        a := 2
        b := &a
        *b = 20
        fmt.Println(a) //20
    }
    
    func temp(d string) *data {
        ...
        retrun &d 
    }
    ```

* Array, Slice
  
  * ```go
    func main(){
        names := [5]string{"1","2","3","4","5"}
        names[3] = "asd"
        //slice 는 크기가 없는 배열이다.
        names := []string{"1","2","3","4","5"}
        names = append(names, "6")
    }
    ```

* map
  
  * ```go
    func main(){
        gt := map[string]string{"name":"gt","age":"12"}
        for key, value := range gt {
            fmt.Println(key, value)
        }
    }
    ```

* Structs
  
  * ```go
    type person struct{
        name string
        age int
        favFood []string
    }
    ```
    
    
    
    ```go
    func main() {
        favFood:=[]string{"kimchi","ramen"}
        gt := person{"gt",18,favFood}
        //아래와 같이 만드는게 더 명확하다.  
        gt := person{name:"gt",age:18,favFood:favFood}
        //이렇게도 가능
        gt2 := new(person) //zero value 로 초기화 된    
    }
    
    ```
