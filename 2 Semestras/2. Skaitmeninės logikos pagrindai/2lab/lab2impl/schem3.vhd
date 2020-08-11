-- VHDL model created from schematic schem3.sch -- Apr 01 18:11:27 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity SCHEM3 is
      Port (       b : In    std_logic;
                   c : In    std_logic;
                   a : In    std_logic;
                QDin : Out   std_logic;
               Reset : In    std_logic;
                   d : In    std_logic;
                   S : Out   std_logic;
                   R : Out   std_logic );

end SCHEM3;

architecture SCHEMATIC of SCHEM3 is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal  R_DUMMY : std_logic;
   signal     N_14 : std_logic;
   signal     N_15 : std_logic;
   signal  S_DUMMY : std_logic;
   signal     N_10 : std_logic;
   signal     N_11 : std_logic;
   signal QDin_DUMMY : std_logic;
   signal     N_12 : std_logic;
   signal     N_13 : std_logic;
   signal      N_2 : std_logic;
   signal      N_4 : std_logic;
   signal      N_9 : std_logic;

   component or2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and2
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component xnor2
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

   component nd3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   Z : Out   std_logic );
   end component;

begin

   QDin <= QDin_DUMMY;
   S <= S_DUMMY;
   R <= R_DUMMY;

   I22 : or2
      Port Map ( A=>b, B=>c, Z=>N_2 );
   I3 : and2
      Port Map ( A=>N_4, B=>N_2, Z=>S_DUMMY );
   I21 : xnor2
      Port Map ( A=>N_2, B=>d, Z=>R_DUMMY );
   I31 : inv
      Port Map ( A=>R_DUMMY, Z=>N_14 );
   I32 : inv
      Port Map ( A=>S_DUMMY, Z=>N_15 );
   I20 : inv
      Port Map ( A=>d, Z=>N_4 );
   I12 : nd2
      Port Map ( A=>N_13, B=>N_12, Z=>QDin_DUMMY );
   I25 : nd2
      Port Map ( A=>N_11, B=>N_14, Z=>N_10 );
   I26 : nd2
      Port Map ( A=>N_15, B=>N_13, Z=>N_9 );
   I18 : nd3
      Port Map ( A=>QDin_DUMMY, B=>N_11, C=>Reset, Z=>N_12 );
   I27 : nd3
      Port Map ( A=>N_13, B=>a, C=>N_10, Z=>N_11 );
   I28 : nd3
      Port Map ( A=>N_9, B=>a, C=>N_11, Z=>N_13 );

end SCHEMATIC;
