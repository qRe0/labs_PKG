#include "widget.h"

#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    Widget w;
    w.show();
    w.setWindowTitle("Lab2 by qRe <3");
    w.resize(700, 500);
    return a.exec();
}
