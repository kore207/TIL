```
./configure --prefix=/root/newdisk/optnew/opencv-rely -shared
```





```
#Makefile
CC=/root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc
LDSHARED=/root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc -shared -Wl,-soname,libz.so.1,--version-script,zlib.map
AR=/root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-ar


RANLIB=arm-linux-gnueabihf-ranlib
```



```
CC=/root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --host=arm-linux --prefix=/root/newdisk/optnew/opencv-rely --enable-shared --enable-static
```





```
CC=/root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --host=arm-linux --prefix=/root/newdisk/optnew/opencv-rely --enable-shared --enable-static
```



export LDFLAGS="-L /apps/lib"
export CPPFLAGS="-I /apps/include"





```
CC=/root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --prefix=/root/newdisk/optnew/opencv-rely --host=arm-linux
```



```
CC=/root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --enable-shared --host=arm-linux --disable-asm --prefix=/root/newdisk/optnew/opencv-rely
```



```
CC=/root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc ./configure --prefix=/root/newdisk/optnew/opencv-rely --host=arm-linux  --disable-assembly
```



```
./configure --prefix=/root/newdisk/optnew/opencv-rely --enable-shared --disable-static --enable-gpl --enable-cross-compile  --arch=arm --disable-stripping --target-os=linux --enable-libx264 --enable-libxvid --cc=/root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc --enable-swscale --extra-ldflags=-L/root/newdisk/optnew/opencv-rely/lib --extra-cflags=-I/root/newdisk/optnew/opencv-rely/include
```



```
#toolchain.cmake
###########user defined#############
set( CMAKE_SYSTEM_NAME Linux )
set( CMAKE_SYSTEM_PROCESSOR arm )
set( CMAKE_C_COMPILER /root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-gcc )
set( /root/gcc-linaro-4.9/bin/arm-linux-gnueabihf-g++ )
###########user defined#############
set( CMAKE_FIND_ROOT_PATH /root/newdisk/optnew/opencv-rely)
set( CMAKE_FIND_ROOT_PATH_MODE_PROGRAM NEVER )
set( CMAKE_FIND_ROOT_PATH_MODE_LIBRARY ONLY)
set( CMAKE_FIND_ROOT_PATH_MODE_INCLUDE ONLY)
######################################
INCLUDE_DIRECTORIES( /root/newdisk/optnew/opencv-rely/include )
LINK_DIRECTORIES( /root/newdisk/optnew/opencv-rely/lib )
```



```
//Flags used by the linker.
CMAKE_EXE_LINKER_FLAGS:STRING=-lpthread -lrt
```