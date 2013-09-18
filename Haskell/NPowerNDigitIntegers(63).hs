n_power_n_digit_nums = sum $ map (\x-> length $ takeWhile (\y->(==y)$length$show$(x^y)) [1..])[1..9]

