import Data.Numbers.Primes
import Data.List
rad n = (n,product$nub$primeFactors n)
sorted_radical k =fst$ (!!k)$sortBy (\a b->compare (snd a) (snd b))$map rad [1..100000]
thousandth_sorted_radical = sorted_radical 999
