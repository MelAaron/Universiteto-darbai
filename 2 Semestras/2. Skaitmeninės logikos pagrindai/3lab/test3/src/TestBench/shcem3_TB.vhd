library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;

	-- Add your library and packages declaration here ...

entity shcem3_tb is
end shcem3_tb;

architecture TB_ARCHITECTURE of shcem3_tb is
	-- Component declaration of the tested unit
	component shcem3
	port(
		A0 : in STD_LOGIC;
		A1 : in STD_LOGIC;
		C : in STD_LOGIC;
		Reset : in STD_LOGIC;
		x4 : in STD_LOGIC;
		Q4 : out STD_LOGIC;
		x3 : in STD_LOGIC;
		Q3 : out STD_LOGIC;
		x2 : in STD_LOGIC;
		Q2 : out STD_LOGIC;
		x1 : in STD_LOGIC;
		Q1 : out STD_LOGIC;
		x0 : in STD_LOGIC;
		Q0 : out STD_LOGIC;
		T : in STD_LOGIC );
	end component;

	-- Stimulus signals - signals mapped to the input and inout ports of tested entity
	signal A0 : STD_LOGIC;
	signal A1 : STD_LOGIC;
	signal C : STD_LOGIC;
	signal Reset : STD_LOGIC;
	signal x4 : STD_LOGIC;
	signal x3 : STD_LOGIC;
	signal x2 : STD_LOGIC;
	signal x1 : STD_LOGIC;
	signal x0 : STD_LOGIC;
	signal T : STD_LOGIC;
	-- Observed signals - signals mapped to the output ports of tested entity
	signal Q4 : STD_LOGIC;
	signal Q3 : STD_LOGIC;
	signal Q2 : STD_LOGIC;
	signal Q1 : STD_LOGIC;
	signal Q0 : STD_LOGIC;

	-- Add your code here ...

begin

	-- Unit Under Test port map
	UUT : shcem3
		port map (
			A0 => A0,
			A1 => A1,
			C => C,
			Reset => Reset,
			x4 => x4,
			Q4 => Q4,
			x3 => x3,
			Q3 => Q3,
			x2 => x2,
			Q2 => Q2,
			x1 => x1,
			Q1 => Q1,
			x0 => x0,
			Q0 => Q0,
			T => T
		);

	-- Add your stimulus here ...
Resetas: process begin
Reset <= '0';
    wait for 10 ns;
    Reset <= '1';
    wait;
end process; 
        
Sinchro: process
begin
    c <= '0';
    wait for 20 ns;
    c <= '1';
    wait for 20 ns;
end process;  

Postumiai: process
begin
	T <= '0';
    x4 <= '0'; x3 <= '0'; x2 <= '1'; x1 <= '1'; x0 <= '0'; wait for 10 ns;    
    A1 <= '0'; A0 <= '0'; wait for 40 ns; --iraso
    A1 <= '1'; A0 <= '0'; wait for 40 ns; --LR1
    A1 <= '0'; A0 <= '1'; wait for 40 ns; --CL2
    A1 <= '1'; A0 <= '1'; wait for 40 ns; --AR2		
	
	T <= '1';
	x4 <= '1'; x3 <= '1'; x2 <= '0'; x1 <= '1'; x0 <= '0';
	A1 <= '0'; A0 <= '0'; wait for 40 ns; --iraso
	A1 <= '1'; A0 <= '0'; wait for 120 ns; --LR1
	A1 <= '0'; A0 <= '1'; wait for 80 ns; --CL2
	A1 <= '1'; A0 <= '1'; wait for 40 ns; --AR2
	assert false report " Pabaiga " severity failure ;
end process;

end TB_ARCHITECTURE;

configuration TESTBENCH_FOR_shcem3 of shcem3_tb is
	for TB_ARCHITECTURE
		for UUT : shcem3
			use entity work.shcem3(schematic);
		end for;
	end for;
end TESTBENCH_FOR_shcem3;

