import Data.Char (digitToInt)

xor True False = True
xor False True = True
xor _ _ = False

append_spaces num = (take (8 - (length num)) (repeat ' ')) ++ num

smallest_divisor n next  = find_divisor n 2 next
					 		where find_divisor n divisor next | (truncate (sqrt (fromIntegral n))) < divisor = n
						    					  		      | (rem n divisor)==0 = divisor
												  	          | otherwise =  find_divisor n (next divisor) next
get_next 2 = 3
get_next x = x+2

is_prime n = n == smallest_divisor n get_next


my_digitToInt num | num == ' ' = 0
				  | otherwise = (digitToInt num) + 1

seven_segment_codes = [[False,False,False,False,False,False,False],
					   [True,True,True,True,True,True,False],
				       [False,True,True,False,False,False,False],
				       [True,True,False,True,True,False,True],
				       [True,True,True,True,False,False,True],
				       [False,True,True,False,False,True,True],
				       [True,False,True,True,False,True,True],
				       [True,False,True,True,True,True,True],
				       [True,True,True,False,False,True,False],
				       [True,True,True,True,True,True,True],
				       [True,True,True,True,False,True,True]
					   ]

digital_roots num | num < 10  = [num]
		  | otherwise = num : digital_roots (sum $ map digitToInt $ show num) 


transitions num1 num2  = let transition_for_digit d1 d2 = length $ filter id  (zipWith xor (seven_segment_codes!!(my_digitToInt d1)) (seven_segment_codes!!(my_digitToInt d2)))
					    in sum $ zipWith transition_for_digit (append_spaces num1) (append_spaces num2)


sams_transitions num1 num2 = (transitions num1 "") + (transitions "" num2)


sams_total_transitions nums =  sum $ zipWith sams_transitions ([""] ++ (map show nums)) ((map show nums)++[""])
maxs_total_transitions nums =  sum $ zipWith transitions ([""] ++ (map show nums)) ((map show nums)++[""])

difference_in_transitions= sum (map (\x -> (sams_total_transitions (digital_roots x)) -  (maxs_total_transitions (digital_roots x))) (filter is_prime [10^7 .. ((10^7)+(10^7))]))