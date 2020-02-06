#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QDebug>



struct zint_symbol *my_symbol;

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}
int symbology=1;
void MainWindow::createEncode()
{
    QString content="";
    my_symbol = ZBarcode_Create();
    my_symbol->border_width=10;
    my_symbol->symbology=symbology;
     my_symbol->scale=5.0;
    if(my_symbol != NULL)
    {qDebug() << "2" ;
        content = ui->textBarcode->toPlainText();
        unsigned char * sequence=NULL;
        sequence=(unsigned char*)qstrdup(content.toLatin1().constData());
qDebug() << "3" ;
//        strcpy(my_symbol->outfile,(char*)qstrdup(content.toLatin1().constData()));

        ZBarcode_Encode_and_Print(my_symbol,sequence,0,0);
        qDebug() << "4" ;
    }
    qDebug() << "5" ;
    ZBarcode_Delete(my_symbol);
qDebug() << "6" ;
    showImageEncode();
    qDebug() << "7" ;
}

void MainWindow::showImageEncode()
{
qDebug() << "1" ;
    QString path = QDir::currentPath()+"/out.png";
qDebug() << "2" <<path;
    IplImage *src = cvLoadImage((const char*)path.toLatin1().data(),CV_LOAD_IMAGE_COLOR);
qDebug() << "3" ;
     QImage img_show = QImage((const unsigned char*)(src->imageData),src->width,src->height,QImage::Format_RGB888).rgbSwapped();
     qDebug() << "4" ;
     ui->showlabel_2->setPixmap(QPixmap::fromImage(img_show,Qt::AutoColor).scaledToWidth(185));
}

void MainWindow::on_pushButton_clicked()
{
    qDebug() << "OK" ;
//    createEncode() ;
//    auto zint = ZBarcode_Create() ;
//    zint->symbology = BARCODE_UPCA ;
//    ZBarcode_Encode(zint, reinterpret_cast<const uint8_t*>("0123456789"), 0);
//    ZBarcode_Print(zint, 0); // this saves the generated barcode to "out.png"
//    ZBarcode_Delete(zint);
    auto zint = ZBarcode_Create();
        zint->symbology = BARCODE_UPCA;
        ZBarcode_Encode(zint, reinterpret_cast<const uint8_t*>("02468"), 0);

        // at this point, instead of calling ZBarcode_Print() to save the file to "out.png", we'll tell Zint to
        // create a bitmap, then access the bitmap directly to populate a cv::Mat object with the barcode image

        ZBarcode_Buffer(zint, 0);

        // now that the bitmap is created, we know the final size, so create a cv::Mat
        cv::Mat mat(zint->bitmap_height, zint->bitmap_width, CV_8UC3); // 8-bit unsigned, 3 colour channels

        int bitmap_idx = 0; // index into the Zint barcode bitmap

        for (int y = 0; y < zint->bitmap_height; y ++)
        {
            for (int x = 0; x < zint->bitmap_width; x ++)
            {
                uint8_t * ptr = mat.ptr(y, x);
                // remember that OpenCV's Mat is BGR, not RGB, so the indexes here are reversed for red and blue
                ptr[0] = zint->bitmap[bitmap_idx + 2]; // blue
                ptr[1] = zint->bitmap[bitmap_idx + 1]; // green
                ptr[2] = zint->bitmap[bitmap_idx + 0]; // red
                bitmap_idx += 3;
            }
        }

        // the barcode image has been copied to our OpenCV Mat, so we no longer need the Zint structure
        ZBarcode_Delete(zint);

        cv::imshow("barcode", mat);
        cv::waitKey();

}
