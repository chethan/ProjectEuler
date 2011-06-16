import Data.List(maximumBy,group,sort)
import Data.Ord(comparing)

all_triplets =[a+b+c |a<-[1..1000],b<-[1..a],c<-[b..(1000-(a+b))],(a*a)==(b*b)+(c*c)] 
maximum_solution = head $ maximumBy (comparing length)$group$sort all_triplets
