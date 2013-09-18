import Data.Numbers.Primes(isPrime)
import Data.Char(digitToInt)
import Data.List(inits,tails)

is_truncatable num = let check_prime xs = all (\x->isPrime$ (read x::Int)) xs
		     in (check_prime (init$tails$show num)) && (check_prime (tail$inits$show num))

truncatable_primes_sum = sum $ take 11 $ filter is_truncatable [11..]
