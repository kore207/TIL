**ajax의 setting :** 많은 인자가 있지만 중요한 것만 설명



**url:** 보낼 주소를 적는다. 당연하지만 없어선 안된다.

**type:** 보낼 타입을 지정한다. 설정안하면 get으로 가므로 사실 위의 예제에서는 생략해도 가능. 보통 가독성때문에 적는 경우가 많음

**method:** type과 동등하다. 사실 type이 옛날부터 존재하고 method가 뒤에생겼다. 구버전은 type만 사용가능

**data:** body에 data를 실을 때 사용한다. post등 body가 필요하다면 선택해얗나다.

**headers:** 헤더지정가능, js object로 넣어준다. 토큰같은거 사용할때 보통 사용한다.

**dataType:** 데이터의 타입을 개략적으로 지정할 수 있다. 보통 안쓰는게 권장이나 옜날부터 사용해서 아직도 쓰는 사람이 있다.

**contentType:** 컨텐트 타입을 직접 정할 수 있는데 안쓰는게 권장이다. mime타입을 지정하려면 headers에서 바꿔주는게 정석, 경우에 따라 아예 안될 수 있으니 조심.

**async:** 기본적으로는 true인데 false를 지정하면 동기로 만들 수 있으나 머리에 총맞은거 아니면 사용할 일 없다. 웹 화면 멈추게 할거면 사용하라.

**beforeSend:** 보내기 직전에 할 행동을 정의한다. 모듈화를 깔끔하게 하고싶으면 자주 사용하는 것 같다.

**jsonp:** jsonp를 사용할지 물어본다. 요즘은 cors가 대세라서 잘 안쓰이나 경우에 따라서는 써야할 수 있다.

**success:** callback function으로 성공했을 때의 행동을 물어본다. done과 동등하다. 만약 done과 같이 쓴다면 done보다 먼저 작동한다.

**error:** callback function으로 실패했을 때의 행동을 물어본다. fail과 동등하다. 만약 fail과 같이 쓴다면 fail보다 먼저 작동한다.

**complete:** callback function으로 종료했을 때의 행동을 물어본다. always와 동등하다. 만약 always와 같이 쓴다면 always보다 먼저 작동한다.