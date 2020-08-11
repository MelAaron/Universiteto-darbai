#!/bin/sh
a=$HOME;
echo $HOME;
cd $HOME;
ls;
HOME="/home";
echo $HOME;
cd $HOME;
ls;
HOME=$a;
echo $HOME;