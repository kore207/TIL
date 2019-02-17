## 1장~3장. 실습 환경 구축

### 가상머신 VMware

* VMware를 설치해서 가상환경 (전산실 개념)을 구축한다.
* 가상 서버 폴더 4개를 만듬

* 용량은 Maximum 값을 설정 하면  vmware가 알아서 점차적으로 늘려간다.

  |                | Server                               | Server(B)              | Client          | WinClient               |
  | -------------- | ------------------------------------ | ---------------------- | --------------- | ----------------------- |
  | 주요 용도      | 서버 전용                            | 서버 전용(텍스트 모드) | 클라이언트 전용 | Windows 클라이언트 전용 |
  | 게스트 OS 종류 | Ubuntu-64bit                         | Ubuntu-64bit           | Ubuntu-64bit    | Windows 10              |
  | 설치할 ISO     | Ubuntu Desktop                       | Ubuntu Server          | Ubuntu GNOME    | Windows10               |
  | 가상머신 이름  | Server                               | Server(B)              | Client          | WinClient               |
  | 네트워크 타입  | Use network address translation(NAT) | NAT                    | NAT             | NAT                     |
  | IP             | 192.168.111.100                      | 192.168.111.200        | AUTO            | AUTO                    |

  * 게이트웨이 겸 DNS 서버 192.168.111.2 호스트 OS 192.168.111.1

* 운영체제의 특정 시점을 저장하는 스냅숏 기능을 사용할 수 있다.

* 현재 컴퓨터 상태를 그대로 저장해 놓고, 다음 사용할 때 현재 상태를 이어서 구동할 수 있다(Suspend 기능)

  

  * root 사용자로 설정
  * Snapshot 기능을 통해 환경 되돌릴수 있다.( pro기능)

  