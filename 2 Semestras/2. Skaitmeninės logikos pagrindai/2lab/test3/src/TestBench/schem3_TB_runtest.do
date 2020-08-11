SetActiveLib -work
comp -include "C:\Users\User\Documents\1. KTU\2 Semestras\2. SLP\2lab\lab2impl\schem3.vhd" 
comp -include "$dsn\src\TestBench\schem3_TB.vhd" 
asim +access +r TESTBENCH_FOR_schem3 
wave 
wave -noreg d
wave -noreg b
wave -noreg c
wave -noreg a
wave -noreg Reset
wave -noreg QDin
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\schem3_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_schem3 
