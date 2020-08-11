setenv SIM_WORKING_FOLDER .
set newDesign 0
if {![file exists "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/M1_Test/M1_Test.adf"]} { 
	design create M1_Test "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab"
  set newDesign 1
}
design open "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/M1_Test"
cd "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab"
designverincludedir -clear
designverlibrarysim -PL -clear
designverlibrarysim -L -clear
designverlibrarysim -PL pmi_work
designverlibrarysim ovi_xp2
designverdefinemacro -clear
if {$newDesign == 0} { 
  removefile -Y -D *
}
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr12.vhd"
vlib "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/M1_Test/work"
set worklib work
adel -all
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr12.vhd"
entity CNT12
vsim  +access +r CNT12   -PL pmi_work -L ovi_xp2
add wave *
run 1000ns
