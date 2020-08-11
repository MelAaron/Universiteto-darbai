setenv SIM_WORKING_FOLDER .
set newDesign 0
if {![file exists "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/2lab/schem1test/schem1test.adf"]} { 
	design create schem1test "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/2lab"
  set newDesign 1
}
design open "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/2lab/schem1test"
cd "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/2lab"
designverincludedir -clear
designverlibrarysim -PL -clear
designverlibrarysim -L -clear
designverlibrarysim -PL pmi_work
designverlibrarysim ovi_xp2
designverdefinemacro -clear
if {$newDesign == 0} { 
  removefile -Y -D *
}
addfile "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/2lab/lab2impl/schem1.vhd"
vlib "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/2lab/schem1test/work"
set worklib work
adel -all
vcom -dbg -work work "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/2lab/lab2impl/schem1.vhd"
entity SCHEM1
vsim  +access +r SCHEM1   -PL pmi_work -L ovi_xp2
add wave *
run 1000ns
