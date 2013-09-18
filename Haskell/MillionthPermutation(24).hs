import Data.List (delete)
flatmap func seq = foldr (\x acc -> x ++ acc) [] (map func seq)

my_permutations (x:[]) = [[x]]
my_permutations (xs) = flatmap (\x-> (map (\y -> x:y) (my_permutations (delete x xs)))) (xs)

millionth_lexiographic_permutation = (my_permutations [0,1,2,3,4,5,6,7,8,9])!!999999