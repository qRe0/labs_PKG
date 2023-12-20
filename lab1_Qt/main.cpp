
#include "colors.h"

#include <QApplication>


int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    Colors w;
    w.setWindowTitle("Lab1 by qRe <3");
//    w.setFixedSize(800,600);
    w.show();
    return a.exec();
}
