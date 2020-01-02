## Ubuntu OpenCV porting

> 환경.  (19.04.15)
>
> Ubuntu 14.04 LTS
>
> QT -5.6.3(Embedded). Qt-5.10.0(ubuntu), qt creator 4.5.0
>
> Arm-linux-gnueabihf-gcc version 4.9 
>
> Target board -ti am437x cortex 9
>
> Sudo 는 생략 한다.



" 최종적으로 빌드 및 실행 까지 성공 했지만 porting 이란게 타겟 보드에 알맞게 설정 해야하기 때문에 혹시나 이 기록을 참고하시는 분이 있다면 에러 및 추가 변수는 구글링과 삽질을 통해 해결해야함 "



1. 편의를 위해 cmake-gui 설치 (version 2.8.12.2)

    ~~~ 
    root@ubuntu:~# apt-get install cmake-qt-gui
    ~~~

2. Jpeg 라이브러리 다운 (jpeg 사용 안하면 상관 없음)

    ~~~
    root@ubuntu:~# wget http://www.ijg.org/files/jpegsrc.v6b.tar.gz
    root@ubuntu:~# tar xvfz jpegsrc.v6b.tar.gz
    root@ubuntu:~# cd jpegsrc.v6b
    root@ubuntu:~/jpeg-6b# CC=arm-linux-gnueabihf-gcc ./configure --host=arm-linux --build=i7 --prefix=/usr
    //cc=크로스 컴파일러에 알맞게 적는다
    //prefix= 역시 적절하게 선택
    root@ubuntu:~/jpeg-6b# make
    root@ubuntu:~/jpeg-6b# cp *.h /usr/include
    root@ubuntu:~/jpeg-6b# cp libjpeg.a /usr/lib
    // 이부분 역시 라이브러리 위치에 알맞게 적절하게 선택 하면 된다.
    ~~~

    

3. firefox - opencv git 에서 2.4.12.zip 다운 (save File)

    * 이때 자신의 우분투 및 qt 버전에 혹은 cmake 버전에 호환되는 opencv를 잘 찾아서 적용 시켜야 한다.

    ~~~
    root@ubuntu:~# mkdir opencv //여기에 압축 해제
    root@ubuntu:~# cd opencv 
    root@ubuntu:~# mkdir opencv-2.4.12-build
    root@ubuntu:~# cmake-gui
    ~~~

4. cmake gui 창

    1. Browse source => 압축푼 opencv directory

    2. Browse build => opencv-2.4.12-build

    3. configure =>(unix make file)specific options for cross-compiling

        * operating system =Linux
        * version 3.12.10
        * Processor Arm
        * C / C++ 알맞게 선택 
            * 예시 C  (/root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc)
        * Target root 컴파일러 최상위 (/root/gcc-linaro-4.9)
        * finish

    4. configuring done 이 되면서 변경사항과 혹시 에러가 뜬 부분이 생김 

    5. 여기서부턴 각자 타겟 보드에 맞게 알아서 설정 잘해야하는 부분이 있음 

        내 목적에 맞게 예시 (groupd , advanced 체크박스 체크해서 알아서 확인)

        * BUILD에서 체크한 부분 

            BUILD_SHARED_LIBS , BUILD_WITH_DEBUG_INFO

        * WITH 

            WITH_FFMPEG , WITH_PNG, WITH_QT

        * configure 누르면 qt 위치 설정

        * 이부분은 https//corehunter.tistory.com/34 를 참고

        * generate 한뒤 build 에 가서 make(-j 옵션 알아서)->make install 

        * /usr/local/include 에 opencv, opencv2가 생겨야함 

        

        6. Qt 설정

            * 생성한 프로젝트의 .pro 에 

            * ``` 
                INCLUDEPATH += "/usr/local/include/"
                LIBS += `pkg-config —libs opencv` 
                ```

                * 이떄 터미널에서 pkg-config —libs opencv 쳤을때 라이브러리들이 나와야 정상

            * 하고 runqmake

            * 참고로 NORMAR 이 소스상에 define 돼있으면 opencv와 겹치기 떄문에 바꿔줘야함

        7. 타겟보드설정

        8. 타겟보드에 opencv build 안의 라이브러리들을 보드 라이브러리 위치에 다 때려박는다

            * Opencv/opencv-2.4.12-build/lib 를 타겟보드 /root/lib 에 복사

            

