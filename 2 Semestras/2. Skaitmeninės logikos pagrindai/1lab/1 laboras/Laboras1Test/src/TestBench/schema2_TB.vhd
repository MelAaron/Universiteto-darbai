library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;

	-- Add your library and packages declaration here ...

entity schema2_tb is
end schema2_tb;

architecture TB_ARCHITECTURE of schema2_tb is
	-- Component declaration of the tested unit
	component schema2
	port(
		a : in STD_LOGIC;
		b : in STD_LOGIC;
		c : in STD_LOGIC;
		d : in STD_LOGIC;
		e : in STD_LOGIC;
		f : in STD_LOGIC;
		rez : out STD_LOGIC );
	end component;

	-- Stimulus signals - signals mapped to the input and inout ports of tested entity
	signal a : STD_LOGIC;
	signal b : STD_LOGIC;
	signal c : STD_LOGIC;
	signal d : STD_LOGIC;
	signal e : STD_LOGIC;
	signal f : STD_LOGIC;
	-- Observed signals - signals mapped to the output ports of tested entity
	signal rez : STD_LOGIC;

	-- Add your code here ...

begin

	-- Unit Under Test port map
	UUT : schema2
		port map (
			a => a,
			b => b,
			c => c,
			d => d,
			e => e,
			f => f,
			rez => rez
		);

	-- Add your stimulus here ...
	fp: process
	begin
	f <= '0'; wait for 10 ns;
	f <= '1'; wait for 10 ns;
	end process ;
ep: process
	begin
	e <= '0'; wait for 20 ns;
	e <= '1'; wait for 20 ns;
	end process ;
dp: process
	begin
	d <= '0'; wait for 40 ns;
	d <= '1'; wait for 40 ns;
	end process ;
cp: process
	begin
	c <= '0'; wait for 80 ns;
	c <= '1'; wait for 80 ns;
	end process ;
bp: process
	begin
	b <= '0'; wait for 160 ns;
	b <= '1'; wait for 160 ns;
	end process ;
ap: process
	begin
	a <= '0'; wait for 320 ns;
	a <= '1'; wait for 320 ns;
	assert false report " Pabaiga " severity failure ;
	end process ;

end TB_ARCHITECTURE;

configuration TESTBENCH_FOR_schema2 of schema2_tb is
	for TB_ARCHITECTURE
		for UUT : schema2
			use entity work.schema2(schematic);
		end for;
	end for;
end TESTBENCH_FOR_schema2;

