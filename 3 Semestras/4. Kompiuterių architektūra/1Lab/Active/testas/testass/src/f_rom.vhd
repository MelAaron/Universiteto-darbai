
--KTU 2015
--Informatikos fakultetas
--Kompiuteriu katedra
--Kompiuteriu Architektura [P175B125] 
--Kazimieras Bagdonas

library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;

entity ROM is 
	port (
		RST_ROM 	: in std_logic;
		ROM_CMD 	: in std_logic_vector(7 downto 0);	  
		ROM_Dout 	: out std_logic_vector(1 to 80)
		);
end ROM ;

architecture rtl of ROM is
	
	type memory is array (0 to 255) of std_logic_vector(1 to 80) ; 	
	
	constant ROM_CMDln : memory := (	  
--                     1         2         3         4         5         6         7         8 Dvi komentaro eilutes duoda bitu numerius   
--            12345678901234567890123456789012345678901234567890123456789012345678901234567890    (nuo 1 iki 80)
	
0=> "10000000000000100000000000000000000000000000000000000000000000000000000000000001",  --Irasom N2 I B
1=> "10000000000000000000010000000000000000000000000000000000000000000000000000000010",  --Irasom N2 I C
2=> "10000000000000000000000000001000000000000000000000000000000000000000000000000011",  --Irasom N1 I D
3=> "10000000000000000000000000000000000100000000000000000000000000000000000000000100",  --Irasom N3 I E
4=> "00001000000000000000000000000000000000000000000000000000000000000000000000000101",  --Irasom D I MUX
5=> "00000001000000000000000000000000000000000000000000001000000000000000000000000110",  --M = L + 1; A = M; MUX = A;
6=> "01000000000000000000000000001000000000000000000000000000000000000000000000000111",  --D = MUX
7=> "00100000000000000000000000000000000000000000000000000000000000000000000000001000",  --MUX = B;
8=> "00000001000000000000000000000000000000000000000000100000000000000000000000001001",  --M = NOT(L); A = M;
9=> "01000000000000100000000000000000000000000000000000000000000000000000000000001010",  --MUX = A; B = MUX(A);
10=> "00010000000000000000000000000000000000000000000000000000000000000000000000001011",  --MUX = C
11=> "00000001000000000000000000000000000000000000000000100000000000000000000000001100",  --M = NOT(L); A = M;
12=> "01000000000000000000010000000000000000000000000000000000000000000000000000001101",  --MUX = A; C = MUX(A);
13=> "00100000000000000000000000000000000000000000000000000000010000000000000000001110",  --MUX = B; Reset(A);
14=> "00000000000000000000000000000000000000000000000000010000000000000001000000010000",  --CNT--
15=> "00001000000000000000000000000000000000000000000000000000000000000000000000010100",  --MUX = D;
16=> "00000000000000000000000000000000000000000000000000000000000000000000011000010001",  --LS = 6
17=> "00000000000000010000000100000000000000000000000000000000000000000000000000010011",  --LL1  B; LR1  C
18=> "00000001000000000000000000000000000000000000000001000000000000000000000000010001",  --M = L + R; A = M'
19=> "00000000000000000000000000000000000000000000000000000000000000000000110100001110",  --LS = 13
20=> "00000001000000000000000000000000000000000000000001000000000000000000000000010101",  --M = R + L; A = M; SUDETIS. Atsakymas papildomam kode
21=> "01000000000000000000000000000000000000000010000000000000000000000000000000010111",  --MUX = A; F = MUX;
22=> "00000100000000000000000000000000000000000000000000000000010000000000000000011011",  --MUX = E; Reset(A);
23=> "00000000000000000000000000000000000000000000000000000000000000000000000100011000",  --LS = 1;
24=> "01000000000000100000000000000000000000000000000000000000000000000000000000010110",  --MUX = A; B = MUX;
25=> "00000001000000000000000000000000000000000000000000000100000000000000000000011010",  --M = L - 1; A = M;
26=> "00000001000000000000000000000000000000000000000000100000000000000000000000011000",  --M = NOT(L) A = M;
27=> "00000001000000000000000000000000000000000000000001000000000000000000000000011100",  --M = R + L; A = M;
28=> "00000001000000000000000000000000000000000000000000010000000000000000000000011101",  --M = NOT(R.); A = M;
29=> "00000001000000000000000000000000000000000000000000000010000000000000000000011110",  --M = R + 1; A = M;
30=> "01000000000000000000000000001000000000000000000000000000000000000000000000011111",  --MUX = A; D = MUX
31=> "00000000000000000000000000000000000000000000000000000000010000010000000000100000",  --Reset(A, CNT);
32=> "00000001000000000000000000000000000000000000000000010000000000000000000000100001",  --M = NOT(L); A = M;
33=> "01000000000000000000010000000000000000000000000000000000000000000001000000100011",  --MUX = A; C = MUX; CNT--;
34=> "00100000000000000000000000000000000000000000000000000000000000000000000000100111",  --MUX = B;
35=> "00000000000000000000000000000000000000000000000000000000000000000000110100100100",  --LS = 13;
36=> "00000000000000000000000000000000000000000000000000000000000000000001000000100110",  --CNT--;
37=> "00000000000000000000001000000000000000000000000000000000010000010000000000100010",  --Reset(CNT, A); LL1(C.);
38=> "00000000000000000000001000000100000010000000000000000000000000000000000000100011",  --LL1(C, D, E)
39=> "00000001000000000000000000000000000000000000000001000000000000000000000000101000",  --M = R + L; A = M;
40=> "00001000000000000000000000000000000000000000000000000000000000000000000000101010",  --MUX = D;
41=> "00000000000000000000000000000000000000000000000000000000010000000000000000110011",  --Reset(A);
42=> "00000001000000000000000000000000000000000000000001000000000000000000000000101011",  --M = L + R; A = M;
43=> "00000000000000000000000000000000000000000000000000000000000000000001000000101100",  --CNT --;
44=> "00000000000000000000000000000000000000000000000000000000000000000000000100101101",  --LS = 1;
45=> "00000000000000000000000000100000000000000000000000000000000000000000000000101111",  --CL1(C.);
46=> "00000000000000000000001000000000000000000000000000000000000000000000000000110000",  --LL1(C.);
47=> "00010000100000000000000000000000000000000000000000000000000000000000000000110010",  --LL1(A); MUX = C;
48=> "00000100000000000000000000000000000000000000000000000000000000000000000000110001",  --MUX = E;
49=> "00000001000000000000000000000000000000000000000001000000000000000000000000101111",  --M = R + L; A = M;
50=> "00000000000000000000000000000000000000000000000000000000000000000000110100101000",  --LS = 13;
51=> "00010000000000000000000000000000000000000000000000000000000000000000000000110100",  --MUX = C;
52=> "00000001000000000000000000000000000000000000000001000000000000000000000000110110",  --M = R + L; A = M;
53=> "00000000000000000000000000000000000000000000000000000000000000000010000000000000",  --Data output
54=> "00000000000000000000000000000000000000000000000000000000000000000000101100110111",  --LS = 11;
55=> "00000001000000000000000000000000000000000000000000010000000000000000000000111000",  --M = NOT(R.); A = M;
56=> "01000000000000000000000000000000000000000000000000000000000000000000000000110101",  --MUX = A;








	
	others => (others => '0') );   
	
	
	
	
begin
	process (RST_ROM, ROM_CMD) 
		
	begin
		if 	RST_ROM'event and RST_ROM = '1'	 then 
			ROM_Dout <= ROM_CMDln(0);
		elsif ROM_CMD'event then
			ROM_Dout <= ROM_CMDln(to_integer(unsigned(ROM_CMD))); 
		end if;
		
	end process;
	
end rtl;