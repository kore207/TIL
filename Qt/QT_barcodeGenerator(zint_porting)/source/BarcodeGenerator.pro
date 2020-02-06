#-------------------------------------------------
#
# Project created by QtCreator 2020-02-06T13:42:13
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = BarcodeGenerator
TEMPLATE = app

# The following define makes your compiler emit warnings if you use
# any feature of Qt which has been marked as deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if you use deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0


SOURCES += \
        main.cpp \
        mainwindow.cpp

HEADERS += \
        mainwindow.h

FORMS += \
        mainwindow.ui

target.path = /root
INSTALLS += target

INCLUDEPATH += "/usr/local/include/"
INCLUDEPATH += "/usr/include/"
INCLUDEPATH += "/usr/local/lib/"
LIBS += `pkg-config --libs opencv`
#LIBS += `pkg-config --libs zbar`
LIBS += /usr/local/lib/*.so



