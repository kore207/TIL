### OpenCV : Open Source Computer Vision Library

* Image Processing
  * Hough TF (원형) , Cell Segmentation , Edge Detection, Deburring, Histogram equalization
* Robot/Machine/Video/Vision
  * Face Detection, Cup pose estimation, Obstacle avoidance, Inspection, Tracking(Multi Pedestrian), Feature Detection 
* Artificial intelligence
  * Deep learning, Image understanding, Emotion Detection, Handwriting Recognition
* 3D geometry
  * Stereo Camera, SLAM & 3D reconstruction, 3D reconstruction, Camera Calibration
* Etc..
  * Nvidia CUDA, OpenCL, TBB, Bundle Adjstment, 3D visualizer ...

---

### Mat

* Matrix class (행렬)

  * Image, values, ... Think of all the data ina Matrix

    ``` cpp
    Mat mtx(3,3, CV_32F) ; //make a 3*3 floating-point matrix
    Mat cmtx(10,1,CV_64FC2) ; //make a 10*1 2-channel floating-point 
    Mat img(Size(5,3), CV_8UC3) ;//make a 3-channel (color) image U=>unsigned char 
    //(row,col) , size(with  height)
    
    //Create a point
    Mat * mtx3 = new Mat(3,3,CV32F) ;
    delete mtx 3 ;
    
    //value set and print
    mtx.setTo(10) ;
    cout << mtx <<endl ;
    ```

* Mat use -> + - * / inv

  ```
  Mat m = Mat::zeros(3,3, CV_64F) ; // 0으로 초기화 ones 1로 초기화
  m *= 3 ; ---
  
  double dm[3][3] = { {1,2,1,} , {0,1,1}, {1,0,0} } ;
  Mat m2 = Mat (3,3, CV_64F, dm) ;
  
  cout << m.*m2 << endl //행렬곱
  cout << m.mul(m2) << endl // mul->행렬곱이 아닌 각각 요소끼리 곱
  cout << m2.inv() << endl //역행렬
  cout << m2.t() << endl //전치행렬
  ```

### Mat use

``` cpp
int main(){
    Mat img = imread("ss.jpg") ; //road img
    Sobel(img,img,img.depth(),1,0) ;//sobel edge effect
    flip(img, img2, 1) ; //flip        
    namedWindow("img", 0) ; //window
    imshow("img", img) ; //show

    waitKey(10) ;

    destroyAllWindow() ;
    return 0 ;
    }
```

---

Approach Pixel

1. At approach : 안정적, 느림
2. Ptr approach : 비교적 빠르고 안정적, data보단 느림 사용하기 까다로움
3. Data approach : 빠름, 오류에대한 검증이 안됨
4. Iterator
5. vector

