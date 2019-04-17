## About Mat

```
Mat img = imread("img",0) ; //gray 채널을 1로 만든다는 의미도 있다.
nameWindow("imgWindow",1) //0: 원본 1: 창크기에 따라 resizing 가능
bitwise_not(img,img) ; //이미지 반전

//clone
Mat img2 = img.clone() ;

Rect r(img.cols / 4 , img.ros/4,img.cols/4*2, img.rows/4*2) ;
Mat img5 = img(r).clone() ;

img.copyto(img2) ; //r 영역만 복사
```

* 1Pixel 보통 1byte(8bit) 0(black)~255(white)
* 100*200 픽셀의 그림은 1차원 배열로 나열 되고 (x,y) 는 data[y * width + x] 로 나타낼 수 있다.
* color 일때는 3가지 데이터가 들어간다 Scalar ->R G B  (데이터는 B,G,R 순)
  * data[y * (width * 3) + (x * 3) + 0] -> B
  * data[y * (width * 3) + (x * 3) + 1] -> G  
  * data[y * (width * 3) + (x * 3) + 2] -> R
* 색상 반전

``` c
//Using Data
for(int i=0; i<img.rows ; i++){
    for(int j=0; j<img.cols; j++){
        usigned char r, g, b ;
        b= img.data[i * img.step +j * img.eleSize() + 0] ; //eleSize() 1pixel의 실제 사이즈
        g= img.data[i * img.step +j * img.eleSize() + 1] ;
        r= img.data[i * img.step +j * img.eleSize() + 2] ;
        
        img.data[i * img.step + j * img.eleSize() + 0] = unsigned char(255 -b) ;
        img.data[i * img.step + j * img.eleSize() + 0] = unsigned char(255 -g) ;
        img.data[i * img.step + j * img.eleSize() + 0] = unsigned char(255 -r) ;
    }
}

//Using At
for(int i=0; i<img.rows ; i++){
    for(int j=0; j<img.cols; j++){
       //Vec3b means 'uchar 3ch'
        unsigned char b = img.at< cv:: Vec3b >(i,j)[0] ;
        unsigned char g = img.at< cv:: Vec3b >(i,j)[1] ;
        unsigned char r = img.at< cv:: Vec3b >(i,j)[2] ;
        
        img.at<cv::Vec3b>(i,j)[0] = unsigned char(255 - b) ;
        img.at<cv::Vec3b>(i,j)[1] = unsigned char(255 - g) ;
        img.at<cv::Vec3b>(i,j)[2] = unsigned char(255 - r) ;
    }
}

//Using ptr
for(int i=0; i<img.rows ; i++){
    cv::Vec3b* ptr = img.ptr< cv::Vec3b >(i) ;
    for(int j=0; j<img.cols; j++){
       //1
        unsigned char b1 = (ptr[j][0]) ; //뒤는 채널임
        unsigned char g1 = (ptr[j][1]) ;
        unsigned char r1 = (ptr[j][2]) ;
        //2 좀더 깔끔
        cv::Vec3b bgr = ptr[j] ;
        unsigned char b2 = (bgr[0]) ;
        unsigned char g2 = (bgr[0]) ;
        unsigned char r2 = (bgr[0]) ;
        
        ptr[j] = cv:: Vec3b(255-b1, 255-g1, 255-r1) ;
    }
}

//using iteration
cv:: MatIterator_<cv::Vec3b> itd = img.begin< cv::Vec3b>(), itd_end = img.end<cv::Vec3b>() ;

for(int i=0; itd !=itd.end; ++itd, ++i){ //i를 쓰진 않지만 몇번짼지 카운트할때 사용
    cv::Vec3b bar =(*itd) ;
    (*itd)[0] = 255 - bar[0] ;
    (*itd)[1] = 255 - bar[1] ;
    (*itd)[2] = 255 - bar[2] ;
}
    
```

* emg.elemSize() : 한 픽셀 크기
* img.channels() : 채널 수
* img.rows() : 열의 수
* img.step() : 행의 바이트 수