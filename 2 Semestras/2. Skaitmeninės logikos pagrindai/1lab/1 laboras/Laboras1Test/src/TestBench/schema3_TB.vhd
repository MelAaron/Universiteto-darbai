library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;

	-- Add your library and packages declaration here ...

entity schema3_tb is
end schema3_tb;

architecture TB_ARCHITECTURE of schema3_tb is
	-- Component declaration of the tested unit
	component schema3
	port(
		b : in STD_LOGIC;
		c : in STD_LOGIC;
		f : in STD_LOGIC;
		e : in STD_LOGIC;
		rez : out STD_LOGIC;
		d : in STD_LOGIC;
		a : in STD_LOGIC );
	end component;

	-- Stimulus signals - signals mapped to the input and inout ports of tested entity
	signal b : STD_LOGIC;
	signal c : STD_LOGIC;
	signal f : STD_LOGIC;
	signal e : STD_LOGIC;
	signal d : STD_LOGIC;
	signal a : STD_LOGIC;
	-- Observed signals - signals mapped to the output ports of tested entity
	signal rez : STD_LOGIC;

	-- Add your code here ...

begin

	-- Unit Under Test port map
	UUT : schema3
		port map (
			b => b,
			c => c,
			f => f,
			e => e,
			rez => rez,
			d => d,
			a => a
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

configuration TESTBENCH_FOR_schema3 of schema3_tb is
	for TB_ARCHITECTURE
		for UUT : schema3
			use entity work.schema3(schematic);
		end for;
	end for;
end TESTBENCH_FOR_schema3;

