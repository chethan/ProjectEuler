import Data.List(permutations,sort)
import Data.Numbers.Primes(primes)
import Data.Char(intToDigit)

is_pandigital num = (sort$temp)==['1'..intToDigit(length temp)] where temp = show num
pandigital_prime=last$filter is_pandigital $takeWhile (<(10^7)) primes


