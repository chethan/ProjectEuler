import Data.Char (digitToInt)
import Data.Numbers.Primes (isPrime)

xor True False = True
xor False True = True
xor _ _ = False

append_spaces num = (take (8 - (length num)) (repeat ' ')) ++ num

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

difference_in_transitions= sum (map (\x -> (sams_total_transitions (digital_roots x)) -  (maxs_total_transitions (digital_roots x))) (filter isPrime [10^7 .. ((10^7)+(10^7))]))