generate_seq_list (x:[]) = []
generate_seq_list (x:xs) = (map (\j -> (x,j)) xs) ++ generate_seq_list xs

pentagonal_nums = map (\x -> truncate (x *(3 *x - 1)/2)) [2400,2399..1]
filtered = filter (\(x,y)-> (elem (toInteger (x+y)) pentagonal_nums) && (elem (toInteger (x-y)) pentagonal_nums)) (generate_seq_list pentagonal_nums)