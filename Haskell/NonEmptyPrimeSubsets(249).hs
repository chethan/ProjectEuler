import Data.Numbers.Primes

powerset []     = [0]
powerset (x:xs) = xss /\/ map (+x) xss where xss = powerset xs

[] /\/ ys = ys
(x:xs) /\/ ys = x : (ys /\/ xs)

non_empty_prime_subsets = length$filter isPrime$powerset$takeWhile (<100) primes

