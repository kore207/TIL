# Building OpenCV 2.4.x with full hardware optimization for the Pandaboard ES

[Edit](https://github.com/praveen-palanisamy/Pandaboard-ES/wiki/Building-OpenCV-2.4.x-with-full-hardware-optimization-for-the-Pandaboard-ES/_edit)[New Page](https://github.com/praveen-palanisamy/Pandaboard-ES/wiki/_new)

Praveen Palanisamy edited this page on 24 Jun 2015 · [5 revisions](https://github.com/praveen-palanisamy/Pandaboard-ES/wiki/Building-OpenCV-2.4.x-with-full-hardware-optimization-for-the-Pandaboard-ES/_history)

This wiki will walk you through the process of cross compiling the latest (bleeding edge) OpenCV library with SIMD optimization for the dual core ARM cortex-a9 based Pandaboard ES (OMAP 4460).

The host computer is assumed to be running linux (especially Ubuntu).
**Obtain the cross compilation tools for the Pandaboard ES**
Refer to the [Setting-up-a-cross-compiling-environment-to-build-linux-applications-for-embedded-targets](https://github.com/praveenofpersia/Pandboard-ES/wiki/Setting-up-a-cross-compiling-environment-to-build-linux-applications-for-embedded-targets) wiki for more details on how to do this.
OR simply proceed with :
`sudo apt-get install gcc-arm-linux-gnueabihf`

**Requirements for building OpenCV**
The following packages are needed for cross compiling OpenCV on the host computer.

- Git
- Cmake 2.6+
- pkgconfig
- python 2.6

In case you don't have any of these, install these first before proceeding.

- Get opencv source and prepare to build
  `mkdir opencv`
  `cd opencv`
  `git clone https://github.com/Itseez/opencv.git`
  `cd opencv-master`
  `mkdir build`
  `cd build`
- Edit Cmake variables to tell it to use the cross compiler.
  `gedit ../platforms/linux/arm-gnueabi.toolchain.cmake`
  add these lines at appropriate place in the file:

```
set( CMAKE_C_COMPILER gcc-arm-linux-gnueabihf)`
`set( CMAKE_CXX_COMPILER g++-arm-linux-gnueabihf)`
**NOTE:**in case you installed a different tool chain like the codesourcery's toolchain, replace the compiler with your correct compiler prefixes)
Set additional C_FLAGS for utilizing the hardware to the fullest:
`set(CMAKE_C_FLAGS "-mcpu=cortex-a9 -O3 -mfloat-abi=hard -ftree-vectorize -ftree-vectorizer-verbose=9" CACHE STRING "c flags")
```

***Run cmake***
cmake -DUSE_NEON=ON -DWITH_TBB=ON -DBUILD_TBB=ON -DBUILD_EXAMPLES=ON -DCMAKE_TOOLCHAIN_FILE=../platforms/linux/arm-gnueabi.toolchain.cmake ../ |& tee LOG_OF_CMAKE_OUTPUT.txt

** flags need explanation? (To be added on request) **

Look at the LOG_OF_CMAKE_OUTPUT.txt to see what exactly happend.

Run Cmake curses GUI to enable/disable OpenCV related configurations:
You can install Cmake curses GUI by using
`sudo apt-get install ccmake`
Now run Cmake curses GUI
`ccmake .` (Don't forget the dot !)

This will bring up a screen full of options that can be edited. Make sure that the following items are **OFF**. If it is ON, you can toggle it by scrolling to the option and hitting Enter

- BUILD_NEW_PYTHON_SUPPORT
- BUILD_TESTS
- WITH_1394
- WITH_CUDA
- WITH_EIGEN2
- WITH_FFMPEG
- WITH_GSTREAMER
- WITH_GTK
- WITH_JASPER
- WITH_JPEG
- WITH_OPENEXR
- WITH_PNG
- WITH_PVAPI
- WITH_QT
- WITH_QT_OPENGL
- WITH_TBB
- WITH_TIFF
- WITH_UNICAP
- WTH_V4L
- WITH_XINE

Make sure you run `ccmake .` and turn **OFF** these parameters otherwise you may get some build errors.
Now go ahead and run make by entering:
`make |& tee log_of_make.txt`
The log_of_make.txt will be use full for future reference or in case of errors. Since the `ftree-vetorizer-verbose=9` (Value is from 1 to 9. 9 being the most verbose level) flag was used, the output contains detail information about what was vectorized by the compiler (for SIMD) like how many loops were vectorized in a functions etc...

To build OpenCV 2.4.0 with libjpeg-turbo you need:

```
build libjpeg-turbo as static library

configure OpenCV with the following command:

cmake -DWITH_JPEG=ON -DBUILD_JPEG=OFF -DJPEG_INCLUDE_DIR=/path/to/libjepeg-turbo/include/ -DJPEG_LIBRARY=/path/to/libjpeg-turbo/lib/libjpeg.a /path/to/OpenCV  
```

If you followed the [Installing libjpeg turbo on pandaboard with vectorization for SIMD utilizing the neon co processor](https://github.com/praveen-palanisamy/Pandaboard-ES/wiki/Installing-libjpeg-turbo-on-pandaboard-with-vectorization-for-SIMD-utilizing-the-neon-co-processor) wiki to install libjepg-turbo, you can install openCV with libjepg-turbo by using the following cmake command from the build directory: cmake -D CMAKE_BUILD_TYPE=RELEASE -D CMAKE_INSTALL_PREFIX=/usr/local -D BUILD_EXAMPLES=ON -DWITH_JPEG=ON -DBUILD_JPEG=OFF -DJPEG_INCLUDE_DIR=/opt/libjpeg-turbo/include/ -DJPEG_LIBRARY=/opt/libjpeg-turbo/lib/libjpeg.a -DUSE_NEON=ON -DWITH_TBB=ON ../ |& tee log_of_cmake.txt

======================================================================== Visit [http://praveenpalanisamy.com](http://praveenpalanisamy.com/) for related projects and wikis on Robotics and Computer Vision.

<https://github.com/praveen-palanisamy/Pandaboard-ES/wiki/Building-OpenCV-2.4.x-with-full-hardware-optimization-for-the-Pandaboard-ES> 참조



---

\0. opencv cross compile 방법

https://github.com/praveen-palanisamy/Pandboard-ES/wiki/Building-OpenCV-2.4.x-with-full-hardware-optimization-for-the-Pandaboard-ES

\1. NEON 옵션

\- 주의해야할 점이 타겟보드가 ARM 계열이라면 제대로된 실시간 성능이 나오려면 NEON 옵션을 반드시 활성화를 해줘야 합니다.

\2. OPENCV와 QT4에 대하여

http://answers.opencv.org/question/70750/does-opencv3-support-qt4/

\- cmake -DWITH_QT=4 XXX 요렇게 하시면 됩니다.

\3. floating-point 연산

\- softfp인지 hardfp인지 알아보시고 적절하게 넣어주면 됩니다.

[출처] [크로스컴파일 관련하여 문의드립니다. (OpenCV KOREA 대한민국 최고의 컴퓨터비젼 커뮤니티)](https://cafe.naver.com/opencv/49640) |작성자 [서울박종덕](https://cafe.naver.com/opencv.cafe?iframe_url=/CafeMemberNetworkView.nhn%3Fm=view%26memberid=pjd86)