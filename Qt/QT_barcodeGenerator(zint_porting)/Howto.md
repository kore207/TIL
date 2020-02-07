> 바코드 생성을 위한 Zint 사용

### (Embeddied linux인 경우) Zint 라이브러리 설치

* 설치환경: Ubuntu 14.04 LTS, qt 5.~

* 다음 링크에서 최신 버전을 다운 받는다 . https://sourceforge.net/projects/zint/ 
  * 2020.2.7일 기준 2.7.0 
  * 이때 라이브러리의 버전은 민감할수 있음. 이전 버전은 QT4에 대해 빌드가 되어있어서 QT버전이 맞지 않으면 컴파일 에러가 날수있다.
* 다운 받은 파일을 압축해제 하고 cmake-gui 를 통해 타겟보드의 컴파일러로 크로스 컴파일 한다. 
* make, make install 한뒤 복사뒨 라이브러리 파일을 타겟보드의 lib 폴더에 복사하면 완료 



> 아래 사이트에 zint 사용법을 참고한다.
>
> https://www.ccoderun.ca/programming/2019-08-16_Zint/ 

## Summary

I recently took a look at a few open-source barcode generators for Linux. There is an ancient package named "barcode" but it was archaic and didn't seem to do what I needed.

The one I finally decided to use is called Zint, and it works well, but isn't available in Ubuntu's package manager.

This post will show how to build, install it, and call it from a C/C++ application.

## Installing Zint

On Ubuntu 18.10, Zint isn't available to install with apt-get. So browse to https://sourceforge.net/projects/zint/ to get the latest source tarball. The one I grabbed is zint-2.6.3_final.tar.gz from early June 2019, available at https://sourceforge.net/projects/zint/files/zint/2.6.3/.

Then run the following:

 cd ~/src/ tar zxvf ~/Downloads/zint-2.6.3_final.tar.gz cd zint-2.6.3.src/ cd build cmake -DCMAKE_BUILD_TYPE=Release .. make sudo make install

Depending on what packages you have installed, you may get a warnings about Qt missing. I wasn't looking for the fancy Qt application, I was looking for the .so library, so ignore the warnings.

Running sudo make install will install the following key files:

- /usr/local/lib/libzint.so
- /usr/local/include/zint.h

## Using the Zint C API

Using the libzint.so library from a C/C++ application is very simple. Here is a quick application which will create a out.png file with the requested barcode:

 \#include <zint.h> #include <iostream> int main() { auto zint = ZBarcode_Create(); zint->symbology = BARCODE_UPCA; ZBarcode_Encode(zint, reinterpret_cast<const uint8_t*>("0123456789"), 0); ZBarcode_Print(zint, 0); // this saves the generated barcode to "out.png" ZBarcode_Delete(zint); 	return 0; } 

This will save the barcode to a file named out.png. The barcode should look like this: ![normal barcode image](https://www.ccoderun.ca/programming/2019-08-16_Zint/out1.png)

Note the line with zint->symbology = BARCODE_UPCA. Looking through the [Zint documentation (section 5.7, "Specifying a Symbology")](http://zint.org.uk/Manual.aspx?type=p&page=5), there are more than 140 different barcodes types supported. UPC-A is just a simple common one I was using to test.

To build, you'll need to link again libzint.so. The CMakeLists.txt file I was using with the source file above is the following:

 PROJECT ( ZintTest C CXX ) CMAKE_MINIMUM_REQUIRED ( VERSION 3.1 ) FIND_LIBRARY ( Zint zint ) ADD_EXECUTABLE ( ZintTest ZintTest.cpp ) TARGET_LINK_LIBRARIES ( ZintTest ${Zint} ) 

The barcode can be customized further. Refer to the [the documentation](http://zint.org.uk/Manual.aspx?type=p&page=5) for details. Here is a slightly more elaborate example:

 \#include <zint.h> #include <iostream> #include <cstring> int main() { auto zint = ZBarcode_Create(); 	strcpy(zint->bgcolour, "C0C0FF"); strcpy(zint->fgcolour, "000000"); 	zint->output_options  = BOLD_TEXT; zint->border_width    = 3;  // in pixels zint->height          = 20; // in pixels zint->scale           = 1.0; zint->symbology       = BARCODE_UPCA; ZBarcode_Encode(zint, reinterpret_cast<const uint8_t*>("9876543210"), 0); 	ZBarcode_Print(zint, 0); // this saves the generated barcode to "out.png" 	ZBarcode_Delete(zint); 	return 0; } 

Note the blueish background specified using typical RGB HTML hex colour codes, the explicit height, and the blank border around the outside of the barcode image. The barcode should look like this: ![narrow barcode with blueish background](https://www.ccoderun.ca/programming/2019-08-16_Zint/out2.png)

## Combining Zint and OpenCV

Instead of calling Zbarcode_Print() to have the barcode written out to disk, Zint can also be told to render the barcode in memory as an easy-to-access bitmap. We can then access that bitmap to populate a OpenCV cv::Mat object:

 \#include <zint.h> #include <opencv2/opencv.hpp> int main() { auto zint = ZBarcode_Create(); zint->symbology = BARCODE_UPCA; ZBarcode_Encode(zint, reinterpret_cast<const uint8_t*>("02468"), 0); 	// at this point, instead of calling ZBarcode_Print() to save the file to "out.png", we'll tell Zint to // create a bitmap, then access the bitmap directly to populate a cv::Mat object with the barcode image 	ZBarcode_Buffer(zint, 0); 	// now that the bitmap is created, we know the final size, so create a cv::Mat cv::Mat mat(zint->bitmap_height, zint->bitmap_width, CV_8UC3); // 8-bit unsigned, 3 colour channels 	int bitmap_idx = 0; // index into the Zint barcode bitmap 	for (int y = 0; y < zint->bitmap_height; y ++) { 	for (int x = 0; x < zint->bitmap_width; x ++) 	{ 		uint8_t * ptr = mat.ptr(y, x); 		// remember that OpenCV's Mat is BGR, not RGB, so the indexes here are reversed for red and blue 		ptr[0] = zint->bitmap[bitmap_idx + 2]; // blue 		ptr[1] = zint->bitmap[bitmap_idx + 1]; // green 		ptr[2] = zint->bitmap[bitmap_idx + 0]; // red 		bitmap_idx += 3; 	} } 	// the barcode image has been copied to our OpenCV Mat, so we no longer need the Zint structure ZBarcode_Delete(zint); 	cv::imshow("barcode", mat); cv::waitKey(); 	return 0; } 