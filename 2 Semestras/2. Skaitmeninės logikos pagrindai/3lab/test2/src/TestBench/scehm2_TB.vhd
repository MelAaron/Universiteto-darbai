library ieee;
use ieee.std_logic_1164.all;
library xp2;
use xp2.components.all;

	-- Add your library and packages declaration here ...

entity scehm2_tb is
end scehm2_tb;

architecture TB_ARCHITECTURE of scehm2_tb is
	-- Component declaration of the tested unit
	component scehm2
	port(
		A0 : in STD_LOGIC;
		A1 : in STD_LOGIC;
		Reset : in STD_LOGIC;
		C : in STD_LOGIC;
		Q0 : out STD_LOGIC;
		Q1 : out STD_LOGIC;
		Q2 : out STD_LOGIC;
		Q3 : out STD_LOGIC;
		Q4 : out STD_LOGIC;
		D0 : in STD_LOGIC;
		D1 : in STD_LOGIC;
		D2 : in STD_LOGIC;
		D3 : in STD_LOGIC;
		D4 : in STD_LOGIC );
	end component;

	-- Stimulus signals - signals mapped to the input and inout ports of tested entity
	signal A0 : STD_LOGIC;
	signal A1 : STD_LOGIC;
	signal Reset : STD_LOGIC;
	signal C : STD_LOGIC;
	signal D0 : STD_LOGIC;
	signal D1 : STD_LOGIC;
	signal D2 : STD_LOGIC;
	signal D3 : STD_LOGIC;
	signal D4 : STD_LOGIC;
	-- Observed signals - signals mapped to the output ports of tested entity
	signal Q0 : STD_LOGIC;
	signal Q1 : STD_LOGIC;
	signal Q2 : STD_LOGIC;
	signal Q3 : STD_LOGIC;
	signal Q4 : STD_LOGIC;

	-- Add your code here ...

begin

	-- Unit Under Test port map
	UUT : scehm2
		port map (
			A0 => A0,
			A1 => A1,
			Reset => Reset,
			C => C,
			Q0 => Q0,
			Q1 => Q1,
			Q2 => Q2,
			Q3 => Q3,
			Q4 => Q4,
			D0 => D0,
			D1 => D1,
			D2 => D2,
			D3 => D3,
			D4 => D4,
			DR => DR,
			DL => DL
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
	DL <= '1'; DR <= '1';
    D4 <= '0'; D3 <= '0'; D2 <= '0'; D1 <= '0'; D0 <= '1';
	wait for 15 ns;
	A0 <= '1'; A1 <= '1';
	wait for 35 ns;
	A0 <= '0'; A1 <= '0';
	wait for 80 ns;
	A1 <='1';
	wait for 200 ns;
	DL <= '0'; DR <= '0';
	D4 <= '1'; D3 <= '1'; D2 <= '0'; D1 <= '0'; D0 <= '1';
	A0 <= '1';
	wait for 40 ns;
	A1 <= '0';
	wait for 210 ns;
	assert false report " Pabaiga " severity failure ;
end process;

end TB_ARCHITECTURE;

configuration TESTBENCH_FOR_scehm2 of scehm2_tb is
	for TB_ARCHITECTURE
		for UUT : scehm2
			use entity work.scehm2(schematic);
		end for;
	end for;
end TESTBENCH_FOR_scehm2;

