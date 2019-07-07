ffmpeg [log]



> ffmpeg를 컴파일 하기위한 의존성 있는 라이브러리들 다운 (아래 과정 모두 SUDO)

~~~ bash
#apt-get update

#apt-get -y install autoconf automake build-essential libass-dev libfreetype6-dev libgpac-dev libsdl1.2-dev libtheora-dev libtool libva-dev libvdpau-dev libvorbis-dev libx11-dev libxext-dev libxfixes-dev pkg-config texi2html zlib1g-dev
~~~



> ffmpeg_sources 폴더 생성

~~~ bash
$mkdir ~ffmpeg_sources
~~~





> Yasm 설치

~~~ bash
$> cd ~/ffmpeg_sources
$> wget http://www.tortall.net/projects/yasm/releases/yasm-1.2.0.tar.gz
$> tar xzvf yasm-1.2.0.tar.gz
$> cd yasm-1.2.0
$> ./configure --prefix="$HOME/ffmpeg_build" --bindir="$HOME/bin"
$> make
$> make install
$> make distclean
~~~



* ffmpeg 빌드시 Yasm을 사용하는데 Yasm 실행 명령어를 찾지 못하는 경우엔 /usr/bin 폴더로 yasm 결과 파일을 직접 복사했다. (sudo cp ../bin/yasm /usr/bin) 
* nasm도 마찬가지로 해볼것

> Nasm 설치

```bash
$ cd ~/ffmpeg_sources
$ wget http://www.nasm.us/pub/nasm/releasebuilds/2.13.01/nasm-2.13.01.tar.xz
$ tar -xvf nasm-2.13.01.tar.xz
$ cd nasm-2.13.01
$ ./configure
$ make
$ sudo make install
```



### 각종 코덱 설치 

> libx264 설치

~~~ bash
$> cd ~/ffmpeg_sources
$> wget http://download.videolan.org/pub/x264/snapshots/last_x264.tar.bz2
$> tar xjvf last_x264.tar.bz2
$> cd x264-sanpshot*
$> PATH="$PATH:$HOME/bin" ./configure --prefix="$HOME/ffmpeg_build" --bindir="$HOME/bin" --enable-static
$> make
$> make install
$> make distclean
~~~



> libfdk-aac 설치

~~~ bash
$> cd ~/ffmpeg_sources
$> wget -O fdk-aac.zip https://github.com/mstorsjo/fdk-aac/zipball/master
$> unzip fdk-aac.zip
$> cd mstorsjo-fdk-aac*
$> autoreconf -fiv
$> ./configure --prefix="$HOME/ffmpeg_build" --disable-shared
$> make
$> make install
$> make distclean
~~~



>libmp3lame 설치

~~~ bash
$> sudo apt-get install libmp3lame-dev
~~~



> libopus 설치

~~~ bash
$> cd ~/ffmpeg_sources
$> wget http://downloads.xiph.org/releases/opus/opus-1.1.tar.gz
$> tar xzvf opus-1.1.tar.gz
$> cd opus-1.1
$> ./configure --prefix="$HOME/ffmpeg_build" --disable-shared
$> make
$> make install
$> make distclean
~~~



> libvpx 설치

~~~ bash
$> cd ~/ffmpeg_sources
$> wget http://webm.googlecode.com/files/libvpx-v1.3.0.tar.bz2
# 안되면
# wget https://src.fedoraproject.org/lookaside/pkgs/libvpx/libvpx-v1.3.0.tar.bz2/14783a148872f2d08629ff7c694eb31f/libvpx-v1.3.0.tar.bz2

$> tar xjvf libvpx-v1.3.0.tar.bz2
$> cd libvpx-v1.3.0
$> ./configure --prefix="$HOME/ffmpeg_build" --disable-examples
$> make
$> make install
$> make clean
~~~



> ffmpeg 설치

~~~bash
$> cd ~/ffmpeg_sources

$> wget http://ffmpeg.org/releases/ffmpeg-snapshot.tar.bz2
#버전 문제로 안되면 http://www.ffmpeg.org/releases/ffmpeg-2.2.16.tar.bz2 이전버전해보기
#http://www.ffmpeg.org/releases/ffmpeg-2.6.7.tar.gz
$> tar xjvf ffmpeg-snapshot.tar.bz2

$> cd ffmpeg

$> PATH="$PATH:$HOME/bin" PKG_CONFIG_PATH="$HOME/ffmpeg_build/lib/pkgconfig" ./configure --prefix="$HOME/ffmpeg_build" --extra-cflags="-I$HOME/ffmpeg_build/include" --extra-ldflags="-L$HOME/ffmpeg_build/lib" --bindir="$HOME/bin" --extra-libs="-ldl" --enable-gpl --enable-libass --enable-libfdk-aac --enable-libfreetype --enable-libmp3lame --enable-libopus --enable-libtheora --enable-libvorbis --enable-libvpx --enable-libx264 --enable-nonfree --enable-x11grab

$> make

$> make install

$> make distclean

$> hash -r
~~~



* 이떄 에러가 나서 --enable-x11grab , --enable-libmp3lame 등 지워줌

  * PATH="$PATH:$HOME/bin" PKG_CONFIG_PATH="$HOME/ffmpeg_build/lib/pkgconfig" ./configure --prefix="$HOME/ffmpeg_build" --extra-cflags="-I$HOME/ffmpeg_build/include" --extra-ldflags="-L$HOME/ffmpeg_build/lib" --bindir="$HOME/bin" --extra-libs="-ldl" --enable-gpl --enable-libass --enable-libfdk-aac --enable-libfreetype --enable-libtheora --enable-libvorbis --enable-libx264 --enable-nonfree

* ERROR: opus not found using pkg-config 는 패키 직접 등록

  * 설치한 package의 pkg-config 정보가 인식이 안될때 

    ~~~ bash
    $ pkg-config --list-all # pkg-config 가 제대로 설정 파일을 인식했는지 확인
    #pkg-config의 모든 위치
    $ locate pkgconfig
    #pkg-config 를 등록하려면
    $export PKG_CONFIG_PATH=/home/me/usr/libxml/lib/pkgconfig #등록하려는 경로 
    #제대로 설정되었는지 확인하려면
    $echo $PKG_CONFIG_PATH
    ~~~

    

> extra avcodec 설치

~~~ bash
$> sudo apt-get install libavcodec-extra-53 # 안됨
~~~

> 환경변수 설정 

~~~bash
$> echo "MANPATH_MAP $HOME/bin $HOME/ffmpeg_build/share/man" >> ~/.manpath
$> . ~/.profile
~~~



-> opencv 설치시 cmake-gui 하고 ffmpeg_include_dir 을 설치 경로( ffmpeg_build/include) 설정해줌

->make 에서 애러남 

sol1 . -2.4.11 -> 2.4.13.2 ( 2016/10 **이후** OpenCV 릴리즈 사용 ) 하라고 함

sol2 . 

```cpp
복사하여 다음의 상단에 붙여 넣으십시오.
opencv-3.3.0/modules/videoio/src/cap_ffmpeg_impl.hpp

#define AV_CODEC_FLAG_GLOBAL_HEADER (1 << 22)
#define CODEC_FLAG_GLOBAL_HEADER AV_CODEC_FLAG_GLOBAL_HEADER
#define AVFMT_RAWPICTURE 0x0020
```





OPENCV 과정

1. opencv 에서 ffmpeg가 컴파일 될수 있도록 make 한다 .
2. 타겟보드에서도 ffmpeg가 사용될수있도록 크로스컴파일하여 보드에 설치한다.

---

```
# goto http://sourceforge.net/projects/opencvlibrary/files/opencv-unix/
# download the latest stable opencv such as 2.4.6.1 (http://sourceforge.net/projects/opencvlibrary/files/opencv-unix/2.4.5/opencv-2.4.5.1.tar.gz/download) to current directory (such as home or ~/Document)
# cd /opt
# tar -xvf <path-to-download-folder>/OpenCV-2.4.6.1.tar.gz
# cd OpenCV-2.4.6.1
# create a foler under current dir (following previous step, this should be <opencv-dir>), called prepare
# cd prepare
# Copy the following script to gedit and save as install.sh to current dir, this should be <opencv-dir>/prepare
# Check corresponding url used in the script for latest versions of the package and replace as required
# Open terminal and navigate to location used above
# sudo chmod +x install.sh
# ./install
```

```
echo "Removing any pre-installed ffmpeg, x264, and other dependencies (not all the previously installed dependecies)"
sudo apt-get remove ffmpeg x264 libx264-dev libvpx-dev librtmp0 librtmp-dev libopencv-dev
sudo apt-get update

arch=$(uname -m)
if [ "$arch" == "i686" -o "$arch" == "i386" -o "$arch" == "i486" -o "$arch" == "i586" ]; then
flag=0
else
flag=1
fi

echo "Installing Dependenices"
sudo apt-get install autoconf automake make g++ curl cmake bzip2 python unzip \
  build-essential checkinstall git git-core libass-dev libgpac-dev \
  libsdl1.2-dev libtheora-dev libtool libva-dev libvdpau-dev libvorbis-dev libx11-dev \
  libxext-dev libxfixes-dev pkg-config texi2html zlib1g-dev

echo "downloading yasm (assembler used by x264 and FFmpeg)"
# use git or tarball (not both)
wget http://www.tortall.net/projects/yasm/releases/yasm-1.2.0.tar.gz
tar xzvf yasm-1.2.0.tar.gz
cd yasm-1.2.0

echo "installing yasm"
./configure
make
sudo make install
cd ..

echo 'READ NOTE BELOW which was extracted from http://wiki.serviio.org/doku.php?id=build_ffmpeg_linux'
echo 'New version of x264 contains by default support of OpenCL. If not installed or without sense (example Ubuntu 12.04LTS on VMWare) add to configure additional option --disable-opencl. Without this option ffmpeg could not be configured (ERROR: libx264 not found).'

echo "downloading x264 (H.264 video encoder)"
# use git or tarball (not both)
# git clone http://repo.or.cz/r/x264.git or
git clone git://git.videolan.org/x264.git
cd x264
# wget ftp://ftp.videolan.org/pub/videolan/x264/snapshots/x264-snapshot-20130801-2245-stable.tar.bz2
# tar -xvjf x264-snapshot-20130801-2245-stable.tar.bz2
# cd x264-snapshot-20130801-2245-stable/

echo "Installing x264"
if [ $flag -eq 0 ]; then
./configure --enable-static --disable-opencl
else
./configure --enable-shared --enable-pic --disable-opencl
fi
make
sudo make install
cd ..

echo "downloading fdk-aac (AAC audio encoder)"
# use git or tarball (not both)
git clone --depth 1 git://github.com/mstorsjo/fdk-aac.git
cd fdk-aac

echo "installing fdk-aac"
autoreconf -fiv
./configure --disable-shared
make
sudo make install
cd ..

echo "installing libmp3lame-dev (MP3 audio encoder.)"
sudo apt-get install libmp3lame-dev

echo "downloading libopus (Opus audio decoder and encoder.)"
wget http://downloads.xiph.org/releases/opus/opus-1.0.3.tar.gz
tar xzvf opus-1.0.3.tar.gz
cd opus-1.0.3

echo "installing libopus"
./configure --disable-shared
make
sudo make install
cd ..

echo "downloading libvpx VP8/VP9 video encoder and decoder)"
# use git or tarball (not both)
git clone --depth 1 http://git.chromium.org/webm/libvpx.git
cd libvpx
# wget http://webm.googlecode.com/files/libvpx-v1.1.0.tar.bz2 (this seems not to be update, but can still be used if the fedoraproject link below is not available))
# wget http://pkgs.fedoraproject.org/repo/pkgs/libvpx/libvpx-v1.2.0.tar.bz2/400d7c940c5f9d394893d42ae5f463e6/libvpx-v1.2.0.tar.bz2
# tar xvjf libvpx-v1.2.0.tar.bz2
# cd libvpx-v1.2.0

echo "installing libvpx"
./configure --disable-examples
make
sudo make install
cd ..

sudo ldconfig

echo "downloading ffmpeg"
# git clone http://repo.or.cz/r/ffmpeg.git
git clone git://source.ffmpeg.org/ffmpeg.git
cd ffmpeg/
# wget http://ffmpeg.org/releases/ffmpeg-2.0.tar.bz2
# tar -xvjf ffmpeg-2.0.tar.bz2
# cd ffmpeg-2.0/

echo "installing ffmpeg" 
if [ $flag -eq 0 ]; then
./configure --enable-gpl --enable-libass --enable-libfdk-aac --enable-libopus --enable-libfaac --enable-libmp3lame --enable-libopencore-amrnb --enable-libopencore-amrwb --enable-libtheora --enable-libvorbis --enable-libx264 --enable-libxvid --enable-nonfree --enable-postproc --enable-version3 --enable-x11grab --enable-libvpx
else
./configure --enable-gpl --enable-libass --enable-libfdk-aac --enable-libopus --enable-libfaac --enable-libmp3lame --enable-libopencore-amrnb --enable-libopencore-amrwb --enable-libtheora --enable-libvorbis --enable-libx264 --enable-libxvid --enable-nonfree --enable-postproc --enable-version3 --enable-x11grab --enable-libvpx --enable-shared
fi

make
sudo make install
hash -r

cd .. # move up one level to prepare folder
cd .. # move up one level to opencv folder

echo "Checking to see if you're using your new ffmpeg"
ffmpeg 2>&1 | head -n1

sudo ldconfig
```



---

gcc 버전 낮추기

```bash
$sudo update-alternatives --install /usr/bin/gcc gcc /usr/bin/gcc-5 10
$sudo update-alternatives --install /usr/bin/gcc gcc /usr/bin/gcc-4.9 20
$sudo update-alternatives --install /usr/bin/g++ g++ /usr/bin/g++-5 10
$sudo update-alternatives --install /usr/bin/g++ g++ /usr/bin/g++-4.9 20

$sudo update-alternatives --config gcc
```







https://tipok.org.ua/downloads/media/aac+/libaacplus/libaacplus-2.0.2.tar.gz

```
./autogen.sh --with-parameter-expansion-string-replace-capable-shell=/bin/bash --host=arm-linux-gnueabihf --enable-shared --disable-static --prefix=/root/ARM_build/
```

```
./configure --host=arm-unknown-linux-gnueabihf --enable-shared --disable-static --cross-prefix=${CCPREFIX} --prefix=/root/ARM_build --extra-cflags='-march=armv6' --extra-ldflags='-march=armv6'
```



```
./configure --enable-cross-compile --cross-prefix=${CCPREFIX} --enable-shared --disable-static --arch=armel --target-os=linux --prefix=/opt/arm/ffmpeg 
```





/root/gcc-linaro-4.9/bin/../lib/gcc/arm-linux-gnueabihf/4.9.3/../../../../arm-linux-gnueabihf/bin/ld: warning: libavcodec.so.57, needed by ../../lib/libopencv_highgui.so.2.4.12, not found (try using -rpath or -rpath-link)



/root/gcc-linaro-4.9/bin/../lib/gcc/arm-linux-gnueabihf/4.9.3/../../../../arm-linux-gnueabihf/bin/ld: warning: libavformat.so.57, needed by ../../lib/libopencv_highgui.so.2.4.12, not found (try using -rpath or -rpath-link)
/root/gcc-linaro-4.9/bin/../lib/gcc/arm-linux-gnueabihf/4.9.3/../../../../arm-linux-gnueabihf/bin/ld: warning: libavutil.so.55, needed by ../../lib/libopencv_highgui.so.2.4.12, not found (try using -rpath or -rpath-link)
/root/gcc-linaro-4.9/bin/../lib/gcc/arm-linux-gnueabihf/4.9.3/../../../../arm-linux-gnueabihf/bin/ld: warning: libswscale.so.4, needed by ../../lib/libopencv_highgui.so.2.4.12, not found (try using -rpath or -rpath-link)



opencv -build 에서 위 의 오류 나서 링크 걸어주는거 해봐야함 



```py
  /usr/bin/ld: warning: libinference_engine.so, needed by /opt/intel/computer_vision_sdk_2018.2.319/opencv/lib/libopencv_dnn.so.3.4.2, not found (try using -rpath or -rpath-link)
```

```py
LD_LIBRARY_PATH=$LD_LIBRARY_PATH:/opt/intel/computer_vision_sdk_2018.2.319/deployment_tools/inference_engine/lib/ubuntu_16.04/intel64 your_application_here
```