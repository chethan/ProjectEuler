trib = 3:5:9:zipWith3 (\x y z -> x+y+z) trib (tail trib) (tail$tail trib)
find_not_dividing a b c n | c == 0 = False
		          | a*b*c ==1 = True
		          | otherwise = find_not_dividing b c (rem (a+b+c) n) n

odd_num_not_dividing_seq = (filter (find_not_dividing 3 5 9) [29,31..2009])!!122
