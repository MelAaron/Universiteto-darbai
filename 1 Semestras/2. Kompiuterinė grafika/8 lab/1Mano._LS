(defun c:ManoFigura1 ()

  (setq Pradinis (getpoint "Nurodykite Pradini Taska"))
  (setq Antras (list ( + (car Pradinis)60) (cadr Pradinis)))
  (setq Trecias (list ( - (car Antras) 22) (+ (cadr Antras) 5)))
  (setq Ketvirtas (list (car Trecias) ( + (cadr Trecias) 5)))
  (setq Penktas (list ( + (car Pradinis)22) ( + (cadr Pradinis) 5)))
  (setq Sestas (list (car Penktas) (+(cadr Penktas)5)))
  (command "line" Sestas Penktas Pradinis Antras Trecias Ketvirtas "")

  (setq E1 (list (-(car Pradinis)50) ( + (cadr Pradinis)10)))
  (setq E2 (list (+(car E1)160) (cadr E1)))
  (setq E3 (list (car E2) (+(cadr E2)90)))
  (setq E4 (list (car E1) (+(cadr E1)90)))
  (command "line" E1 E2 E3 E4 E1"")

  (setq M1 (list (+(car E1)10) (+(cadr E1)10)))
  (setq M2 (list (-(car E2)10) (+(cadr E2)10)))
  (setq M3 (list (-(car E3)10) (-(cadr E3)10)))
  (setq M4 (list (+(car E4)10) (-(cadr E4)10)))
  (command "line" M1 M2 M3 M4 M1 "")

  
  (setq Extra (list (+ (car M1)10) (+(cadr M1)10)))
  (command "color" 2)
  (command "-hatch" Extra "properties" "ANSI31" 100 0 "")

  (setq Extra2 (list(+(car E1)5) (+(cadr E1)5)))
  (command "color" 250)
  (command "-hatch" "properties" "solid" Extra2 "")

  (setq Extra3 (list(+(car Pradinis)5) (+(cadr Pradinis)1)))
  (command "color" 250)
  (command "-hatch" "properties" "solid" Extra3 "")

  (setq Tekst (list (+(car E1)30) (+(cadr E1)20)))
  (command "color" 5)
  (command "text" Tekst 10 0 Autocad Extra3 "")
  
  )