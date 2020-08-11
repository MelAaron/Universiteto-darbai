library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;

	-- Add your library and packages declaration here ...

entity failas_tb is
end failas_tb;

architecture TB_ARCHITECTURE of failas_tb is
	-- Component declaration of the tested unit
	component failas
	port(
		c : in STD_LOGIC;
		b : in STD_LOGIC;
		a : in STD_LOGIC;
		d : in STD_LOGIC;
		f : out STD_LOGIC );
	end component;

	-- Stimulus signals - signals mapped to the input and inout ports of tested entity
	signal c : STD_LOGIC;
	signal b : STD_LOGIC;
	signal a : STD_LOGIC;
	signal d : STD_LOGIC;
	-- Observed signals - signals mapped to the output ports of tested entity
	signal f : STD_LOGIC;

	-- Add your code here ...

begin

	-- Unit Under Test port map
	UUT : failas
		port map (
			c => c,
			b => b,
			a => a,
			d => d,
			f => f
		);

	-- Add your stimulus here ...
	process begin
a <= '0'; b <= '0'; c <= '0'; d <= '0';
wait for 10 ns ;
a <= '0'; b <= '0'; c <= '0'; d <= '1';
wait for 10 ns ;
a <= '0'; b <= '0'; c <= '1'; d <= '0';
wait for 10 ns ;
a <= '0'; b <= '0'; c <= '1'; d <= '1';
wait for 10 ns ;
a <= '0'; b <= '1'; c <= '0'; d <= '0';
wait for 10 ns ;
a <= '0'; b <= '1'; c <= '0'; d <= '1';
wait for 10 ns ;
a <= '0'; b <= '1'; c <= '1'; d <= '0';
wait for 10 ns ;
a <= '0'; b <= '1'; c <= '1'; d <= '1';
wait for 10 ns ;
a <= '1'; b <= '0'; c <= '0'; d <= '0';
wait for 10 ns ;
a <= '1'; b <= '0'; c <= '0'; d <= '1';
wait for 10 ns ;
a <= '1'; b <= '0'; c <= '1'; d <= '0';
wait for 10 ns ;
a <= '1'; b <= '0'; c <= '1'; d <= '1';
wait for 10 ns ;
a <= '1'; b <= '1'; c <= '0'; d <= '0';
wait for 10 ns ;
a <= '1'; b <= '1'; c <= '0'; d <= '1';
wait for 10 ns ;
a <= '1'; b <= '1'; c <= '1'; d <= '0';
wait for 10 ns ;
a <= '1'; b <= '1'; c <= '1'; d <= '1';
wait for 10 ns ;
wait ;
end process ;



end TB_ARCHITECTURE;

configuration TESTBENCH_FOR_failas of failas_tb is
	for TB_ARCHITECTURE
		for UUT : failas
			use entity work.failas(schematic);
		end for;
	end for;
end TESTBENCH_FOR_failas;

