-- VHDL model created from schematic schem1.sch -- Apr 01 18:11:27 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity SCHEM1 is
      Port (   Reset : In    std_logic;
                   Q : Out   std_logic;
                   S : Out   std_logic;
                   R : Out   std_logic;
                   b : In    std_logic;
                   c : In    std_logic;
                   d : In    std_logic;
                   a : In    std_logic );

end SCHEM1;

architecture SCHEMATIC of SCHEM1 is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal  R_DUMMY : std_logic;
   signal  S_DUMMY : std_logic;
   signal     N_13 : std_logic;
   signal     N_14 : std_logic;
   signal  Q_DUMMY : std_logic;
   signal     N_11 : std_logic;
   signal     N_12 : std_logic;
   signal      N_8 : std_logic;

   component nd3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
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

   component inv
      Port (       A : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component nd2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

begin

   Q <= Q_DUMMY;
   S <= S_DUMMY;
   R <= R_DUMMY;

   I18 : nd3
      Port Map ( A=>Q_DUMMY, B=>N_11, C=>Reset, Z=>N_12 );
   I19 : xnor2
      Port Map ( A=>N_13, B=>d, Z=>R_DUMMY );
   I3 : and2
      Port Map ( A=>N_14, B=>N_13, Z=>S_DUMMY );
   I20 : or2
      Port Map ( A=>b, B=>c, Z=>N_13 );
   I21 : inv
      Port Map ( A=>d, Z=>N_14 );
   I9 : nd2
      Port Map ( A=>a, B=>R_DUMMY, Z=>N_11 );
   I10 : nd2
      Port Map ( A=>S_DUMMY, B=>a, Z=>N_8 );
   I12 : nd2
      Port Map ( A=>N_8, B=>N_12, Z=>Q_DUMMY );

end SCHEMATIC;
