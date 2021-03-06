powerMod m _ 0 =  1
powerMod m x n | n > 0 = f x' (n-1) x' where
  x' = x `rem` m
  f _ 0 y = y
  f a d y = g a d where
    g b i | even i    = g (b*b `rem` m) (i `quot` 2)
          | otherwise = f b (i-1) (b*y `rem` m)
modlist = map (\x-> powerMod (10^16) x x) [1..250250]
