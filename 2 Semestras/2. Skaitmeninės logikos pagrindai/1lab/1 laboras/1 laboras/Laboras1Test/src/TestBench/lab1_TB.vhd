library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;

	-- Add your library and packages declaration here ...

entity lab1_tb is
end lab1_tb;

architecture TB_ARCHITECTURE of lab1_tb is
	-- Component declaration of the tested unit
	component lab1
	port(
		a : in STD_LOGIC;
		b : in STD_LOGIC;
		c : in STD_LOGIC;
		d : in STD_LOGIC;
		e : in STD_LOGIC;
		f : in STD_LOGIC );
	end component;

	-- Stimulus signals - signals mapped to the input and inout ports of tested entity
	signal a : STD_LOGIC;
	signal b : STD_LOGIC;
	signal c : STD_LOGIC;
	signal d : STD_LOGIC;
	signal e : STD_LOGIC;
	signal f : STD_LOGIC;
	-- Observed signals - signals mapped to the output ports of tested entity

	-- Add your code here ...

begin

	-- Unit Under Test port map
	UUT : lab1
		port map (
			a => a,
			b => b,
			c => c,
			d => d,
			e => e,
			f => f
		);

	-- Add your stimulus here ...
	process begin
		a <= '1'; b <= '1'; d <= '1'; c <= '1'; e <= '1'; f <= '0';
		wait;
		end process;

end TB_ARCHITECTURE;

configuration TESTBENCH_FOR_lab1 of lab1_tb is
	for TB_ARCHITECTURE
		for UUT : lab1
			use entity work.lab1(schematic);
		end for;
	end for;
end TESTBENCH_FOR_lab1;

