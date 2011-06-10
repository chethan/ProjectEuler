expression_value n a b = (n*n) + (a*n)+b 

smallest_divisor n next  = find_divisor n 2 next
					 		where find_divisor n divisor next | (truncate (sqrt (fromIntegral n))) < divisor = n
						    					  		      | (rem n divisor)==0 = divisor
												  	          | otherwise =  find_divisor n (next divisor) next
get_next 2 = 3
get_next x = x+2

is_prime n = n == smallest_divisor n get_next

prime_seq_length a b = length $ takeWhile (is_prime.abs) $ map (\n->expression_value n a b) [0..]  

prime_seq_lengths =maximum$map (\b->maximum$(map (\a-> ((prime_seq_length a b),(a,b))) [-999,-997..999])) (filter is_prime [1..1000])

coeff_product = snd $ prime_seq_lengths
