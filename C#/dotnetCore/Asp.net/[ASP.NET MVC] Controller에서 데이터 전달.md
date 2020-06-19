### [ASP.NET MVC] Controller에서 데이터 전달

MVC에서는 컨트롤러가 데이터를 만들어서 뷰로 전달하는 역할을 한다.

ASP.NET MVC에서는 데이터를 전달 하기 위해 ViewBag을 이용하거나 강력한 형식의 뷰(Strongly Typed View)를 이용하는 방법이 있다.



1. ViewBag을 이용한 데이터 전달 

* ViewBag은 dynamic 형식을 사용하여 변수의 Type을 검사하지 않는다. 변수의 타입을 검사하지 않기 떄문에 어떤 Object도 ViewBag에 저장하여 뷰에 전달이 가능하다.

```c# 
public class MyFirstController : Controller
{
    public ActionResult Index()
    {
        ViewBag.Message = "Hello World!";
        
        MyFirstModel myFistModel = new MyFirstModel()
        {
            Message = "Hello World!",
            CurrentDateTime = Convert.ToString(DateTime.Now)
        };
        
        ViewBag.myFirstModel = myFirstModel;
        
        return View();
    }
}
```



* 뷰에서의 데이터 사용방법은 ViewBag에서 정한 속성으로 접근하면 된다. 데이터를 가져올때는 @를 붙이는데 이즈 Razor 코드블록이다.



2. 강력한 형식의 뷰(Strongly Typed View)

* 강력한 형식의 뷰는 컨트롤러에서 뷰함수를 리턴할 때 객체를 전달하고 뷰에서는 전달한 객체를 사용하는 방법이다.

```c 
public class MySecondController : Controller
{
    public ActionResult Index()
    {
        MySecondModel mySecondModel = new MySecondModel()
        {
Title = "MySecondModel",
        Message = "강력한 형식의 뷰 예제 입니다."};        
        
        return View(mySecondModel);
    }
}
```

* 컨트롤러의 Index함수에서 마우스 오른쪽 버튼을 클릭하여 뷰추가항목을 선택하면 강력한 형식의 뷰만들이기 체크하면된다. 

https://hackersstudy.tistory.com/91