setenv SIM_WORKING_FOLDER .
set newDesign 0
if {![file exists "C:/Users/arnsve2/Downloads/1 laboras/Laboras1Test/Laboras1Test/Laboras1Test.adf"]} { 
	design create Laboras1Test "C:/Users/arnsve2/Downloads/1 laboras/Laboras1Test"
  set newDesign 1
}
design open "C:/Users/arnsve2/Downloads/1 laboras/Laboras1Test/Laboras1Test"
cd "C:/Users/arnsve2/Downloads/1 laboras/Laboras1Test"
designverincludedir -clear
designverlibrarysim -PL -clear
designverlibrarysim -L -clear
designverlibrarysim -PL pmi_work
designverlibrarysim ovi_xp2
designverdefinemacro -clear
if {$newDesign == 0} { 
  removefile -Y -D *
}
addfile "C:/Users/arnsve2/Downloads/1 laboras/impl1/Lab1.vhd"
vlib "C:/Users/arnsve2/Downloads/1 laboras/Laboras1Test/Laboras1Test/work"
set worklib work
adel -all
vcom -dbg -work work "C:/Users/arnsve2/Downloads/1 laboras/impl1/Lab1.vhd"
entity LAB1
vsim  +access +r LAB1   -PL pmi_work -L ovi_xp2
add wave *
run 1000ns
