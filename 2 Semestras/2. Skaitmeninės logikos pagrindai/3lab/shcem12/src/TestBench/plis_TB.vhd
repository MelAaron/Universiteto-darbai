library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;

	-- Add your library and packages declaration here ...

entity plis_tb is
end plis_tb;

architecture TB_ARCHITECTURE of plis_tb is
	-- Component declaration of the tested unit
	component plis
	port(
		A0 : in STD_LOGIC;
		A1 : in STD_LOGIC;
		C : in STD_LOGIC;
		Reset : in STD_LOGIC;
		Q4 : out STD_LOGIC;
		Q3 : out STD_LOGIC;
		Q2 : out STD_LOGIC;
		Q1 : out STD_LOGIC;
		Q0 : out STD_LOGIC );
	end component;

	-- Stimulus signals - signals mapped to the input and inout ports of tested entity
	signal A0 : STD_LOGIC;
	signal A1 : STD_LOGIC;
	signal C : STD_LOGIC;
	signal Reset : STD_LOGIC;
	-- Observed signals - signals mapped to the output ports of tested entity
	signal Q4 : STD_LOGIC;
	signal Q3 : STD_LOGIC;
	signal Q2 : STD_LOGIC;
	signal Q1 : STD_LOGIC;
	signal Q0 : STD_LOGIC;

	-- Add your code here ...

begin

	-- Unit Under Test port map
	UUT : plis
		port map (
			A0 => A0,
			A1 => A1,
			C => C,
			Reset => Reset,
			Q4 => Q4,
			Q3 => Q3,
			Q2 => Q2,
			Q1 => Q1,
			Q0 => Q0
		);

	-- Add your stimulus here ...

end TB_ARCHITECTURE;

configuration TESTBENCH_FOR_plis of plis_tb is
	for TB_ARCHITECTURE
		for UUT : plis
			use entity work.plis(schematic);
		end for;
	end for;
end TESTBENCH_FOR_plis;

