import Data.Char(digitToInt)
import Data.MemoTrie(memo)

next_digit num = foldr(\x y -> (+y)$(^2)$digitToInt x) 0 $show num

is_arriving_at_89 1 = False
is_arriving_at_89 89 = True
is_arriving_at_89 num = cached_func (next_digit num) where cached_func = memo is_arriving_at_89

numbers_arriving_at_89 = length $ filter is_arriving_at_89 [2..(10^7)]
