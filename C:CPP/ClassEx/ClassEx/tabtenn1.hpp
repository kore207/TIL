//
//  tabtenn1.hpp
//  ClassEx
//
//  Created by Kim GT  on 13/02/2019.
//  Copyright © 2019 Kim GT . All rights reserved.
//

#ifndef tabtenn1_hpp
#define tabtenn1_hpp

#include <stdio.h>
#include <string>

using namespace std;

class TableTennisPlayer
{
private:
    string firstname;
    string lastname;
    bool hasTable;
    
public:
    TableTennisPlayer(const string &fn = "none",
                      const string &ln = "none", bool ht = false );
    void Name() const;
    bool HasTable() const
    {
        return hasTable;
    }
    
    void ResetTable(bool v)
    {
        hasTable = v;
    }
    
};

//간단한 파생 클래스
class RatedPlayer : public TableTennisPlayer
{
private:
    unsigned int rating;
public:
    RatedPlayer(unsigned int r = 0, const string &fn="none",
                const string &ln = "none", bool ht = false);
    RatedPlayer(unsigned int r, const TableTennisPlayer &tp);
    unsigned int Rating()
    {
        return rating;
    }
    void ResetRating(unsigned int r)
    {
        rating = r;
    }
};
#endif /* tabtenn1_hpp */
