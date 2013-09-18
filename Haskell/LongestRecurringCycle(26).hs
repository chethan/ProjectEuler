import Data.List(elemIndex,maximumBy)
import Data.Ord(comparing)

recurring_length d 0 rs = 0
recurring_length d q rs = let r = rem (q*10) d
			in case	elemIndex r rs of
			  	Just i -> i+1
			  	Nothing -> recurring_length d r (r:rs)   

longest_recurring_cycle = fst $ maximumBy (comparing snd) [(a,recurring_length a 1 [])|a<-[1..999]]
