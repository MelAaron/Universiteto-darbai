-- VHDL model created from schematic Lab1.sch -- Mar 13 15:53:50 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity LAB1 is
      Port (     rez : Out   std_logic;
                   a : In    std_logic;
                   b : In    std_logic;
                   c : In    std_logic;
                   d : In    std_logic;
                   e : In    std_logic;
                   f : In    std_logic );

end LAB1;

architecture SCHEMATIC of LAB1 is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal     N_25 : std_logic;
   signal     N_26 : std_logic;
   signal     N_27 : std_logic;
   signal     N_28 : std_logic;
   signal      N_1 : std_logic;
   signal      N_2 : std_logic;
   signal      N_3 : std_logic;
   signal      N_4 : std_logic;
   signal      N_5 : std_logic;
   signal      N_6 : std_logic;
   signal      N_7 : std_logic;
   signal      N_8 : std_logic;
   signal      N_9 : std_logic;
   signal     N_14 : std_logic;
   signal     N_15 : std_logic;
   signal     N_16 : std_logic;
   signal     N_17 : std_logic;
   signal     N_18 : std_logic;
   signal     N_19 : std_logic;
   signal     N_20 : std_logic;
   signal     N_21 : std_logic;
   signal     N_22 : std_logic;
   signal     N_23 : std_logic;
   signal     N_24 : std_logic;

   component and3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component or2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and5
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   E : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component inv
      Port (       A : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and4
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component or4
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   Z : Out   std_logic );
   end component;

begin

   I27 : and3
      Port Map ( A=>a, B=>N_4, C=>N_3, Z=>N_28 );
   I28 : and3
      Port Map ( A=>N_6, B=>d, C=>f, Z=>N_27 );
   I29 : and3
      Port Map ( A=>a, B=>N_4, C=>N_1, Z=>N_26 );
   I26 : and3
      Port Map ( A=>b, B=>N_2, C=>N_14, Z=>N_17 );
   I30 : and3
      Port Map ( A=>d, B=>e, C=>N_8, Z=>N_16 );
   I31 : and3
      Port Map ( A=>N_6, B=>N_5, C=>N_4, Z=>N_9 );
   I32 : or2
      Port Map ( A=>N_5, B=>N_4, Z=>N_15 );
   I33 : or2
      Port Map ( A=>N_9, B=>N_7, Z=>N_8 );
   I34 : and5
      Port Map ( A=>N_6, B=>N_3, C=>e, D=>f, E=>N_15, Z=>N_18 );
   I18 : inv
      Port Map ( A=>c, Z=>N_4 );
   I17 : inv
      Port Map ( A=>a, Z=>N_6 );
   I16 : inv
      Port Map ( A=>b, Z=>N_5 );
   I15 : inv
      Port Map ( A=>d, Z=>N_3 );
   I14 : inv
      Port Map ( A=>e, Z=>N_2 );
   I13 : inv
      Port Map ( A=>f, Z=>N_1 );
   I21 : and2
      Port Map ( A=>c, B=>N_2, Z=>N_24 );
   I22 : and2
      Port Map ( A=>N_2, B=>N_1, Z=>N_23 );
   I20 : and2
      Port Map ( A=>N_4, B=>e, Z=>N_21 );
   I19 : and2
      Port Map ( A=>e, B=>N_1, Z=>N_20 );
   I35 : and4
      Port Map ( A=>N_6, B=>c, C=>N_3, D=>N_1, Z=>N_25 );
   I23 : and4
      Port Map ( A=>a, B=>N_5, C=>N_3, D=>N_22, Z=>N_19 );
   I36 : and4
      Port Map ( A=>a, B=>b, C=>c, D=>f, Z=>N_7 );
   I25 : or4
      Port Map ( A=>N_19, B=>N_18, C=>N_17, D=>N_16, Z=>rez );
   I24 : or4
      Port Map ( A=>N_24, B=>N_23, C=>N_21, D=>N_20, Z=>N_22 );
   I37 : or4
      Port Map ( A=>N_28, B=>N_27, C=>N_26, D=>N_25, Z=>N_14 );

end SCHEMATIC;
