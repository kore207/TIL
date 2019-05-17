## VI ,도움말, 기타 사용법 정리

> 기본적인 정리 외에 유용한 것들 기록해두기

#### 	명령모드

* p: 복사한 내용을 현재 행 이우에 붙여 넣기
* P: 복사한 내용을 현재 행 이전에 붙여 넣기
* :Set number : 행 번호 표시:
* man: (manual) 
* touch: 빈파일을 만들거나 기존 파일의 생성시간을 현재로 만듬
* rm -f  = rm 
* . : 현재 디렉토리
* mkdir -p aaa/bbb (디렉터리 뒤까지 생성)
* rm -r aaa (내부 파일이 있든 상관하지 않고 디렉터리 삭제)
* head/tail -num : 파일의 맨 앞/뒤 (num)줄 확인
* file : 파일 정보 



### 외부 기기

* mount : 현재 연결된 장치들

  * umount :연결을 끊는다.

  * USB는 FAT32 형식이 기본이다.

    
#### VI

* 비정상 종료시 ls -a 명령어를 통해 .* (숨김파일)의 리스트를 확인하고 rm -f를 통해 임시파일(.swp)을 삭제한다.

### ETC

* iso image 만들기
  * dpkg --get-selections genisoimage
  * genisoimage -r -J -o 이름.iso 위치

---

### 네트워크 관련 필수 개념

* TCP/IP :컴퓨터끼리 네트워크 상으로 의사소통을 하는 프로토콜 중 가장 널리 사용되는 프로토콜의 한 종류
* 호스트 이름 : 각각의 컴퓨터에 지정된 이름
* 도메인 이름: naver.com 과 같은 형식


cmake or cmake-gui 에서 특정 패키지를 찾지 못할때 
​    
export PKG_CONFIG_PATH=/home/me/usr/libxml/lib/pkgconfig

제대로 설정되었는지 확인하려면
echo $PKG_CONFIG_PATH

이런식으로 직접 등록하면 인식한다.
​    

​    

​    

​    

​    

​    

​    

​    

​    
