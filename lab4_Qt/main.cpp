#include "mainwindow.h"

#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.setWindowTitle("Lab4 by qRe <3");
    w.setFixedSize(800, 600);
    w.show();
    return a.exec();
}
