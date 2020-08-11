SetActiveLib -work
comp -include "C:\Users\PC\Documents\1. KTU\1. KTU\2 Semestras\2. SLP\3lab\impl1\scehm2.vhd" 
comp -include "$dsn\src\TestBench\scehm2_TB.vhd" 
asim +access +r TESTBENCH_FOR_scehm2 
wave 
wave -noreg A0
wave -noreg A1
wave -noreg Reset
wave -noreg C
wave -noreg Q0
wave -noreg Q1
wave -noreg Q2
wave -noreg Q3
wave -noreg Q4
wave -noreg D0
wave -noreg D1
wave -noreg D2
wave -noreg D3
wave -noreg D4
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\scehm2_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_scehm2 
