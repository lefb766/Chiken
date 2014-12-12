#! /bin/sh

delete_first_line()
{
    sed -n '2,$p' $1
}

for source in foo.hpp foo.cpp main.cpp; do
     delete_first_line $source
done

