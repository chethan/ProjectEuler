import Data.Numbers.Primes
import Data.List

consecutive_numbers 0 _ count  index  = index
consecutive_numbers _ [] count  index = index
consecutive_numbers num (x:xs) count index| count==num = index
					  | num==x = consecutive_numbers num (xs) (count+1) (index+1) 
 				          | otherwise = consecutive_numbers num (xs) 0 (index+1)


consecutive_prime_factors = (consecutive_numbers 4 (map (length.nub.primeFactors) [1..]) 0 0)-3
