;
; suskaiciuoti     /   ](a+2b)/(a-x)    , kai a-x>0
;              y = |   a^2-3b           , kai a-x=0
;                  \   |c+x|            , kai a-x<0
; skaiciai be zenklo
; Duomenys a - b, b - w, c - w, x - w, y - b

stekas  SEGMENT STACK
DB 256 DUP(0)
stekas  ENDS

duom    SEGMENT
a    DB 100  ;10000 ; perpildymo situacijai
b    DW 100
c    DW 65400
x    DW 250;10,20,10,41,12,9,45,6,0
kiek    = ($-x)/2
y    DB kiek dup(0AAh)      
isvb    DB 'x=',6 dup (?), ' y=',6 dup (?), 0Dh, 0Ah, '$'
perp    DB 'Perpildymas', 0Dh, 0Ah, '$'
daln    DB 'Dalyba is nulio', 0Dh, 0Ah, '$'
netb    DB 'Netelpa i baita', 0Dh, 0Ah, '$'
spausk  DB 'Skaiciavimas baigtas, spausk bet kuri klavisa,', 0Dh, 0Ah, '$'
duom    ENDS

prog    SEGMENT
assume ss:stekas, ds:duom, cs:prog
pr:    MOV ax, duom
MOV ds, ax
XOR si, si      ; (suma mod 2) si = 0
XOR di, di      ; di = 0
c_pr:   MOV cx, kiek
JCXZ pab
cikl:
XOR ax, ax  ;Nuresetinu ax
MOV al, a   ;isidedu i al a
CMP ax, x[si];lyginu a su x
JE f2       ;jei a = x
JB f3       ;jei a < x

;XOR ax, ax
;MOV al, a
;SUB ax, x[si]
;CMP ax, 0
;JE f2
;JB f3

f1:        ;](a+2b)/(a-x)[

XOR ah, ah  ;nunulinu ah
MOV al, a   ;isikeliu a i al, nes a yra B

SUB ax, x[si]  ;atimu is ax(ah:al) zodi x. Atimtyje operandai vienodi, atsakymas lieka ax
CMP ax, 0   ;patikrina ar vardiklis 0
JE kl2      ;dalyba is 0
MOV bx, ax  ;perkeliu ax i bx, kad toliau galeciau daryt veiksmus

MOV ax, 2   ;isidedu 2 i ax  
MUL b       ;po daugybos gaunu dviguba zodi dx:ax=ax*Op
JC kl1      ;sandauga netilpo i ax
                     
MOV dl, a
XOR dh, dh
ADD ax, dx  ;Pridedu a sudeties atsakymas liks pirmame operande(ax)
JC kl1      ;suma netilpo i ax

XOR dx, dx  ;nunulinu dx, ten liks liekana
DIV bx      ;AX:=DX:AX/Op DX:=liek; Padalinu ax(skaitikli) is bx(vardiklio)

JMP re


f2:        ;a^2-3b
MOV ax, 3  ;isidedu 3 i ax
MUL b      ;padauginu 3*b, gaunu dviguba zodi dx:ax
JC kl1     ;sandauga netilpo i ax
MOV bx, ax ;isidedu ax(3b) i bx

MOV al, a  ;pasiemu a i al, nes jis yra B      
XOR ah, ah ;nunulinu ah
MUL a      ;padauginu is a, ax:=al*Op, gaunu W 
JC kl1     ;sandauga netilpo i ax

SUB ax, bx  ;Is ax(a^2) atimu bx(3b) atsakymas lieka ax
JC kl1     ;astakymas po sudeties lieka ax
JMP re


f3:             ;]c+x[
MOV ax, c       ;ikeliam c reiksme i ax registra(kadangi c yra zodis)
ADD ax, x[si]   ;sudedam ax (c) su x[si], ats lieka ax
JC kl1          
                ;JMP re nerasau, nes ir taip atlikus veiksmus ten eis

re:
CMP ah, 0     ;ar telpa rezultatasi baita
JE ger
JMP kl3
ger:    MOV y[di], al
INC si
INC si
INC di
LOOP cikl
pab:
;rezultatu isvedimas i ekrana
;============================
XOR si, si
XOR di, di
MOV cx, kiek
JCXZ is_pab
is_cikl:
MOV ax, x[si]  ; isvedamas skaicius x yra ax reg.
PUSH ax
MOV bx, offset isvb+2
PUSH bx
CALL binasc
MOV al, y[di]
XOR ah, ah        ; isvedamas skaicius y yra ax reg.
PUSH ax
MOV bx, offset isvb+11
PUSH bx
CALL binasc

MOV dx, offset isvb
MOV ah, 9h
INT 21h
;============================
INC si
INC si
INC di
LOOP is_cikl
is_pab:
;===== PAUZE ===================
;===== paspausti bet kuri klavisa ===
LEA dx, spausk
MOV ah, 9
INT 21h
MOV ah, 0
INT 16h
;============================
MOV ah, 4Ch   ; programos pabaiga, grizti i OS
INT 21h
;============================

kl1:    LEA dx, perp
MOV ah, 9
INT 21h
XOR al, al
JMP ger
kl2:    LEA dx, daln
MOV ah, 9
INT 21h
XOR al, al
JMP ger
kl3:    LEA dx, netb
MOV ah, 9
INT 21h
XOR al, al
JMP ger

; skaiciu vercia i desimtaine sist. ir issaugo
; ASCII kode. Parametrai perduodami per steka
; Pirmasis parametras ([bp+6])- verciamas skaicius
; Antrasis parametras ([bp+4])- vieta rezultatui

binasc    PROC NEAR
PUSH bp
MOV bp, sp
; naudojamu registru issaugojimas
PUSHA
; rezultato eilute uzpildome tarpais
MOV cx, 6
MOV bx, [bp+4]
tarp:    MOV byte ptr[bx], ' '
INC bx
LOOP tarp
; skaicius paruosiamas dalybai is 10
MOV ax, [bp+6]
MOV si, 10
val:    XOR dx, dx
DIV si
;  gauta liekana verciame i ASCII koda
ADD dx, '0'   ; galima--> ADD dx, 30h
;  irasome skaitmeni i eilutes pabaiga
DEC bx
MOV [bx], dl
; skaiciuojame pervestu simboliu kieki
INC cx
; ar dar reikia kartoti dalyba?
CMP ax, 0
JNZ val

POPA
POP bp
RET
binasc    ENDP
prog    ENDS
END pr

