SetActiveLib -work
comp -include "C:\Users\User\Documents\1. KTU\2 Semestras\2. SLP\2lab\lab2impl\schem1.vhd" 
comp -include "$dsn\src\TestBench\schem1_TB.vhd" 
asim +access +r TESTBENCH_FOR_schem1 
wave 
wave -noreg a
wave -noreg b
wave -noreg c
wave -noreg d
wave -noreg S
wave -noreg R
wave -noreg Q
wave -noreg Reset
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\schem1_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_schem1 
