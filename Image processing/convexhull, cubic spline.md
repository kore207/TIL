Convex : 꺾이는 점 or 최외곽의 점을 추출

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

