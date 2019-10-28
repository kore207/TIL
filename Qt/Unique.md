### Unique



> eventFilter(Qobject* object, QEvent* event) 함수의 사용

* 각 Widget의 Event를 처리하기 위해서 subcalss를 이용해서 class를 만들어 사용하는 것 보다 evectFilter(Qobject* object, QEvent * event) 함수를 이용하는 것이 개발 속도에 도움이 된다.

```c 
//ex) QLineEdit Widget을 사용할떄 key Event를 확인하고 싶은 경우
QLineEdit * ed = new QlineEdit(this) ;
ed->installEventFilter(this) ;

bool Dialog::eventFilter(Qobject, QEvent* event)
{
    if(object == ed)
    {
        QEvent::Type type == event->type() ;
        if(event->type() ==QEvent::KeyPress){
            QKeyEvent *KeyEvent = static_cast<QKeyEvent*>(event) ;
            if(keyEvent->ket() == Qt::Key_Enter){
                filseSaveClick() ;
                return true ;
            }
        }
    }
    return QDialog::eventFilter(object, event) ;
}
```

* return을 할떄  false 를 하면 Dialog 에서 기존과 같이 처리가 된다. 따라서 내가 원하는 방식을 처리하고 기존 방식을 처리하지 않게 하기 ㅜ이해서는 true를 리턴해야한다. 

* QTableWidget은 object를 가지고 하면 안된다. 위제 내부에 있는 viewport()에 installEventFilter(this)를 해야 원하는 이벤트를 처리할 수 있다. 

  -> QTableWidget *tw = new QtableWidget(this) ;

  tw->viewport()->intallEventFilter(this) ;

* MouseMove Event를 처리하기 위해서는 widget에서 setMouseTracking(true)를 설정 해줘야 한다.

* 참조 :  https://mydevnote.tistory.com/216 
* 참조2:  https://www.qtcentre.org/threads/50090-QApplication-handle-all-event-why-does-not-include-QKeyEvent 