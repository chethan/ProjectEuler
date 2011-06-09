import Data.Char (digitToInt)

smallest_divisor n next  = find_divisor n 2 next
					 		where find_divisor n divisor next | (truncate (sqrt (fromIntegral n))) < divisor = n
						    					  		      | (rem n divisor)==0 = divisor
												  	          | otherwise =  find_divisor n (next divisor) next
get_next 2 = 3
get_next x = x+2

is_prime n = n == smallest_divisor n get_next

all_rotations num =  let temp_rotations num rotation_count| rotation_count == 0 = []
														  | otherwise = (read num :: Int) : temp_rotations ((tail num) ++ [head num]) (rotation_count-1)
			          in temp_rotations (show num) (length (show num))											    

circular_primes_count = let check_circular_prime num = (not$ any (\x->any (==x) "02468") $ show num) && (all is_prime $ all_rotations num) 
						in length $ filter check_circular_prime [3,5..999999]