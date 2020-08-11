SetActiveLib -work
comp -include "C:\Users\User\Documents\1. KTU\2 Semestras\2. SLP\Demo\impl1\Failas.vhd" 
comp -include "$dsn\src\TestBench\failas_TB.vhd" 
asim +access +r TESTBENCH_FOR_failas 
wave 
wave -noreg c
wave -noreg b
wave -noreg a
wave -noreg d
wave -noreg f
# The following lines can be used for timing simulation
# acom <backannotated_vhdl_file_name>
# comp -include "$dsn\src\TestBench\failas_TB_tim_cfg.vhd" 
# asim +access +r TIMING_FOR_failas 
