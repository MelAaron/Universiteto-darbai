library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;

	-- Add your library and packages declaration here ...

entity schem1_tb is
end schem1_tb;

architecture TB_ARCHITECTURE of schem1_tb is
	-- Component declaration of the tested unit
	component schem1
	port(
		a : in STD_LOGIC;
		b : in STD_LOGIC;
		c : in STD_LOGIC;
		d : in STD_LOGIC;
		S : out STD_LOGIC;
		R : out STD_LOGIC;
		Q : out STD_LOGIC;
		Reset : in STD_LOGIC );
	end component;

	-- Stimulus signals - signals mapped to the input and inout ports of tested entity
	signal a : STD_LOGIC;
	signal b : STD_LOGIC;
	signal c : STD_LOGIC;
	signal d : STD_LOGIC;
	signal Reset : STD_LOGIC;
	-- Observed signals - signals mapped to the output ports of tested entity
	signal S : STD_LOGIC;
	signal R : STD_LOGIC;
	signal Q : STD_LOGIC;

	-- Add your code here ...

begin

	-- Unit Under Test port map
	UUT : schem1
		port map (
			a => a,
			b => b,
			c => c,
			d => d,
			S => S,
			R => R,
			Q => Q,
			Reset => Reset
		);

	-- Add your stimulus here ...
	Reset_proc: process begin
		Reset <= '0'; wait for 3 ns;
		Reset <= '1'; wait;
	end process;	
	
	clock_proc: process begin
		a <= '1'; wait for 10 ns;
		a <= '0'; wait for 10 ns;
	end process;
	
	RS_proc: process begin 
	b <= '0'; c <= '1'; d<= '0'; wait for 25 ns; --1 irasymas
	b <= '0'; c <= '0'; d<= '1'; wait for 20 ns; --Info saugojimas
	b <= '0'; c <= '0'; d<= '0'; wait for 20 ns; --0 irasymas
	b <= '0'; c <= '0'; d<= '1'; wait for 20 ns; --Info saugojimas
	b <= '1'; c <= '0'; d<= '0'; wait for 20 ns; --1 irasymas
	b <= '0'; c <= '0'; d<= '1'; wait for 20 ns; --Info saugojimas
	b <= '0'; c <= '1'; d<= '1'; wait for 20 ns; --0 irasymas
	b <= '0'; c <= '0'; d<= '1'; wait for 20 ns; --Info saugojimas
	assert false report " Pabaiga " severity failure ;
	end process;

end TB_ARCHITECTURE;

configuration TESTBENCH_FOR_schem1 of schem1_tb is
	for TB_ARCHITECTURE
		for UUT : schem1
			use entity work.schem1(schematic);
		end for;
	end for;
end TESTBENCH_FOR_schem1;

