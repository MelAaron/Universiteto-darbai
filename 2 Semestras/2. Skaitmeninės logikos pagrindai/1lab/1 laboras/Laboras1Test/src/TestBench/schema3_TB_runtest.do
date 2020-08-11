SetActiveLib -work
comp -include "C:\Users\User\Documents\1. KTU\2 Semestras\2. SLP\New folder\1 laboras\impl1\schema3.vhd" 
comp -include "$dsn\src\TestBench\schema3_TB.vhd" 
asim +access +r TESTBENCH_FOR_schema3 
wave 
wave -noreg b
wave -noreg c
wave -noreg f
wave -noreg e
wave -noreg rez
wave -noreg d
wave -noreg a
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\schema3_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_schema3 
