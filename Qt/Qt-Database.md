### Qt-Sqlite 데이터베이스다루기



> 가장 먼저 .pro 파일에서  CONFIG += sql 을 해줘야 한다.

MainWindow.h에서 다음과 같이 씁니다.

```cpp
#include <QMainWindow>
#include <QSql>
#include <QDebug>

namespace Ui 
{
    class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:

private:
    Ui::MainWindow *ui;
    QSqlDatabase db;
};
```

이제 MainWindow.cpp에서 :

```cpp
#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    db = QSqlDatabase::addDatabase("QSQLITE" , "CONNECTION NAME");
    db.setDatabaseName(":memory:");
    if(!db.open())
    {
        qDebug() << "Can't create in-memory Database!";
    }
    else
    {
        qDebug() << "In-memory Successfully created!";
        QSqlQuery query; // QSqlQuery *query = new QSqlQuery(db) ;안되는경우 ..
        
        if (!query.exec("CREATE TABLE employees (ID INTEGER, name TEXT, phone TEXT, address TEXT)"))
        {
            qDebug() << "Can't create table!";
            return;
        }
        if (!query.exec("INSERT INTO employees (ID, name, phone, address) VALUES (201, 'Bob', '5555-5555', 'Antarctica')"))
        {
            qDebug() << "Can't insert record!";
            return;
        }

        qDebug() << "Database filling completed!";
        if(!query.exec("SELECT name , phone , address FROM employees WHERE ID = 201"))
        {
            qDebug() << "Can't Execute Query !";
            return;
        }
        qDebug() << "Query Executed Successfully !";
        while(query.next())
        {
            qDebug() << "Employee Name : " << query.value(0).toString();
            qDebug() << "Employee Phone Number : " << query.value(1).toString();
            qDebug() << "Employee Address : " << query.value(1).toString();
        }
    }
}

MainWindow::~MainWindow()
{
    delete ui;
}
```