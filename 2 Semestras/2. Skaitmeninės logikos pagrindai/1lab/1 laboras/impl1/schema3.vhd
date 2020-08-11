-- VHDL model created from schematic schema3.sch -- Mar 13 15:53:50 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity SCHEMA3 is
      Port (       b : In    std_logic;
                   c : In    std_logic;
                   f : In    std_logic;
                   e : In    std_logic;
                 rez : Out   std_logic;
                   d : In    std_logic;
                   a : In    std_logic );

end SCHEMA3;

architecture SCHEMATIC of SCHEMA3 is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal     N_21 : std_logic;
   signal     N_22 : std_logic;
   signal     N_23 : std_logic;
   signal     N_24 : std_logic;
   signal     N_25 : std_logic;
   signal     N_26 : std_logic;
   signal     N_27 : std_logic;
   signal     N_28 : std_logic;
   signal     N_29 : std_logic;
   signal     N_30 : std_logic;
   signal     N_31 : std_logic;
   signal     N_32 : std_logic;
   signal     N_33 : std_logic;
   signal     N_34 : std_logic;
   signal     N_35 : std_logic;
   signal     N_36 : std_logic;
   signal     N_17 : std_logic;
   signal     N_18 : std_logic;
   signal     N_19 : std_logic;
   signal     N_20 : std_logic;

   component or5
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   D : In    std_logic;
                   E : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component mux41
      Port (      D0 : In    std_logic;
                  D1 : In    std_logic;
                  D2 : In    std_logic;
                  D3 : In    std_logic;
                 SD1 : In    std_logic;
                 SD2 : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component inv
      Port (       A : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component or2
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

   component or3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component and3
      Port (       A : In    std_logic;
                   B : In    std_logic;
                   C : In    std_logic;
                   Z : Out   std_logic );
   end component;

begin

   I68 : or5
      Port Map ( A=>N_25, B=>N_24, C=>N_28, D=>N_27, E=>N_26, Z=>N_29 );
   I39 : mux41
      Port Map ( D0=>N_17, D1=>N_32, D2=>N_29, D3=>N_23, SD1=>d, SD2=>a,
                 Z=>rez );
   I13 : inv
      Port Map ( A=>f, Z=>N_36 );
   I15 : inv
      Port Map ( A=>e, Z=>N_35 );
   I16 : inv
      Port Map ( A=>b, Z=>N_33 );
   I18 : inv
      Port Map ( A=>c, Z=>N_34 );
   I53 : or2
      Port Map ( A=>N_21, B=>N_22, Z=>N_23 );
   I54 : or2
      Port Map ( A=>N_30, B=>N_31, Z=>N_32 );
   I55 : and4
      Port Map ( A=>b, B=>c, C=>e, D=>f, Z=>N_22 );
   I56 : and4
      Port Map ( A=>b, B=>N_34, C=>N_35, D=>N_36, Z=>N_21 );
   I57 : and4
      Port Map ( A=>b, B=>c, C=>N_35, D=>N_36, Z=>N_18 );
   I58 : or3
      Port Map ( A=>N_20, B=>N_19, C=>N_18, Z=>N_17 );
   I69 : and3
      Port Map ( A=>b, B=>N_34, C=>N_35, Z=>N_25 );
   I70 : and3
      Port Map ( A=>N_33, B=>c, C=>N_35, Z=>N_24 );
   I71 : and3
      Port Map ( A=>N_33, B=>N_35, C=>N_36, Z=>N_28 );
   I72 : and3
      Port Map ( A=>N_33, B=>N_34, C=>e, Z=>N_27 );
   I73 : and3
      Port Map ( A=>N_33, B=>e, C=>N_36, Z=>N_26 );
   I59 : and3
      Port Map ( A=>N_33, B=>N_34, C=>e, Z=>N_30 );
   I60 : and3
      Port Map ( A=>b, B=>N_35, C=>f, Z=>N_31 );
   I66 : and3
      Port Map ( A=>N_34, B=>e, C=>f, Z=>N_19 );
   I67 : and3
      Port Map ( A=>N_33, B=>e, C=>f, Z=>N_20 );

end SCHEMATIC;
