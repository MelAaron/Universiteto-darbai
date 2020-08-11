SetActiveLib -work
comp -include "C:\Users\PC\Documents\1. KTU\1. KTU\2 Semestras\2. SLP\3lab\impl1\schem1.vhd" 
comp -include "$dsn\src\TestBench\schem1_TB.vhd" 
asim +access +r TESTBENCH_FOR_schem1 
wave 
wave -noreg A0
wave -noreg A1
wave -noreg Reset
wave -noreg C
wave -noreg x0
wave -noreg Q0
wave -noreg Q1
wave -noreg Q2
wave -noreg Q3
wave -noreg Q4
wave -noreg x1
wave -noreg x2
wave -noreg x3
wave -noreg x4
wave -noreg DL
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\schem1_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_schem1 
