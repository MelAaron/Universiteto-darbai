-- VHDL model created from schematic pliss.sch -- May 24 18:42:14 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity PLISS is
      Port (      A0 : In    std_logic;
                  A1 : In    std_logic;
                   C : In    std_logic;
               Reset : In    std_logic;
                  Q4 : Out   std_logic;
                  Q3 : Out   std_logic;
                  Q2 : Out   std_logic;
                  Q1 : Out   std_logic;
                  Q0 : Out   std_logic );

end PLISS;

architecture SCHEMATIC of PLISS is

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
      Port Map ( A=>N_16, Z=>Q3 );
   I22 : inv
      Port Map ( A=>N_18, Z=>Q0 );
   I23 : inv
      Port Map ( A=>N_19, Z=>Q1 );
   I24 : inv
      Port Map ( A=>N_20, Z=>Q2 );
   I25 : inv
      Port Map ( A=>N_17, Z=>Q4 );
   I26 : vlo
      Port Map ( Z=>N_21 );
   I27 : vlo
      Port Map ( Z=>N_22 );
   I28 : vlo
      Port Map ( Z=>N_23 );
   I1 : vlo
      Port Map ( Z=>N_15 );
   I29 : vhi
      Port Map ( Z=>N_1 );
   I30 : vhi
      Port Map ( Z=>N_2 );
   I3 : vhi
      Port Map ( Z=>N_4 );
   I4 : vhi
      Port Map ( Z=>N_3 );
   I6 : and2
      Port Map ( A=>N_10, B=>Reset, Z=>N_5 );
   I7 : and2
      Port Map ( A=>N_11, B=>Reset, Z=>N_6 );
   I8 : and2
      Port Map ( A=>N_12, B=>Reset, Z=>N_7 );
   I9 : and2
      Port Map ( A=>N_13, B=>Reset, Z=>N_8 );
   I10 : and2
      Port Map ( A=>N_14, B=>Reset, Z=>N_9 );
   I11 : mux41
      Port Map ( D0=>N_21, D1=>N_19, D2=>N_16, D3=>N_20, SD1=>A1,
                 SD2=>A0, Z=>N_10 );
   I12 : mux41
      Port Map ( D0=>N_22, D1=>N_20, D2=>N_17, D3=>N_16, SD1=>A1,
                 SD2=>A0, Z=>N_11 );
   I13 : mux41
      Port Map ( D0=>N_1, D1=>N_16, D2=>N_18, D3=>N_17, SD1=>A1, SD2=>A0,
                 Z=>N_12 );
   I14 : mux41
      Port Map ( D0=>N_2, D1=>N_17, D2=>N_19, D3=>N_3, SD1=>A1, SD2=>A0,
                 Z=>N_13 );
   I15 : mux41
      Port Map ( D0=>N_23, D1=>N_15, D2=>N_20, D3=>N_4, SD1=>A1, SD2=>A0,
                 Z=>N_14 );
   I16 : fd1s3ax
      Port Map ( CK=>C, D=>N_5, Q=>N_18 );
   I17 : fd1s3ax
      Port Map ( CK=>C, D=>N_6, Q=>N_19 );
   I18 : fd1s3ax
      Port Map ( CK=>C, D=>N_7, Q=>N_20 );
   I19 : fd1s3ax
      Port Map ( CK=>C, D=>N_8, Q=>N_16 );
   I20 : fd1s3ax
      Port Map ( CK=>C, D=>N_9, Q=>N_17 );

end SCHEMATIC;
