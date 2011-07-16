import Data.Numbers.Primes
import Data.List(nub)

pascal_triangle = [1] : map (\x->zipWith (+) ([0]++x) (x ++ [0])) pascal_triangle
is_squarefree num = all (\x-> ((mod num x)>0))$takeWhile (<=num) $map (^2) primes
squarefree_binomial_coefficients = sum$filter is_squarefree$nub$concat$take 51$pascal_triangle
