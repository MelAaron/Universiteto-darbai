SetActiveLib -work
comp -include "C:\Users\PC\Documents\1. KTU\1. KTU\2 Semestras\2. SLP\4lab\cntr12.vhd" 
comp -include "$dsn\src\TestBench\cnt12_TB.vhd" 
asim +access +r TESTBENCH_FOR_cnt12 
wave 
wave -noreg CLK
wave -noreg RST
wave -noreg CNT_CMD
wave -noreg CNT_C
wave -noreg CNT_O
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\cnt12_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_cnt12 
