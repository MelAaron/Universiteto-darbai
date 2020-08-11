setenv SIM_WORKING_FOLDER .
set newDesign 0
if {![file exists "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/VHDLtest/VHDLtest.adf"]} { 
	design create VHDLtest "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab"
  set newDesign 1
}
design open "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/VHDLtest"
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
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr167.vhd"
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr23.vhd"
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/top_cntr.vhd"
addfile "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/schem1.vhd"
vlib "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/VHDLtest/work"
set worklib work
adel -all
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr167.vhd"
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/cntr23.vhd"
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/top_cntr.vhd"
vcom -dbg -work work "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab/schem1.vhd"
entity TOP_CNT
vsim  +access +r TOP_CNT   -PL pmi_work -L ovi_xp2
add wave *
run 1000ns
