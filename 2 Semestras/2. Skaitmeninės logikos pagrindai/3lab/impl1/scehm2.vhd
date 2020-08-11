-- VHDL model created from schematic scehm2.sch -- May 08 16:04:47 2019

library IEEE;
use IEEE.std_logic_1164.all;
library xp2;
use xp2.components.all;

entity SCEHM2 is
      Port (      A0 : In    std_logic;
                  A1 : In    std_logic;
               Reset : In    std_logic;
                   C : In    std_logic;
                  Q0 : Out   std_logic;
                  Q1 : Out   std_logic;
                  Q2 : Out   std_logic;
                  Q3 : Out   std_logic;
                  Q4 : Out   std_logic;
                  D0 : In    std_logic;
                  D1 : In    std_logic;
                  D2 : In    std_logic;
                  D3 : In    std_logic;
                  D4 : In    std_logic;
                  DL : In    std_logic;
                  DR : In    std_logic );

end SCEHM2;

architecture SCHEMATIC of SCEHM2 is

   SIGNAL gnd : std_logic := '0';
   SIGNAL vcc : std_logic := '1';

   signal      N_3 : std_logic;
   signal Q4_DUMMY : std_logic;
   signal Q3_DUMMY : std_logic;
   signal Q2_DUMMY : std_logic;
   signal Q1_DUMMY : std_logic;
   signal Q0_DUMMY : std_logic;
   signal      N_4 : std_logic;
   signal      N_5 : std_logic;
   signal      N_6 : std_logic;
   signal      N_7 : std_logic;
   signal      N_8 : std_logic;
   signal      N_9 : std_logic;
   signal     N_10 : std_logic;
   signal     N_11 : std_logic;
   signal     N_12 : std_logic;

   component fd1s3ax
      Port (      CK : In    std_logic;
                   D : In    std_logic;
                   Q : Out   std_logic );
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

begin

   Q0 <= Q0_DUMMY;
   Q1 <= Q1_DUMMY;
   Q2 <= Q2_DUMMY;
   Q3 <= Q3_DUMMY;
   Q4 <= Q4_DUMMY;

   I23 : fd1s3ax
      Port Map ( CK=>C, D=>N_5, Q=>Q0_DUMMY );
   I24 : fd1s3ax
      Port Map ( CK=>C, D=>N_4, Q=>Q1_DUMMY );
   I25 : fd1s3ax
      Port Map ( CK=>C, D=>N_7, Q=>Q2_DUMMY );
   I26 : fd1s3ax
      Port Map ( CK=>C, D=>N_9, Q=>Q3_DUMMY );
   I20 : fd1s3ax
      Port Map ( CK=>C, D=>N_11, Q=>Q4_DUMMY );
   I27 : and2
      Port Map ( A=>N_3, B=>Reset, Z=>N_4 );
   I28 : and2
      Port Map ( A=>N_6, B=>Reset, Z=>N_5 );
   I29 : and2
      Port Map ( A=>N_8, B=>Reset, Z=>N_7 );
   I30 : and2
      Port Map ( A=>N_10, B=>Reset, Z=>N_9 );
   I10 : and2
      Port Map ( A=>N_12, B=>Reset, Z=>N_11 );
   I31 : mux41
      Port Map ( D0=>Q1_DUMMY, D1=>Q2_DUMMY, D2=>Q0_DUMMY, D3=>D1,
                 SD1=>A0, SD2=>A1, Z=>N_3 );
   I32 : mux41
      Port Map ( D0=>Q0_DUMMY, D1=>Q1_DUMMY, D2=>DL, D3=>D0, SD1=>A0,
                 SD2=>A1, Z=>N_6 );
   I33 : mux41
      Port Map ( D0=>Q2_DUMMY, D1=>Q3_DUMMY, D2=>Q1_DUMMY, D3=>D2,
                 SD1=>A0, SD2=>A1, Z=>N_8 );
   I34 : mux41
      Port Map ( D0=>Q3_DUMMY, D1=>Q4_DUMMY, D2=>Q2_DUMMY, D3=>D3,
                 SD1=>A0, SD2=>A1, Z=>N_10 );
   I15 : mux41
      Port Map ( D0=>Q4_DUMMY, D1=>DR, D2=>Q3_DUMMY, D3=>D4, SD1=>A0,
                 SD2=>A1, Z=>N_12 );

end SCHEMATIC;
