; trikampio braizymas
(DEFUN C:trikampis()
  (SETQ Taskas1 (GETPOINT "\n Iveskite tasko Taskas1 koordinates:"))
  (SETQ Taskas2 (GETPOINT "\n Iveskite tasko Taskas2 koordinates:"))
  (SETQ Taskas3 (GETPOINT "\n Iveskite tasko Taskas3 koordinates:"))
  (Command "LINE" Taskas1 Taskas2 Taskas3 "C"))