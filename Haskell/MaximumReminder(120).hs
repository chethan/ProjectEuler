reminder a n = rem ((a-1)^n +(a+1)^n) (a*a)
maximum_reminder_sum_bruteforce = sum$map (\a->maximum$map (reminder a) [1..(a*2)]) [3..1000]
maximum_reminder_sum = sum$([a*a-2*a|a<-[4,6..1000]]++[a*a-a|a<-[3,5..999]]) 	
