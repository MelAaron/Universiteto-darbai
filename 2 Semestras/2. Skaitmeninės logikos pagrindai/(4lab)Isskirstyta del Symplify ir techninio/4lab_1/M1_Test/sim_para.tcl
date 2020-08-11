lappend auto_path "C:/lscc/diamond/3.10_x64/data/script"
package require simulation_generation
set ::bali::simulation::Para(PROJECT) {M1_Test}
set ::bali::simulation::Para(PROJECTPATH) {C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab_1}
set ::bali::simulation::Para(FILELIST) {"C:/Users/PC/Documents/1. KTU/1. KTU/2 Semestras/2. SLP/4lab_1/cntr12.vhd" }
set ::bali::simulation::Para(GLBINCLIST) {}
set ::bali::simulation::Para(INCLIST) {"none"}
set ::bali::simulation::Para(WORKLIBLIST) {"work" }
set ::bali::simulation::Para(COMPLIST) {"VHDL" }
set ::bali::simulation::Para(SIMLIBLIST) {pmi_work ovi_xp2}
set ::bali::simulation::Para(MACROLIST) {}
set ::bali::simulation::Para(SIMULATIONTOPMODULE) {CNT12}
set ::bali::simulation::Para(SIMULATIONINSTANCE) {}
set ::bali::simulation::Para(LANGUAGE) {VHDL}
set ::bali::simulation::Para(SDFPATH)  {}
set ::bali::simulation::Para(ADDTOPLEVELSIGNALSTOWAVEFORM)  {1}
set ::bali::simulation::Para(RUNSIMULATION)  {1}
set ::bali::simulation::Para(HDLPARAMETERS) {}
set ::bali::simulation::Para(POJO2LIBREFRESH)    {}
set ::bali::simulation::Para(POJO2MODELSIMLIB)   {}
::bali::simulation::ActiveHDL_Run
