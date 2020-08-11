SetActiveLib -work
comp -include "C:\Users\User\Documents\1. KTU\2 Semestras\2. SLP\1 laboras\impl1\Lab1.vhd" 
comp -include "$dsn\src\TestBench\lab1_TB.vhd" 
asim +access +r TESTBENCH_FOR_lab1 
wave 
wave -noreg a
wave -noreg b
wave -noreg c
wave -noreg d
wave -noreg e
wave -noreg f
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\lab1_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_lab1 
