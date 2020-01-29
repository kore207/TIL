> QT에서 XML을 사용하기 위해 헤더파일과 .Pro파일에 xml을 추가해야 한다.
>
> ```c	
> #include <QtXml> 
> ```
>
> ```c
> QT 			+= xml
> ```



#### XML 문서 작성

* XML 작성 소스

```c 
QString File_Path = "C://Users/test.xml";
QStringList text;
text.append("WINDOW");
text.append("LINUX");
text.append("UNIX");
QDomDocument doc;
QDomElement xml = doc.createElement("script"); //요소 설정
doc.appendChild(xml);

foreach( QString txt , text) {
    QDomElement child_element = doc.createElement("os"); //자식노드 속성 설정
    child_element.setAttribute("Name",txt);
    xml.appendChild(child_element);
}
SaveXmlFile(&doc,File_Path);

-
void MainWindow::SaveXmlFile(QDomDocument *doc, QString path)
{
    QFile file(path);
    if (file.open(QIODevice::WriteOnly | QIODevice::Text))
    {
        QTextStream stream(&file);
        stream << doc->toString();
        file.close();
        doc->clear();
    }
}

```



* XML 문서 읽기

```c
void MainWindow::LoadXmlFile(QDomDocument *doc, QString path)
{
    QFile load_xml_file(path);
    if (load_xml_file.open(QIODevice::ReadOnly | QIODevice::Text))
    {
        // Save the xml file content
        doc->setContent(&load_xml_file);
        load_xml_file.close();
    }
}

```





[참조 블로그]( https://jdh5202.tistory.com/306?category=713732 )