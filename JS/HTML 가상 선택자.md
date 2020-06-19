#### HTML 가상 선택자 ::before, ::after (가상 엘리먼트)



> 가상 선택자: css의 기능이며, 실제 태그가 존재하지 않지만 css를 통해서 마치 태그가 있는 것처럼 동작
>
> html에 태그를 작성하지 않고도 css로 가상 태그를 만들 수 있음



```css
<div class="num">
	number
	<div class="one"></div>
	<div class="two"></div>
	fin
</div>

.num::befor{content:'before';}
.num::after{content:'after';}
```

num 클래스 전후로 content가 생성된다.



