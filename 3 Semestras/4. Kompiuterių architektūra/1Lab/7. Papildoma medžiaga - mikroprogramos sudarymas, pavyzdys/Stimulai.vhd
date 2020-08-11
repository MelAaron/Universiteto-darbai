	resetas: process
	begin
		RST <='1'; 
		wait for 2ns;
		RST <='0'; 
		wait;
	end process;
	
	sinchronizacija: process
	begin
		CLK <= '0';	
		wait for 5 ns;
		CLK <= '1';
		wait for 5 ns;
	end process;	
	
	
	Daugyba: process 
	begin 
--		Din <= "0000000000010011"; -- N1  +19
		Din <= "0000000001001011"; -- N1  +75

		wait for 15ns;
--		Din <= "1111111111110111"; -- N2  -9
		Din <= "1111111111001111"; -- N1  -49
		wait for 10ns;
		Din <= "0000000000000000"; 			
				
		wait until S_Done = '1';
		wait for 60 ns;
		assert 1=0 report "Modeliavimas baigtas" severity   failure;
	end process;