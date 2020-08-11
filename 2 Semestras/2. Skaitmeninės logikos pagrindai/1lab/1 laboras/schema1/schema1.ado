setenv SIM_WORKING_FOLDER .
set newDesign 0
if {![file exists "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras/schema1/schema1.adf"]} { 
	design create schema1 "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras"
  set newDesign 1
}
design open "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras/schema1"
cd "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras"
designverincludedir -clear
designverlibrarysim -PL -clear
designverlibrarysim -L -clear
designverlibrarysim -PL pmi_work
designverlibrarysim ovi_xp2
designverdefinemacro -clear
if {$newDesign == 0} { 
  removefile -Y -D *
}
addfile "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras/impl1/Lab1.vhd"
addfile "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras/impl1/schema2.vhd"
addfile "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras/impl1/schema3.vhd"
vlib "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras/schema1/work"
set worklib work
adel -all
vcom -dbg -work work "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras/impl1/Lab1.vhd"
vcom -dbg -work work "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras/impl1/schema2.vhd"
vcom -dbg -work work "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/New folder/1 laboras/impl1/schema3.vhd"
entity LAB1
vsim  +access +r LAB1   -PL pmi_work -L ovi_xp2
add wave *
run 1000ns
