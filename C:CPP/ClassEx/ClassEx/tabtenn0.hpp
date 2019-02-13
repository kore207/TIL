//
//  tabtenn0.hpp
//  ClassEx
//
//  Created by Kim GT  on 11/02/2019.
//  Copyright © 2019 Kim GT . All rights reserved.
//

#ifndef tabtenn0_hpp
#define tabtenn0_hpp


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
                      const string &ln = "non", bool ht = false);
    void Name() const;//선수이름
    bool HasTable() const{ //탁구대를 소유했는지의 여부
        return hasTable;
    };
    void ResetTable(bool v){
        hasTable = v;
    };
};

#endif /* tabtenn0_hpp */
