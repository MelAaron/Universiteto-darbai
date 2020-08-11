library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;

	-- Add your library and packages declaration here ...

entity schem3_tb is
end schem3_tb;

architecture TB_ARCHITECTURE of schem3_tb is
	-- Component declaration of the tested unit
	component schem3
	port(
		d : in STD_LOGIC;
		b : in STD_LOGIC;
		c : in STD_LOGIC;
		a : in STD_LOGIC;
		Reset : in STD_LOGIC;
		QDin : out STD_LOGIC );
	end component;

	-- Stimulus signals - signals mapped to the input and inout ports of tested entity
	signal d : STD_LOGIC;
	signal b : STD_LOGIC;
	signal c : STD_LOGIC;
	signal a : STD_LOGIC;
	signal Reset : STD_LOGIC;
	-- Observed signals - signals mapped to the output ports of tested entity
	signal QDin : STD_LOGIC;

	-- Add your code here ...

begin

	-- Unit Under Test port map
	UUT : schem3
		port map (
			d => d,
			b => b,
			c => c,
			a => a,
			Reset => Reset,
			QDin => QDin
		);

	-- Add your stimulus here ...
	clock_pro : process begin
		a <= '0';
		wait for 10 ns;
		a <= '1';
		wait for 10 ns;
	end process;
	
	reset_proc : process begin
		Reset <= '0';
		wait for 2 ns;
		Reset <= '1';
		wait;
	end process;
	
	test_proc : process begin --trigerio signalus valdantis procesas
		b <= '0'; c <= '0'; d <= '1'; --Saugo (2)
		wait for 25 ns;
		b <= '0'; c <= '1'; d <= '0'; --Iraso 1	(3)
		wait for 20 ns;
		b <= '0'; c <= '0'; d <= '1'; --Saugo (2)
		wait for 20 ns;
		b <= '0'; c <= '0'; d <= '0'; --Iraso 0	(1)
		wait for 20 ns;
		b <= '0'; c <= '0'; d <= '1'; --Saugo (2)
		wait for 20 ns;
		b <= '1'; c <= '0'; d <= '0'; --Iraso 1	(5)
		wait for 20 ns;
		b <= '0'; c <= '1'; d <= '1'; --Iraso 0	(4)
		wait for 20 ns;
		b <= '0'; c <= '0'; d <= '1'; --Saugo (2)
		wait for 20 ns;
		b <= '0'; c <= '1'; d <= '0'; --Iraso 1	(3)
		wait for 20 ns;
		b <= '1'; c <= '0'; d <= '1'; --Iraso 0	(6)
		wait for 30 ns;
		b <= '1'; c <= '1'; d <= '0'; --Iraso 1	(7)
		wait for 30 ns;
		b <= '0'; c <= '0'; d <= '1'; --Saugo (2)
		wait for 20 ns;
		b <= '1'; c <= '1'; d <= '1'; --Iraso 0 (8)
		wait for 20 ns;	
		assert false report " Pabaiga " severity failure ;
	end process;

end TB_ARCHITECTURE;

configuration TESTBENCH_FOR_schem3 of schem3_tb is
	for TB_ARCHITECTURE
		for UUT : schem3
			use entity work.schem3(schematic);
		end for;
	end for;
end TESTBENCH_FOR_schem3;

