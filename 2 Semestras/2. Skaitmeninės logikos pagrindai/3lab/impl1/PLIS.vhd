-- VHDL model created from schematic PLIS.sch -- May 08 16:04:47 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity PLIS is
      Port (      A0 : In    std_logic;
                  A1 : In    std_logic;
                   C : In    std_logic;
               Reset : In    std_logic;
                  Q4 : Out   std_logic;
                  Q3 : Out   std_logic;
                  Q2 : Out   std_logic;
                  Q1 : Out   std_logic;
                  Q0 : Out   std_logic );

end PLIS;

architecture SCHEMATIC of PLIS is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal      N_1 : std_logic;
   signal      N_2 : std_logic;
   signal      N_3 : std_logic;
   signal      N_4 : std_logic;
   signal      N_5 : std_logic;
   signal      N_6 : std_logic;
   signal      N_7 : std_logic;
   signal      N_8 : std_logic;
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

   component inv
      Port (       A : In    std_logic;
                   Z : Out   std_logic );
   end component;

   component vlo
      Port (       Z : Out   std_logic );
   end component;

   component vhi
      Port (       Z : Out   std_logic );
   end component;

   component and2
      Port (       A : In    std_logic;
                   B : In    std_logic;
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

   component fd1s3ax
      Port (      CK : In    std_logic;
                   D : In    std_logic;
                   Q : Out   std_logic );
   end component;

begin

   I21 : inv
      Port Map ( A=>N_1, Z=>Q3 );
   I22 : inv
      Port Map ( A=>N_2, Z=>Q0 );
   I23 : inv
      Port Map ( A=>N_3, Z=>Q1 );
   I24 : inv
      Port Map ( A=>N_4, Z=>Q2 );
   I25 : inv
      Port Map ( A=>N_5, Z=>Q4 );
   I26 : vlo
      Port Map ( Z=>N_6 );
   I27 : vlo
      Port Map ( Z=>N_7 );
   I28 : vlo
      Port Map ( Z=>N_10 );
   I1 : vlo
      Port Map ( Z=>N_23 );
   I29 : vhi
      Port Map ( Z=>N_8 );
   I30 : vhi
      Port Map ( Z=>N_9 );
   I3 : vhi
      Port Map ( Z=>N_12 );
   I4 : vhi
      Port Map ( Z=>N_11 );
   I6 : and2
      Port Map ( A=>N_18, B=>Reset, Z=>N_13 );
   I7 : and2
      Port Map ( A=>N_19, B=>Reset, Z=>N_14 );
   I8 : and2
      Port Map ( A=>N_20, B=>Reset, Z=>N_15 );
   I9 : and2
      Port Map ( A=>N_21, B=>Reset, Z=>N_16 );
   I10 : and2
      Port Map ( A=>N_22, B=>Reset, Z=>N_17 );
   I11 : mux41
      Port Map ( D0=>N_6, D1=>N_3, D2=>N_1, D3=>N_4, SD1=>A1, SD2=>A0,
                 Z=>N_18 );
   I12 : mux41
      Port Map ( D0=>N_7, D1=>N_4, D2=>N_5, D3=>N_1, SD1=>A1, SD2=>A0,
                 Z=>N_19 );
   I13 : mux41
      Port Map ( D0=>N_8, D1=>N_1, D2=>N_2, D3=>N_5, SD1=>A1, SD2=>A0,
                 Z=>N_20 );
   I14 : mux41
      Port Map ( D0=>N_9, D1=>N_5, D2=>N_3, D3=>N_11, SD1=>A1, SD2=>A0,
                 Z=>N_21 );
   I15 : mux41
      Port Map ( D0=>N_10, D1=>N_23, D2=>N_4, D3=>N_12, SD1=>A1, SD2=>A0,
                 Z=>N_22 );
   I16 : fd1s3ax
      Port Map ( CK=>C, D=>N_13, Q=>N_2 );
   I17 : fd1s3ax
      Port Map ( CK=>C, D=>N_14, Q=>N_3 );
   I18 : fd1s3ax
      Port Map ( CK=>C, D=>N_15, Q=>N_4 );
   I19 : fd1s3ax
      Port Map ( CK=>C, D=>N_16, Q=>N_1 );
   I20 : fd1s3ax
      Port Map ( CK=>C, D=>N_17, Q=>N_5 );

end SCHEMATIC;
