#!/bin/sh
a=$PATH;
echo $PATH;
who | grep arnsve2;
PATH="/data/ld/ld2/4/grep"
echo "pakeista";
echo $PATH;
who | grep arnsve2;
PATH=$a;
echo "atkeista";
who | grep arnsve2;