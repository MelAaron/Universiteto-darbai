lappend auto_path "C:/lscc/diamond/3.10_x64/data/script"
package require simulation_generation
set ::bali::simulation::Para(PROJECT) {JM1}
set ::bali::simulation::Para(PROJECTPATH) {C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab_2}
set ::bali::simulation::Para(FILELIST) {"C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab_2/cntr31.vhd" "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab_2/cntr12.vhd" "C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab_2/JM1.vhd" }
set ::bali::simulation::Para(GLBINCLIST) {}
set ::bali::simulation::Para(INCLIST) {"none" "none" "none"}
set ::bali::simulation::Para(WORKLIBLIST) {"work" "work" "work" }
set ::bali::simulation::Para(COMPLIST) {"VHDL" "VHDL" "VHDL" }
set ::bali::simulation::Para(SIMLIBLIST) {pmi_work ovi_xp2}
set ::bali::simulation::Para(MACROLIST) {}
set ::bali::simulation::Para(SIMULATIONTOPMODULE) {TOP_CNT}
set ::bali::simulation::Para(SIMULATIONINSTANCE) {}
set ::bali::simulation::Para(LANGUAGE) {VHDL}
set ::bali::simulation::Para(SDFPATH)  {}
set ::bali::simulation::Para(ADDTOPLEVELSIGNALSTOWAVEFORM)  {1}
set ::bali::simulation::Para(RUNSIMULATION)  {1}
set ::bali::simulation::Para(HDLPARAMETERS) {}
set ::bali::simulation::Para(POJO2LIBREFRESH)    {}
set ::bali::simulation::Para(POJO2MODELSIMLIB)   {}
::bali::simulation::ActiveHDL_Run
