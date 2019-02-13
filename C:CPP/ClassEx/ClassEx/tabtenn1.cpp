//
//  tabtenn1.cpp
//  ClassEx
//
//  Created by Kim GT  on 13/02/2019.
//  Copyright © 2019 Kim GT . All rights reserved.
//

#include "tabtenn1.hpp"
#include <iostream>

TableTennisPlayer::TableTennisPlayer(const string &fn,
                                     const string &ln, bool ht) : firstname(fn),
                                    lastname(ln),hasTable(ht){}

void TableTennisPlayer::Name() const
{
    cout <<lastname <<", "<<firstname;
}

//RatedPlayer 메서드
RatedPlayer::RatedPlayer(unsigned int r, const string &fn,
                         const string & ln, bool ht) :TableTennisPlayer(fn, ln, ht)
{
    rating = r;
}

RatedPlayer::RatedPlayer(unsigned int r, const TableTennisPlayer &tp):TableTennisPlayer(tp), rating(r)
{
    
}
