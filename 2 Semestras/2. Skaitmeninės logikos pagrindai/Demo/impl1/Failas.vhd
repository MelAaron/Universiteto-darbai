-- VHDL model created from schematic Failas.sch -- Feb 05 13:35:00 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity FAILAS is
      Port (       c : In    std_logic;
                   b : In    std_logic;
                   a : In    std_logic;
                   d : In    std_logic;
                   f : Out   std_logic );

end FAILAS;

architecture SCHEMATIC of FAILAS is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal      N_1 : std_logic;
   signal      N_2 : std_logic;
   signal      N_3 : std_logic;
   signal      N_4 : std_logic;
   signal      N_5 : std_logic;
   signal      N_6 : std_logic;

   component inv
      Port (       A : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component or4
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component nr3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   Z : Out   std_logic );
   end component;

begin

   I3 : inv
      Port Map ( A=>c, Z=>N_5 );
   I4 : inv
      Port Map ( A=>a, Z=>N_6 );
   I5 : or4
      Port Map ( A=>N_4, B=>N_3, C=>N_2, D=>N_1, Z=>f );
   I6 : nr3
      Port Map ( A=>b, B=>N_5, C=>d, Z=>N_3 );
   I7 : and2
      Port Map ( A=>N_6, B=>N_5, Z=>N_1 );
   I8 : and3
      Port Map ( A=>a, B=>b, C=>c, Z=>N_2 );
   I9 : and3
      Port Map ( A=>N_6, B=>b, C=>d, Z=>N_4 );

end SCHEMATIC;
