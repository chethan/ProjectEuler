import Data.List(sort,nub)
distinct_term_in_seq = length $ nub $ sort $ [(a^b)|a<-[2..100],b<-[2..100]]
