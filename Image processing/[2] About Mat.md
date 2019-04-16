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



