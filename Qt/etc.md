### QT 의 기본 .pro & qmake

> 출처: <https://saengjja.tistory.com/145> [생짜]  

* **.pro( Qt Project file )**

  *   QT Creator로 프로젝트를 생성하면 해당 프로젝트 명의 '.pro' 프로젝트 파일이 생성된다.  '.pro'  파일은 QT 프로젝트를 구성하는 파일이고 qmake 를 통해 자동적으로 Makefile을 만들 수 있다. 

* **.pri( Qt Project Include file )**

  * .pri 파일은  .pro 파일의 형식과 완전히 동일하고 일반적으로 프로젝트 포함 파일이라고 한다. 기본적으로 기능을 공유하기 위해 프로그래밍 언어로 모듈을 포함하는 것과 유사하다. 공통적으로 필요한 환경을 .pri파일에 설정하고 .pro파일에 'include( .pri 파일 경로)' 또는 'include($$PWD/***.pri)' 해서 사용한다.

* **qmkae**

  * 유닉스/리눅스에서 컴파일 할 때 주로 Makefile을 사용하지만 Makefile 자체를 익히는데는 많은 시간이 필요하다.

  Makefile을 쉽게 생성해주는 여러가지 툴들이 있는 qmake는 QT에서 주로 사용하는 다중 플랫폼용 Makefile 생성툴이다.

  QT Project를 생성하면 '.pro' 파일이 생성되는데 '.pro'파일에 qmake 문법에 맞게 기술한 후 'Run qmake'를 실행하면

  유닉스, 리눅스 용 Makefile이 생성된다. ( Run qmake는 QT Creator 에서 Popup 메뉴로 실행 시킬 수 있다. )

  Qmake에 대한 자세한 사항은 [qmake Manual](http://doc.qt.io/qt-4.8/qmake-manual.html#qmake) , **qmke Function Reference** 을 참고하면 된다.

  '.pro' 파일에 기술하는 qmake 문법은 유닉스/리눅스에서 사용하는 쉘스크립트 문법과 유사하다.

  qmake에서 사용하는 시스템 변수에 값을 대입하면 된다.

  주석은 '#'로 시작한다. '.pro' 또는 '.pri' 파일내에서 변수를 사용할 수 있는데 사용할 변수 앞에 '$$'를 붙여 주면 된다.

  여러줄을 기술할 때는 '\'( 백슬러시 )를 사용하면 된다.

  ```
  INCLUDERPATH = $$PWD \
  
                            ./lib
  
  HEADERS = ../hdr
  SOURCE = main.cpp \
                 $$INCLUDERPATH
  
  SOURCE += ../src
  ```

  

**qmake의 시스템 변수**

**TEMPLATE**

프로젝트 파일의 타입을 정의한다. app, vcapp, lib, vclib, subdirs 등이 올수 있다.

TEMPLATE = app : 독입적인 어플리케이션 (default값이다. 생략하면 app가 기본)

TEMPLATE = lib : static lib 또는 shared lib

TEMPLATE = subdirs : 내용은 없고 하위 디렉토리를 정의한다는 의미이다.

HEADERS 

해터파일을 적는다.

ex) HEADERS += animateditem.h

 

**SOURCES**

소스파일이다.

SOURCES += ledmeter.cpp main.cpp toplevel.cpp view.cpp

 

**TARGET**

실행파일의 이름이다. 보통 gcc 컴파일 시 –o 옵션 뒤에 붙는 이름이다.

생략 시 .pro 파일 앞에 붙는 이름이 default 값이 된다.

 

**DEFINES**

Define . gcc 컴파일 시 –D  옵션뒤에 붙는 옵션이다.

ex) DEFINES += HAVE_KEYBOARD

 

**LIBS**

프로젝트에 링크할 라이브러리를 지정한다.

라이브러리는 절래경로를 사용해 지정하거나 –L 옵션과 –l 과 같이 사용된다.

ex) LIBS += -lpng -L../../lib

 

**INCLUDEPATH**

전역 헤더 파일의 위치를 찾기위한 경로 지정. –I 옵션과 같은 역할

ex) INCLUDEPATH += ../shared

 

**DESTDIR**

실행 이미지가 설치될 디렉토리를 지정한다. 기본값은 플랫폼에 따라 다른데, 리눅스의 경우 현재 디렉토리에 실행파일이 생성되고, 윈도우에서는 debug나 release 디렉토리 아래 생성된다.

ex) DESTDIR = ../../../../bin

 

**DEPENDPATH**

QMAKE가 dependency 검색 시 사용되는 경로를 지정한다.

ex) DEPENDPATH = ../../include



**MOC_DIR**

moc 파일들이 생성되는 경로를 지정한다.

ex) MOC_DIR=$$OUT_PWD/.moc

 

**SUBDIRS**

하위 디렉토리에 있는 .pro 파일을 재귀적으로 호출될 수 있도록 하위 디렉토리를 지정한다.

ex) SUBDIRS += qtestlib designer

 

**FORMS**

uic에 의해 처리되는 QT디자이너로 생성된 .ui파일을 지정한다.

ex) FORMS += mainwindow.ui

 

**RESOURCES**

rcc에 의해 처리되는 실행파일내에 포함되는 리소스파일을 정의한 xml파일 .qrc를 지정한다.

ex) RESOURCES += assistant.qrc

 

**VERSION**

target 라이브러리의 버전 번호를 지정한다.

ex) VERSION=$${QT_MAJOR_VERSION}.$${QT_MINOR_VERSION}

 

**DLLDESTDIR**

dll파일이 설치될 경로를 지정한다. (디폴트값은 DESTDIR)

ex) DLLDESTDIR = $$OUTPUT_DIR/bin

 

**QT**

프로젝트에 사용될 Qt의 모듈을 지정한다.

디폴트값은 core 와 gui이다. 이는 QtCore 모듈과 QtGui 모듈을 포함한다는 의미이다.

QT에 지정되는 모듈은 대랴

core gui network opengl sql svg xml xmlpatterns qt3support 등이 있다.

Qt Creator에서 Qt모듈을 클릭하여 설정하는데 설정 시 .pro파일에 선택된 모듈들이 포함되는 것을 볼 수 있다.

**CONFIG**

CONFIG 변수는 빌드시 다양한 옵션들을 제어하기 위해 사용된다.

CONFIG += release warn_on qt 등의 형식으로 사용된다.

CONIFG와 사용되는 변수들

| debug      | compile with debug options enabled                           |
| ---------- | ------------------------------------------------------------ |
| release    | compile with optimization enabled, ignored if debug is specified |
| warn_on    | The Compiler should emit more warnings than normally         |
| warn_off   | The Compiler should emit no warnings or as few as possible   |
| ordered    | Order subdirectories so parallelized builds work             |
| qt         | The target is a Qt application/library and requires Qt header file/library |
| opengl     | The target require the OpenGL(or Mesa)                       |
| thread     | The target is a multi threaded application or library        |
| x11        | The target is an X11 application or library                  |
| windows    | The target is Win32 window application                       |
| console    | The target is a Win32 console application                    |
| shared     | The target is a shared object/DLL                            |
| static     | The target is a static library                               |
| plugin     | The target is a plugin(requires TARGET=lib, and implies shared) |
| exceptions | Turn on compiler exception support                           |
| rtti       | Turns on compiler RTTI support                               |
| stl        | Turns on Qt STL support                                      |
| flat       | only for TEMPLATE=vcapp; puts all sources files into one group and all header files into another group, independedt of the directory structure |



**qmake의 내장함수**

**조건문**

기본 문법은 아래와 같다.

condition {

​    then-case

} else {

​    else-case

}

{ 문은 반드시 condition 옆에 있어야 하고 }는 하나의 라인이어야 한다.

즉,

condition

{

then-case } 등으로 인식되지 않는다.

 

이제 사용예를 보자

win {

   debug {

​      SOURCE += debug.cpp

   } else {

​      SOURCE += release.cpp

   }

}

 

위 문장은 다음과 같이 사용할 수 있다.

condition:then-case

사용예

debug:SOURCE+=debug.cpp

else:SOURCE+=release.cpp

 

이경우 !(이 아닐경우)를 사용할 수 있다.

!debug:SOURCE+=release.cpp

 

**isEmpty(variablename)**

변수가 비었는지를 검사한다.

사용예

isEmpty(VERSION) {

   VERSION=4.3.0

}

 

**CONFIG(config)**

조건분과 유사하다. mutual exclusion을 사용할 수 있다.

사용예

CONFIG(release) {

   then-case

}





### GUI event

* 함수가 끝나면 repaint()  혹은 update()  처럼 gui 가 없데이트 된다

  이때 꼭 함수가 끝나고 처리되지 않게 하련면 qApp->processEvents(); 해주면 된다.


### q Embedded screenshot
```c
    QScreen *screen = QGuiApplication::primaryScreen() ;
    QPixmap *map = new QPixmap(screen->grabWindow(0)) ;
    bool result = map->save("/root/sshot.bmp","BMP") ;
```

### QWidget
> <https://stackoverflow.com/questions/40241527/qpushbutton-to-open-qwidget>
* 버튼을 눌러서 콤보박스 형식으로 위젯을 띄우기 위해 버튼이벤트 내부에서 Widget을 호출하면 함수가 종료하는 순간 소멸되기 때문에 dialog에서 사용하는 done(숫자)로  리턴받는것 보단 불편하다.
  * 띄우는건 new 로 메모리 동적 할당을 받으면 된다.
  * windowflag를 Qt::popup으로 주면 focusOut 될때 자동으로 꺼진다.
* 보통 widget이나 dialog에서 this->close() 는 창을 가리는 것이지 메모리 영역에서 제거 되지는 않는다.
  * 제거하기 위해서는 QWidget::setAttribute(Qt::WA_DeleteOnCLose)를 설정하면 되긴하지만 런타임중에 해당 위젯을 삭제하는 것은 위험하다. 
  * 이런경우 deleteLate()를 호출해 두면 다음 이벤트 루프에서 해당 위젯이 삭제된다.
