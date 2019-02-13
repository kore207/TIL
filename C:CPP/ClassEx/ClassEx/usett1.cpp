//
//  usett1.cpp
//  ClassEx
//
//  Created by Kim GT  on 13/02/2019.
//  Copyright © 2019 Kim GT . All rights reserved.
//

#include <stdio.h>
#include <iostream>
#include "tabtenn1.hpp"

using namespace std;

int main()
{
    TableTennisPlayer player2("Tara", "Boomdea", false);
    RatedPlayer rplayer1(1140, "Mallory",  "Duck", true);
    rplayer1.Name();
    if(rplayer1.HasTable())
        cout << ": 탁구대가 있다."<<endl;
    else
        cout << ":탁구대가 없다."<<endl;
    cout <<"이름: ";
    player2.Name();
    cout <<"; 랭킹: "<< rplayer1.Rating()<<endl;
    
    //TabeTennisPlayer 객체를 사용하여 RatedPlayer를 초기화 한다
    RatedPlayer rplayer2(1212, player2);
    cout << "이름: ";
    rplayer2.Name();
    cout <<"; 랭킹: " << rplayer2.Rating() <<endl;
    
    return 0;
 }
