setenv SIM_WORKING_FOLDER .
set newDesign 0
if {![file exists "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/3lab/test1/test1.adf"]} { 
	design create test1 "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/3lab"
  set newDesign 1
}
design open "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/3lab/test1"
cd "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/3lab"
designverincludedir -clear
designverlibrarysim -PL -clear
designverlibrarysim -L -clear
designverlibrarysim -PL pmi_work
designverlibrarysim ovi_xp2
designverdefinemacro -clear
if {$newDesign == 0} { 
  removefile -Y -D *
}
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/3lab/impl1/schem1.vhd"
vlib "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/3lab/test1/work"
set worklib work
adel -all
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/3lab/impl1/schem1.vhd"
entity SCHEM1
vsim  +access +r SCHEM1   -PL pmi_work -L ovi_xp2
add wave *
run 1000ns
