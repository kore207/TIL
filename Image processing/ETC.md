OpenCV 

Canny는 이미지상에서 윤곽선만 찾아내고

findContours는 윤곽선의 좌표 추출
--- 
    Mat src ;
    src= imread("/root/test5.png") ;
    blur(src, src, Size(3,3)) ;

    Mat canny_output;
    vector<vector<Point> > contours;
    vector<Vec4i> hierarchy;
    Canny( src, canny_output, 30, 100, 3 );
    findContours( canny_output, contours, hierarchy, CV_RETR_TREE, CV_CHAIN_APPROX_SIMPLE, Point(0, 0) );
    Mat drawing = Mat::zeros( canny_output.size(), CV_8UC3 );
//    RNG rng(12345) ;
//    double arc = arcLength( contours, false);

    for( int i = 0; i< contours.size(); i++ )
    {
//      Scalar color = Scalar( 0, 0, 255 );
        if(arcLength( contours[i],0) <900 || arcLength( contours[i],0) > 1500)
            continue ;

//        Scalar color = Scalar(rng.uniform(0,255), rng.uniform(0,255), rng.uniform(0,255) ) ;
        Scalar color[] = {Scalar(0, 0, 255),Scalar(0, 255,0) };
        drawContours( drawing, contours, i, color[i], 2, 8, hierarchy, 0, Point() );
        qDebug() << contours[i].size() ;
        for(unsigned int j=0;j<contours[i].size();j++)        
            qDebug()<< contours[i].at(j).x << contours[i].at(j).y<<endl;         
    }


--- 
프로그램에서 영상 데이터를 unsigned char* 형의 버퍼로 가지고 이용하는 경우가 종종 있다.
이 데이터 형을 IplImage 형으로 변환하려면 아래와 같은 방법으로 변환 가능하다.
unsigned char *buffer= ...;
IplImage *img = cvCreateImage(cvSize(w,h),8,channels);
cvSetData( img , buffer , w*channels);

Mat 형식으로 변환하기 위해서는 
Mat temp = Mat( H, W, CV_8UC1 );
temp.data = buffer;
와 같은 형태로 변환 가능
출처: https://jangjy.tistory.com/143 [살다보니..]

windowresize("name",height, weight) opencv window 창 크기 
