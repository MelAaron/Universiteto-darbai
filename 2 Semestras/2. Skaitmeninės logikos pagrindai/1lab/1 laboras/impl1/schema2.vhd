-- VHDL model created from schematic schema2.sch -- Mar 13 15:53:50 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity SCHEMA2 is
      Port (     rez : Out   std_logic;
                   a : In    std_logic;
                   b : In    std_logic;
                   c : In    std_logic;
                   d : In    std_logic;
                   e : In    std_logic;
                   f : In    std_logic );

end SCHEMA2;

architecture SCHEMATIC of SCHEMA2 is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal     N_24 : std_logic;
   signal      N_9 : std_logic;
   signal     N_10 : std_logic;
   signal     N_11 : std_logic;
   signal     N_12 : std_logic;
   signal     N_13 : std_logic;
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
   signal      N_1 : std_logic;
   signal      N_2 : std_logic;
   signal      N_3 : std_logic;
   signal      N_4 : std_logic;
   signal      N_5 : std_logic;
   signal      N_6 : std_logic;
   signal      N_7 : std_logic;
   signal      N_8 : std_logic;

   component nd5
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   E : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component nd2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component nd3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component nd4
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component inv
      Port (       A : In    std_logic;
                   Z : Out   std_logic );
   end component;

begin

   I38 : nd5
      Port Map ( A=>N_23, B=>N_18, C=>e, D=>f, E=>N_22, Z=>N_20 );
   I21 : nd2
      Port Map ( A=>c, B=>N_16, Z=>N_17 );
   I44 : nd2
      Port Map ( A=>e, B=>N_24, Z=>N_11 );
   I45 : nd2
      Port Map ( A=>N_12, B=>e, Z=>N_13 );
   I46 : nd2
      Port Map ( A=>N_16, B=>N_24, Z=>N_15 );
   I40 : nd2
      Port Map ( A=>b, B=>c, Z=>N_22 );
   I39 : nd2
      Port Map ( A=>N_2, B=>N_1, Z=>N_3 );
   I41 : nd3
      Port Map ( A=>N_23, B=>N_19, C=>N_12, Z=>N_2 );
   I42 : nd3
      Port Map ( A=>d, B=>e, C=>N_3, Z=>N_9 );
   I26 : nd3
      Port Map ( A=>a, B=>N_12, C=>N_18, Z=>N_7 );
   I27 : nd3
      Port Map ( A=>N_23, B=>d, C=>f, Z=>N_6 );
   I28 : nd3
      Port Map ( A=>a, B=>N_12, C=>N_24, Z=>N_5 );
   I29 : nd3
      Port Map ( A=>b, B=>N_16, C=>N_8, Z=>N_21 );
   I36 : nd4
      Port Map ( A=>a, B=>N_19, C=>N_18, D=>N_14, Z=>N_10 );
   I47 : nd4
      Port Map ( A=>N_17, B=>N_15, C=>N_13, D=>N_11, Z=>N_14 );
   I43 : nd4
      Port Map ( A=>a, B=>b, C=>c, D=>f, Z=>N_1 );
   I32 : nd4
      Port Map ( A=>N_23, B=>c, C=>N_18, D=>N_24, Z=>N_4 );
   I33 : nd4
      Port Map ( A=>N_7, B=>N_6, C=>N_5, D=>N_4, Z=>N_8 );
   I37 : nd4
      Port Map ( A=>N_10, B=>N_20, C=>N_21, D=>N_9, Z=>rez );
   I18 : inv
      Port Map ( A=>c, Z=>N_12 );
   I17 : inv
      Port Map ( A=>a, Z=>N_23 );
   I16 : inv
      Port Map ( A=>b, Z=>N_19 );
   I15 : inv
      Port Map ( A=>d, Z=>N_18 );
   I14 : inv
      Port Map ( A=>e, Z=>N_16 );
   I13 : inv
      Port Map ( A=>f, Z=>N_24 );

end SCHEMATIC;
