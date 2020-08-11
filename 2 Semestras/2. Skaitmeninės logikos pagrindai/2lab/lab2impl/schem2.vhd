-- VHDL model created from schematic schem2.sch -- Apr 01 18:11:27 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity SCHEM2 is
      Port (   Reset : In    std_logic;
                   a : In    std_logic;
                  Q2 : Out   std_logic;
                   d : In    std_logic;
                   b : In    std_logic;
                   c : In    std_logic );

end SCHEM2;

architecture SCHEMATIC of SCHEM2 is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal     N_13 : std_logic;
   signal      M_S : std_logic;
   signal      M_R : std_logic;
   signal      S_R : std_logic;
   signal      S_S : std_logic;
   signal     N_12 : std_logic;
   signal Q2_DUMMY : std_logic;
   signal      N_2 : std_logic;
   signal      N_6 : std_logic;
   signal      N_8 : std_logic;
   signal      N_9 : std_logic;
   signal     N_10 : std_logic;
   signal     N_11 : std_logic;

   component inv
      Port (       A : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component xnor2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component or2
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

   component nd2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

begin

   Q2 <= Q2_DUMMY;

   I19 : inv
      Port Map ( A=>a, Z=>N_12 );
   I20 : inv
      Port Map ( A=>d, Z=>N_13 );
   I21 : xnor2
      Port Map ( A=>N_2, B=>d, Z=>M_R );
   I3 : and2
      Port Map ( A=>N_13, B=>N_2, Z=>M_S );
   I22 : or2
      Port Map ( A=>b, B=>c, Z=>N_2 );
   I23 : nd3
      Port Map ( A=>S_S, B=>N_6, C=>Reset, Z=>S_R );
   I18 : nd3
      Port Map ( A=>Q2_DUMMY, B=>N_9, C=>Reset, Z=>N_11 );
   I24 : nd2
      Port Map ( A=>a, B=>M_R, Z=>N_6 );
   I25 : nd2
      Port Map ( A=>a, B=>M_S, Z=>N_8 );
   I26 : nd2
      Port Map ( A=>N_8, B=>S_R, Z=>S_S );
   I10 : nd2
      Port Map ( A=>N_12, B=>S_S, Z=>N_10 );
   I9 : nd2
      Port Map ( A=>N_12, B=>S_R, Z=>N_9 );
   I12 : nd2
      Port Map ( A=>N_10, B=>N_11, Z=>Q2_DUMMY );

end SCHEMATIC;
