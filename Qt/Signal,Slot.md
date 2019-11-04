### SIGNAL / SLOT

* 시그널/슬롯을 이용하기 위해서는 두가지 요소를 만족 시켜줘야 한다.

첫번째는 **QObject를 상속** 받아야 하며, 두번째는 상속 받은 클래스에 **Q_OBJECT 매크로를 명시** 하고 있어야 한다.

connect를 사용하는 방법은 가장 일반적으로connect(sender, SIGNAL(signal()), receiver, SLOT(slot()) 의 형태로 사용하며,
receiver를 this로 사용하는 경우connect(sender, SIGNAL(signal()), SLOT(slot()) 형식으로 this를 생략하는 것도 가능 하다.
또한 멤버 변수로 할당된 오브젝트를 받아서 시그널을 발생 시키는 경우 오브젝트에 슬롯을 만들어 슬롯 내부에서 시그널을 emit 시키는 것이 아니라,
connect(sender1, SIGNAL(signal1()), sender2, SIGNAL(signal2()) 의 형태로 만들어 signal1이 발생 할 때 signal2를 발생 시키도록 연결하는 것도 가능하다.


### SIGNAL 을 이용한 marquee label

```c
<생성>
    QString pad(25, ' ');
    actual_text_ = "Select the property above and start tracing." + pad;
    t.setGeometry(1400,200,500,50);
    t.show();

    connect(&timer, SIGNAL(timeout()), this, SLOT(timer_timeout())) ;
    timer.start(50);
    
void MainWindow::timer_timeout()
{
    pos_ = ++pos_ % actual_text_.length();
    t.setText(actual_text_.mid(pos_).append(actual_text_.left(pos_)));
}
```
