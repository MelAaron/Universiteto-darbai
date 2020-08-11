-- VHDL model created from schematic shcem3.sch -- May 08 16:04:47 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity SHCEM3 is
      Port (      A0 : In    std_logic;
                  A1 : In    std_logic;
                   C : In    std_logic;
               Reset : In    std_logic;
                  x4 : In    std_logic;
                  Q4 : Out   std_logic;
                  x3 : In    std_logic;
                  Q3 : Out   std_logic;
                  x2 : In    std_logic;
                  Q2 : Out   std_logic;
                  x1 : In    std_logic;
                  Q1 : Out   std_logic;
                  x0 : In    std_logic;
                  Q0 : Out   std_logic;
                   T : In    std_logic );

end SHCEM3;

architecture SCHEMATIC of SHCEM3 is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal Q0_DUMMY : std_logic;
   signal Q1_DUMMY : std_logic;
   signal Q2_DUMMY : std_logic;
   signal Q3_DUMMY : std_logic;
   signal Q4_DUMMY : std_logic;
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

   component vlo
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

   Q4 <= Q4_DUMMY;
   Q3 <= Q3_DUMMY;
   Q2 <= Q2_DUMMY;
   Q1 <= Q1_DUMMY;
   Q0 <= Q0_DUMMY;

   I1 : vlo
      Port Map ( Z=>N_11 );
   I6 : and2
      Port Map ( A=>N_6, B=>Reset, Z=>N_1 );
   I7 : and2
      Port Map ( A=>N_7, B=>Reset, Z=>N_2 );
   I8 : and2
      Port Map ( A=>N_8, B=>Reset, Z=>N_3 );
   I9 : and2
      Port Map ( A=>N_9, B=>Reset, Z=>N_4 );
   I10 : and2
      Port Map ( A=>N_10, B=>Reset, Z=>N_5 );
   I11 : mux41
      Port Map ( D0=>x0, D1=>Q1_DUMMY, D2=>Q3_DUMMY, D3=>Q2_DUMMY,
                 SD1=>A1, SD2=>A0, Z=>N_6 );
   I12 : mux41
      Port Map ( D0=>x1, D1=>Q2_DUMMY, D2=>Q4_DUMMY, D3=>Q3_DUMMY,
                 SD1=>A1, SD2=>A0, Z=>N_7 );
   I13 : mux41
      Port Map ( D0=>x2, D1=>Q3_DUMMY, D2=>Q0_DUMMY, D3=>Q4_DUMMY,
                 SD1=>A1, SD2=>A0, Z=>N_8 );
   I14 : mux41
      Port Map ( D0=>x3, D1=>Q4_DUMMY, D2=>Q1_DUMMY, D3=>T, SD1=>A1,
                 SD2=>A0, Z=>N_9 );
   I15 : mux41
      Port Map ( D0=>x4, D1=>N_11, D2=>Q2_DUMMY, D3=>T, SD1=>A1, SD2=>A0,
                 Z=>N_10 );
   I16 : fd1s3ax
      Port Map ( CK=>C, D=>N_1, Q=>Q0_DUMMY );
   I17 : fd1s3ax
      Port Map ( CK=>C, D=>N_2, Q=>Q1_DUMMY );
   I18 : fd1s3ax
      Port Map ( CK=>C, D=>N_3, Q=>Q2_DUMMY );
   I19 : fd1s3ax
      Port Map ( CK=>C, D=>N_4, Q=>Q3_DUMMY );
   I20 : fd1s3ax
      Port Map ( CK=>C, D=>N_5, Q=>Q4_DUMMY );

end SCHEMATIC;
