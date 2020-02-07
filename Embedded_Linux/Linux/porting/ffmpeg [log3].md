1. libz

```bash
lmk@lmk-virtual-machine:/home/newdisk$ sudo tar -zvxf zlib-1.2.8.tar.gz
lmk@lmk-virtual-machine:/home/newdisk$ cd zlib-1.2.8
lmk@lmk-virtual-machine:/home/newdisk/zlib-1.2.8$ sudo ./configure --prefix=/root/newdisk/optnew/opencv-rely -shared
lmk@lmk-virtual-machine:/home/newdisk/zlib-1.2.8$ sudo vi Makefile
```



```bash
#Makefile
CC=/root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc
LDSHARED= /root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc -shared -Wl,-soname,libz.so.1,--version-script,zlib.map
AR=/root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-ar
RANLIB=/root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-ranlib
```

2. libjpe

   ```bash
   lmk@lmk-virtual-machine:/home/newdisk$ sudo tar -zvxf jpegsrc.v9.tar.gz
   lmk@lmk-virtual-machine:/home/newdisk$ cd jpeg-9
   lmk@lmk-virtual-machine:/home/newdisk/jpeg-9$ sudo CC=/root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --host=arm-linux --prefix=/root/newdisk/optnew/opencv-rely --enable-shared --enable-static
   lmk@lmk-virtual-machine:/home/newdisk/jpeg-9$ sudo make
   lmk@lmk-virtual-machine:/home/newdisk/jpeg-9$ sudo make install
   ```

3.libpng

```bash
lmk@lmk-virtual-machine:/home/newdisk$ sudo xz -d libpng-1.6.29.tar.xz
lmk@lmk-virtual-machine:/home/newdisk$ sudo tar -xvf libpng-1.6.29.tar
lmk@lmk-virtual-machine:/home/newdisk$ cd libpng-1.6.29
lmk@lmk-virtual-machine:/home/newdisk/libpng-1.6.29$ sudo CC=/root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --host=arm-linux --prefix=/root/newdisk/optnew/opencv-rely --enable-shared --enable-static
#zlib 못찾아서->CC=/root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --host=arm-linux --prefix=/root/newdisk/optnew/opencv-rely --enable-shared --enable-static LDFLAGS=-L/root/newdisk/optnew/opencv-rely/lib CPPFLAGS=-I/root/newdisk/optnew/opencv-rely/include

lmk@lmk-virtual-machine:/home/newdisk/libpng-1.6.29$ sudo make
lmk@lmk-virtual-machine:/home/newdisk/libpng-1.6.29$ sudo make install
```



4.yasm

```
lmk@lmk-virtual-machine:/home/newdisk$ sudo tar -zvxf yasm-1.3.0.tar.gz
lmk@lmk-virtual-machine:/home/newdisk$ cd yasm-1.3.0
lmk@lmk-virtual-machine:/home/newdisk/yasm-1.3.0$ sudo CC=/root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --prefix=/root/newdisk/optnew/opencv-rely --host=arm-linux
lmk@lmk-virtual-machine:/home/newdisk/yasm-1.3.0$ sudo make
lmk@lmk-virtual-machine:/home/newdisk/yasm-1.3.0$ sudo make install
```



5. libx264

```
lmk@lmk-virtual-machine:/home/newdisk$ sudo tar -jxvf last_x264.tar.bz2
lmk@lmk-virtual-machine:/home/newdisk$ cd x264-snapshot-20170612-2245 
lmk@lmk-virtual-machine:/home/newdisk/x264-snapshot-20170612-2245$ sudo CC=/root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --enable-shared --host=arm-linux --disable-asm --prefix=/root/newdisk/optnew/opencv-rely
lmk@lmk-virtual-machine:/home/newdisk/x264-snapshot-20170612-2245$ sudo make
lmk@lmk-virtual-machine:/home/newdisk/x264-snapshot-20170612-2245$ sudo make install
```



6.libxvid

```
lmk@lmk-virtual-machine:/home/newdisk$ cd xvidcore-1.3.3
lmk@lmk-virtual-machine:/home/newdisk/xvidcore-1.3.3$ cd build/generic
lmk@lmk-virtual-machine:/home/newdisk/xvidcore-1.3.3/build/generic$ sudo CC=/root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --prefix=/root/newdisk/optnew/opencv-rely --host=arm-linux  --disable-assembly
lmk@lmk-virtual-machine:/home/newdisk/xvidcore-1.3.3/build/generic$ sudo make
lmk@lmk-virtual-machine:/home/newdisk/xvidcore-1.3.3/build/generic$ sudo make install
```

7.ffmpeg

```
lmk@lmk-virtual-machine:/home/newdisk$ sudo tar -jvxf ffmpeg-3.3.2.tar.bz2
lmk@lmk-virtual-machine:/home/newdisk$ cd ffmpeg-3.3.2
lmk@lmk-virtual-machine:/home/newdisk/ffmpeg-3.3.2$
sudo ./configure --prefix=/root/newdisk/optnew/opencv-rely --enable-shared --disable-static --enable-gpl --enable-cross-compile  --arch=arm --disable-stripping --target-os=linux --enable-libx264 --enable-libxvid --cc=/root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc --enable-swscale --extra-ldflags=-L/root/newdisk/optnew/opencv-rely/lib --extra-cflags=-I/root/newdisk/optnew/opencv-rely/include
lmk@lmk-virtual-machine:/home/newdisk/ffmpeg-3.3.2$ sudo make
lmk@lmk-virtual-machine:/home/newdisk/ffmpeg-3.3.2$ sudo make install
```



8.opencv crosscompile

```
lmk@lmk-virtual-machine:/home/newdisk$ sudo unzip opencv-3.1.0.zip
lmk@lmk-virtual-machine:/home/newdisk$ cd opencv-3.1.0
lmk@lmk-virtual-machine:/home/newdisk/opencv-3.1.0$ sudo mkdir BuildOpencv
lmk@lmk-virtual-machine:/home/newdisk/opencv-3.1.0$ cd BuildOpencv
lmk@lmk-virtual-machine:/home/newdisk/opencv-3.1.0/BuildOpencv$ sudo vim toolchain.cmake
#toolchain.cmake
###########user defined#############
set( CMAKE_SYSTEM_NAME Linux )
set( CMAKE_SYSTEM_PROCESSOR arm )
set( CMAKE_C_COMPILER /root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc )
set( CMAKE_CXX_COMPILER /root/newdisk/optnew/opt/gcc-linaro-4.9/bin/arm-linux-gnueabihf-g++ )
LINK_DIRECTORIES( /root/newdisk/optnew/opencv-rely/lib )
INCLUDE_DIRECTORIES( /root/newdisk/optnew/opencv-rely/include )
###########user defined#############
set( CMAKE_FIND_ROOT_PATH /root/newdisk/optnew/opencv-rely)
set( CMAKE_FIND_ROOT_PATH_MODE_PROGRAM NEVER )
set( CMAKE_FIND_ROOT_PATH_MODE_LIBRARY ONLY)
set( CMAKE_FIND_ROOT_PATH_MODE_INCLUDE ONLY)
######################################
```



export PKG_CONFIG_PATH=/usr/local/lib/pkgconfig