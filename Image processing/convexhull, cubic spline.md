Convex : 꺾이는 점 or 최외곽의 점을 추출
* convex에서 뜬금없는 점 ex (0,0)같은게 있으면 전부 흐트러지게된다 
```c
int MakeConvex(PointF *conPoint, PointF *srcPoint)
{
    for(int i = 0; i < MAX_STEP ; i++)
    {
        orgPointA[i].X = srcPoint[i].X ;
        orgPointA[i].Y = srcPoint[i].Y ;
    }
    FirstPoint(orgPointA);
    PointAngle(orgPointA);
    PointSort(1, MAX_STEP - 1);
    PointSearch(orgPointA);

    conPoint[0].X = orgPointA[0].X ; // PointF(orgPointA[0].X, orgPointA[0].Y) ;
    conPoint[0].Y = orgPointA[0].Y ;

    int conCount = ConvexPoint.count() ; // .Count();
    for(int i=0 ; i<conCount ; i++)
    {
        PointA Peek = ConvexPoint.top();
        conPoint[i+1].X = Peek.X ;
        conPoint[i+1].Y = Peek.Y ;
        ConvexPoint.pop();
    }
    return conCount+1;
}
```



spline : 점들을 3차항으로 부드럽게 연결 함



``` c
void CubicSpline(int iEa, float *x, float *y, int oEa, float *xs, float *ys)
{
    float firstDx = NAN, firstDy = NAN, lastDx = NAN, lastDy = NAN;

    float *dists; //  = new float[n]; // cumulative distance

    float totalDist = 0;

    InputEA = iEa ;
    OutputEA = oEa ;

    // ============== memory allocation.
    xOrig = (float *)malloc(sizeof(float) * InputEA);
    yOrig = (float *)malloc(sizeof(float) * InputEA);
    thisA = (float *)malloc(sizeof(float) * InputEA);
    thisB = (float *)malloc(sizeof(float) * InputEA);

    dists = (float *)malloc(sizeof(float) * InputEA);
    dists[0] = 0;

    for (int i = 1; i < InputEA; i++)
    {
        float dx = x[i] - x[i - 1];
        float dy = y[i] - y[i - 1];
        float dist = sqrt(dx * dx + dy * dy);		//float dist = (float)Math.Sqrt(dx * dx + dy * dy);
        totalDist += dist;
        dists[i] = totalDist;
    }

    // Create 'times' to interpolate to
    float dt = totalDist / (OutputEA - 1);
    float *times;		//float times[OutputEA];
    times = (float *)malloc(sizeof(float) * OutputEA);

    times[0] = 0;
    for (int i=1 ; i<OutputEA; i++)
    {
        times[i] = times[i - 1] + dt;
    }

    //FitAndEval(dists, x, times, firstDx / dt, lastDx / dt);
    Fit(dists, x, firstDx / dt, lastDx / dt); // , debug);
    Eval(xs, times);


    //FitAndEval(dists, y, times, firstDy / dt, lastDy / dt);
    Fit(dists, y, firstDy / dt, lastDy / dt);
    Eval(ys, times);

    free(times) ;
    free(dists) ;
    free(xOrig) ;
    free(yOrig) ;
    free(thisA) ;
    free(thisB) ;
}
```

### Floodfill 
* 내부 채우기 
``` c 
int floodFill(InputOutputArray image, Point seedPoint, Scalar newVal, Rect* rect=0, Scalar loDiff=Scalar(), Scalar upDiff=Scalar(), int flags=4 )
```
Parameters:	
image – Input/output 1- or 3-channel, 8-bit, or floating-point image. It is modified by the function unless the FLOODFILL_MASK_ONLY flag is set in the second variant of the function. See the details below.

mask –Operation mask that should be a single-channel 8-bit image, 2 pixels wider and 2 pixels taller than image. Since this is both an input and output parameter, you must take responsibility of initializing it. Flood-filling cannot go across non-zero pixels in the input mask. For example, an edge detector output can be used as a mask to stop filling at edges. On output, pixels in the mask corresponding to filled pixels in the image are set to 1 or to the a value specified in flags as described below. It is therefore possible to use the same mask in multiple calls to the function to make sure the filled areas do not overlap.

Note Since the mask is larger than the filled image, a pixel  (x, y) in image corresponds to the pixel  (x+1, y+1) in the mask .
seedPoint – Starting point.

newVal – New value of the repainted domain pixels.

loDiff – Maximal lower brightness/color difference between the currently observed pixel and one of its neighbors belonging to the component, or a seed pixel being added to the component.

upDiff – Maximal upper brightness/color difference between the currently observed pixel and one of its neighbors belonging to the component, or a seed pixel being added to the component.
rect – Optional output parameter set by the function to the minimum bounding rectangle of the repainted domain.
flags –Operation flags. The first 8 bits contain a connectivity value. The default value of 4 means that only the four nearest neighbor pixels (those that share an edge) are considered. A connectivity value of 8 means that the eight nearest neighbor pixels (those that share a corner) will be considered. The next 8 bits (8-16) contain a value between 1 and 255 with which to fill the mask (the default value is 1). For example, 4 | ( 255 << 8 ) will consider 4 nearest neighbours and fill the mask with a value of 255. The following additional options occupy higher bits and therefore may be further combined with the connectivity and mask fill values using bit-wise or (|):FLOODFILL_FIXED_RANGE If set, the difference between the current pixel and seed pixel is considered. Otherwise, the difference between neighbor pixels is considered (that is, the range is floating).

FLOODFILL_MASK_ONLY If set, the function does not change the image ( newVal is ignored), and only fills the mask with the value specified in bits 8-16 of flags as described above. This option only make sense in function variants that have the mask parameter.
