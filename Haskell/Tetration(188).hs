
powerMod m _ 0 =  1
powerMod m x n | n > 0 = f x' (n-1) x' where
  x' = x `rem` m
  f _ 0 y = y
  f a d y = g a d where
    g b i | even i    = g (b*b `rem` m) (i `quot` 2)
          | otherwise = f b (i-1) (b*y `rem` m)


tetration a 1 num_digits = rem a (10^num_digits)
tetration a k num_digits = powerMod (10^num_digits) a (tetration a (k-1) num_digits) 

last_8_digits = tetration 1777 1855 8
