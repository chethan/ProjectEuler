crazy_function a b c n | n > b =  n - c
		       |otherwise =  crazy_function a b c (a + (crazy_function a b c (a + (crazy_function a b c (a + (crazy_function a b c (a + n)))))))

sum_func a b c = let temp_func a b c n 
				| n >= b = 0 
			        | otherwise = (crazy_function a b c n) + (temp_func a b c (n+1))
		 in temp_func a b c 0

last_digits num num_of_digits = rem num (10^num_of_digits)

