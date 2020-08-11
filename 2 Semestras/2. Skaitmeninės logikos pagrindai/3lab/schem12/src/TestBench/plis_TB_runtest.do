SetActiveLib -work
comp -include "C:\Users\PC\Documents\1. KTU\1. KTU\2 Semestras\2. SLP\3lab\impl1\PLIS.vhd" 
comp -include "$dsn\src\TestBench\plis_TB.vhd" 
asim +access +r TESTBENCH_FOR_plis 
wave 
wave -noreg A0
wave -noreg A1
wave -noreg C
wave -noreg Reset
wave -noreg Q4
wave -noreg Q3
wave -noreg Q2
wave -noreg Q1
wave -noreg Q0
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\plis_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_plis 
