(defun c:figura2 ()
  
(setq pradinistaskas(getpoint "Pradinis taskas"))
(setq linija1 (list (car pradinistaskas) (+ (cadr pradinistaskas) 5)))
(command "line" pradinistaskas linija1 "")
 
(setq trikampis1 (list (- (car linija1) 5) (cadr linija1)))
(setq trikampis2 (list (+ (car linija1) 5) (cadr linija1)))
(setq trikampis3 (list (car linija1) (+ (cadr linija1) 5)))
(command "line" trikampis1 trikampis2 trikampis3 trikampis1 "")

(setq keturkampis1 (list (- (car trikampis3) 5) (cadr trikampis3)))
(setq keturkampis2 (list (+ (car trikampis3) 5) (cadr trikampis3)))
(setq keturkampis3 (list (- (car trikampis3) 5) (+ (cadr trikampis3) 20)))
(setq keturkampis4 (list (+ (car trikampis3) 5) (+ (cadr trikampis3) 20)))
(command "line" keturkampis1 keturkampis3 keturkampis4 keturkampis2 keturkampis1 "")

(setq trikampis11 (list (car trikampis3) (+ (cadr trikampis3) 20)))
(setq trikampis12 (list (- (car trikampis11) 5) (+ (cadr trikampis11) 20)))
(setq trikampis13 (list (+ (car trikampis11) 5) (+ (cadr trikampis11) 20)))
(command "line" trikampis11 trikampis12 trikampis13 trikampis11 "")

(setq linija11 (list (car trikampis11) (+ (cadr trikampis11) 20)))
(setq linija12 (list (car trikampis11) (+ (cadr trikampis11) 40)))
(command "line" linija11 linija12 "")

(setq trikampis31 (list (- (car linija12) 5) (cadr linija12)))
(setq trikampis32 (list (+ (car linija12) 5) (cadr linija12)))
(setq trikampis33 (list (car linija12) (+ (cadr linija12) 5)))
(command "line" trikampis31 trikampis32 trikampis33 trikampis31 "")

(setq linija31 (list (car keturkampis2) (+ (cadr keturkampis2) 10)))
(setq linija32 (list (+ (car keturkampis2) 10) (+ (cadr keturkampis2) 10)))
(command "line" linija31 linija32 "")

(setq trikampis41 (list (+ (car linija32) 5) (+ (cadr linija31) 5)))
(setq trikampis42 (list (+ (car linija32) 5) (- (cadr linija31) 5)))
(command "line" linija32 trikampis41 trikampis42 linija32 "")

(setq linija41(list (+ (car linija32) 5) (cadr linija32)))
(setq linija42(list (+ (car linija32) 10) (cadr linija32)))
(command "line" linija41 linija42 "")

)
