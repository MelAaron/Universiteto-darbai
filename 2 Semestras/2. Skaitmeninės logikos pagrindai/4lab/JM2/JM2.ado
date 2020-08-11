setenv SIM_WORKING_FOLDER .
set newDesign 0
if {![file exists "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/JM2/JM2.adf"]} { 
	design create JM2 "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab"
  set newDesign 1
}
design open "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/JM2"
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
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/JM1.vhd"
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr50.vhd"
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr31.vhd"
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr12.vhd"
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/LM2.vhd"
vlib "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/JM2/work"
set worklib work
adel -all
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/JM1.vhd"
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr50.vhd"
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr31.vhd"
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr12.vhd"
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/LM2.vhd"
entity TOP_CNT
vsim  +access +r TOP_CNT   -PL pmi_work -L ovi_xp2
add wave *
run 1000ns
