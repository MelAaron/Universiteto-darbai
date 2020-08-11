--KTU 2019
--Informatikos fakultetas
--Kompiuteriu katedra
--Skaitmenine Logika [P175B100]
--Kazimieras Bagdonas

library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity TOP_CNT is port (  
		
		CLK_I 	: in std_logic; --Sinchro signalas
		RST_I 	: in std_logic; -- Reset signalas
		ENBL_I 	: in std_logic; -- Aktyvavimo signalas	
		CNT_CO	: out std_logic --Pernasa
		);
end TOP_CNT;		

architecture struct of TOP_CNT is  

signal C,RST_internal,C1,C2,C3 : std_logic;
signal CNT_1_O :  std_logic_vector(3 downto 0); --12 counteris
signal CNT_2_O :  std_logic_vector(4 downto 0); --31 counteris
signal CNT_3_O :  std_logic_vector(5 downto 0); --50 counteris

component	 CNT12 
	port	(
		CLK : in std_logic; --Sinchro signalas
		RST : in std_logic; -- Reset signalas
		CNT_CMD  : in std_logic; -- Komanda	
		CNT_C	 : out std_logic; --Pernasa
		CNT_O	 : out std_logic_vector(3 downto  0));	
end component;	

component	 CNT31_2 
	port  (
		CLK : in std_logic; --Sinchro signalas
		RST : in std_logic; -- Reset signalas
		CNT_CMD  : in std_logic; -- Komanda	
		CNT_C	 : out std_logic; --Kai pasiekia 0  
		CNT_O	 : out std_logic_vector(4 downto  0) );	
end component;


component	 CNT50 
	port  (
		CLK : in std_logic; --Sinchro signalas
		RST : in std_logic; -- Reset signalas
		CNT_CMD  : in std_logic; -- Komanda	
		CNT_C	 : out std_logic; --Kai pasiekia 0  
		CNT_O	 : out std_logic_vector(5 downto  0) );	
end component;


begin
	CNT_1: 	CNT12	port map (CLK=>CLK_I, 	
		RST=>RST_internal, CNT_CMD=>ENBL_I, 
		CNT_C=>C1, CNT_O=>CNT_1_O);
	CNT_2:	CNT31_2  port map (CLK=> C1,		
		RST=>RST_internal, CNT_CMD=>ENBL_I, 
		CNT_C=>C2, CNT_O=>CNT_2_O);
	CNT_3: CNT50 port map (CLK=>C2,
		RST=>RST_internal, CNT_CMD=>ENBL_I,
		CNT_C=>C3, CNT_O=>CNT_3_O);
	
	process(CLK_I,RST_I)
	begin 
		if 	(RST_I = '1') then
			RST_internal <=	'1';  
		elsif CLK_I'event and CLK_I = '1' then  
			if ((CNT_3_O(3) = '1')
				and (CNT_3_O(2) = '0')
				and (CNT_3_O(1) = '0')
				and (CNT_3_O(0) = '1')
				
				and (CNT_2_O(4) = '1')
				and (CNT_2_O(3) = '1')
				and (CNT_2_O(2) = '1')
				and (CNT_2_O(1) = '1')
				and (CNT_2_O(0) = '0'))  then  
				RST_internal <=	'1'; 
				CNT_CO <= '1';
			else
				RST_internal <=	'0';  
				CNT_CO <= '0';	
			end if;			
		end if;
	end process;
end struct;
