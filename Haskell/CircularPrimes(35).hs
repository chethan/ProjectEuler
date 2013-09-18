import Data.Char (digitToInt)
import Data.Numbers.Primes(isPrime)

all_rotations num =  let temp_rotations num rotation_count| rotation_count == 0 = []
														  | otherwise = (read num :: Int) : temp_rotations ((tail num) ++ [head num]) (rotation_count-1)
			          in temp_rotations (show num) (length (show num))											    

circular_primes_count = let check_circular_prime num = (not$ any (\x->any (==x) "02468") $ show num) && (all isPrime $ all_rotations num) 
						in (+1)$length $ filter check_circular_prime [3,5..999999]
