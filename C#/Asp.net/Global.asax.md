### Global.asax 란?

Global.asax 파일은 예전 ASP에서 사용되었던 global.asa 파일에서 사용되었던 내용을 .NET 환경에서 사용할 수 있도록 만든 파일입니다. Global 이란 뜻처럼, 전역 데이터를 관리할 수 있을뿐 아니라 웹 사이트의 시작과 종료, 새로운 사용자의 접속 시도 및 접속 종료시 등 여러가지 프로그래밍 코드를 작성할 수 있는 곳입니다.

### Event 종류와 순서

* BeginRequest
* AuthenticateRequest
* AuthorizeRequest
* ResolveRequestCache
* AcquireRequestState
* PreRequestHandlerExecute
* **HTTP Handler**
* PostRequestHandlerExecute
* ReleaseRequestState
* UpdateRequestCahche

> 이외에 Application이 시작/ 종료시 1번씩 실행되는 Event

* Application_Init
* Application_Start
* Application_Dispose
* Application_End