``` c
 //1.중점으로부터 최외각 상하좌우 찾기
    int tx=1280, ty=1024, bx=0,by=0, rx=0, ry=0, lx=0, ly=0  ;
    for(int x=640; x<1280; x++)
    {
        int idx = 512 * 1280 + x ;

        if(target[idx] == 0)
            break ;

        for(int y = 512; y > 0; y--)
        {
            idx = y * 1280 +x ;

            if(target[idx]  == 0)
            {
                if(ty > y)
                {
                    tx = x ;
                    ty = y ;

                    target[idx] = 180 ;
                }
                break ;
            }

        }
    }
