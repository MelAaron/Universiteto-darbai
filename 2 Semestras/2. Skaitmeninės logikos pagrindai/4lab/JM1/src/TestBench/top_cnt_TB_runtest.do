SetActiveLib -work
comp -include "C:\Users\PC\Documents\1. KTU\1. KTU\2 Semestras\2. SLP\4lab\cntr31.vhd" 
comp -include "C:\Users\PC\Documents\1. KTU\1. KTU\2 Semestras\2. SLP\4lab\schem1.vhd" 
comp -include "C:\Users\PC\Documents\1. KTU\1. KTU\2 Semestras\2. SLP\4lab\cntr12.vhd" 
comp -include "C:\Users\PC\Documents\1. KTU\1. KTU\2 Semestras\2. SLP\4lab\JM1.vhd" 
comp -include "$dsn\src\TestBench\top_cnt_TB.vhd" 
asim +access +r TESTBENCH_FOR_top_cnt 
wave 
wave -noreg CLK_I
wave -noreg RST_I
wave -noreg ENBL_I
wave -noreg CNT_CO
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\top_cnt_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_top_cnt 
