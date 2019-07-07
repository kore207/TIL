### GUI event

* 함수가 끝나면 repaint()  혹은 update()  처럼 gui 가 없데이트 된다

  이때 꼭 함수가 끝나고 처리되지 않게 하련면 qApp->processEvents(); 해주면 된다.

