library ieee;
use ieee.NUMERIC_STD.all;
use ieee.std_logic_1164.all;

	-- Add your library and packages declaration here ...

entity cnt12_tb is
end cnt12_tb;

architecture TB_ARCHITECTURE of cnt12_tb is
	-- Component declaration of the tested unit
	component cnt12
	port(
		CLK : in STD_LOGIC;
		RST : in STD_LOGIC;
		CNT_CMD : in STD_LOGIC;
		CNT_C : out STD_LOGIC;
		CNT_O : out STD_LOGIC_VECTOR(3 downto 0) );
	end component;

	-- Stimulus signals - signals mapped to the input and inout ports of tested entity
	signal CLK : STD_LOGIC;
	signal RST : STD_LOGIC;
	signal CNT_CMD : STD_LOGIC;
	-- Observed signals - signals mapped to the output ports of tested entity
	signal CNT_C : STD_LOGIC;
	signal CNT_O : STD_LOGIC_VECTOR(3 downto 0);

	-- Add your code here ...

begin

	-- Unit Under Test port map
	UUT : cnt12
		port map (
			CLK => CLK,
			RST => RST,
			CNT_CMD => CNT_CMD,
			CNT_C => CNT_C,
			CNT_O => CNT_O
		);

	-- Add your stimulus here ...
	clock_proc:process  begin--sinchrosignala valdantis  procesas
	CLK  <='0';
	wait  for 1 ns;
	CLK  <='1';
	wait  for 1 ns;
end  process;	 

reset_process:process  begin--isorini reset signala valdantis  procesas
	RST  <='1';
	wait  for 1 ns;
	RST  <='0';
	wait for 1100 ns;	 
	RST  <='1';
	wait  for 1 ns;
	RST  <='0';
	wait;
end  process;	

enbl_process:process  begin--ijungimo signala valdantis  procesas
	CNT_CMD  <='0';
	wait  for 10 ns;
	CNT_CMD  <='1';
	wait for 1700 ns;  
	CNT_CMD  <='0';
	wait  for 10 ns;
	CNT_CMD  <='1';
	wait; 	
end  process;

end TB_ARCHITECTURE;

configuration TESTBENCH_FOR_cnt12 of cnt12_tb is
	for TB_ARCHITECTURE
		for UUT : cnt12
			use entity work.cnt12(rtl);
		end for;
	end for;
end TESTBENCH_FOR_cnt12;

