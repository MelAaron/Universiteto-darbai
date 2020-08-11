SetActiveLib -work
comp -include "C:\Users\User\Documents\1. KTU\2 Semestras\2. SLP\New folder\1 laboras\impl1\schema2.vhd" 
comp -include "$dsn\src\TestBench\schema2_TB.vhd" 
asim +access +r TESTBENCH_FOR_schema2 
wave 
wave -noreg rez
wave -noreg a
wave -noreg b
wave -noreg c
wave -noreg d
wave -noreg e
wave -noreg f
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\schema2_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_schema2 
