### GET , POST 메서드

---

두 방식 모두, 서버에 요청을 하는 메서드이다.

* GET 방식은 클라이언트의 데이터를 URL 뒤에 붙여서 보낸다. 

  * www.ex.com?id=ABC&pass=1234
  * 2개 이상의 key-value 쌍 데이터를 보낼때는 &마크로 구분해준다.
  * URL에 붙이므로, HTTP 패킷의 헤더에 포함되어 서버에 요청한다.
  * 따라서 BODY에 특별한 내용을 넣을 것이 없으므로 BODY가 빈상태로 보내진다
  * URL형태이므로 특정 페이지를 다른사람 에게 접속하게 할 수 있다.
  * 간단한 데이터를 넣도록 설계되어, 데이터를 보내는 양의 한계가 있다.

* POST방식은 데이터 전송을 기반으로 한 요청 메서드이다.

  * URL에 붙이지 않고 BODY에다 데이터를 넣어 보낸다.

  * 따라서, 헤더필드중 BODY의 데이터를 설명하는 Content-Type 헤더필드가 들어가고 어떤 데이터 타입인지 명시한다.

    * application/x-www-form-urlencoded
    * text/plain
    * multipart/form-data

    