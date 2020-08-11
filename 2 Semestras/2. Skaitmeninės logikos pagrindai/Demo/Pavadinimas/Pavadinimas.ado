setenv SIM_WORKING_FOLDER .
set newDesign 0
if {![file exists "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/Demo/Pavadinimas/Pavadinimas.adf"]} { 
	design create Pavadinimas "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/Demo"
  set newDesign 1
}
design open "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/Demo/Pavadinimas"
cd "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/Demo"
designverincludedir -clear
designverlibrarysim -PL -clear
designverlibrarysim -L -clear
designverlibrarysim -PL pmi_work
designverlibrarysim ovi_xp2
designverdefinemacro -clear
if {$newDesign == 0} { 
  removefile -Y -D *
}
addfile "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/Demo/impl1/Failas.vhd"
vlib "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/Demo/Pavadinimas/work"
set worklib work
adel -all
vcom -dbg -work work "C:/Users/User/Documents/1. KTU/2 Semestras/2. SLP/Demo/impl1/Failas.vhd"
entity FAILAS
vsim  +access +r FAILAS   -PL pmi_work -L ovi_xp2
add wave *
run 1000ns
