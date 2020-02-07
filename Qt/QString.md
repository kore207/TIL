>  ## QString

```

문자열 초기화 및 정의
QString makersweb("makersweb.net");
QString str1 = "This is QString";
QString str2{"foobar"};
```

 

문자열의 길이, 사이즈, 카운트

```
QString str("macaron");

int length = str.length();
// length == 7

int size = str.size();
// size == 7

int count = str.count();
// count == 7
```

 

문자열 뒤에 이어 붙이기, 앞에 붙이기

```
// auto keyword from C++11
auto url = QString("makersweb");
url.append(".net");
// url == "makersweb.net"

url.prepend("https://");
// url == "https://makersweb.net"
```

 

null 과 empty 체크

```
QString address;

bool ret = address.isEmpty();
// ret == true
ret = address.isNull();
// ret == true

address = "";

ret = address.isEmpty();
// ret == true
ret = address.isNull();
// ret == false
```

 

split 특정문자를 기준으로 문자열 분리(자르기, 나누기)

```
QString address = "192.168.0.1";

QStringList list = address.split(".");
// list == ("192", "168", "0", "1")
```

 

문자열 치환

```
QString year    = "2025";
QString month   = "11";
QString day     = "20";

auto date = QString("%1. %2. %3").arg(year).arg(month).arg(day);
// date == "2025. 11. 20"

date = "%3. %2. %1";
auto newformat = date.arg(year, month, day);
// newformat == "20. 11. 2025"
```

 

지정된 인덱스 위치에있는 문자 반환

```
QString str("no smoking");

QChar c = str.at(3);
// c == 's'
```

 

문자열의 마지막 또는 앞의 문자 반환

```
QString str("dessert");

QChar c = str.back();
// c == 't'

c = str.front();
// c == 'd'
```

 

문자열의 끝에서 입력 수 만큼 제거

```
QString filename("file.txt");

filename.chop(3);
// str == "file."
```

 

문자열의 끝에서 입력 수 만큼 뺀 앞의 문자열을 반환

```
QString filename("config.ini");

auto name = filename.chopped(4);
// name == "config"
```

 

문자열의 왼쪽 또는 오른쪽 끝에서 입력 수 만큼의 문자열을 반환

```
QString str = "FREE WIFI";

QString left = str.left(4);
// left == "FREE"

QString right = str.right(4);
// right == "WIFI";
```

 

문자열의 내용을 지우고 null로 만듦.

```
QString text("text");

text.clear();
// text.isNull() == true
// text == ""
```

 

숫자를 문자열로, 문자를 숫자로 변환

```
auto str = QString::number(123);
// str == "123"

int num = str.toInt();
// num == 123
```

 

문자열에 특정 문자열 포함 여부(검색)

```
QString str = "Don't stop.";

bool ret = str.contains("don't", Qt::CaseInsensitive); // 대소문자 구분 없이
// ret == true
```

 

문자열에서 특정 문자열의 시작 위치(인덱스)

```
QString str = "Don't stop.";

int index = str.indexOf("stop", Qt::CaseInsensitive);
// index == 6

index = str.indexOf("go", Qt::CaseInsensitive);
// index == -1
```

 

C++ 표준 문자열로, 표준 문자열을 QString으로 변환

```
QString str("standard");

std::string stdstring = str.toStdString();

QString qstring = QString::fromStdString(stdstring);
```

 

특정 문자로 채움

```
QString str;

str.resize(10);
str.fill('*');
// str == "**********"

str.fill('@', 5); // string is resized(리사이징됨)
// str == "@@@@@"
```

 

특정 위치에 문자열 끼워넣기

```
QString str = "https://makersweb.net";

str.insert(8, QString("www."));
// str == "https://www.makersweb.net"
```

 

지정 위치부터 입력 수 만큼 삭제

```
QString str = "https://www.makersweb.net";

str.remove(8, 4);
// str == "https://makersweb.net"
```

 

문자열이 대문자 또는 소문자로 이뤄져 있는지 여부 반환. 문자열을 대, 소문자로 변환.

```
QString str("Foobar");

str.isUpper();
// false
str.isLower();
// false

auto upper = str.toUpper();
auto lower = str.toLower();

upper.isUpper();
// true
lower.isLower();
// true
```

 

특정 위치부터 지정 길이만큼 다른 문자열로 바꾸기

인덱스 위치에서 시작하는 n 개의 문자를 이후의 문자열로 대체하고이 문자열에 대한 참조를 반환.

```
QString str("you can't do it.");
QString can("can");

str.replace(4, 5, can);
// str == "you can do it."
```

 

문자열의 한 섹션(특정 부분)을 반환.

필드는 왼쪽에서부터 0, 1, 2 등으로 번호가 매겨지며, 오른쪽에서 왼쪽으로는 -1, -2 등으로 번호가 매겨짐.

```
QString path = "/home/user/workspace/file.txt";

QString fileName = path.section("/", -1);
// fileName == "file.txt"

QString location = path.section("/", 0, -2);
// location == "/home/user/workspace"
```

 