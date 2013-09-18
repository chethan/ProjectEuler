import Data.Ratio
is_curious a b c = (a*10+b)%(b*10+c) == a%c
unorthodox_canceling = denominator $ product [a%c|a<-[1..9],b<-[1..9],c<-[1..9],is_curious a b c,a/=b && b/=c]
