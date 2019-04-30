### Drawing

* Line: void line(input, Point pt1, Point pt2, const Scalar& color, int thickness=1, int lineType=LINE_8, intshift=0)
  * Scalar(B,G,R)
* Circle: void circle(intput, Point center, int radius, const Scalar& color, int thickness=1, intlineType=LINE_8, int shift=0)
  * shift = -1 이면 내부가 채워진다.
* rectangle: void rectangle(intput Point pt1, Point pt2, const Scalar& color, int thickness =1 , int lineType = LINE_8, int shift = 0)
* ellipse : void ellipse(img, Point center, Size axes, double angle, double startangle, double endangle, const Scalar& color, int thickness=1, int linetype=LINE_8, int shift = 0) 혹은 RotatedRect 사용 
* polyline :void polylines(Mat& img, const Point* const* pts, const int* npts,int ncontours, bool is closed, const Scalar& color, int thickness =1, int lineType+LINE_8, int shift = 0)





