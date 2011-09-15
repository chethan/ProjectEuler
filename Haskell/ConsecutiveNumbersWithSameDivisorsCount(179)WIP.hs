import Data.Number.Primes

number_of_divisors num = foldr (\x y -> (*y)$(+1)$length x) 1$group$primeFactors num

consecutive_numbers_with


