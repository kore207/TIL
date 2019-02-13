//
//  main.cpp
//  ClassEx
//
//  Created by Kim GT  on 11/02/2019.
//  Copyright © 2019 Kim GT . All rights reserved.
//

#include <iostream>
#include "tabtenn0.hpp"

using namespace std;

int main(int argc, const char * argv[]) {
    // insert code here...
    TableTennisPlayer player1("Chuck", "Blizzard", true);
    TableTennisPlayer player2("Tara", "Boomdea", false);
    player1.Name();
    if(player1.HasTable())
        cout << ":탁구대가 있다.\n";
    else
        cout << ":탁구대가 없다.\n";
    
    player2.Name();
    if(player1.HasTable())
        cout << ":탁구대가 있다.\n";
    else
        cout << ":탁구대가 없다.\n";
    return 0;
}
